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
