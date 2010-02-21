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
    public partial class AllOpenJobs : Page
    {
        public AllOpenJobs()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //ServiceReferenceTechnicians.ServiceLocksmithClient webService = new ServiceReferenceTechnicians.ServiceLocksmithClient();
            //webService.GetJobsListCompleted += new EventHandler<ServiceReferenceTechnicians.GetJobsListCompletedEventArgs>(webService_GetJobsListCompleted);
            //webService.GetJobsListAsync();
        }

        //void webService_GetJobsListCompleted(object sender, ServiceReferenceLocksmith.GetJobsListCompletedEventArgs e)
        //{
        //    _DataGridAllJobs.ItemsSource = e.Result;
        //}

        private void _DataGridAllJobs_CellEditEnded(object sender, DataGridCellEditEndedEventArgs e)
        {
            if (!_buttonSubmitChanges.IsEnabled)
            {
                _buttonSubmitChanges.IsEnabled = true;
            }
        }

    }
}
