using PrologSudoku.Model.Abstract;

namespace PrologSudoku.Model.Concrete
{
    public class Square : ISquare
    {
        public short Value { get; set; }
    }
}
