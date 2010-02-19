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
        protected void Page_Load(object sender, EventArgs e)
        {
            object tournamentIdObject = Request.QueryString["TournamentId"];
            if (tournamentIdObject != null && !string.IsNullOrEmpty(tournamentIdObject.ToString()))
            {
                string tournamentId = tournamentIdObject.ToString();
                try
                {
                    Guid guid = new Guid(tournamentId);
                    bool isTournamentOpen = TournamentManager.IsTournamentOpen(this.Master.OrgBasicInfo.Id, guid);
                    if (!isTournamentOpen)
                    {
                        this.Panel1.Enabled = false;
                        this.lblMsg.Text = string.Format("The Registrantion to the tournament is closed. Contact your <a href='ContactModerator.aspx?OrgId={0}'>moderator</a>  for any issue you have.",
                            this.Master.OrgBasicInfo.Id);
                        this.lblMsg.CssClass = "AlertText";
                    }
                }
                catch (Exception)
                {
                    this.InvalidRequest();
                }
            }
            else
            {
                this.InvalidRequest();
            }
        }

        private void InvalidRequest()
        {
            this.Panel1.Visible = false;
            this.lblMsg.Text = "Invalid request";
            this.lblMsg.CssClass = "AlertText";
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
            string tournamentId = Request.QueryString["TournamentId"].ToString();
            PlayersManager.InsertPlayer(this.Master.OrgBasicInfo.Id.ToString(), name, string.Empty, email, string.Empty, tournamentId);
            this.Panel1.Visible = false;
            this.lblMsg.Text = string.Format("Thank you for register. An invitaion for your first match will be sent to your email[{0}]", email);
        }


    }
}
