using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.DataLayer;
using TourneyLogic.Web.UI.WebControls;
using TourneyLogic.Web.UI.WebControls.Collections;

namespace StrongerOrg.Backoffice
{
    public partial class Tournaments : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void navMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            mvTournament.ActiveViewIndex = int.Parse(this.Menu1.SelectedValue);
        }


        private void ScheduleViewActivate()
        {
            if (this.GridView1.SelectedValue == null) return;
            Guid tournamentId = new Guid(this.GridView1.DataKeys[this.GridView1.SelectedIndex].Values["Id"].ToString());
            string tournamentName = this.GridView1.DataKeys[this.GridView1.SelectedIndex].Values["TournamentName"].ToString();
            this.lblTournamentName.Text = tournamentName;
            //for now..straight database kick
            IEnumerable<DateTime> dates;
            using (TournaDataContext db = new TournaDataContext())
            {
                var dateInfo = db.Schedules.Where(y => y.TournamentId == tournamentId).
                     Select(y =>
                         new
                         {
                             Id = y.Id,
                             StartDate = y.Start,
                             PlayerAId = y.PlayerA,
                             PlayerA = db.Players.Where(p => p.Id == y.PlayerA).Select(n => n.Name).First(),
                             PlayerBId = y.PlayerB,
                             PlayerB = db.Players.Where(p => p.Id == y.PlayerB).Select(n => n.Name).First(),
                             ScoreA = y.ScoreA,
                             ScoreB = y.ScoreB,
                             WinnerId = (y.ScoreA.HasValue && y.ScoreB.HasValue) ?
                                    (y.ScoreA > y.ScoreB) ? 0 : 1 : -1,
                                    MatchupId = y.MatchUpId

                             //Score = (y.ScoreA.HasValue && y.ScoreB.HasValue) ? string.Format("{0}-{1}", y.ScoreA.Value.ToString(), y.ScoreB.Value.ToString()) : string.Empty
                         })
                     .ToList();

                //schedDatesGrid.DataSource = dateInfo.Select((x, i) =>
                //    new
                //    {
                //        Id = x.Id,
                //        StartDate = x.StartDate,
                //        GameName = String.Format("Game {0} - {1}:{2}", i + 1, x.PlayerA, x.PlayerB),
                //        Score = string.Format("{0}-{1}", x.ScoreA, x.ScoreB)
                //    }
                //    );
                //schedDatesGrid.DataBind();
                Calendar cal = this.mvTournament.Views[0].FindControl("calSchedules") as Calendar;
                if (dateInfo.Count > 0)
                {
                    cal.Visible = true;
                    dates = dateInfo.Select(x => x.StartDate);
                    cal.VisibleDate = dates.ElementAt(0);
                    cal.SelectedDates.Clear();
                    foreach (DateTime date in dates)
                    {
                        cal.SelectedDates.Add(date);
                    }
                    //this.Bracket1.Competitors.Clear();
                    //this.Bracket1.Results.Clear();
                    //BracketControlCollection<BracketCompetitor> bcc = new BracketControlCollection<BracketCompetitor>();
                    //BracketCollection<BracketMatchupResult> bcBm = new BracketCollection<BracketMatchupResult>();
                    //int i=1;
                    //foreach (var item in dateInfo)
                    //{
                        
                    //    if (item.WinnerId != -1)
                    //    {
                    //        bcBm.Add(new BracketMatchupResult() { MatchupID = item.MatchupId, WinningCompetitorId = "BracketCompetitor" + (i + item.WinnerId).ToString() });
                    //    }
                    //    bcc.Add(new BracketCompetitor() {  CompetitorId = item.PlayerAId.ToString(), CompetitorName = item.PlayerA});
                    //    bcc.Add(new BracketCompetitor() { CompetitorId = item.PlayerBId.ToString(), CompetitorName = item.PlayerB});
                    //    i += 2;
                        
                    //}
                    //this.Bracket1.Results = bcBm;
                   // this.Bracket1.Competitors = bcc;

                   

                    //this.Bracket1.Competitors.Add(new BracketCompetitor() { CompetitorName = "pini", CompetitorId = "5" });
                    //this.brcStandings.DataSource = dateInfo.Select((x) => new
                    //{
                    //    PlayerA = x.PlayerA,
                    //    PlayerB = x.PlayerB
                    //});
                    //this.brcStandings.DataBind();



                }
                else
                {
                    cal.Visible = false;
                    string noMatchupFoundMsg = string.Format(@"No match ups have been created yet. The auto match up process will start on 
                        {0} .If you wish to run the match up with the current registred players  
                        ", this.GridView1.Rows[this.GridView1.SelectedIndex].Cells[2].Text);
                    this.lblCalendarMatchupResult.Visible = true;
                    this.lblRememberEdit.Visible = true;
                    this.lbCreateMatchUps.Visible = true;
                    this.lblCalendarMatchupResult.Text = noMatchupFoundMsg;
                }
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ScheduleViewActivate();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            this.GridView1.SelectedIndex = 0;
            this.ScheduleViewActivate();
        }

        protected void lbEditPicksMode_Click(object sender, EventArgs e)
        {
            this.lbEditPicksMode.Text = "Save and Colse"; 
            //this.Bracket1.DisplayMode = Bracket.BracketDisplayMode.EditPicksMode;
        }

        protected void standingsSqlDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void lbClearAllScheduledGames_Click(object sender, EventArgs e)
        {
            using (TournaDataContext db = new TournaDataContext())
            {
                Guid tournamentId = new Guid(this.GridView1.DataKeys[this.GridView1.SelectedIndex].Values["Id"].ToString());
                db.ScheduleTournamentDelete(tournamentId);
                this.lblClearAllScheduledGames.Visible = true;
                this.mvTournament.DataBind();
            }
        }
        public string BuildNavigateUrl(object id, object playerId)
        {
            string orgId = Master.OrgBasicInfo.Id.ToString();
            return string.Format("~/OrganisationSite/StandingUpdate.aspx?OrgId={0}&PlayerId={1}&ScheduleId={2}", orgId, playerId.ToString(), id.ToString());
        }

        protected void lbScheduleRegisteredPlayer_Click(object sender, EventArgs e)
        {
            Guid tournamentId = new Guid(this.GridView1.DataKeys[this.GridView1.SelectedIndex].Values["Id"].ToString());
            List<StrongerOrg.Backoffice.Entities.TournamentAlgorithm.Competitor> competitorsList = PlayersManager.GetPlayers(this.Master.OrgBasicInfo.Id, tournamentId);
            List<StrongerOrg.Backoffice.Entities.TournamentAlgorithm.Matchup> mathcupList = 
                StrongerOrg.Backoffice.Entities.TournamentAlgorithm.Tournament.TournamentFactory(TournamentTypes.SingleElimination).Execute(competitorsList);

            this.mvTournament.ActiveViewIndex = 2;
            this.Menu1.Items[1].Selected = true;
            this.gvStandingsPreview.DataSource = mathcupList;
            this.gvStandingsPreview.DataBind();
        }

        protected void gvStandingsPreview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int round = int.Parse(e.Row.Cells[1].Text);
                if ((round % 2) == 0)
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0FC");
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                }
            }
        }

        
        //protected void schedDatesGrid_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    schedDatesGrid.EditIndex = e.NewEditIndex;
        //    //binddata();
        //}

        //protected void schedDatesGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    schedDatesGrid.EditIndex = -1;
        //}
    }
}
