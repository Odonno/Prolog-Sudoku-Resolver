using PrologSudoku.Model.Model.Abstract;

namespace PrologSudoku.Services.Services.Abstract
{
    public interface IResolverService
    {
        #region Properties

        string PrologFilePath { get; }
        string SudokuPrologFilePath { get; }

        #endregion


        #region Methods

        ISudoku Resolve(ISudoku sudoku);

        #endregion
    }
}
