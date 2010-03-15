using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using StrongerOrg.Backoffice.Entities.GameStandingTableAdapters;
using StrongerOrg.Backoffice.Entities;
using StrongerOrg.Backoffice.DataLayer;


namespace StrongerOrg.OrganisationSite
{
    //http://localhost:21106/OrganisationSite/StandingUpdate.aspx?OrgId=28f7a6b6-abfb-4544-b700-3363ce4bb1d9&PlayerId=843c2f2a-33e6-42c1-9b3f-30d99bf51800&MatchupId=111

    public partial class StandingUpdate : System.Web.UI.Page
    {
        Guid orgId;
        Guid playerId;
        int tournamentMatchupId;
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = new Guid(Request.QueryString["OrgId"].ToString());
            playerId = new Guid(Request.QueryString["PlayerId"].ToString());
            tournamentMatchupId = int.Parse(Request.QueryString["MatchupId"].ToString());
            if (!IsPostBack)
            {
                this.SetPageValues(orgId, playerId, tournamentMatchupId);
            }
        }

        private void SetPageValues(Guid orgId, Guid playerId, int tournamentMatchupId)
        {
            using (TournaDataContext tdc = new TournaDataContext())
            {
               MatchupGetResult matchUp = tdc.MatchupGet(tournamentMatchupId).Single();



               this.lblPlayerA.Text = matchUp.PlayerAName;
               //this.lblDescriptionA.Text = standingDataTable[
               this.lblPlayerB.Text = matchUp.PlayerBName;
               if (matchUp.ScoreA.HasValue && matchUp.ScoreB.HasValue)
               {
                   this.btnUpdate.Enabled = false;
                   //string timeStamp = (standingDataTable[0].TimeStamp != DBNull.Value) ? standingDataTable[0].TimeStamp.ToString() : "N/A";
                   this.lblMessage.Text = string.Format("The score was updated by {0} at {1}.<br> In case of dispute you can contact the tournament ",
                       matchUp.UpdatedBy.ToString(), "N/A");
                   this.hlContactModerator.Visible = true;
                   this.hlContactModerator.NavigateUrl = string.Format("ContactModerator.aspx?OrgId={0}", orgId);
                   this.rntbScoreA.Value = matchUp.ScoreA;
                   this.rntbScoreB.Value = matchUp.ScoreB;
                   this.rntbScoreA.Enabled = false;
                   this.rntbScoreB.Enabled = false;
                   this.rblPlayers.Enabled = false;
               }
               else
               {
                   this.btnUpdate.Enabled = true;
               }
               if (this.rblPlayers.Items.Count == 0)
               {
                   this.rblPlayers.Items.Add(new ListItem(matchUp.PlayerAName, matchUp.PlayerAId.ToString()));
                   this.rblPlayers.Items.Add(new ListItem(matchUp.PlayerBName, matchUp.PlayerBId.ToString()));
               }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("UpdateGameStandings", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@SchedulesId", SqlDbType.Int).Value = tournamentMatchupId;
                command.Parameters.Add("@ScoreA", SqlDbType.Int).Value = this.rntbScoreA.Value.Value;
                command.Parameters.Add("@ScoreB", SqlDbType.Int).Value = this.rntbScoreB.Value.Value;
                command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = playerId;
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime).Value = DateTime.Now;
                conn.Open();
                int rowsEffected = command.ExecuteNonQuery();
            }
            this.SetPageValues(orgId, playerId, tournamentMatchupId);
        }
    }
}
