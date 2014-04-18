using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
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
        }

        #endregion


        #region Methods

        private void GenerateSquares()
        {
            // Generate rows of the grid
            for (int i = 0; i < 9; i++)
                Squares.RowDefinitions.Add(new RowDefinition());

            // Generate columns of the grid
            for (int j = 0; j < 9; j++)
                Squares.ColumnDefinitions.Add(new ColumnDefinition());

            // Generate pixels
            const short extraThickness = 5;
            const short minThickness = 1;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Get thickness of the Square border
                    short leftThickness = (j % 3 == 0) ? extraThickness : minThickness;
                    short topThickness = (i % 3 == 0) ? extraThickness : minThickness;
                    short rightThickness = (j == 8) ? extraThickness : minThickness;
                    short bottomThickness = (i == 8) ? extraThickness : minThickness;

                    // Create the TextBlock to show the value of the square
                    var textBlock = new TextBlock
                    {
                        Text = _mainViewModel.Sudoku.Squares[i * 9 + j].Value.ToString(), 
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };

                    // Create a Border around the TextBlock
                    var border = new Border
                    {
                        BorderThickness = new Thickness(leftThickness, topThickness, rightThickness, bottomThickness),
                        BorderBrush = new SolidColorBrush(Colors.Lime),
                        Child = textBlock
                    };

                    Grid.SetRow(border, i);
                    Grid.SetColumn(border, j);
                    Squares.Children.Add(border);
                }
            }
        }

        #endregion
    }
}

