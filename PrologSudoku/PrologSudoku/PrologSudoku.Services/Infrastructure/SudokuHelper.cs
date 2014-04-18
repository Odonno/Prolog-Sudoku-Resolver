using System;
using System.Text.RegularExpressions;
using PrologSudoku.Model.Model.Abstract;

namespace PrologSudoku.Services.Infrastructure
{
    public static class SudokuHelper
    {
        public static string ConvertSudokuToPrologTab(this ISudoku sudoku)
        {
            throw new NotImplementedException();
        }

        public static void ConvertPrologTabToSudoku(this ISudoku sudoku, string prologTab)
        {
            var regex = new Regex("[\\[\\]]");
            string[] values = regex.Replace(prologTab, "").Split(',');

            for (int i = 0; i < values.Length; i++)
                sudoku.Squares[i].Value = short.Parse(values[i]);
        }
    }
}
