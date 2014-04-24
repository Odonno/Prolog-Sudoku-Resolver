﻿using System.Windows.Controls;
using System.Windows.Input;
using PrologSudoku.ViewModel.ViewModel.Abstract;
using PrologSudoku.ViewModel.ViewModel.Concrete;

namespace PrologSudoku.UI.UserControls
{
    /// <summary>
    /// Interaction logic for ValueUserControl.xaml
    /// </summary>
    public partial class ValueUserControl : UserControl
    {
        #region Properties

        public IMainViewModel Main { get { return MainViewModel.Instance; } }
        public short Value { get; private set; }

        #endregion


        #region Constructor

        public ValueUserControl(short value)
        {
            Value = value;

            DataContext = this;

            InitializeComponent();
        }

        #endregion

        // add an event "LeftMouseButtonDown" to update the property "SelectValue" of the ViewModel
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.SelectedValue = Value;
        }
    }
}
