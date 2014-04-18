using System.Diagnostics;
using System.IO;
using System.Threading;
using PrologSudoku.Model.Model.Abstract;
using PrologSudoku.Services.Infrastructure;
using PrologSudoku.Services.Services.Abstract;

namespace PrologSudoku.Services.Services.Concrete
{
    public class ResolverService : IResolverService
    {
        #region Properties

        public string PrologFilePath { get { return "C:/Program Files/swipl/bin/swipl.exe"; } }
        public string SudokuPrologFilePath { get { return Path.Combine(Directory.GetCurrentDirectory(), "Assets/sudoku.pl").Replace("\\", "/"); } }

        #endregion


        #region Methods

        public void Resolve(ISudoku sudoku)
        {
            // Création du processus Prolog
            var process = new Process
            {
                StartInfo =
                {
                    FileName = PrologFilePath,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                }
            };
            process.Start();

            // Définition Entrée/Sortie du processus Prolog
            StreamWriter prologInput = process.StandardInput;
            StreamReader prologOutput = process.StandardOutput;

            // Lecture du fichier .pl
            prologInput.WriteLine("consult(\'{0}\').", SudokuPrologFilePath);

            // Envoi d'un prédicat
            // convert sudoku to prolog tab
            prologInput.WriteLine("exec_sudoku({0}, X).", sudoku.ConvertSudokuToPrologTab());
            Thread.Sleep(500);

            // On ferme le processus pour pouvoir lire son contenu
            process.Kill();

            // Lecture du résultat
            // convert prolog tab to sudoku
            sudoku.ConvertPrologTabToSudoku(prologOutput.ReadToEnd());
        }

        #endregion
    }
}
