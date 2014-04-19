using System.Linq;
using PrologSudoku.Model.Model.Abstract;
using PrologSudoku.Model.Model.Concrete;
using PrologSudoku.Services.Infrastructure;
using PrologSudoku.Services.Services.Abstract;

namespace PrologSudoku.Services.Services.Concrete
{
    public class RecursiveResolverService : IRecursiveResolverService
    {
        public void Resolve(ISudoku sudoku)
        {
            ISudoku sudokuResult;

            if (Resolution(sudoku, out sudokuResult))
                for (short i = 0; i < sudoku.Squares.Length; i++)
                    sudoku.Squares[i].Value = sudokuResult.Squares[i].Value;
        }

        private bool Resolution(ISudoku sudoku, out ISudoku sudokuResult)
        {
            for (short i = 1; i < 10; i++)
            {
                sudokuResult = new Sudoku(sudoku);

                // add a value that could match instead of a zero
                var firstZeroSquare = sudokuResult.Squares.First(s => s.Value == 0);
                firstZeroSquare.Value = i;

                // Case 1 : if the sudoku is not correct, so continue
                if (!sudokuResult.IsSudokuCorrect())
                    continue;

                // Case 2 A : if the sudoku is full / complete (no zero) and correct, so it's okay !
                // Case 2 B : if the sudoku is complete but not correct, so continue
                if (sudokuResult.IsSudokuComplete())
                {
                    if (sudokuResult.IsSudokuCorrect())
                        return true;

                    continue;
                }

                // Recursive case : if the sudoku is uncomplete, then continue the recursive resolving method
                ISudoku endSudokuResult;
                if (Resolution(sudokuResult, out endSudokuResult))
                {
                    sudokuResult = endSudokuResult;
                    return true;
                }
            }

            sudokuResult = null;
            return false;
        }
    }
}
