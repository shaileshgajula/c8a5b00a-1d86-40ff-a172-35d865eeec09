using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace StrongerOrg.Backoffice
{
    public partial class _Default : BasePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            
            string tournamentName = this.txtTournamentName.Text;
            string tournamentAbstract = this.txtAbstract.Text;
            string locations = this.txtLocations.Text;
            int numberOfPlayersLimit = Convert.ToInt32(this.txtLimitNumberOfPlayers.Text);
            int gameId = int.Parse(this.rbGame.SelectedValue);
            char tournamentMode = char.Parse(this.rbTournamentMode.SelectedValue);
            string matchingAlog = this.rbMatchingAlog.SelectedValue;
            int gamesPerDay = int.Parse(Request.Form["amount"].ToString());
            string[] timeFrames = Request.Form["timeFrame"].ToString().Split('-');

            TimeSpan timeWindowStart = TimeSpan.Parse(timeFrames[0]);
            TimeSpan timeWindowEnd = TimeSpan.Parse(timeFrames[1]);
                
           
            bool isOpenAllDay = this.cbIsOpenAllDay.Checked;
            string firstPrize = this.txtFirstPrize.Text;
            string secondPrize = this.txtSecondPrize.Text;
            string thirdPrize = this.txtThirdPrize.Text;
            DateTime startDate = DateTime.Parse(this.txtStartDate.Text);
            DateTime lastRegistrationDate = DateTime.Parse(this.txtLastRegistrationDate.Text);
            string tournamentId = TournamentManager.BuildTournament(Master.OrgBasicInfo.Id, tournamentName, tournamentAbstract, locations, numberOfPlayersLimit, gameId,tournamentMode, matchingAlog,gamesPerDay, timeWindowStart,
                timeWindowEnd, isOpenAllDay, firstPrize, secondPrize, thirdPrize, startDate, lastRegistrationDate);
            //string emailTemplate = string.Format(joinTournamentTemplate, Master.OrgBasicInfo.Name, tournamentName,
            //                                        Master.OrgBasicInfo.Id.ToString(),tournamentId, timeWindowStart.ToString(), timeWindowEnd.ToString(),locations,
            //                                        this.txtFirstPrize.Text, this.txtSecondPrize.Text, this.txtThirdPrize.Text);
            //TournamentManager.UpdateEmailTemplate(tournamentId, emailTemplate);
            Response.Redirect(@"~/backoffice/InvitToTournament.aspx?TournamentId=" + tournamentId);
        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.AffectedRows == 0)
            {
                this.lblGames.Visible = true;
                this.Wizard1.Enabled = false;
            }
        }

        protected void rbGame_DataBound(object sender, EventArgs e)
        {
            this.rbGame.SelectedIndex = 0;
        }
       
    }
}
