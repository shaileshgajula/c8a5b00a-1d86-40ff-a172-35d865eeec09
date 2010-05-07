using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.FrontSitePages.UserContorls
{
    public partial class FeeTrailForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = this.txtFirstName.Text;
            string lastName = this.txtLastName.Text;
            string phone = this.txtPhone.Text;
            string email = this.txtEmail.Text;
            string country;
            string state = this.txtState.Text;
            string jobFunction = this.txtJobFunction.Text;
            string companyName = this.txtCompanyName.Text;
            string userName = this.txtUserName.Text;
            string password = this.txtPassword.Text;
        }
    }
}