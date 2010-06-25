using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.Entities;
using StrongerOrg.Backoffice.DataLayer;



namespace StrongerOrg.OrganisationSite
{
    public partial class RescheduleRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int matchupId = int.Parse(Request.QueryString["matchupid"].ToString());
            MatchupGetResult mgr = TournamentMatchupManager.GetMatchupInfo(matchupId);
            string playerId = Request.QueryString["PlayerId"].ToString();
            Guid pId = new Guid(playerId);
            
            if (mgr.PlayerAId == pId)
            {
                this.hfPlayerName.Value = mgr.PlayerAName;
            }
            else
            {
                this.hfPlayerName.Value = mgr.PlayerBName; 
            }
            this.lblTournamentName.Text = mgr.TournamentName;
            this.lblMatchupDate.Text = mgr.Start.ToString("f");
            this.lblMatchup.Text = string.Format("{0} vs. {1}", mgr.PlayerAName, mgr.PlayerBName);

        }

        protected void lbSend_Click(object sender, EventArgs e)
        {
            string orgId = Request.QueryString["OrgId"].ToString();
            string tournamentName = this.lblTournamentName.Text;
            string matchupDate = this.lblMatchupDate.Text;
            string matchup = this.lblMatchup.Text;
            string reason = this.ddlReason.SelectedValue;
            string comment = this.txtComment.Text;
            TournamentMatchupManager.RescheduleRequestNotifyModerator(orgId, this.hfPlayerName.Value, tournamentName, matchupDate, matchup, reason, comment);
            this.divMessage.Visible = true;
        }
    }
}