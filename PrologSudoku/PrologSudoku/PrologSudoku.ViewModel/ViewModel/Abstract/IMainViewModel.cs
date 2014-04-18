using System.Windows.Input;
using PrologSudoku.Model.Model.Abstract;

namespace PrologSudoku.ViewModel.ViewModel.Abstract
{
    public interface IMainViewModel : IViewModel
    {
        ISudoku Sudoku { get; }
        short SelectedValue { get; set; }
        ICommand ResolveCommand { get; }
        ICommand ClearSudokuCommand { get; }
        ICommand SelectSquareCommand { get; }
    }
}
