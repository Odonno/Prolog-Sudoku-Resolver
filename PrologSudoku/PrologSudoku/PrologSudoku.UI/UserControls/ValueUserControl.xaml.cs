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
using PrologSudoku.ViewModel.ViewModel.Abstract;

namespace PrologSudoku.UI.UserControls
{
    /// <summary>
    /// Interaction logic for ValueUserControl.xaml
    /// </summary>
    public partial class ValueUserControl : UserControl
    {
        #region Fields

        private IMainViewModel _mainViewModel;

        #endregion

        #region Properties

        public short Value { get; private set; }

        #endregion


        #region Constructor

        public ValueUserControl(IMainViewModel mainViewModel, short value)
        {
            Value = value;
            _mainViewModel = mainViewModel;

            DataContext = this;

            InitializeComponent();
        }

        #endregion

        // TODO : add an event "LeftMouseButtonDown" to update the property "SelectValue" of the ViewModel
    }
}
