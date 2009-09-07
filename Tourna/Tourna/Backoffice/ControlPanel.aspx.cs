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
using StrongerOrg.Backoffice.DataLayer;

namespace StrongerOrg.Backoffice
{
    public partial class ControlPanel : BasePage
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
            /*string orgId = this.ddlOrganisations.SelectedValue;
            string tournamentId = this.ddlTournament.SelectedValue;
            int numberOfPlayersToCreate = int.Parse(this.TextBox3.Text);
            string orgName = this.ddlOrganisations.SelectedItem.Text;
            this.CreatePlayers(new Guid(orgId), new Guid(tournamentId), numberOfPlayersToCreate, orgName);
            this.lblMsg.Text = string.Format("{0} players has been created for {1} tournament", this.TextBox3.Text, this.ddlTournament.SelectedItem.Text);
             */
        }

        protected void lblDeletePlayers_Click(object sender, EventArgs e)
        {
            /*using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand delCmd = new SqlCommand("PlayersTournamentDelete", conn);
                delCmd.CommandType = CommandType.StoredProcedure;
                delCmd.Parameters.Add("@TournamentId", SqlDbType.VarChar).Value = this.ddlTournament.SelectedValue;
                //delCmd.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                conn.Open();
                int rowsEffected = delCmd.ExecuteNonQuery();
                this.lblMsg.Text = string.Format("{0} rows effected", rowsEffected.ToString());
            }
             */
        }


        protected void TournamentSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            if (e.WhereParameters["Id"] == null)
                return;

            TournaDataContext db = new TournaDataContext();
            
            var products = db.Tournaments.Where(t => t.OrganisationId == (Guid)e.WhereParameters["Id"])
                           .Select( r => new { 
                                Id = r.Id, 
                                OrganisationId = r.OrganisationId, 
                                TournamentName = r.TournamentName,
                                Count = db.Players2Tournaments.Where( x => x.TournamentId == r.Id).Count()
                           });

            e.Result = products;
            
        }


        protected void navMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            this.PageView.ActiveViewIndex = int.Parse(e.Item.Value);
        }

        protected void PlayersView_Activate(object sender, EventArgs e)
        {
            //get the players for the selected tournament
            //get the players
            using (TournaDataContext db = new TournaDataContext())
            {
                var players = from p2t in db.Players2Tournaments
                              join p in db.Players on p2t.PlayerId equals p.Id
                              where p2t.TournamentId == (Guid)this.TouranmentGrid.SelectedValue
                              select new
                                        {
                                            Name = p.Name,
                                            Department = p.Department,
                                            Email = p.Email ?? "Not Provided"
                                        };

                this.playersGrid.DataSource = players.ToList();
                this.playersGrid.DataBind();
            }
        }

        protected void PairView_Activate(object sender, EventArgs e)
        {
            List<PlayersEntity> playersPairs = PairsAlgo.BuildPairs((Guid)(this.TouranmentGrid.SelectedValue));
            this.gvPairs.DataSource = playersPairs;
            this.gvPairs.DataBind();
        }

        protected void ScheduleView_Activate(object sender, EventArgs e)
        {
            Guid tournamentId = new Guid(this.TouranmentGrid.SelectedValue.ToString());
            //SchedulerAlgo.SchedulerGames(tournamentId, PairsAlgo.BuildPairs(tournamentId));
            SchedulerAlgo.ScheduleGames(tournamentId);

            //for now..straight database kick
            IEnumerable<DateTime> dates;
            using (TournaDataContext db = new TournaDataContext())
            {
                dates = db.Schedules.Where(y => y.TournamentId == tournamentId).Select(y => y.Start).ToList();
            }

            CalendarVisualizer vis = new CalendarVisualizer(dates);
            vis.Display(schedulesPlaceHolder);
        }
      
    }
}
