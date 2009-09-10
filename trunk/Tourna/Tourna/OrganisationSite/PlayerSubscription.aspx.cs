using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg
{
    public partial class PlayerSubscription : System.Web.UI.Page
    {
        string orgId;
        protected void Page_Load(object sender, EventArgs e)
        {
            object orgIdObj = Request.QueryString["OrgId"];
            if ( orgIdObj != null && !string.IsNullOrEmpty(orgIdObj.ToString()))
            {
                try
                {
                    orgId = orgIdObj.ToString();
                    Guid guid = new Guid(orgId);
                }
                catch (Exception)
                {
                    this.lblMsg.Text = "Invalid request";
                    this.Panel1.Visible = false;
                }
            }
            else
            {
                this.lblMsg.Text = "Invalid request";
                this.Panel1.Visible = false;
            }
        }

        protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            this.Panel1.Visible = false;
            
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {

            string name = this.txtName.Text;
            //string nickName = this.txtNickName.Text; ;
            string email = this.txtEmail.Text;
            //string department = this.txtDepartment.Text;
            string tournamentId = this.RadioButtonList1.SelectedValue;
            PlayersManager.InsertPlayer(this.orgId, name, string.Empty, email, string.Empty, tournamentId);
            this.Panel1.Visible = false;
            this.lblMsg.Text = "Thank you for register to . " + this.RadioButtonList1.SelectedItem.Text;
        }
    }
}
