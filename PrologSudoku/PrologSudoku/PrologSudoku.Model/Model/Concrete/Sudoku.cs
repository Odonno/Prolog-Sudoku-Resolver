using PrologSudoku.Model.Model.Abstract;

namespace PrologSudoku.Model.Model.Concrete
{
    public class Sudoku : ISudoku
    {
        public ISquare[] Squares { get; set; }

        public Sudoku()
        {
            Squares = new ISquare[81];
            for (int i = 0; i < 81; i++)
                Squares[i] = new Square();
        }
    }
}
