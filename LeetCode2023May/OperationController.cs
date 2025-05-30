using FluentEmail.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace OliverAPI.Controllers
{
    /// <summary>
    /// API client part (data loading from out there)
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly DbLib.DataContext _dataContext;
        private readonly ILogger<OperationController> _logger;
        private readonly IConfiguration _configuration;
        private IFluentEmail _fluentEmail;

        private int SupplyDocDateShift = 4;

        string _emailToReports = "";
        string _emailToErrors = "";
        bool CHECK_DOCUMENT_NUMBER_EXISTS = true;

        /// <summary>
        /// ::ctor
        /// </summary>
        /// <param name="dataContext"></param>
        /// <param name="logger"></param>
        /// <param name="settings"></param>
        /// <param name="fluentEmail"></param>
        public OperationController(DbLib.DataContext dataContext,
            ILogger<OperationController> logger,
            IConfiguration settings,
            IFluentEmail fluentEmail)
        {
            _dataContext = dataContext;
            _logger = logger;
            _configuration = settings;
            _fluentEmail = fluentEmail;

            var appSettings = _configuration.GetSection("AppSettings");

            if (appSettings != null)
            {
                try
                {
                    SupplyDocDateShift = Convert.ToInt32(appSettings["SupplyDocDateShift"]);

                    _emailToReports = appSettings.GetValue<string>("OperationReportEmail");
                    _emailToErrors = appSettings.GetValue<string>("OperationErrorEmail");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "OperationController ctor");
                    SupplyDocDateShift = 2;
                }

                try
                {
                    CHECK_DOCUMENT_NUMBER_EXISTS = appSettings.GetValue<bool>("CheckDocumentNumberExistForShipment");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "OperationController ctor (CheckDocumentNumberExistForShipment)");
                }
            }

            if (SupplyDocDateShift <= 0) SupplyDocDateShift = 1;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("", Name = "BLAH")]
        public string Get()
        {
            return "OK! I`m here";
        }

        /// <summary>
        /// GetAllUsers
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        [HttpGet("allUsers", Name = "GetAllUsers")]
        [Authorize(Roles = "Api, Admin")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult GetAllUsers(int amount = 10)
        {
            _logger.LogInformation(Environment.UserName);

            if (amount <= 0) amount = 1;

            try
            {
                var data = _dataContext.Users
                    .Include(x => x.Role)
                    .Select(x => new { x.Login, Role = x.Role.Name, })
                    .Take(amount)
                    .ToList();
                return new JsonResult(new { users = data });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Проверка корректности заполнения полей поставки (Supply)
        /// </summary>
        /// <param name="supply"></param>
        /// <returns></returns>
        private List<string> CheckSupply(OliverDTO.Oliver.Supply supply)
        {
            List<string> errors = new List<string>();

            if (supply is null)
                throw new ArgumentNullException(nameof(supply));

            if (supply?.Items == null || !supply.Items.Any())
                errors.Add("Supply doesn't contains any item");

            if (supply?.Guid1C == null ||
                supply?.Guid1C == Guid.Empty)
                errors.Add($"Поле {nameof(supply.Guid1C)} не заполнено.");


            if (string.IsNullOrWhiteSpace(supply?.Operation))
                errors.Add($"Поле {nameof(supply.Operation)} не заполнено.");

            string[] op_types = { "truckarrival", "stocktaking", "return", "correction" };
            if (!op_types.Contains(supply?.Operation.ToLower()))
                errors.Add($"Поле {nameof(supply.Operation)} заполнено некорректно (truckarrival | stocktaking | return | correction)");


            if (string.IsNullOrWhiteSpace(supply?.Number1C))
            {
                errors.Add($"Поле {nameof(supply.Number1C)} не указано.");
            }
            else
            {
                if (supply?.Number1C.Length > 100)
                    errors.Add($"Длина поля {nameof(supply.Number1C)} не должно превышать 100 знаков.");

                if (supply?.Number1C is string val)
                {
                    var bad_chars = OliverDTO.Utils.FindIncorrectCharacterDocNumber(val);
                    if (bad_chars != null && bad_chars.Length > 0)
                    {
                        var bc = string.Join(", ", bad_chars);
                        errors.Add($"Номер заказа содержит некорректные символы: {bc}");
                    }
                }
            }


            // у всех товаров д.б. GTIN
            if (supply != null && supply.Items.Any(x => string.IsNullOrEmpty(x.GTIN)))
                errors.Add($"В поставке присутствуют товары без GTIN.");

            // у всех товаров д.б. артикул (Art)
            if (supply != null && supply.Items.Any(x => string.IsNullOrEmpty(x.GTIN)))
                errors.Add($"В поставке присутствуют товары без артикула (поле art).");

            // у всех товаров д.б. заполнено описание [descr]
            bool no_desc = supply != null && supply.Items.Any(x => string.IsNullOrEmpty(x.Descr));
            if (no_desc)
                errors.Add($"В поставке присутствуют товары без описания (поле descr).");

            // все ли типы серийников указаны (поле SNType)
            bool no_sn_type = supply != null && supply.Items.Any(x => x.SNType <= 0);
            if (no_sn_type)
                errors.Add($"В поставке присутствуют товары без типа серийного номера (поле SNType) либо значение некорректно. {Environment.NewLine}Корректные значения: {OliverCommon.SerialNumberTypes.AsString()}");

            // у каждого товара д.б. номер короба
            // 2022-12-29 сделал BoxNum (SSCC) необязательным
            /*
            bool no_box_number = supply != null && supply.Items.Any(x => string.IsNullOrWhiteSpace(x.BoxNum));
            if (no_box_number)
                errors.Add("В поставке присутствуют товары без номера короба (boxnum)");
            */

            // д.б. указано кол-во товара в коробе
            if (supply != null && supply.Items.Any(x => x.ItemInBox <= 0))
                errors.Add($"У некоторых товаров не заполнено поле ItemInBox (кол-во артикула в коробе)");

            /*
            DateTime minDate = DateTime.Now.AddDays(-SupplyDocDateShift);
            DateTime maxDate = DateTime.Now.AddDays(SupplyDocDateShift);
            if (supply?.DocDate.DateTime < minDate || supply?.DocDate.DateTime > maxDate)
                errors.Add($"Значение поля {nameof(supply.DocDate)} не указано или некорректно. Допустимый интервал {minDate:d} - {maxDate:d}");
            */

            return errors;
        }

        /// <summary>
        /// Создание поставки
        /// </summary>
        /// <returns></returns>
        [HttpPost("supply")]
        [Authorize(Roles = "Api, Admin")]
        public IActionResult Supply([FromBody] OliverDTO.Oliver.Supply supply)
        {
            _logger.LogInformation("\r\n>>> SUPPLY\r\n");

            if (!ModelState.IsValid)
            {
                _logger.LogDebug($"Model is not valid. {supply}");
                return BadRequest();
            }

            var claims = User.Identity as ClaimsIdentity;
            var userName = claims?.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrWhiteSpace(userName))
            {
                _logger.LogError("Invalid UserName");
                return BadRequest("Invalid UserName");
            }
            _logger.LogInformation($"UserName: {userName}");
            Debug.Assert(!string.IsNullOrWhiteSpace(userName));
            if (string.IsNullOrWhiteSpace(userName))
                return BadRequest("UserName is not defined");


            var errors = CheckSupply(supply);

            if (errors.Count > 0)
            {
                _logger.LogError("Supply errors");
                foreach (var err in errors)
                    _logger.LogError(err);
                return BadRequest(errors);
            }

            try
            {
                _logger.LogInformation(supply.ToJson());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ToJson error.");
            }

            try
            {
                var ur = _dataContext.UserRoles.OrderBy(x => x.Id).FirstOrDefault();

                if (supply.Items != null && supply.Items.Any())
                {
                    try
                    {
                        List<DbLib.Models.Oliver.NomenclaturePrice> prices = new List<DbLib.Models.Oliver.NomenclaturePrice>();

                        var grouped = (from i in supply.Items select new { i.GTIN, i.Art, i.RetailPrice })
                            .ToList();

                        prices = grouped
                            .Distinct()
                            .Select(x => new DbLib.Models.Oliver.NomenclaturePrice()
                            {
                                GTIN = x.GTIN,
                                Art = x.Art,
                                Descr = string.Empty,
                                RetailPrice = x.RetailPrice
                            })
                            .ToList();

                        var tmp = prices
                            .Select(x => new { x.GTIN, x.RetailPrice })
                            .Distinct()
                            .GroupBy(x => x.GTIN)
                            .Select(g => new { g.Key, Cnt = g.Count() })
                            .ToList();

                        if (tmp.Any(x => x.Cnt > 1))
                        {
                            var badItem = tmp.Where(x => x.Cnt > 1).OrderBy(x => x.Key).FirstOrDefault();
                            throw new InvalidOperationException($"Для одного GTIN указаны разные цены ({badItem?.Key})");
                        }

                        foreach (var p in prices)
                        {
                            var price_exists = _dataContext.NomenclaturePrices
                                .Where(x => x.GTIN == p.GTIN)
                                .OrderBy(x => x.GTIN)
                                .FirstOrDefault();

                            if (price_exists == null)
                            {
                                _dataContext.NomenclaturePrices.Add(p);
                            }
                            else
                            {
                                price_exists.Art = p.Art;
                                price_exists.Descr = p.Descr;
                                price_exists.RetailPrice = p.RetailPrice;
                                _dataContext.NomenclaturePrices.Update(price_exists);
                            }
                        }

                        _dataContext.SaveChanges();
                    }
                    catch (InvalidOperationException nominex)
                    {
                        _logger.LogError(nominex, "Ошибка при сохранеии цен товаров.");
                        throw;
                    }
                    catch (Exception nomex)
                    {
                        var msg = new StringBuilder("Ошибка при сохранении цен товаров.");
                        if (nomex.InnerException != null)
                        {
                            msg.AppendLine(nomex.InnerException.Message);
                        }

                        _logger.LogError(nomex, msg.ToString());

                        throw new InvalidOperationException($"Ошибка при сохранении цен товаров. {msg}", nomex);
                    }
                }



                var db_user = _dataContext.Users.Where(x => x.Login == userName).FirstOrDefault()
                    ?? throw new InvalidOperationException($"User not found in DB: {userName} ");

                _logger.LogInformation($"User found. {userName} - Id: {db_user.Id}");


                var db_customer = _dataContext.Customers
                    .Where(x => x.User == db_user)
                    .FirstOrDefault() ?? throw new InvalidOperationException($"Customer is not defined ({db_user.Name} / {userName}). ");


                _logger.LogInformation($"Customer found. Id:{db_customer.Id}. Name:{db_customer.Name}. Active:{!db_customer.IsDeleted}");
                if (db_customer.IsDeleted)
                    throw new InvalidOperationException("Customer deleted");


                DbLib.Models.Common.Warehouse? db_warehouse = _dataContext.Warehouses.FirstOrDefault();
                if (supply.WarehouseId > 0)
                {
                    var tmp_whs = _dataContext.Warehouses.Where(x => x.Id == supply.WarehouseId).FirstOrDefault();
                    if (tmp_whs != null)
                    {
                        db_warehouse = tmp_whs;
                    }
                    else
                    {
                        _logger.LogInformation($"Warehouse not found. Id:{supply.WarehouseId}");
                    }
                }

                if (db_warehouse == null)
                    throw new InvalidOperationException("Warehouse not found in DB");



                var existSupply = _dataContext.Supply
                    .Where(x => x.Guid1C == supply.Guid1C)
                    .FirstOrDefault();

                if (existSupply != null)
                {
                    var currentState = (OliverCommon.ProcessStateSupply)existSupply.SupplyState;

                    if (currentState >= OliverCommon.ProcessStateSupply.GotWarehouseResponse)
                    {
                        var errmsg = $"Ошибка: заявка на поставку уже передана на склад. Статус: {currentState.GetDescription()}";
                        _logger.LogError(errmsg);
                        return BadRequest(errmsg);
                    }
                    else
                    {
                        _logger.LogInformation($"Поставка {supply.Number1C} ({supply.Guid1C}) существует. Удаляем!");

                        _dataContext.Supply.Remove(existSupply);

                        _dataContext.SaveChanges();
                    }
                }


                DbLib.Models.Oliver.Supply dbsupply = new DbLib.Models.Oliver.Supply()
                {
                    Guid1C = supply.Guid1C,
                    Operation = supply.Operation,
                    Number1C = supply.Number1C,
                    OperationDate = DateTime.Now,
                    ReceiverGln = supply.ReceiverGln,
                    SenderGln = supply.SenderGln,
                    SupplyerGln = supply.SupplyerGln,
                    CurrencyCode = supply.CurrencyCode,

                    Customer = db_customer,
                    Warehouse = db_warehouse,
                    UserName = userName,
                };

                List<DbLib.Models.Oliver.SupplyItem> dbitems = new List<DbLib.Models.Oliver.SupplyItem>();
                if (supply.Items != null)
                {
                    foreach (var item in supply.Items)
                    {
                        var db_item = new DbLib.Models.Oliver.SupplyItem()
                        {
                            Art = item.Art,
                            GTIN = item.GTIN,
                            ManufacturerGln = item.ManufacturerGln,
                            Num = item.Num,
                            Quantity = item.Quantity,
                            RetailPrice = item.RetailPrice,
                            Descr = item.Descr,
                            ShortDescr = item.ShortDescr,
                            BoxNum = item.BoxNum,
                            SNType = item.SNType,
                            GtinDM = item.GtinDM,
                            ItemInBox = item.ItemInBox,
                        };

                        if (item.dms != null && item.dms.Any())
                        {
                            db_item.Dms = item.dms
                                .Select(x => new DbLib.Models.Oliver.SupplyItemDm() { SupplyItem = db_item, DM = x })
                                .ToList();
                        }

                        dbitems.Add(db_item);
                    }
                }

                dbsupply.Items = dbitems;
                _dataContext.Supply.Add(dbsupply);
                _dataContext.SaveChanges();
                return Ok($"Supply {supply.Number1C} ({supply.Guid1C}) successfully created. ");
            }
            catch (JsonException jex)
            {
                _logger.LogError(jex, "Supply");
                return BadRequest("Incorrect JSON format. ");
            }
            catch (Exception ex)
            {
                var msg = new StringBuilder($"Load supply error. {ex.GetType()}");
                msg.Append(ex.Message);
                msg.Append(ex.InnerException?.Message);
                _logger.LogError(ex, msg.ToString());
                return BadRequest($"Load supply error. {ex.GetType()}. More info in logs. ");
            }
        }

        /// <summary>
        /// Проверка полей заявки на отгрузку
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        private List<string> CheckShipment(OliverDTO.Oliver.Shipment shipment)
        {
            if (shipment == null) return new List<string>() { "Shipment is NULL " };

            shipment.Validate();

            var errors = new List<string>();

            if (shipment.GuidSales == Guid.Empty)
                errors.Add($"{nameof(shipment.GuidSales)} не указан");

            if (string.IsNullOrWhiteSpace(shipment.DocNo))
            {
                errors.Add($"Номер документа ({nameof(shipment.DocNo)}) не указан");
            }
            else
            {
                string val = shipment.DocNo;
                var bad_chars = OliverDTO.Utils.FindIncorrectCharacterDocNumber(val);
                if (bad_chars != null && bad_chars.Length > 0)
                {
                    var bc = string.Join(", ", bad_chars);
                    errors.Add($"Номер заказа (DocNo) содержит некорректные символы: {bc}");
                }
            }

            if (string.IsNullOrWhiteSpace(shipment.ClientName))
                errors.Add($"Не указано значение поля {nameof(shipment.ClientName)}");

            if (string.IsNullOrWhiteSpace(shipment.ClientAddress))
                shipment.ClientAddress = "-";
            // errors.Add($"Не указано значение поля {nameof(shipment.ClientAddress)}");

            if (string.IsNullOrWhiteSpace(shipment.ClientCode))
                errors.Add($"Не указано значение поля {nameof(shipment.ClientCode)}");

            if (string.IsNullOrWhiteSpace(shipment.DeliveryAddress))
                shipment.DeliveryAddress = "-";
            // errors.Add($"Не указано значение поля {nameof(shipment.DeliveryAddress)}");

            if (shipment.Items.Any(x => x.Gtin.Length < 11))
                errors.Add("В модели найдены GTIN с длиной менее 11 знаков");

            if (shipment.Items.Any(x => x.Qty <= 0))
                errors.Add("Кол-во артикула должно быть больше 0");

            return errors;
        }

        /// <summary>
        /// Заявка на отгрузку
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        [HttpPost("shipment")]
        [Authorize(Roles = "Api, Bmj, Admin")]
        public IActionResult Shipment([FromBody] OliverDTO.Oliver.Shipment shipment)
        {
            Debug.Assert(shipment != null);
            Contract.Assert(shipment != null);

            if (shipment == null)
                return BadRequest("Invalid parameter [Shipment] (NULL)");

            _logger.LogInformation("\r\n>>> SHIPMENT");
            _logger.LogInformation(shipment.ToJson());

            if (!ModelState.IsValid)
            {
                _logger.LogDebug($"Model is not valid. {shipment}");
                return BadRequest();
            }



            /////////////////////////////////////////////////////////
            // check user credentials
            var claims = User.Identity as ClaimsIdentity;
            var userName = claims?.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrWhiteSpace(userName))
            {
                _logger.LogError("Invalid UserName");
                return BadRequest("Invalid UserName");
            }
            _logger.LogInformation($"UserName: {userName}");
            Debug.Assert(!string.IsNullOrWhiteSpace(userName));
            if (string.IsNullOrWhiteSpace(userName))
                return BadRequest("UserName is not defined");



            var errors = CheckShipment(shipment);

            if (errors.Count > 0)
            {
                var subj = $"[{shipment.DocNo}] Ошибка передачи заявки от клиента (валидация не пройдена)";
                StringBuilder body = new StringBuilder(subj);

                foreach (var err in errors)
                    body.AppendLine(err);
                body.AppendLine();

                _logger.LogError(body.ToString());

                if (_fluentEmail != null)
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(_emailToReports))
                            throw new InvalidOperationException("Email recipients list is empty (AppSettings->OperationReportEmail)");

                        _fluentEmail?
                            .To(_emailToReports)
                            .Subject(subj)
                            .Body(body.ToString())
                            .SendAsync();
                    }
                    catch (Exception sendEmailEx)
                    {
                        _logger.LogCritical(sendEmailEx, "Ошибка отправки отчёта о загружаемой заявке по Email");
                    }
                }

                return BadRequest(errors);
            }

            try
            {
                InsertShipment(shipment, userName);

                return Ok($"[{shipment.DocNo}] Заявка на отгрузку ({shipment.GuidSales}) создана. API-login: {userName}");
            }
            catch (Exception ex)
            {
                try
                {
                    var subj = $"[{shipment.DocNo}] Ошибка передачи заявки от клиента (сервис)";
                    StringBuilder body = new StringBuilder(subj);
                    body.AppendLine();
                    body.AppendLine();
                    body.AppendLine(ex.Message);
                    body.AppendLine();
                    body.AppendLine();
                    body.AppendLine("===");
                    body.AppendLine(shipment.ToJson());
                    body.AppendLine("===");

                    _fluentEmail.To(_emailToReports)
                        .Subject(subj)
                        .Body(body.ToString())
                        .SendAsync();
                }
                catch (Exception sendEmailEx)
                {
                    _logger.LogCritical(sendEmailEx, "");
                }

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Добавление заявки на отгрузку
        /// </summary>
        /// <param name="shipment"></param>
        /// <param name="userName">API login</param>
        /// <exception cref="InvalidOperationException"></exception>
        private void InsertShipment(OliverDTO.Oliver.Shipment shipment, string userName)
        {

            // c h e c k    u s e r 
            var db_user = _dataContext.Users.Where(x => x.Login == userName).FirstOrDefault()
                ?? throw new InvalidOperationException($"User not found in DB: {userName} ");

            _logger.LogInformation($"User found. {userName} - Id: {db_user.Id}");


            // c h e c k    c u s t o m e r
            var db_customer = _dataContext.Customers
                .Where(x => x.User == db_user)
                .FirstOrDefault() ?? throw new InvalidOperationException("Customer is not defined");

            _logger.LogInformation($"Customer found. Id:{db_customer.Id}. Name:{db_customer.Name}. Active:{!db_customer.IsDeleted}");
            if (db_customer.IsDeleted)
                throw new InvalidOperationException("Customer deleted");


            // c h e c k   w a r e h o u s e
            DbLib.Models.Common.Warehouse? db_warehouse = _dataContext.Warehouses.FirstOrDefault();

            /*
            if (shipment.WarehouseId > 0)
            {
                var tmp_whs = _dataContext.Warehouses.Where(x => x.Id == supply.WarehouseId).FirstOrDefault();
                if (tmp_whs != null)
                {
                    db_warehouse = tmp_whs;
                }
                else
                {
                    _logger.LogInformation($"Warehouse not found. Id:{supply.WarehouseId}");
                }
            }
            */

            if (db_warehouse == null)
                throw new InvalidOperationException("Warehouse not found in DB");


            /*
             * as of 2024.05.17
            var existsDocNo = _dataContext.Shipment
                .Where(x => x.DocNo == shipment.DocNo
                && x.GuidSales != shipment.GuidSales
                && x.OperationDate.Year == DateTime.Now.Year
                && x.ProcessState > 0)
                .FirstOrDefault();
            */


            /////////////////////////////////////////////////////////////////////////
            // проверяем что в текущем году нет документа с таким же номером [DocNo]
            var existsDocNo = _dataContext.Shipment
                .Where(x => x.DocNo == shipment.DocNo
                && x.CustomerId == db_customer.Id
                && x.OperationDate.Year == DateTime.Now.Year)
                .FirstOrDefault();

            if (existsDocNo != null
                && existsDocNo.GuidSales != shipment.GuidSales
                && CHECK_DOCUMENT_NUMBER_EXISTS)
            {
                // попытка создать заявку с существующим номером но с другим GUID
                // if (existsDocNo.ProcessState != (int)OliverCommon.ProcessStateSupply.Error)

                var emsg = (@$"[{shipment.DocNo}] order (shipment.DocNo) already exists. 
State: {existsDocNo.ProcessState} 
GUID: {existsDocNo.GuidSales}
Попытка создать заявку с существующим номером документа {shipment.DocNo}, но отличающимся GUID: {shipment.GuidSales}");

                _logger.LogError(emsg);

                throw new DocumentNumberExistsException(existsDocNo.DocNo, existsDocNo.GuidSales, DateTime.Now.Year);
            }

            var exists = _dataContext.Shipment
                .Where(x => x.GuidSales == shipment.GuidSales)
                .FirstOrDefault();

            if (exists != null)
            {
                if (exists.DocNo != shipment.DocNo)
                {
                    var emsg = $"[{shipment.GuidSales}] заявка с таким GUID уже существует в БД, однако имеет отличный № док-та: {exists.DocNo}. Вы указали DocNo: {shipment.DocNo}";
                    throw new InvalidOperationException(emsg);
                }

                var currentState = (OliverCommon.ProcessStateSupply)exists.ProcessState;

                if (currentState >= OliverCommon.ProcessStateSupply.SentToWarehouse)
                    throw new OrderInProcessException(shipment.DocNo, shipment.GuidSales, $"{currentState} : {currentState.GetDescription()}");

                _dataContext.Remove(exists);
                _dataContext.SaveChanges();
                _logger.LogInformation($"Shipment deleted [{shipment.DocNo} :: {shipment.GuidSales}]");
            }


            DateTime shipmentDate = DateTime.Now;
            try
            {
                shipmentDate = Convert.ToDateTime(shipment.ExpProcessDate);
            }
            catch (Exception ex)
            {
                var msg = $"Ошибка преобразования даты отгрузки в формат DateTime. '{shipment.ExpProcessDate}'. ";
                _logger.LogError(ex, msg);
                // throw new InvalidOperationException(msg);
                shipmentDate = DateTime.Now.AddHours(3);
            }

            if (shipmentDate < DateTime.Now.Date)
            {
                // var msg = $"Дата отгрузки не может быть меньше текущей даты. '{shipment.ExpProcessDate}' ";
                // _logger.LogError(msg);
                // throw new InvalidOperationException(msg);
                shipmentDate = DateTime.Now.AddHours(2);
            }

            var dbShipment = new DbLib.Models.Oliver.Shipment()
            {
                GuidSales = shipment.GuidSales,
                DocNo = shipment.DocNo,
                ExpProcessDate = shipmentDate,
                OperationDate = DateTime.Now,
                ClientCode = shipment.ClientCode,
                ClientName = shipment.ClientName,
                ClientAddress = shipment.ClientAddress,
                DeliveryAddress = shipment.DeliveryAddress,
                Memo = shipment.Memo,
                Items = new List<DbLib.Models.Oliver.ShipmentItem>(),
                ProcessState = 0,
                Customer = db_customer,
                UserName = userName,
                Warehouse = db_warehouse,
            };

            foreach (var item in shipment.Items)
            {
                dbShipment.Items.Add(new DbLib.Models.Oliver.ShipmentItem()
                {
                    GTIN = item.Gtin,
                    Quantity = item.Qty,
                    Price = (decimal)item.Price,
                });
            }

            _dataContext.Shipment.Add(dbShipment);
            _dataContext.SaveChanges();
            _logger.LogInformation($"{Environment.NewLine}Shipment saved {dbShipment.DocNo} [{dbShipment.Id} :: {shipment.GuidSales}]{Environment.NewLine}");
        }

        /// <summary>
        /// SerialNumberTypes
        /// </summary>
        /// <returns></returns>
        [HttpGet("SerialNumberTypes")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> SerialNumberTypes()
        {
            try
            {
                return Ok(await _dataContext.SerialNumberTypes.ToListAsync());
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid().ToString();
                _logger.LogError(ex, $"[{errorId}] SerialNumberTypes error.");
                return BadRequest($"SerialNumberTypes error (errorId:{errorId})");
            }
        }
    }
}
