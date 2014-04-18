using System.Text;
using System.Text.RegularExpressions;
using PrologSudoku.Model.Model.Abstract;

namespace PrologSudoku.Services.Infrastructure
{
    public static class SudokuHelper
    {
        public static string ConvertSudokuToPrologTab(this ISudoku sudoku)
        {
            var sbuilder = new StringBuilder();

            // Start the array
            sbuilder.Append("[");

            // Add every values
            foreach (ISquare t in sudoku.Squares)
                sbuilder.Append(string.Format("{0},", t.Value));

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
    }
}
