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
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
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


        public void Resolution()
        {
            //Création du processus Prolog
            Process P = new Process();
            P.StartInfo.FileName = "C:/Program Files/swipl/bin/swipl.exe";
            P.StartInfo.UseShellExecute = false;
            P.StartInfo.RedirectStandardInput = true;
            P.StartInfo.RedirectStandardOutput = true;
            P.Start();

            //Définition Entrée/Sortie du processus Prolog
            StreamWriter prologInput = P.StandardInput;
            StreamReader prologOutput = P.StandardOutput;

            //Lecture du fichier .pl
            prologInput.WriteLine("consult(\'C:/Users/Matthieu/Documents/Prolog/sudoku.pl\').");

            //Envoit d'un prédicat
            prologInput.WriteLine("sudokuExemple(X).");
            Thread.Sleep(200);

            //On ferme le processus pour pouvoir lire son contenu
            P.Kill();
            String temp = prologOutput.ReadToEnd();

            //Ecriture dans un fichier
            File.AppendAllText("C:/Users/Matthieu/Desktop/sortie_Sudoku.txt", temp);
            //Console.ReadLine();
        }

        #endregion
    }
}

    