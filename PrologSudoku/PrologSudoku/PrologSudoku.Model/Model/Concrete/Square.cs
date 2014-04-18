using PrologSudoku.Model.Model.Abstract;

namespace PrologSudoku.Model.Model.Concrete
{
    public class Square : ISquare
    {
        public short Value { get; set; }
    }
}
