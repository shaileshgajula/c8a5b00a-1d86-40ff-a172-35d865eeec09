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
            mvTournament.ActiveViewIndex = int.Parse(navMenu.SelectedValue);
        }


        private void ScheduleViewActivate()
        {
            if (this.GridView1.SelectedValue == null) return;
            Guid tournamentId = new Guid(this.GridView1.SelectedValue.ToString());

            //for now..straight database kick
            IEnumerable<DateTime> dates;
            using (TournaDataContext db = new TournaDataContext())
            {
                var dateInfo = db.Schedules.Where(y => y.TournamentId == tournamentId).
                     Select(y =>
                         new
                         {
                             StartDate = y.Start,
                             PlayerAId = y.PlayerA,
                             PlayerA = db.Players.Where(p => p.Id == y.PlayerA).Select(n => n.Name).First(),
                             PlayerBId = y.PlayerB,
                             PlayerB = db.Players.Where(p => p.Id == y.PlayerB).Select(n => n.Name).First(),
                             ScoreA = y.ScoreA,
                             ScoreB = y.ScoreB
                         })
                     .ToList();

                schedDatesGrid.DataSource = dateInfo.Select((x, i) =>
                    new
                    {
                        StartDate = x.StartDate,
                        GameName = String.Format("Game {0} - {1}:{2}", i + 1, x.PlayerA, x.PlayerB),
                        Score = string.Format("{0}-{1}", x.ScoreA, x.ScoreB)
                    }
                    );
                schedDatesGrid.DataBind();
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
                    this.Bracket1.Competitors.Clear();
                    this.Bracket1.Results.Clear();
                    BracketControlCollection<BracketCompetitor> bcc = new BracketControlCollection<BracketCompetitor>();
                    foreach (var item in dateInfo)
                    {
                        bcc.Add(new BracketCompetitor() { CompetitorId = item.PlayerAId.ToString(), CompetitorName = item.PlayerA });
                        bcc.Add(new BracketCompetitor() { CompetitorId = item.PlayerBId.ToString(), CompetitorName = item.PlayerB });
                    }
                    this.Bracket1.Competitors = bcc;
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
                }
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

    }
}
