using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace StrongerOrg.Backoffice
{
    public partial class Games2Organisation : BasePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = conn;
                command.CommandText = "GetOrganisations2Games";
                command.Parameters.Add("@OrganisationId", System.Data.SqlDbType.UniqueIdentifier).Value = Master.OrgBasicInfo.Id;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.Default);
                while (reader.Read())
                {
                    ListItem l = new ListItem(reader.GetString(1), reader.GetInt32(0).ToString());
                    l.Selected = (reader.GetInt32(2) != 0);
                    this.CheckBoxList1.Items.Add(l);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.DeleteAllItems();
            foreach (ListItem item in this.CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    int gameId = int.Parse(item.Value);
                    this.InsertItem(gameId);
                }
            }
        }

        private void InsertItem(int gameId)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conn;
                command.CommandText = "Organisations2GamesInsert";
                command.Parameters.Add("@OrganisationId", System.Data.SqlDbType.UniqueIdentifier).Value = Master.OrgBasicInfo.Id;
                command.Parameters.Add("@GameId", System.Data.SqlDbType.NVarChar, 150).Value = gameId;
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        private void DeleteAllItems()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conn;
                command.CommandText = "Organisations2GamesDelete";
                command.Parameters.Add("@OrganisationId", System.Data.SqlDbType.UniqueIdentifier).Value = Master.OrgBasicInfo.Id;
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
