using PrologSudoku.Model.Model.Abstract;

namespace PrologSudoku.Services.Services.Abstract
{
    public interface IRecursiveResolverService : IResolverService
    {
        bool IsSudokuCorrect(ISudoku sudoku);
    }
}
