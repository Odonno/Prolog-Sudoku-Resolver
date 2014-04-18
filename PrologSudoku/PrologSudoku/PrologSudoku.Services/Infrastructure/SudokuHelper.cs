using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PrologSudoku.Model.Model.Abstract;

namespace PrologSudoku.Services.Infrastructure
{
    public static class SudokuHelper
    {
        #region Methods used with Prolog

        public static string ConvertSudokuToPrologTab(this ISudoku sudoku)
        {
            var sbuilder = new StringBuilder();

            // Start the array
            sbuilder.Append("[");

            // Add every values
            foreach (var square in sudoku.Squares)
                sbuilder.Append(string.Format("{0},", square.Value));

            // Delete the last character (',')
            sbuilder.Remove(sbuilder.Length - 1, 1);

            // End the array
            sbuilder.Append("]");

            return sbuilder.ToString();
        }

        public static void ConvertPrologTabToSudoku(this ISudoku sudoku, string prologTab)
        {
            var regex = new Regex("[\\[,\\]]");
            string values = regex.Replace(prologTab, "");

            for (int i = 0; i < values.Length; i++)
                sudoku.Squares[i].Value = short.Parse(values.Substring(i, 1));
        }

        #endregion


        #region Methods used with C#

        public static bool IsRowsCorrect(this ISudoku sudoku)
        {
            // TODO : test it
            for (short i = 0; i < 9; i++)
                if (!IsNineSquaresCorrect(sudoku.Squares.Skip(i * 9).Take(9)))
                    return false;

            return true;
        }

        public static bool IsColumnsCorrect(this ISudoku sudoku)
        {
            // TODO : test it
            for (short i = 0; i < 9; i++)
                if (!IsNineSquaresCorrect(sudoku.Squares.Where((s, index) => index % 9 == i)))
                    return false;

            return true;
        }

        public static bool IsInternSquaresCorrect(this ISudoku sudoku)
        {
            // TODO : test it
            for (short i = 0; i < 3; i++)
                for (short j = 0; j < 3; j++)
                    if (!IsNineSquaresCorrect(sudoku.Squares.Skip(i * 27 + j * 3).Take(3).Skip(6).Take(3).Skip(6).Take(3)))
                        return false;

            return true;
        }

        public static bool IsNineSquaresCorrect(this IEnumerable<ISquare> squares)
        {
            // TODO : test it
            var results = squares.Where(s => s.Value > 0).GroupBy(s => s.Value, (key, g) => new { value = key, count = g.Count() });
            return !(results.Max(r => r.count) > 1);
        }

        #endregion
    }
}
