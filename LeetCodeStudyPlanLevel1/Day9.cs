using System;
using System.Drawing;

namespace LeetCodeStudyPlanLevel1
{
    internal class Day9
    {
        /// <summary>
        /// 733. Flood Fill
        /// https://leetcode.com/problems/flood-fill/?envType=study-plan&id=level-1
        ///
        /// An image is represented by an m x n integer grid image where image[i][j] represents the pixel value of the image.
        ///
        /// You are also given three integers sr, sc, and color.
        /// You should perform a flood fill on the image starting from the pixel image[sr][sc].
        ///
        /// To perform a flood fill, consider the starting pixel,
        /// plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel,
        /// plus any pixels connected 4-directionally to those pixels (also with the same color),
        /// and so on.
        /// Replace the color of all of the aforementioned pixels with color.
        ///
        /// Return the modified image after performing the flood fill.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            return FloodFill_1(image, sr, sc, color);
            // return FloodFill_2(image, sr, sc, color);
        }

        public int[][] FloodFill_1(int[][] image, int sr, int sc, int color)
        {
            var res = image;
            int defaultColor = image[sr][sc];
            List<int> colors = new List<int>() { color, defaultColor };
            Queue<Point> points = new Queue<Point>();

            if (image[sr][sc] != color)
                points.Enqueue(new Point(sr, sc));

            while (points.Count > 0)
            {
                var p = points.Dequeue();

                res[p.X][p.Y] = color;

                if (p.X > 0 && image[p.X - 1][p.Y] == defaultColor)
                    points.Enqueue(new Point(p.X - 1, p.Y));

                if (p.X < image.Length - 1 && image[p.X + 1][p.Y] == defaultColor)
                    points.Enqueue(new Point(p.X + 1, p.Y));

                if (p.Y > 0 && image[p.X][p.Y - 1] == defaultColor)
                    points.Enqueue(new Point(p.X, p.Y - 1));

                if (p.Y < image[p.X].Length - 1 && image[p.X][p.Y + 1] == defaultColor)
                    points.Enqueue(new Point(p.X, p.Y + 1));

                /*
                if (p.X > 0 && !colors.Contains(image[p.X - 1][p.Y]))
                    points.Enqueue(new Point(p.X - 1, p.Y));

                if (p.X < image.Length - 1 && !colors.Contains(image[p.X + 1][p.Y]))
                    points.Enqueue(new Point(p.X + 1, p.Y));

                if (p.Y > 0 && !colors.Contains(image[p.X][p.Y - 1]))
                    points.Enqueue(new Point(p.X, p.Y - 1));

                if (p.Y < image[p.Y].Length - 1 && !colors.Contains(image[p.X][p.Y + 1]))
                    points.Enqueue(new Point(p.X, p.Y + 1));
                */
            }

            return res;
        }

        private int[][] FloodFill_2(int[][] image, int sr, int sc, int color)
        {
            if (image[sr][sc] == color) return image;
            var defaultColor = image[sr][sc];

            check(image, sr, sc, color, defaultColor);

            return image;
        }

        private void check(int[][] image, int x, int y, int color, int defaultColor)
        {
            if (x < 0 || x >= image.Length || y < 0 || y >= image[x].Length)
                return;

            if (image[x][y] != defaultColor)
                return;

            image[x][y] = color;

            check(image, x - 1, y, color, defaultColor);
            check(image, x + 1, y, color, defaultColor);
            check(image, x, y - 1, color, defaultColor);
            check(image, x, y + 1, color, defaultColor);
        }

        /// <summary>
        /// 200. Number of Islands
        /// https://leetcode.com/problems/number-of-islands/?envType=study-plan&id=level-1
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            return NumIslands_1(grid);
        }

        private int NumIslands_1(char[][] grid)
        {
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        count++;

                        // update visited cells ver. 1
                        updateCell(grid, i, j);

                        // update visited cells ver. 2 (using Parallel.ForEach)
                        // DFS(grid, i, j);
                    }
                }
            }
            return count;
        }

        private void updateCell(char[][] grid, int x, int y)
        {
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[x].Length)
                return;

            if (grid[x][y] == '0')
                return;

            grid[x][y] = '0';

            updateCell(grid, x - 1, y);
            updateCell(grid, x + 1, y);
            updateCell(grid, x, y - 1);
            updateCell(grid, x, y + 1);
        }

        private static List<Tuple<int, int>> directions = new List<Tuple<int, int>>()
        {
            new Tuple<int, int> (0, 1),
            new Tuple<int, int> (0, -1),
            new Tuple<int, int> (1, 0),
            new Tuple<int, int> (-1, 0),
        };

        private void DFS(char[][] grid, int x, int y)
        {
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[x].Length)
                return;

            if (grid[x][y] == '0')
                return;

            grid[x][y] = '0';

            Parallel.ForEach(directions, d => DFS(grid, x + d.Item1, y + d.Item2));
        }


        /////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 509. Fibonacci Number
        /// https://leetcode.com/problems/fibonacci-number/?envType=study-plan&id=level-1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fibonacci_Ver1(int n)
        {
            int res = 0;
            res = calcFib(n);
            return res;
        }

        int calcFib(int n)
        {
            if (n <= 1)
                return n;

            return calcFib(n - 1) + calcFib(n - 2);
        }

        public int Fibonacci_Ver2(int N)
        {
            return (int)Math.Round((Math.Pow(((Math.Sqrt(5) + 1) / 2), N)) / Math.Sqrt(5));
        }

    }
}