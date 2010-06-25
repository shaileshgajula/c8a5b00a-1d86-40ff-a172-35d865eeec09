using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace StrongerOrg.Backoffice.UserControls
{
    public partial class TournamentDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            int rowIndex = DetailsView1.DataItemIndex;
            TextBox tbAbstract = DetailsView1.Rows[rowIndex].FindControl("txtAbstract") as TextBox;
            TextBox tbLastRegistrationDate = DetailsView1.Rows[rowIndex].FindControl("txtLastRegistrationDate") as TextBox;
            TextBox tbStartDate = DetailsView1.Rows[rowIndex].FindControl("txtStartDate") as TextBox;
            TextBox tbTimeWindowStart = DetailsView1.Rows[rowIndex].FindControl("txtTimeWindowStart") as TextBox;
            TextBox tbTimeWindowEnd = DetailsView1.Rows[rowIndex].FindControl("txtTimeWindowEnd") as TextBox;
            e.NewValues["Abstract"] = tbAbstract.Text;
            e.NewValues["LastRegistrationDate"] = tbLastRegistrationDate.Text;
            e.NewValues["StartDate"] = tbStartDate.Text;
            TimeSpan tsStart = TimeSpan.Parse(tbTimeWindowStart.Text);
            DateTime dtStart = new DateTime(2000, 1, 1, tsStart.Hours, tsStart.Minutes, 0);
            TimeSpan tsEnd = TimeSpan.Parse(tbTimeWindowEnd.Text);
            DateTime dtEnd = new DateTime(2000, 1, 1, tsEnd.Hours, tsEnd.Minutes, 0);
            e.NewValues["TimeWindowStart"] = dtStart;
            e.NewValues["TimeWindowEnd"] = dtEnd;
        }
        protected string CompetitorType(object competitorType)
        {
            char c = Convert.ToChar(competitorType);
            if (c == 'P')
                return "Players";
            else
            {
                LinkButton hlEditTeams = this.DetailsView1.FindControl("lbEditTeams") as LinkButton;
                if (hlEditTeams != null) hlEditTeams.Visible = true;
                return "";
            }
        }
        protected void btnAddTeam_Click(object sender, EventArgs e)
        {
            string teamName = this.txtTeamName.Text;
            string tournamentId = Request.QueryString["TournamentId"].ToString();
            PlayersManager.InsertTeam(((StrongerOrg.Backoffice.BackOffice)this.Page.Master).OrgBasicInfo.Id.ToString(), teamName, 'T', tournamentId);

            this.cblTeams.DataBind();
            this.ModalPopupExtender2.Show();
        }
        protected void lbEditTeams_Click(object sender, EventArgs e)
        {
            this.ModalPopupExtender2.Show();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idsToDelete = string.Empty;
            foreach (ListItem item in this.cblTeams.Items)
            {
                if (item.Selected)
                {
                    idsToDelete += string.Format("'{0}',", item.Value);
                }
            }
            if (!string.IsNullOrEmpty(idsToDelete))
            {
                idsToDelete = idsToDelete.Substring(0, idsToDelete.Length - 1);
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(
                        string.Format("Delete from players where id in ({0})", idsToDelete), conn);
                    command.CommandType = CommandType.Text;
                    conn.Open();
                    command.ExecuteNonQuery();
                    this.cblTeams.DataBind();
                }
            }
            this.ModalPopupExtender2.Show();
        }

        protected string CompetitorsLink(object tournamentId, string tournamentName, object competitorType)
        {
            char c = Convert.ToChar(competitorType);
            if (c == 'P')
                return string.Format("OrganisationPlayers.aspx?TournamentId={0}&TournamentName={1}", tournamentId, tournamentName);
            else
            {
                return string.Format("TournamentTeams.aspx?TournamentId={0}&TournamentName={1}", tournamentId, tournamentName);
            }
        }
    }
}