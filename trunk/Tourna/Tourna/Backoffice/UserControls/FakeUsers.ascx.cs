using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using StrongerOrg.Backoffice.Entities;

namespace StrongerOrg.Backoffice.UserControls
{
    public partial class FakeUsers : System.Web.UI.UserControl
    {
        public int i = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbBindToTournament_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand insertCmd = new SqlCommand("PlayerInsert", conn);
                insertCmd.CommandType = CommandType.StoredProcedure;
                insertCmd.Parameters.Add("@organisationId", SqlDbType.UniqueIdentifier).Value = ((StrongerOrg.Backoffice.BackOffice)this.Page.Master).OrgBasicInfo.Id;
                insertCmd.Parameters.Add("@TournamentId", SqlDbType.UniqueIdentifier).Value = new Guid(this.Request.QueryString["TournamentId"].ToString());
                insertCmd.Parameters.Add("@name", SqlDbType.VarChar, 150);
                insertCmd.Parameters.Add("@email", SqlDbType.VarChar, 150);
                insertCmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                conn.Open();
                int rowsEffected = 0;
                foreach (GridViewRow row in this.GridView1.Rows)
                {
                    CheckBox cb = row.Cells[1].FindControl("cbItem") as CheckBox;
                    if (cb != null && cb.Checked)
                    {
                        string name = row.Cells[2].Text;
                        string email = row.Cells[3].Text;

                        insertCmd.Parameters["@name"].Value = name;
                        insertCmd.Parameters["@email"].Value = email;
                        insertCmd.ExecuteNonQuery();
                        rowsEffected++;
                    }
                }
                this.lblMsg.Text = string.Format("{0} players have been registered", rowsEffected);
            }
        }

        protected void btnMatchUpPlayers_Click(object sender, EventArgs e)
        {
            Guid tournamentId = new Guid(this.Request.QueryString["TournamentId"].ToString());
            Guid orgId = ((StrongerOrg.Backoffice.BackOffice)this.Page.Master).OrgBasicInfo.Id;
            StrongerOrg.BL.Jobs.TournamentMatchupManager.Build(tournamentId, orgId);
            this.lblMsg.Text ="Match ups have been build";
            OnDataChange();
        }

        protected void btnClearMatchups_Click(object sender, EventArgs e)
        {
            Guid tournamentId = new Guid(this.Request.QueryString["TournamentId"].ToString());
            StrongerOrg.Backoffice.Entities.TournamentMatchupManager.Delete(tournamentId);
            this.lblMsg.Text = "Match ups have been deleted";
            OnDataChange();
        }
        public event Action OnDataChange;
        protected void btnCleanPlayers_Click(object sender, EventArgs e)
        {
            PlayerManager pm = new PlayerManager();
            int rowsEffected = pm.DeleteTournamentPlayers(new Guid(this.Request.QueryString["TournamentId"].ToString()));
             this.lblMsg.Text = string.Format("{0} players have been deleted", rowsEffected);
            OnDataChange();
        }

        protected void btnNotifyPlayers_Click(object sender, EventArgs e)
        {
            List<StrongerOrg.BL.DL.MatchupsToNotifyGetResult> result = StrongerOrg.BL.Jobs.TournamentMatchupManager.GetMatchupsToNotify(new Guid(this.Request.QueryString["TournamentId"].ToString()));
            foreach (StrongerOrg.BL.DL.MatchupsToNotifyGetResult item in result)
            {
                StrongerOrg.BL.Jobs.TournamentMatchupManager.NotifyPlayers(item);
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.className='SelectedRowStyle'");
                    e.Row.Attributes.Add("onmouseout", "this.className='AlternatingRow'");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.className='SelectedRowStyle'");
                    e.Row.Attributes.Add("onmouseout", "this.className='RowBackColor'");
                }
            }
        }

        //    protected void lbCheckAll_Click(object sender, EventArgs e)
        //    {
        //        foreach (GridViewRow row in this.GridView1.Rows)
        //        {
        //            CheckBox cb = row.Cells[0].FindControl("cbItem") as CheckBox;
        //            if (cb != null)
        //            {
        //                cb.Checked = true;
        //            }
        //        }
        //    }
    }
}