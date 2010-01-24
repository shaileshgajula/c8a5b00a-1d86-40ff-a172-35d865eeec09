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

namespace LockSmith.SL.Controls
{
    public partial class TechnicianScreen : UserControl
    {
        public TechnicianScreen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstName = this.txtFirstName.Text;
            string lastName = this.txtFirstName.Text;
            string phone = this.txtFirstName.Text;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
        }
    }
}
