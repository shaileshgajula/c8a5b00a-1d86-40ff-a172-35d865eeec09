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
            ServiceReferenceTechnicians.ServiceLocksmithClient webService = new ServiceReferenceTechnicians.ServiceLocksmithClient();
            webService.InsertNewJobCompleted+=new EventHandler<ServiceReferenceTechnicians.InsertNewJobCompletedEventArgs>(webService_InsertNewJobCompleted);
            webService.InsertNewJobAsync(_textBoxAddress.Text, _textBoxCity.Text, ((ComboBoxItem)_comboBoxCompanies.SelectedItem).Content.ToString(), Convert.ToDecimal(_textBoxCost.Text),
                                         null, _textBoxFirstName.Text, null, null, _textBoxInfo.Text, ((ComboBoxItem)_comboBoxJobPricing.SelectedItem).Content.ToString(),
                                         ((ComboBoxItem)_comboBoxJobType.SelectedItem).Content.ToString(), _textBoxLastName.Text, _textBoxMobilePhone.Text, null,
                                         ((ComboBoxItem)_comboBoxJobPayment.SelectedItem).Content.ToString(), _textBoxPhone.Text, _textBoxMobilePhone.Text, ((ComboBoxItem)_comboBoxStates.SelectedItem).Content.ToString(),
                                         null, null, null, ((ComboBoxItem)_comboBoxTechnician.SelectedItem).Content.ToString(), Convert.ToDecimal(_textBoxTotal.Text));

        }

        void webService_InsertNewJobCompleted(object sender, ServiceReferenceTechnicians.InsertNewJobCompletedEventArgs e)
        {
            if (e.Result)
            {
                MessageBox.Show("New Job has saved successfully.");
            }
            else
            {
                MessageBox.Show("Failed to save new Job.");
            }
        }
    }
}
