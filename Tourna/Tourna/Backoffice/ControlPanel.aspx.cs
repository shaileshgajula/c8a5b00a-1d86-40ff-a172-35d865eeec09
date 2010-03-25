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





        protected void navMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int pageIndex = int.Parse(e.Item.Value);
            this.PageView.ActiveViewIndex = pageIndex;

            Action executeLogic = ViewFactory(pageIndex);
            executeLogic();
        }





        protected void TournamentSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BackOffice masterPage = this.Master as BackOffice;
            Guid orgId = masterPage.OrgBasicInfo.Id;

            TournaDataContext db = new TournaDataContext();
            var tourneys = from tr in db.Tournaments
                           where tr.OrganisationId == orgId
                           select new
                           {
                               Id = tr.Id,
                               TournamentName = tr.TournamentName
                           };

            e.Result = tourneys;
        }


        private Action ViewFactory(int index)
        {
            Action execFunc = () => { throw new Exception("Wrong menu"); };
            switch (index)
            {
                case 0:
                    execFunc = PlayerViewActivate;
                    break;
                case 1:
                    execFunc = PairViewActivate;
                    break;
                case 2:
                    execFunc = ScheduleViewActivate;
                    break;
            }

            return execFunc;
        }

        private void PlayerViewActivate()
        {
            //get the players for the selected tournament
            //get the players
            using (TournaDataContext db = new TournaDataContext())
            {
                var players = from p2t in db.Players2Tournaments
                              join p in db.Players on p2t.PlayerId equals p.Id
                              where p2t.TournamentId == new Guid(this.drpDownTournamentList.SelectedValue)
                              select new
                                        {
                                            Name = p.Name,
                                            Department = p.Department,
                                            Email = p.Email ?? "Not Provided"
                                        };

                var list = players.ToList();
                this.playersGrid.DataSource = list;
                this.playersGrid.DataBind();

                this.lblNumOfPlayers.Text = list.Count().ToString();
            }

        }

        private void PairViewActivate()
        {
            var names = Enum.GetNames(typeof(PairsAlgorithmType));
            this.drpPairAlgo.DataSource = names;
            this.drpPairAlgo.DataBind();

            var pairNames = Enum.GetNames(typeof(PairsMatchType));
            this.drpPairing.DataSource = pairNames;
            this.drpPairing.DataBind();

            this.PerformRepairing();
        }

        private void PerformRepairing()
        {
            //re-pair based on whats selected
            string pairing = this.drpPairing.SelectedValue;
            string playerMat = this.drpPairAlgo.SelectedValue;

            PairsAlgorithmType playerMatcType = (PairsAlgorithmType)Enum.Parse(typeof(PairsAlgorithmType), playerMat);
            PairsMatchType pairingType = (PairsMatchType)Enum.Parse(typeof(PairsMatchType), pairing);
            int numOfGames = int.Parse(this.txtMultiGame.Text);

            switch (pairingType)
            {
                case PairsMatchType.Bracket:
                    {
                        this.lblMultiGame.Visible = false;
                        this.txtMultiGame.Visible = false;
                        this.lbtnPairUp.Visible = false;
                        numOfGames = 1;
                        break;
                    }
                default:
                    {
                        this.lblMultiGame.Visible = true;
                        this.txtMultiGame.Visible = true;
                        this.lbtnPairUp.Visible = true;
                        break;
                    }
            }


            List<PlayersEntity> playersPairs = PairsAlgo.BuildPairs(new Guid(this.drpDownTournamentList.SelectedValue), playerMatcType, pairingType, numOfGames);
            this.pairGrid.DataSource = playersPairs;
            this.pairGrid.DataBind();

            this.lblNumActiveGames.Text = playersPairs.Count().ToString();

        }



        private void ScheduleViewActivate()
        {
            Guid tournamentId = new Guid(this.drpDownTournamentList.SelectedValue);

            //for now..straight database kick
            IEnumerable<DateTime> dates;                       
            using (TournaDataContext db = new TournaDataContext())
            {
               var  dateInfo = db.TournamentMatchups.Where(y => y.TournamentId == tournamentId).
                    Select(y =>
                        new 
                            {
                                StartDate = y.Start,
                                PlayerA = db.Players.Where( p => p.Id == y.PlayerA).Select( n => n.Name).First(),
                                PlayerB = db.Players.Where(p => p.Id == y.PlayerB).Select(n => n.Name).First(),
                            })
                    .ToList();



               schedDatesGrid.DataSource = dateInfo.Select((x, i) => 
                   new
                       {
                           StartDate = x.StartDate,
                           GameName = String.Format("Game {0} - {1}:{2}",i+1,x.PlayerA,x.PlayerB),
                           PlayerA = x.PlayerA,
                           PlayerB = x.PlayerB
                       }
                   );
               schedDatesGrid.DataBind();

               dates = dateInfo.Select(x => x.StartDate);
            }


            //if (dates.Count() == 0)
                //this.RunScheduler();

            CalendarVisualizer vis = new CalendarVisualizer(dates);
            vis.Display(schedulesPlaceHolder);

        }

        private void RunScheduler()
        {
            Guid tournamentId = new Guid(this.drpDownTournamentList.SelectedValue);
            SchedulerAlgo.ScheduleGames(tournamentId, this.drpPairAlgo.SelectedValue, this.drpPairing.SelectedValue);

            this.ScheduleViewActivate();
        }

        protected void lbtnAddPlayers_Click(object sender, EventArgs e)
        {
            Guid orgId = (this.Master as BackOffice).OrgBasicInfo.Id;
            Guid tournamentId = new Guid(this.drpDownTournamentList.SelectedValue);
            int numberOfPlayersToCreate = int.Parse(this.txtNumPlayer.Text);

            string orgName = (this.Master as BackOffice).OrgBasicInfo.Name;
            this.CreatePlayers(orgId, tournamentId, numberOfPlayersToCreate, orgName);

            this.PlayerViewActivate();
        }

        protected void drpPairAlgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PerformRepairing();
        }

        protected void drpPairing_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PerformRepairing();
        }

        protected void lbtnPairUp_Click(object sender, EventArgs e)
        {
            this.PerformRepairing();
        }

        protected void lbtnPlayersExport_Click(object sender, EventArgs e)
        {
            GridViewExportUtil.Export("PlayersList.xlsx", this.playersGrid);
        }

        protected void lbtnPairsExport_Click(object sender, EventArgs e)
        {
            GridViewExportUtil.Export("PairView.xlsx", this.pairGrid);
        }

        protected void lbtnExportSchedules_Click(object sender, EventArgs e)
        {
            GridViewExportUtil.Export("GameSchedules.xlsx", this.schedDatesGrid);
        }


        protected void schedMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int pageIndex = int.Parse(e.Item.Value);
            this.scheduleMultiView.ActiveViewIndex = pageIndex;

            this.ScheduleViewActivate();
        }

        protected void lbtnForceReschedule_Click(object sender, EventArgs e)
        {
            this.RunScheduler();
        }

       

        protected void drpDownTournamentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ScheduleViewActivate();
        }

        protected void lBtnSave_Click(object sender, EventArgs e)
        {
            RunScheduler();
        }

        protected void lbRunSchuler_Click(object sender, EventArgs e)
        {
            StrongerOrg.BL.Jobs.TournamentMatchupManager.Build(new Guid(this.drpDownTournamentList.SelectedValue), this.Master.OrgBasicInfo.Id );
        }

        protected void lbNotifyPlayers_Click(object sender, EventArgs e)
        {
           List<StrongerOrg.BL.DL.MatchupsToNotifyGetResult> result= StrongerOrg.BL.Jobs.TournamentMatchupManager.GetMatchupsToNotify(new Guid(this.drpDownTournamentList.SelectedValue));
           foreach (StrongerOrg.BL.DL.MatchupsToNotifyGetResult item in result)
           {
               StrongerOrg.BL.Jobs.TournamentMatchupManager.NotifyPlayers(item);
           }
        }

        protected void lblClearMatchups_Click(object sender, EventArgs e)
        {
            StrongerOrg.Backoffice.Entities.TournamentMatchupManager.Delete(new Guid(this.drpDownTournamentList.SelectedValue));
        }

    }
}
