using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace StrongerOrg.Backoffice
{
	public partial class ManageUsers : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string searchByParam = this.ddlSearchBy.SelectedValue;
            //string searchKey = this.txtSearchParam.Text;
            //MembershipUserCollection muc = null;
            //switch (searchByParam)
            //{
            //    case "User":
            //        muc= Membership.FindUsersByName(searchKey);
            //        break;
            //    case "Email":
            //        muc = Membership.FindUsersByEmail(searchKey);
            //        break;
            //    case "OrganisationName":
            //        muc = StrongerOrg.Backoffice.Entities.ManageUsers.FindUsersByOrganisationName(searchKey);
            //        break;
            //}
            //this.GridView1.
            //this.ObjectDataSource1.Select();
            //this.GridView1.DataSource = muc;
            //this.GridView1.DataBind();
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                Membership.CreateUser(this.txtUserName.Text, this.txtPassword.Text, this.txtEmail.Text);
                Roles.AddUserToRole(this.txtUserName.Text, this.rbRoles.SelectedValue);
                HttpContext.Current.Profile.GetPropertyValue("OrganisationId");
                this.GridView1.DataBind();
            }
            catch (Exception ex)
            {
                this.ErrorMessage.Text = ex.Message;
            }
        }
	}
}
