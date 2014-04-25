namespace PrologSudoku.Services.Services.Abstract
{
    public interface IPrologResolverService : IResolverService
    {
        #region Properties

        string PrologFilePath { get; }
        string SudokuPrologFilePath { get; }

        #endregion
    }
}
