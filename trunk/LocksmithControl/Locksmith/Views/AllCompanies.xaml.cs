﻿using System;
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
    public partial class AllCompanies : Page
    {
        public AllCompanies()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ServiceReferenceLocksmith.ServiceLocksmithClient webService = new ServiceReferenceLocksmith.ServiceLocksmithClient();
            webService.GetCompanyListCompleted += new EventHandler<ServiceReferenceLocksmith.GetCompanyListCompletedEventArgs>(webService_GetCompanyListCompleted);
            webService.GetCompanyListAsync();            
        }

        void webService_GetCompanyListCompleted(object sender, ServiceReferenceLocksmith.GetCompanyListCompletedEventArgs e)
        {
            _DataGridAllCompanies.ItemsSource = e.Result;
        }

        private void _DataGridAllCompanies_CellEditEnded(object sender, DataGridCellEditEndedEventArgs e)
        {
            if (!_buttonSubmitChanges.IsEnabled)
            {
                _buttonSubmitChanges.IsEnabled = true;
            }
        }

    }
}