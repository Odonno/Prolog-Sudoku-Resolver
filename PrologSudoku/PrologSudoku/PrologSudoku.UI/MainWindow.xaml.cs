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

namespace PrologSudoku.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}

    