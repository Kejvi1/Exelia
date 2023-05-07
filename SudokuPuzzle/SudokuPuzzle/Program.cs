using System;
using System.Linq;

namespace SudokuPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] goodSudoku1 = {
                new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},

                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},

                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };


            int[][] goodSudoku2 = {
                new int[] {1,4, 2,3},
                new int[] {3,2, 4,1},

                new int[] {4,1, 3,2},
                new int[] {2,3, 1,4}
            };

            int[][] badSudoku1 =  {
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9}
            };

            int[][] badSudoku2 = {
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {1}
            };

            Console.WriteLine($"First sudoku puzzle has the result: {ValidateSudoku(goodSudoku1)}");
            Console.WriteLine($"Second sudoku puzzle has the result: {ValidateSudoku(goodSudoku2)}");
            Console.WriteLine($"Third sudoku puzzle has the result: {ValidateSudoku(badSudoku1)}");
            Console.WriteLine($"Fourth sudoku puzzle has the result: {ValidateSudoku(badSudoku2)}");
        }

        static bool ValidateSudoku(int[][] puzzle)
        {
            var length = puzzle.Length;
            var sqrtLength = (int)Math.Sqrt(length);

            //check if any dimension is equal to zero
            if (length == 0)
                return false;

            //check the square root of the dimensions if it is a perfect square
            if (sqrtLength % 1 != 0)
                return false;

            //check the rows
            if (!ValidateRows(puzzle, length))
                return false;

            //check the columns
            if (!ValidateColumns(puzzle, length))
                return false;

            //check the little squares
            if (!ValidateSquare(puzzle, length, sqrtLength))
                return false;

            return true;
        }

        /// <summary>
        /// Validate the rows of the array
        /// </summary>
        /// <param name="puzzle">The 2d sudoku array</param>
        /// <param name="length">Length of the 2d array</param>
        /// <returns>True/false</returns>
        private static bool ValidateRows(int[][] puzzle, int length)
        {
            if (Enumerable.Range(0, length)
                .Any(i => puzzle.Skip(i * length).Take(length) //looping through the rows
                .Any(r => CheckValues(r, length)))) //check the values if they are ok
                return false;

            return true;
        }

        /// <summary>
        /// Validate the columns of the array
        /// </summary>
        /// <param name="puzzle">The 2d sudoku array</param>
        /// <param name="length">Length of the 2d array</param>
        /// <returns>True/false</returns>
        private static bool ValidateColumns(int[][] puzzle, int length)
        {
            if (Enumerable.Range(0, length)
                //select all the values from the 2d array that have the index that is being looped and we pass it to the checkValues func
                .Any(j => CheckValues(puzzle.Select(y => y[j]).ToArray(), length)))
                return false;

            return true;
        }

        /// <summary>
        /// Validate the squares of the array
        /// </summary>
        /// <param name="puzzle">The 2d sudoku array</param>
        /// <param name="length">Length of the 2d array</param>
        /// <param name="sqrtLength">The square root length of the array. Needed for building the blocks</param>
        /// <returns>True/false</returns>
        private static bool ValidateSquare(int[][] puzzle, int length, int sqrtLength)
        {
            for (int i = 0; i < length; i += sqrtLength)
            {
                for (int j = 0; j < length; j += sqrtLength)
                {
                    var square = Enumerable.Range(i, sqrtLength).SelectMany(r => Enumerable.Range(j, sqrtLength).Select(c => puzzle[r][c])).ToArray();

                    if (CheckValues(square, length))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Function where we check if the array meets the requirements:
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>Value should be bigger than 1</item>
        /// <item>Value should be lower than the length (N)</item>
        /// <item>The array must not contain duplicate values</item>
        /// </list>
        /// </remarks>
        private static readonly Func<int[], int, bool> CheckValues = (x, length) =>
        {
            if (x.Distinct().Count() != length //check if the values contain duplicates
                || x.Any(v => v < 1 || v > length)) //check if the values are lower than one or higher than the length of the array
                return true;

            return false;
        };
    }
}