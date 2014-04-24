using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PrologSudoku.Model.Model.Abstract;
using PrologSudoku.ViewModel.ViewModel.Abstract;
using PrologSudoku.ViewModel.ViewModel.Concrete;

namespace PrologSudoku.UI.UserControls
{
    /// <summary>
    /// Interaction logic for SquareUserControl.xaml
    /// </summary>
    public partial class SquareUserControl : UserControl
    {
        #region Properties

        public IMainViewModel Main { get { return MainViewModel.Instance; } }
        public ISquare Square { get; private set; }
        public Thickness Thickness { get; private set; }

        #endregion


        #region Constructor

        public SquareUserControl(ISquare square, Thickness thickness)
        {
            Square = square;
            Thickness = thickness;

            DataContext = this;

            InitializeComponent();
        }

        #endregion
    }
}
