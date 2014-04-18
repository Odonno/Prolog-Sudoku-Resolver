using PrologSudoku.ViewModel.ViewModel.Abstract;

namespace PrologSudoku.ViewModel.ViewModel.Concrete
{
    public sealed class MainViewModel : BaseViewModel, IMainViewModel
    {
        #region Properties

        private static IMainViewModel _instance;
        public static IMainViewModel Instance { get { return _instance ?? (_instance = new MainViewModel()); } }

        #endregion



        #region Contructor

        private MainViewModel() { }

        #endregion
    }
}
