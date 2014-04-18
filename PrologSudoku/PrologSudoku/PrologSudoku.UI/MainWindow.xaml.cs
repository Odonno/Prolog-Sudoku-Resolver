using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PrologSudoku.ViewModel.ViewModel.Abstract;
using PrologSudoku.ViewModel.ViewModel.Concrete;
using Path = System.IO.Path;

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
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    short topThickness = 1;
                    short leftThickness = 1;
                    short rightThickness = 1;
                    short bottomThickness = 1;

                    if (j % 3 == 0)
                        leftThickness = 5;

                    if (i % 3 == 0)
                        topThickness = 5;

                    if (i == 8)
                        bottomThickness = 5;

                    if (j == 8)
                        rightThickness = 5;


                    var border = new Border
                    {
                        BorderThickness = new Thickness(leftThickness, topThickness, rightThickness, bottomThickness),
                        BorderBrush = new SolidColorBrush(Colors.Lime)
                    };
                    var rectangle = new Rectangle { Fill = new SolidColorBrush(Colors.Black) };

                    border.Child = rectangle;

                    Grid.SetRow(border, i);
                    Grid.SetColumn(border, j);
                    Squares.Children.Add(border);
                }
            }
        }

        #endregion
    }
}

