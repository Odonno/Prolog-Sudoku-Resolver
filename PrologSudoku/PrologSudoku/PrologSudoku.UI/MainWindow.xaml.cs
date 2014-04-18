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

