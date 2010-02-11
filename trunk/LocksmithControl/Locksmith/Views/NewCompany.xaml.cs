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
    public partial class NewCompany : Page
    {
        public NewCompany()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void _buttonSave_Click(object sender, RoutedEventArgs e)
        {
            ServiceReferenceTechnicians.ServiceLocksmithClient webService = new ServiceReferenceTechnicians.ServiceLocksmithClient();
            webService.InsertNewComapnyCompleted += new EventHandler<ServiceReferenceTechnicians.InsertNewComapnyCompletedEventArgs>(webService_InsertNewComapnyCompleted);
            webService.InsertNewComapnyAsync(_textBoxCompanyName.Text, _textBoxAddress.Text,
                                             ((ComboBoxItem)_comboBoxStates.SelectedItem).Content.ToString(), _textBoxCity.Text, _textBlockZipCode.Text, _textBoxUrl.Text, _textBoxEmail.Text,
                                             _textBoxPhone1.Text, _textBoxPhone2.Text, _textBoxPhone3.Text, _textBoxFax.Text);   
        }

        void webService_InsertNewComapnyCompleted(object sender, ServiceReferenceTechnicians.InsertNewComapnyCompletedEventArgs e)
        {
            if (e.Result)
            {
                MessageBox.Show("New Company has saved successfully.");
            }
            else
            {
                MessageBox.Show("Failed to save new Company.");
            }
        }
    }
}
