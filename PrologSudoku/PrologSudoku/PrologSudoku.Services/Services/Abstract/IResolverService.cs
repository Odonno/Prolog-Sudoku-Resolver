using PrologSudoku.Model.Model.Abstract;

namespace PrologSudoku.Services.Services.Abstract
{
    public interface IResolverService
    {
        #region Methods

        void Resolve(ISudoku sudoku);

        #endregion
    }
}
