using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrologSudoku.Model.Model.Abstract;
using PrologSudoku.ViewModel.ViewModel.Abstract;

namespace PrologSudoku.UI.UserControls
{
    /// <summary>
    /// Interaction logic for SquareUserControl.xaml
    /// </summary>
    public partial class SquareUserControl : UserControl
    {
        #region Fields

        private IMainViewModel _mainViewModel;

        #endregion

        #region Properties

        public ISquare Square { get; private set; }

        #endregion


        #region Constructor

        public SquareUserControl(IMainViewModel mainViewModel, ISquare square)
        {
            Square = square;
            _mainViewModel = mainViewModel;

            DataContext = _mainViewModel;

            InitializeComponent();
        }

        #endregion
    }
}
