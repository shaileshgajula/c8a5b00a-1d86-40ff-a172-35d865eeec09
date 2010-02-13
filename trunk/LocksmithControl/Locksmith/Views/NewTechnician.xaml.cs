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
    public partial class NewTechnician : Page
    {
        public NewTechnician()
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
            webService.InsertNewTechnicianCompleted += new EventHandler<ServiceReferenceTechnicians.InsertNewTechnicianCompletedEventArgs>(webService_InsertNewTechnicianCompleted);
            webService.InsertNewTechnicianAsync(_textBoxFirstName.Text, _textBoxLastName.Text, _textBoxAddress.Text, ((ComboBoxItem)_comboBoxStates.SelectedItem).Content.ToString(),
                                                _textBoxCity.Text, ((ComboBoxItem)_comboBoxCompanies.SelectedItem).Content.ToString(), _textBoxEmail.Text, _textBoxPhone.Text, _textBoxMobilePhone.Text);                     

        }

        void webService_InsertNewTechnicianCompleted(object sender, ServiceReferenceTechnicians.InsertNewTechnicianCompletedEventArgs e)
        {
            if (e.Result)
            {
                MessageBox.Show("New Technician has saved successfully.");
            }
            else
            {
                MessageBox.Show("Failed to save new Technician.");
            }
        }

    }
}
