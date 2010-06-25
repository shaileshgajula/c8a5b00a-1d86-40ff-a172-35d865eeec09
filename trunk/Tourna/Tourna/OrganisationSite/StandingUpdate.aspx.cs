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
    //http://localhost:53699/OrganisationSite/StandingUpdate.aspx?OrgId=57baf8c4-3524-4273-a12b-c6cea946e920&PlayerId=1929bd8e-1da8-48be-a50a-2e15d7248114&MatchupId=83&fdd

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
            using (TournaDataContext tdc = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ToString()))
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

                    //if (matchUp.End < DateTime.Now)
                    {
                        if (matchUp.Winner.HasValue)
                        {
                            this.SelectButton(matchUp.Winner.Equals(matchUp.PlayerAId) ? this.btnPlayerA : this.btnPlayerB);

                            this.btnPlayerB.Enabled = false;
                            this.btnPlayerA.Enabled = false;
                            this.lblClickOnWinner.Visible = false;
                            string scoreUpdatedBy = string.Empty;
                            if (matchUp.UpdatedBy != null)
                            {
                                scoreUpdatedBy = (matchUp.UpdatedBy.Value.Equals(matchUp.PlayerAId)) ? matchUp.PlayerAName : matchUp.PlayerBName;
                            }
                            else
                            {
                                scoreUpdatedBy = "Moderator";
                            }

                            this.lblUpdateMessage.Text = string.Format("The score was updated by <i>{0}</i>. In case of discrepancy contact moderator", scoreUpdatedBy);
                        }
                        else
                        {
                            this.btnPlayerB.Enabled = true;
                            this.btnPlayerA.Enabled = true;
                        }
                    }
                    //else
                    //{

                    //    this.btnPlayerB.Enabled = true;
                    //    this.btnPlayerA.Enabled = false;

                    //    this.lblUpdateMessage.Text = string.Format("The score update will be open from {0:f}", matchUp.End);
                    //}
                }
                else
                {

                    this.lblUpdateMessage.Text = "The Link is not valid any more, contact your moderator to find out why";
                    this.btnPlayerB.Enabled = false;
                    this.btnPlayerA.Enabled = false;
                }

            }
        }

        private void SelectButton(Button btn)
        {
            btn.Style.Add(HtmlTextWriterStyle.BorderColor, "#FFD729");
            btn.Style.Add(HtmlTextWriterStyle.BorderWidth, "3px");
            btn.Text += " ( Winner )";
        }


        protected void btnPlayer_Click(object sender, EventArgs e)
        {
            Guid updatedByPlayerId = new Guid(Request.QueryString["PlayerId"].ToString());
            int tournamentMatchupId = int.Parse(Request.QueryString["MatchupId"].ToString());
            Button btn = sender as Button;
            //btn.CssClass = "playerSelected";

            Guid winnerPlayerId = new Guid(btn.CommandArgument);
            using (TournaDataContext tdc = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ToString()))
            {
                TournamentMatchup tm = tdc.TournamentMatchups.Single(tmu => tmu.Id == tournamentMatchupId);
                tm.Winner = winnerPlayerId;
                if (updatedByPlayerId != Guid.Empty)
                    tm.UpdatedBy = updatedByPlayerId;
                tdc.SubmitChanges();
                if (tm.NextMatchId != 0)
                {
                    TournamentMatchup nextTm = tdc.TournamentMatchups.Single(tmu => tmu.TournamentId == tm.TournamentId && tmu.MatchUpId == tm.NextMatchId);
                    TournamentMatchupManager.SetNextMatchup(tm.TournamentId, tm.MatchUpId, tm.NextMatchId, winnerPlayerId);

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
                this.SelectButton(btn);
            }


        }


    }
}
