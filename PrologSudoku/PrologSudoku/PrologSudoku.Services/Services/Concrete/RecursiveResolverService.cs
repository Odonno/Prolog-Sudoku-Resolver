using System;
using System.Collections.Generic;
using System.Linq;
using PrologSudoku.Model.Model.Abstract;
using PrologSudoku.Services.Services.Abstract;

namespace PrologSudoku.Services.Services.Concrete
{
    public class RecursiveResolverService : IRecursiveResolverService
    {
        public void Resolve(ISudoku sudoku)
        {
            throw new NotImplementedException();
        }

        public bool IsSudokuCorrect(ISudoku sudoku)
        {
            return IsRowsCorrect(sudoku) && IsColumnsCorrect(sudoku) && IsInternSquaresCorrect(sudoku);
        }

        private bool IsRowsCorrect(ISudoku sudoku)
        {
            // TODO : test it
            for (short i = 0; i < 9; i++)
                if (!IsNineSquaresCorrect(sudoku.Squares.Skip(i * 9).Take(9)))
                    return false;

            return true;
        }

        private bool IsColumnsCorrect(ISudoku sudoku)
        {
            // TODO : test it
            for (short i = 0; i < 9; i++)
                if (!IsNineSquaresCorrect(sudoku.Squares.Where((s, index) => index % 9 == i)))
                    return false;

            return true;
        }

        private bool IsInternSquaresCorrect(ISudoku sudoku)
        {
            // TODO : test it
            for (short i = 0; i < 3; i++)
                for (short j = 0; j < 3; j++)
                    if (!IsNineSquaresCorrect(sudoku.Squares.Skip(i * 27 + j * 3).Take(3).Skip(6).Take(3).Skip(6).Take(3)))
                        return false;

            return true;
        }

        private bool IsNineSquaresCorrect(IEnumerable<ISquare> squares)
        {
            // TODO : test it
            var results = squares.Where(s => s.Value > 0).GroupBy(s => s.Value, (key, g) => new { value = key, count = g.Count() });
            return !(results.Max(r => r.count) > 1);
        }
    }
}
