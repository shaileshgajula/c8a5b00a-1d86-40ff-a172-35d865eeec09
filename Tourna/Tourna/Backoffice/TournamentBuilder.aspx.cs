using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Tourna
{
    public partial class _Default : System.Web.UI.Page
    {
        private const string joinTournamentTemplate = @"Hello All,<br>
                                                        {0} is happy to invite you to participate in our {1}.<br>
                                                        If you care to join please click the following link<br>
                                                        <a href='../OrganisationSite/PlayerSubscription.aspx?OrgId={2}'>join to tournament</a><br>
                                                        The prizes are:<br>
                                                        Prize I:{3}<br>
                                                        Prize II:{4}<br>
                                                        Prize III:{5}<br>";
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
            int firstPrize = int.Parse(this.txtFirstPrize.Text);
            int secondPrize = int.Parse(this.txtSecondPrize.Text);
            int thirdPrize = int.Parse(this.txtThirdPrize.Text);
            DateTime startDate = this.rdpStartDate.SelectedDate.Value;

            string tournamentId = TournamentManager.BuildTournament(tournamentName, tournamentAbstract, locations, numberOfPlayersLimit, gameId, matchingAlog, timeWindowStart,
                timeWindowEnd, isOpenAllDay, firstPrize, secondPrize, thirdPrize, startDate);
            string emailTemplate = string.Format(joinTournamentTemplate, Master.OrganisationName, tournamentName,
                                                    Master.OrganisationId, this.txtFirstPrize.Text, this.txtSecondPrize.Text, this.txtThirdPrize.Text);
            TournamentManager.UpdateEmailTemplate(tournamentId, emailTemplate);
            Response.Redirect(@"~/backoffice/InvitToTournament.aspx?TournamentId=" + tournamentId);
        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.AffectedRows == 0)
            {
                this.lblGames.Visible = true;
                this.hlSetGames.Visible = true;
            }
            else
            {

            }
        }

        protected void rbGame_DataBound(object sender, EventArgs e)
        {
            this.rbGame.SelectedIndex = 0;
        }

    }
}
