using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.DataLayer;
using StrongerOrg.Backoffice.TournamentAlgorithm;

namespace StrongerOrg.Backoffice.UserControls
{
    public partial class CalendarDisplay : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Bind();
        }

        public void Bind()
        {
            this.TournamentMatchupsList.ForEach(sd => { this.calSchedules.SelectedDates.Add(sd.Start); });
        }
        protected void calSchedules_SelectionChanged(object sender, EventArgs e)
        {
            this.Label1.Text = string.Format("Match ups on {0}", this.calSchedules.SelectedDate.ToString("D"));
            this.gvDayMatchups.DataSource = this.TournamentMatchupsList.Where(mu => mu.Start.Date == this.calSchedules.SelectedDate.Date).Select(m => new { m.MatchupId, m.Round, m.PlayerA, m.PlayerB, m.NextMatchId, m.Start, m.WinnerName });
            this.gvDayMatchups.DataBind();
            this.ModalPopupExtender1.Show();
            this.Bind();
        }
        public List<Matchup> TournamentMatchupsList
        {
            get
            {
                object selectedDates = ViewState["MatchupList"];
                if (selectedDates != null)
                {
                    return selectedDates as List<Matchup>;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                ViewState["MatchupList"] = value;
                
            }
        }
    }
}