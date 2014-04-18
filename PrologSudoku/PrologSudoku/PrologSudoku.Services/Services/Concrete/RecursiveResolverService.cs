using System;
using System.Collections.Generic;
using System.Linq;
using PrologSudoku.Model.Model.Abstract;
using PrologSudoku.Services.Infrastructure;
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
            return sudoku.IsRowsCorrect() && sudoku.IsColumnsCorrect() && sudoku.IsInternSquaresCorrect();
        }
    }
}
