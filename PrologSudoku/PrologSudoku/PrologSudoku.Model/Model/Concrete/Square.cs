using System.ComponentModel;
using PrologSudoku.Model.Model.Abstract;

namespace PrologSudoku.Model.Model.Concrete
{
    public class Square : ISquare, INotifyPropertyChanged
    {
        #region Properties

        private short _value;
        public short Value { get { return _value; } set { _value = value; RaisePropertyChanged("Value"); } }

        #endregion


        #region Constructor

        public Square() { }

        public Square(short value)
        {
            _value = value;
        }

        public Square(ISquare square)
        {
            Value = square.Value;
        }

        #endregion


        #region Property Changed implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
