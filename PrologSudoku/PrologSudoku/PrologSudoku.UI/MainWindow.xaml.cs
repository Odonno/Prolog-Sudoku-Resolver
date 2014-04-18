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
            _mainViewModel = new MainViewModel();
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
                    var rectangle = new Rectangle { Fill = new SolidColorBrush(Colors.Black), Stroke = new SolidColorBrush(Colors.Lime), StrokeThickness = 1 };

                    Grid.SetRow(rectangle, i);
                    Grid.SetColumn(rectangle, j);
                    Squares.Children.Add(rectangle);
                }
            }
        }

        #endregion
    }
}

    