using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using StrongerOrg.BackOffice.PairsAlgorithm;
using StrongerOrg.BackOffice.Scheduler;

namespace StrongerOrg.Backoffice
{
    public partial class ControlPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void CreatePlayers(Guid organisationId, Guid tournamentId, int numberOfPlayersToCreate, string orgName)
        {
            DataTable dt = CreateDataTable();
            int alfaBeitCount = 26;
            int alfaInt = 65;
            int g = 0;
            for (int i = 0; i < numberOfPlayersToCreate; i++)
            {
                int r = i % alfaBeitCount;
                if (r == 0)
                {
                    g++;
                }
                char c = (char)(alfaInt + r);
                string name = string.Format("{0}{1}", c.ToString(), g.ToString());
                dt.Rows.Add(organisationId, name, string.Format("{0}@{1}.com", name, orgName), tournamentId);
                //Console.WriteLine(name);
            }
            UpdateDB(dt);
        }

        private void UpdateDB(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand insertCmd = new SqlCommand("PlayerInsert", conn);
                insertCmd.CommandType = CommandType.StoredProcedure;
                insertCmd.Parameters.Add("@organisationId", SqlDbType.UniqueIdentifier).SourceColumn = "organisationId";
                insertCmd.Parameters.Add("@name", SqlDbType.VarChar).SourceColumn = "name";
                insertCmd.Parameters.Add("@email", SqlDbType.VarChar).SourceColumn = "email";
                insertCmd.Parameters.Add("@TournamentId", SqlDbType.UniqueIdentifier).SourceColumn = "TournamentId";
                conn.Open();
                insertCmd.UpdatedRowSource = UpdateRowSource.None;
                adapter.InsertCommand = insertCmd;
                adapter.UpdateBatchSize = 10;
                adapter.Update(dt);
                conn.Close();
            }
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable("aa");
            dt.Columns.Add("OrganisationId", typeof(Guid));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("TournamentId", typeof(Guid));
            return dt;
            //dt.Rows.Add(Guid.NewGuid(), "pini", "pini@g.com");


        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string orgId = this.ddlOrganisations.SelectedValue;
            string tournamentId = this.ddlTournament.SelectedValue;
            int numberOfPlayersToCreate = int.Parse(this.TextBox3.Text);
            string orgName = this.ddlOrganisations.SelectedItem.Text;
            this.CreatePlayers(new Guid(orgId), new Guid(tournamentId), numberOfPlayersToCreate, orgName);
            this.lblMsg.Text = string.Format("{0} players has been created for {1} tournament", this.TextBox3.Text, this.ddlTournament.SelectedItem.Text);
        }

        protected void lblDeletePlayers_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand delCmd = new SqlCommand("PlayersTournamentDelete", conn);
                delCmd.CommandType = CommandType.StoredProcedure;
                delCmd.Parameters.Add("@TournamentId", SqlDbType.VarChar).Value = this.ddlTournament.SelectedValue;
                //delCmd.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                conn.Open();
                int rowsEffected = delCmd.ExecuteNonQuery();
                this.lblMsg.Text = string.Format("{0} rows effected", rowsEffected.ToString());
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            List<PlayersEntity> playersPairs = PairsAlgo.BuildPairs(new Guid(this.ddlTournament.SelectedValue));
            this.gvPairs.DataSource = playersPairs;
            this.gvPairs.DataBind();
        }

        protected void lbScheduleGames_Click(object sender, EventArgs e)
        {
            Guid tournamentId = new Guid(this.ddlTournament.SelectedValue);
            SchedulerAlgo.SchedulerGames(tournamentId, PairsAlgo.BuildPairs(tournamentId));
        }
    }
}
