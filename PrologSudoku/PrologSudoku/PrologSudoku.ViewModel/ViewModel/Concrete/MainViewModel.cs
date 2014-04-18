using System.Windows.Input;
using PrologSudoku.Model.Model.Abstract;
using PrologSudoku.Model.Model.Concrete;
using PrologSudoku.ViewModel.ViewModel.Abstract;

namespace PrologSudoku.ViewModel.ViewModel.Concrete
{
    public sealed class MainViewModel : BaseViewModel, IMainViewModel
    {
        #region Properties

        private static IMainViewModel _instance;
        public static IMainViewModel Instance { get { return _instance ?? (_instance = new MainViewModel()); } }

        public ISudoku Sudoku { get; private set; }
        public ICommand ResolveCommand { get; private set; }

        #endregion



        #region Contructor

        private MainViewModel()
        {
            Sudoku = new Sudoku();
        }

        #endregion
    }
}
