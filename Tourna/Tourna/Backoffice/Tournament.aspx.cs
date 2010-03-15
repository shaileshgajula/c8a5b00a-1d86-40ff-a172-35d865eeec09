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

namespace StrongerOrg.Backoffice
{
    public partial class Tournament : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ScheduleViewActivate();
            }
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

       

       

        protected void btnUpdateStartDate_Click(object sender, EventArgs e)
        {
            int matchUpId = int.Parse(ViewState["ActiveMatchUpId"].ToString());
            DateTime newStartDate = DateTime.Parse(string.Format("{0} {1}:{2}", this.tbStartDate.Text, this.ddlHours.SelectedValue, this.ddlMinutes.SelectedValue));
            TournamentMatchupManager.UpdateStartDate(this.TournamentId, matchUpId, newStartDate);
            this.ScheduleViewActivate();
        }

        protected void lbStartDate_Command(object sender, CommandEventArgs e)
        {
            string[] commandParameters = e.CommandArgument.ToString().Split('*');
            DateTime startDate = DateTime.Parse(commandParameters[0]);
            ViewState["ActiveMatchUpId"] = commandParameters[1];
            this.tbStartDate.Text = startDate.ToShortDateString();
            this.ddlHours.SelectedValue = startDate.Hour.ToString();
            this.ddlMinutes.SelectedValue = (startDate.Minute == 0) ? "00" : startDate.Minute.ToString();
            this.ModalPopupExtender1.Show();
        }
    }
}