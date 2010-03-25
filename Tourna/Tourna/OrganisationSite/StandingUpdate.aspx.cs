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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid orgId = new Guid(Request.QueryString["OrgId"].ToString());
                int tournamentMatchupId = int.Parse(Request.QueryString["MatchupId"].ToString());
                this.SetPageValues(orgId, tournamentMatchupId);
            }
        }

        private void SetPageValues(Guid orgId, int tournamentMatchupId)
        {
            using (TournaDataContext tdc = new TournaDataContext())
            {
                List<MatchupGetResult> matchUps = tdc.MatchupGet(tournamentMatchupId).ToList();
                if (matchUps.Count > 0 && matchUps[0].PlayerBId.HasValue)
                {
                    MatchupGetResult matchUp = matchUps.First();
                    this.btnPlayerA.Text = matchUp.PlayerAName;
                    this.btnPlayerA.CommandArgument = matchUp.PlayerAId.ToString();
                    this.btnPlayerB.Text = matchUp.PlayerBName;
                    this.btnPlayerB.CommandArgument = matchUp.PlayerBId.ToString();
                    this.dvGameDetails.DataSource = matchUps;
                    this.dvGameDetails.DataBind();
                    if (matchUp.End < DateTime.Now)
                    {
                        if (matchUp.Winner.HasValue)
                        {
                            if (matchUp.Winner.Equals(matchUp.PlayerAId))
                            {
                                this.btnPlayerA.CssClass = "playerSelected";
                                this.btnPlayerB.CssClass = "playerNotSelected";
                            }
                            else
                            {
                                this.btnPlayerB.CssClass = "playerSelected";
                                this.btnPlayerA.CssClass = "playerNotSelected";
                            }
                            this.btnPlayerB.Enabled = false;
                            this.btnPlayerA.Enabled = false;
                            string scoreUpdatedBy = (matchUp.UpdatedBy.Value.Equals(matchUp.PlayerAId)) ? matchUp.PlayerAName : matchUp.PlayerBName;
                            this.lblUpdateMessage.Text = string.Format("The score was updated by <b>{0}</b>", scoreUpdatedBy);
                        }
                    }
                    else
                    {
                        this.btnPlayerA.CssClass = "playerNotSelected";
                        this.btnPlayerB.CssClass = "playerNotSelected";
                        this.btnPlayerB.Enabled = false;
                        this.btnPlayerA.Enabled = false;
                        this.lblUpdateMessage.Text = string.Format("The score update will be open from {0:f}", matchUp.End);
                    }
                }
                else
                {
                    this.lblUpdateMessage.Text = "The Link is not valid any more, contact your moderator to find out why";
                    this.btnPlayerA.CssClass = "playerNotSelected";
                    this.btnPlayerB.CssClass = "playerNotSelected";
                    this.btnPlayerB.Enabled = false;
                    this.btnPlayerA.Enabled = false;
                }
                
            }
        }


        protected void btnPlayer_Click(object sender, EventArgs e)
        {
            Guid updatedByPlayerId = new Guid(Request.QueryString["PlayerId"].ToString());
            int tournamentMatchupId = int.Parse(Request.QueryString["MatchupId"].ToString());
            Button btn = sender as Button;
            btn.CssClass = "playerSelected";

            Guid winnerPlayerId = new Guid(btn.CommandArgument);
            using (TournaDataContext tdc = new TournaDataContext())
            {
                TournamentMatchup tm = tdc.TournamentMatchups.Single(tmu => tmu.Id == tournamentMatchupId);
                tm.Winner = winnerPlayerId;
                tm.UpdatedBy = updatedByPlayerId;
                if (tm.NextMatchId != 0)
                {
                    TournamentMatchup nextTm = tdc.TournamentMatchups.Single(tmu => tmu.TournamentId == tm.TournamentId && tmu.MatchUpId == tm.NextMatchId);
                    if (nextTm.PlayerA == Guid.Empty) // Fill the first empty spot (A or B) with the winner id from the last round
                    {
                        nextTm.PlayerA = winnerPlayerId;
                    }
                    else
                    {
                        nextTm.PlayerB = winnerPlayerId;
                    }
                    tdc.SubmitChanges();

                    if (nextTm.PlayerA != Guid.Empty && nextTm.PlayerB != Guid.Empty) // notify A & B 
                    {
                        BL.DL.MatchupsToNotifyGetResult matchupToNotify = StrongerOrg.BL.Jobs.TournamentMatchupManager.GetMatchupsToNotify(nextTm.Id).First();
                        StrongerOrg.BL.Jobs.TournamentMatchupManager.NotifyPlayers(matchupToNotify);
                        if (nextTm.NextMatchId == 0) //Final Game i sent different email template to all tournament's players.
                        {
                            StrongerOrg.BL.Jobs.TournamentMatchupManager.NotifyFinalMatchup(matchupToNotify);
                        }
                    }
                    this.lblUpdateMessage.Text = "Thank you for update the score and congratulations to the winner";
                }
                else
                {
                    tdc.Tournaments.First(t => t.Id == tm.TournamentId).IsTournamentOver = true;
                    this.lblUpdateMessage.Text = "The winner of the tournament !!!";
                    tdc.SubmitChanges();
                }
                
                
                this.btnPlayerB.Enabled = false;
                this.btnPlayerA.Enabled = false;
            }

            
        }
    }
}
