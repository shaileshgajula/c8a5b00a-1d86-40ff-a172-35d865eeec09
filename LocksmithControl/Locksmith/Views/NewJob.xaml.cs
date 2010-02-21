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
            ServiceReferenceLocksmith.ServiceLocksmithClient webService = new ServiceReferenceLocksmith.ServiceLocksmithClient();
            webService.InsertNewJobCompleted += new EventHandler<ServiceReferenceLocksmith.InsertNewJobCompletedEventArgs>(webService_InsertNewJobCompleted);
            webService.InsertNewJobAsync(_textBoxAddress.Text, _textBoxCity.Text, ((ComboBoxItem)_comboBoxCompanies.SelectedItem).Content.ToString(), Convert.ToDouble(_textBoxCost.Text),
                                         _textBoxFirstName.Text, _textBoxInfo.Text, ((ComboBoxItem)_comboBoxJobPricing.SelectedItem).Content.ToString(),
                                         ((ComboBoxItem)_comboBoxJobType.SelectedItem).Content.ToString(), _textBoxLastName.Text, _textBoxMobilePhone.Text,
                                         ((ComboBoxItem)_comboBoxJobPayment.SelectedItem).Content.ToString(), _textBoxPhone.Text, _textBoxMobilePhone.Text,
                                         ((ComboBoxItem)_comboBoxStates.SelectedItem).Content.ToString(),
                                         ((ComboBoxItem)_comboBoxTechnician.SelectedItem).Content.ToString(), Convert.ToDouble(_textBoxTotal.Text));

        }

        void webService_InsertNewJobCompleted(object sender, ServiceReferenceLocksmith.InsertNewJobCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                _textBoxCompanyPayout.Text = e.Result._company.ToString();
                _textBoxGross.Text = e.Result._gross.ToString();
                _textBoxGrossCost.Text = e.Result._grossMinusCost.ToString();
                _textBoxNetPayment.Text = e.Result._businessNet.ToString();
                _textBoxSumCash.Text = e.Result._sumCash.ToString();
                _textBoxTechnicianCut.Text = e.Result._techCut.ToString();
                _textBoxTechnicianPayout.Text = e.Result._techPayout.ToString();                

                MessageBox.Show("New Job has saved successfully.");
            }
            else
            {
                MessageBox.Show("Failed to save new Job.");
            }
        }      
    }
}
