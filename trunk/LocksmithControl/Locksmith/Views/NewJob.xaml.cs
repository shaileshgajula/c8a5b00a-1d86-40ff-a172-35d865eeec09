using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace Locksmith.Views
{
    public partial class NewJob : Page
    {
        public NewJob()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this._datePickerJobDate.Text = DateTime.Today.ToShortDateString();
        }

        private void _buttonSave_Click(object sender, RoutedEventArgs e)
        {         

        }
    }
}
