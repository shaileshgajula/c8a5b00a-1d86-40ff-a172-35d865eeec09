using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.DataLayer;

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
                             PlayerA = db.Players.Where(p => p.Id == y.PlayerA).Select(n => n.Name).First(),
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

                    this.brcStandings.DataSource = dateInfo.Select((x) => new
                    {
                        PlayerA = x.PlayerA,
                        PlayerB = x.PlayerB
                    });
                    this.brcStandings.DataBind();

                    
                    cal.VisibleDate = dates.ElementAt(0);
                    cal.SelectedDates.Clear();
                    foreach (DateTime date in dates)
                    {
                        cal.SelectedDates.Add(date);
                    }
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
