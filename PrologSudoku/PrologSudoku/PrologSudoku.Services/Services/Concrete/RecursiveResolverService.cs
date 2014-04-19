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
            // TODO : Add a value that could match instead of a zero
            
            throw new NotImplementedException();
        }

        public bool Resolution(ISudoku sudoku)
        {
            throw new NotImplementedException();

            if (sudoku.IsSudokuCorrect())
            {
                // if the sudoku is full / complete (no zero) and correct, so it's okay !

                // if the sudoku is correct, then continue the recursive resolving method
            }
        }
    }
}
