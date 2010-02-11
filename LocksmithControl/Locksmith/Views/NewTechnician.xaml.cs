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
    
        //void webService_GetTechnicianListCompleted(object sender, ServiceReferenceTechnicians.GetTechnicianListCompletedEventArgs e)
        //{
        //    if (e.Result != null && e.Result.Count > 0)
        //    {               
        //        _textBoxFirstName.Text = e.Result[0].FirstName;
        //        _textBoxLastName.Text = e.Result[0].LastName;
        //        _textBoxAddress.Text = e.Result[0].Address;

        //        for (int i=0; i < _comboBoxStates.Items.Count; i++)
        //        {
        //            if (((ComboBoxItem)_comboBoxStates.Items[i]).Content.ToString() == e.Result[0].State)
        //            {
        //                _comboBoxStates.SelectedIndex = i;
        //                break;
        //            }
        //        }

        //        for (int i = 0; i < _comboBoxCompanies.Items.Count; i++)
        //        {
        //            if (((ComboBoxItem)_comboBoxCompanies.Items[i]).Content.ToString() == e.Result[0].State)
        //            {
        //                _comboBoxCompanies.SelectedIndex = i;
        //                break;
        //            }
        //        }

        //        _textBoxCity.Text = e.Result[0].City;
        //        _textBoxEmail.Text = e.Result[0].email;
        //        _textBoxMobilePhone.Text = e.Result[0].MobilePhone;
        //        _textBoxPhone.Text = e.Result[0].Phone;
        //    }
        //}

    }
}
