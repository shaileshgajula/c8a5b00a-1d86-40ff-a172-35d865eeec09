using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.DataLayer;

using StrongerOrg.Backoffice.Entities;

using StrongerOrg.BackOffice.Scheduler;
using StrongerOrg.Backoffice.TournamentAlgorithm;
using TourneyLogic.Web.UI.WebControls.Collections;
using TourneyLogic.Web.UI.WebControls;
using System.Drawing;

namespace StrongerOrg.Backoffice
{
    public partial class Tournament : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.UserRole != "Administrator" && this.Menu1.Items.Count > 5 && this.Menu1.Items.Contains(this.Menu1.Items[5]))
            {
                this.Menu1.Items.Remove(this.Menu1.Items[5]);
            }
            this.FakeUsers1.OnDataChange += () => { this.ScheduleViewActivate(); };
            if (!IsPostBack)
            {

                this.ScheduleViewActivate();
            }
            this.Feedbacks1.OrganisationId = this.TournamentId.ToString();
        }
        private Guid TournamentId
        {
            get { return new Guid(Request.QueryString["TournamentId"].ToString()); }
        }
        protected void navMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            mvTournament.ActiveViewIndex = int.Parse(this.Menu1.SelectedValue);
        }


        private void ScheduleViewActivate()
        {

            IEnumerable<DateTime> dates;
            List<Matchup> matchups = TournamentMatchupManager.GetTournamentMatchups(this.TournamentId);
            this.lblTournamentName.Text = TournamentManager.GetTournamentName(this.TournamentId);
            this.gvStandingsPreview.DataSource = matchups;
            this.gvStandingsPreview.DataBind();
            if (matchups.Count > 0)
            {


                dates = matchups.Select(x => x.Start);
                this.calSchedules.VisibleDate = dates.ElementAt(0);
                this.calSchedules.SelectedDates.Clear();
                foreach (DateTime date in dates)
                {
                    this.calSchedules.SelectedDates.Add(date);
                }


                this.BracketTournamentMatchups.Competitors.Clear();
                this.BracketTournamentMatchups.Results.Clear();
                BracketControlCollection<BracketCompetitor> bcc = new BracketControlCollection<BracketCompetitor>();
                BracketCollection<BracketMatchupResult> bcBm = new BracketCollection<BracketMatchupResult>();
                int i = 1;
                //var playoffFirstRoundCompetitors = (from m in matchups
                //        group m by m.Round into g
                //        where g.Count() == 8
                //        select new { MatchupRound = g}).FirstOrDefault();
                foreach (Matchup matchup in matchups)
                {

                    //    if (item.WinnerId != -1)
                    //    {
                    //        bcBm.Add(new BracketMatchupResult() { MatchupID = item.MatchupId, WinningCompetitorId = "BracketCompetitor" + (i + item.WinnerId).ToString() });
                    //    }
                    if (matchup.PlayerAId != Guid.Empty)
                    {
                        bcc.Add(new BracketCompetitor() { CompetitorId = matchup.PlayerAId.ToString(), CompetitorName = matchup.PlayerA });
                        bcc.Add(new BracketCompetitor() { CompetitorId = matchup.PlayerBId.ToString(), CompetitorName = matchup.PlayerB });
                    }
                    //    i += 2;

                }
                //this.Bracket1.Results = bcBm;
                this.BracketTournamentMatchups.Competitors = bcc;

                //this.Bracket1.Competitors.Add(new BracketCompetitor() { CompetitorName = "pini", CompetitorId = "5" });
                //this.brcStandings.DataSource = dateInfo.Select((x) => new
                //{
                //    PlayerA = x.PlayerA,
                //    PlayerB = x.PlayerB
                //});
                //this.brcStandings.DataBind();



                // }

            }
        }

        public string ScoreDisplay(object scoreA, object scoreB)
        {
            if (string.IsNullOrEmpty(scoreA.ToString()) && string.IsNullOrEmpty(scoreB.ToString()))
            {
                return "N/A";
            }
            else
            {
                return string.Format("{0}:{1}", scoreA, scoreB);
            }
        }




        protected void lbEditPicksMode_Click(object sender, EventArgs e)
        {
            this.lbEditPicksMode.Text = "Save and Colse";
            //this.Bracket1.DisplayMode = Bracket.BracketDisplayMode.EditPicksMode;
        }

        protected void standingsSqlDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }


        public string BuildNavigateUrl(object id, object playerId)
        {
            string orgId = Master.OrgBasicInfo.Id.ToString();
            return string.Format("~/OrganisationSite/StandingUpdate.aspx?OrgId={0}&PlayerId={1}&ScheduleId={2}", orgId, playerId.ToString(), id.ToString());
        }


        List<string> roudPlayers = new List<string>();
        int currentRound;
        protected void gvStandingsPreview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int round = int.Parse(e.Row.Cells[1].Text);
                if (currentRound != round)
                { roudPlayers.Clear(); }
                string playerAName = e.Row.Cells[2].Text;
                string playerBName = e.Row.Cells[3].Text;
                if (playerAName != "--" && roudPlayers.Contains(playerAName))
                {
                    e.Row.Cells[2].ForeColor = Color.Red;
                }
                if (playerAName != "--" && roudPlayers.Contains(playerBName))
                {
                    e.Row.Cells[3].ForeColor = Color.Red;
                }
                if ((round % 2) == 0)
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0FC");
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                }
                roudPlayers.Add(playerAName);
                roudPlayers.Add(playerBName);
                currentRound = round;
            }
        }





        protected void btnUpdateStartDate_Click(object sender, EventArgs e)
        {
            int matchUpId = int.Parse(ViewState["ActiveMatchUpId"].ToString());
            DateTime newStartDate = DateTime.Parse(string.Format("{0} {1}:{2}", this.tbStartDate.Text, this.ddlHours.SelectedValue, this.ddlMinutes.SelectedValue));
            Guid playerAId = new Guid(this.ddlPlayerA.SelectedValue);
            Guid playerBId = new Guid(this.ddlPlayerB.SelectedValue);
            Guid winnerId = new Guid(this.rblWinner.SelectedValue);
            int nextMatchupId = int.Parse(this.hfNextMatchupId.Value);
            TournamentMatchupManager.UpdateMatchup(this.TournamentId, matchUpId, newStartDate, playerAId, playerBId, winnerId);
            TournamentMatchupManager.SetNextMatchup(this.TournamentId, nextMatchupId, winnerId);
            this.ScheduleViewActivate();
        }

        protected void lbStartDate_Command(object sender, CommandEventArgs e)
        {
            string[] commandParameters = e.CommandArgument.ToString().Split('*');
            DateTime startDate = DateTime.Parse(commandParameters[0]);
            ViewState["ActiveMatchUpId"] = commandParameters[1];
            string playerAId = commandParameters[2];
            string playerBId = commandParameters[3];
            string winner = commandParameters[4];
            string nextMatchupId = commandParameters[5];
            this.tbStartDate.Text = startDate.ToShortDateString();
            this.ddlHours.SelectedValue = startDate.Hour.ToString();
            this.ddlMinutes.SelectedValue = startDate.Minute.ToString();
            this.ddlPlayerA.SelectedValue = playerAId;
            this.ddlPlayerB.SelectedValue = playerBId;
            this.rblWinner.Items.Clear();
            this.rblWinner.Items.Add(new ListItem("Player A", playerAId));
            this.rblWinner.Items.Add(new ListItem("Player B", playerBId));
            this.rblWinner.Items.Add(new ListItem("N/A", Guid.Empty.ToString()));
            this.rblWinner.SelectedValue = string.IsNullOrEmpty(winner) ? Guid.Empty.ToString() : winner;
            this.hfNextMatchupId.Value = nextMatchupId;
            this.ModalPopupExtender1.Show();
        }
        protected void lbResetScore_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            TournamentMatchupManager.ResetScore(id);
            this.ScheduleViewActivate();
            this.mvTournament.ActiveViewIndex = 1;
        }
    }
}