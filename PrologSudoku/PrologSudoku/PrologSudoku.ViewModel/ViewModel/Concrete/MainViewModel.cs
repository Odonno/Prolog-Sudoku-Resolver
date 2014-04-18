using System;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PrologSudoku.Model.Model.Abstract;
using PrologSudoku.Model.Model.Concrete;
using PrologSudoku.Services.Services.Abstract;
using PrologSudoku.Services.Services.Concrete;
using PrologSudoku.ViewModel.ViewModel.Abstract;

namespace PrologSudoku.ViewModel.ViewModel.Concrete
{
    public sealed class MainViewModel : BaseViewModel, IMainViewModel
    {
        #region Fields

        private IResolverService _resolverService = new ResolverService();

        #endregion


        #region Properties

        private static IMainViewModel _instance;
        public static IMainViewModel Instance { get { return _instance ?? (_instance = new MainViewModel()); } }

        public ISudoku Sudoku { get; private set; }
        public short SelectedValue { get; set; }
        public ICommand ResolveCommand { get; private set; }
        public ICommand ClearSudokuCommand { get; private set; }
        public ICommand SelectSquareCommand { get; private set; }

        #endregion


        #region Contructor

        private MainViewModel()
        {
            Sudoku = new Sudoku();

            ResolveCommand = new RelayCommand(Resolve);
            ClearSudokuCommand = new RelayCommand(ClearSudoku, CanClearSudoku);
            SelectSquareCommand = new RelayCommand(SelectSquare);
        }

        #endregion


        #region Methods

        public void Resolve()
        {
            _resolverService.Resolve(Sudoku);
        }

        public bool CanClearSudoku()
        {
            return Sudoku.Squares.Any(s => s.Value != 0);
        }
        public void ClearSudoku()
        {
            foreach (var square in Sudoku.Squares)
                square.Value = 0;
        }

        public void SelectSquare()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
