using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Tourna.Login
{
    public partial class SetUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbGo_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text;
            string pws = this.txtPws.Text;
            
            if (userName.ToLower().Equals("pini") && pws.ToLower().Equals("123456"))
            {
                this.SecurityPanel.Visible = true;
                this.loginPanel.Visible = false;
            }
            else
            {
                this.lblMsg.Text = "wrong user name or password";
            }
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem item in this.CheckBoxList1.Items)
                {
                    if (item.Selected)
                    {
                        if (!Roles.RoleExists(item.Value))
                        {
                            Roles.CreateRole(item.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.lblMsg.Text = ex.Message;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                
                Roles.AddUserToRole("pini", "Administrator");
            }
            catch (Exception ex)
            {
                this.lblMsg.Text = ex.Message;
            }
        }
    }
}
