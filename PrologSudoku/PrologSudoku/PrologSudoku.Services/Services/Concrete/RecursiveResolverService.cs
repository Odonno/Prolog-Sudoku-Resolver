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
            Resolution(sudoku, out sudokuResult);
        }

        /*public bool Resolution(ISudoku sudoku)
        {
            for (short i = 1; i < 10; i++)
            {
                var sudokuResult = new Sudoku(sudoku);

                // add a value that could match instead of a zero
                var firstZeroSquare = sudokuResult.Squares.First();
                firstZeroSquare.Value = i;

                // if the sudoku is full / complete (no zero), so it's okay ! (correct or incorrect ?)
                if (sudoku.IsSudokuComplete())
                    return sudoku.IsSudokuCorrect();

                // while the sudoku is uncomplete, then continue the recursive resolving method
                return Resolution(sudokuResult);
            }

            return false;
        }*/

        public bool Resolution(ISudoku sudoku, out ISudoku sudokuResult)
        {
            for (short i = 1; i < 10; i++)
            {
                sudokuResult = new Sudoku(sudoku);

                // add a value that could match instead of a zero
                var firstZeroSquare = sudokuResult.Squares.First(s => s.Value == 0);
                firstZeroSquare.Value = i;

                // Case 1 ! the sudoku is not correct, so continue
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
