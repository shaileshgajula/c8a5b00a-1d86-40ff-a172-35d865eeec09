using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace StrongerOrg.Backoffice
{
    public partial class _Default : BasePage
    {
        private const string joinTournamentTemplate = @"Hello All,<br>
                                                        {0} is happy to invite you to participate in our {1}.<br>
                                                        If you care to join please click the following link<br>
                                                        <a href='../OrganisationSite/PlayerSubscription.aspx?OrgId={2}&TournamentId={3}' Target='_blank'>Join to tournament</a><br>
                                                        The tournament is open between {4}pm - {5}pm<br> in {6}
                                                        The prizes are:<br>
                                                        Prize I:{7}<br>
                                                        Prize II:{8}<br>
                                                        Prize III:{9}<br>";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.rdpStartDate.SelectedDate = DateTime.Today;
            }

        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            string tournamentName = this.txtTournamentName.Text;
            string tournamentAbstract = this.txtAbstract.Text;
            string locations = this.txtLocations.Text;
            int numberOfPlayersLimit = Convert.ToInt32(this.rntxtLimitPlayers.Value.Value);
            int gameId = int.Parse(this.rbGame.SelectedValue);
            string matchingAlog = this.rbMatchingAlog.SelectedValue;
            int timeWindowStart = rsTimeWindow.SelectionStart;
            int timeWindowEnd = rsTimeWindow.SelectionEnd;
            bool isOpenAllDay = this.cbIsOpenAllDay.Checked;
            string firstPrize = this.txtFirstPrize.Text;
            string secondPrize = this.txtSecondPrize.Text;
            string thirdPrize = this.txtThirdPrize.Text;
            DateTime startDate = this.rdpStartDate.SelectedDate.Value;
            DateTime lastRegistrationDate = this.rdpLastRegistrationDate.SelectedDate.Value;
            string tournamentId = TournamentManager.BuildTournament(Master.OrgBasicInfo.Id, tournamentName, tournamentAbstract, locations, numberOfPlayersLimit, gameId, matchingAlog, timeWindowStart,
                timeWindowEnd, isOpenAllDay, firstPrize, secondPrize, thirdPrize, startDate, lastRegistrationDate);
            string emailTemplate = string.Format(joinTournamentTemplate, Master.OrgBasicInfo.Name, tournamentName,
                                                    Master.OrgBasicInfo.Id.ToString(),tournamentId, timeWindowStart.ToString(), timeWindowEnd.ToString(),locations,
                                                    this.txtFirstPrize.Text, this.txtSecondPrize.Text, this.txtThirdPrize.Text);
            TournamentManager.UpdateEmailTemplate(tournamentId, emailTemplate);
            Response.Redirect(@"~/backoffice/InvitToTournament.aspx?TournamentId=" + tournamentId);
        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
                this.lblGames.Visible = (e.AffectedRows == 0);
        }

        protected void rbGame_DataBound(object sender, EventArgs e)
        {
            this.rbGame.SelectedIndex = 0;
        }

    }
}
