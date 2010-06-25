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
            string email = this.txtEmail.Text;
            string teamId = this.ddlTeams.SelectedValue;
            
            string tournamentId = Request.QueryString["TournamentId"].ToString();
            if (string.IsNullOrEmpty(teamId))
            {
                PlayersManager.InsertPlayer(this.Master.OrgBasicInfo.Id.ToString(), name, 'P', email, string.Empty, tournamentId);
            }
            else
            {
                PlayersManager.InsertTeamPlayer(this.Master.OrgBasicInfo.Id.ToString(), name, 'P', email, tournamentId, teamId);
            }
            this.Panel1.Visible = false;
            this.phRegister.Visible = true;
            this.lblMsg.Text = string.Format("Thanks for registering. An invitaion for your first match will be sent to your email [{0}]", email);
        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.AffectedRows == 0)
            {
                this.lblTeam.Visible = false;
                this.ddlTeams.Visible = false;
            }
        }


    }
}
