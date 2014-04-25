using System;
using PrologSudoku.Model.Model.Abstract;

namespace PrologSudoku.Model.Model.Concrete
{
    public class Sudoku : ISudoku
    {
        #region Properties

        public ISquare[] Squares { get; set; }

        #endregion


        #region Constructor

        public Sudoku()
        {
            Squares = new ISquare[81];
            for (short i = 0; i < 81; i++)
                Squares[i] = new Square();
        }

        public Sudoku(short[] squares)
        {
            if (squares.Length != 81)
                throw new ArgumentException();

            Squares = new ISquare[81];
            for (short i = 0; i < squares.Length; i++)
                Squares[i] = new Square(squares[i]);
        }

        public Sudoku(ISudoku sudoku)
        {
            Squares = new ISquare[81];
            for (short i = 0; i < 81; i++)
                Squares[i] = new Square(sudoku.Squares[i]);
        }

        #endregion
    }
}
