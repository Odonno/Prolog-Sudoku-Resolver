using PrologSudoku.Model.Model.Abstract;

namespace PrologSudoku.Model.Model.Concrete
{
    public class Square : ISquare
    {
        // TODO : use NotifyPropertyChanged to update the view
        public short Value { get; set; }
    }
}
