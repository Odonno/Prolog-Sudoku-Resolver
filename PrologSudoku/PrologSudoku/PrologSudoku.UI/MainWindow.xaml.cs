using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PrologSudoku.UI.UserControls;
using PrologSudoku.ViewModel.ViewModel.Abstract;
using PrologSudoku.ViewModel.ViewModel.Concrete;

namespace PrologSudoku.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private readonly IMainViewModel _mainViewModel;

        #endregion


        #region Constructor

        public MainWindow()
        {
            _mainViewModel = MainViewModel.Instance;
            DataContext = _mainViewModel;

            InitializeComponent();

            GenerateSquares();
            GenerateValues();
        }

        #endregion


        #region Methods

        private void GenerateValues()
        {
            for (short i = 1; i <= 10; i++)
            {
                // Generate rows of the grid
                Values.RowDefinitions.Add(new RowDefinition());

                // Generate values

                // create a UserControl for the generation of values
                var valueUserControl = new ValueUserControl(_mainViewModel, ((i == 10) ? (short)0 : i));

                Grid.SetRow(valueUserControl, i - 1);
                Values.Children.Add(valueUserControl);
            }
        }

        private void GenerateSquares()
        {
            // Generate rows of the grid
            for (short i = 0; i < 9; i++)
                Squares.RowDefinitions.Add(new RowDefinition());

            // Generate columns of the grid
            for (short j = 0; j < 9; j++)
                Squares.ColumnDefinitions.Add(new ColumnDefinition());

            // Generate squares
            const short extraThickness = 5;
            const short minThickness = 1;

            for (short i = 0; i < 9; i++)
            {
                for (short j = 0; j < 9; j++)
                {
                    // Get thickness of the Square border
                    var borderThickness = new Thickness
                    {
                        Left = (j % 3 == 0) ? extraThickness : minThickness,
                        Top = (i % 3 == 0) ? extraThickness : minThickness,
                        Right = (j == 8) ? extraThickness : minThickness,
                        Bottom = (i == 8) ? extraThickness : minThickness
                    };

                    // create a UserControl for the generation of squares
                    var squareUserControl = new SquareUserControl(_mainViewModel, _mainViewModel.Sudoku.Squares[i * 9 + j], borderThickness);

                    Grid.SetRow(squareUserControl, i);
                    Grid.SetColumn(squareUserControl, j);
                    Squares.Children.Add(squareUserControl);
                }
            }
        }

        #endregion
    }
}

