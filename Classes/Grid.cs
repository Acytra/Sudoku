using System;
using System.Linq;

namespace Sudoku.Classes {

    class Grid {
        public static int Rows => 9;
        public static int Columns => 9;
        public static int subMatrixRows => 3;
        public static int subMatrixColumns => 3;

        private Number[,] matrix = new Number[Rows, Columns];

        public Grid() {

        }

        public void UpdateCell(Number row, Number column, Number newValue) {
            matrix[(int)row - 1, (int)column - 1] = newValue;
        }

        private Number[] GetRow(int row) {
            return Enumerable.Range(0, Columns)
                .Select(x => matrix[row - 1, x])
                .ToArray();
        }

        private Number[] GetColumn(int column) {
            return Enumerable.Range(0, Rows)
                    .Select(x => matrix[x, column - 1])
                    .ToArray();
        }

        public Number[,] GetSquare(int row, int column) {
            Number[,] subMatrix = new Number[subMatrixRows, subMatrixColumns];
            int offsetRow = (row - 1) * subMatrixRows;
            int offsetColumn = (column - 1) * subMatrixColumns;

            for (int i = 0; i < subMatrixRows; i++) {
                for (int j = 0; j < subMatrixColumns; j++) {
                    subMatrix[i, j] = matrix[i + offsetRow, j + offsetColumn];
                }
            }
            return subMatrix;
        }

        public void PrintMatrix() {
            Console.WriteLine("The matrix is:");
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Columns; j++) {
                    Console.WriteLine($"element - [{i},{j}]: {(int)matrix[i, j]}");
                }
            }
            Console.WriteLine();
        }

        public void PrintMatrixWithFormat() {
            Console.WriteLine("The matrix is:");
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Columns; j++)
                    Console.Write($"{(int)matrix[i, j]} ");
                Console.Write("\n");
            }
            Console.WriteLine();
        }

        public void PrintRow(int row) {
            Number[] rowArray = GetRow(row);

            Console.WriteLine($"The row {row} is:");
            for (int i = 0; i < Rows; i++) {
                Console.Write($"{(int)rowArray[i]} ");
            }
            Console.WriteLine("\n");
        }

        public void PrintColumn(int column) {
            Number[] columnArray = GetColumn(column);

            Console.WriteLine($"The column {column} is:");
            for (int i = 0; i < Columns; i++) {
                Console.WriteLine((int)columnArray[i]);
            }
            Console.WriteLine();
        }

        public void PrintSquare(int row, int column) {
            Number[,] square = GetSquare(row, column);
            Console.WriteLine($"The square {row}, {column} is:");
            for (int i = 0; i < subMatrixRows; i++) {
                for (int j = 0; j < subMatrixColumns; j++) {
                    Console.Write($"{(int)square[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}