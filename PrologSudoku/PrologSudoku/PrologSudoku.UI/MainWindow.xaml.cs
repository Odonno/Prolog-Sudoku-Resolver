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
            GenerateValues();
        }

        #endregion


        #region Methods

        private void GenerateValues()
        {
            for (short i = 0; i < 10; i++)
            {
                // Generate rows of the grid
                Values.RowDefinitions.Add(new RowDefinition());

                // Generate values

                // TODO : create a UserControl for the generation of values
                // TODO : add an event "LeftMouseButtonDown" to update the property "SelectValue" of the ViewModel

                // Create the TextBlock to show the value of the square
                var textBlock = new TextBlock
                {
                    Text = (i == 9) ? string.Empty : (i + 1).ToString(),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                // Create a Border around the TextBlock
                var border = new Border
                {
                    BorderThickness = new Thickness(1),
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    Child = textBlock
                };

                Grid.SetRow(border, i);
                Values.Children.Add(border);
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
                    short leftThickness = (j % 3 == 0) ? extraThickness : minThickness;
                    short topThickness = (i % 3 == 0) ? extraThickness : minThickness;
                    short rightThickness = (j == 8) ? extraThickness : minThickness;
                    short bottomThickness = (i == 8) ? extraThickness : minThickness;

                    // TODO : create a UserControl for the generation of squares
                    // TODO : add an event "LeftMouseButtonDown" to call the command "SelectSquareCommand" of the ViewModel (argument = Square clicked)

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

