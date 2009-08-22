using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using StrongerOrg.Backoffice.Entities;

namespace StrongerOrg.Backoffice
{
	public partial class ManageUsers : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                Membership.CreateUser(this.txtUserName.Text, this.txtPassword.Text, this.txtEmail.Text);
                UsersManager.UpdateUserOrganisationId(this.txtUserName.Text, this.Master.OrgBasicInfo.Id);
                RadioButtonList rbRoles= this.LoginView1.FindControl("rbRoles") as RadioButtonList;
                Roles.AddUserToRole(this.txtUserName.Text, rbRoles.SelectedValue);
                this.GridView1.DataBind();
            }
            catch (Exception ex)
            {
                this.ErrorMessage.Text = ex.Message;
            }
        }
	}
}
