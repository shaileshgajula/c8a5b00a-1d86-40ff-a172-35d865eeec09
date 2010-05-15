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
using System.Data.OleDb;

namespace StrongerOrg.Backoffice
{
    public partial class ControlPanel : BasePage
    {
        public int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                
            }
        }

        public DataTable readCsv(string count)
        {
            try
            {
                string strPath = @"C:\Users\Administrator\Documents\Visual Studio 2010\Projects\StrongerOrg\Tourna\Tourna\App_Data";
                string ConnectionString =
                        string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};
                                Extended Properties=""text;HDR=Yes;FMT=Delimited"";"
                                        , strPath);
                string orgId = this.Master.OrgBasicInfo.Id.ToString();
                string CommandText = string.Format(@"SELECT top {0} [first name] + ' ' + [last name] as name, [username]+ '@strongerorg.com' as email  FROM StrongerOrgDemoUserList.csv", count);
                DataSet CSVDataSet = new DataSet();
                OleDbConnection CSVConnection = new OleDbConnection(ConnectionString);
                OleDbDataAdapter CSVAdapter = new OleDbDataAdapter(CommandText, CSVConnection);
                CSVConnection.Open();
                CSVAdapter.Fill(CSVDataSet, "StrongerOrgDemoUserList.csv");
                CSVConnection.Close();
                SqlCommand insertCommand = new SqlCommand("FakeUserInsert", new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString));
                insertCommand.CommandType = CommandType.StoredProcedure;
                insertCommand.Connection.Open();
                foreach (DataRow dr in CSVDataSet.Tables[0].Rows)
                {

                    insertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = dr[0];
                    insertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 150).Value = dr[1];
                    insertCommand.ExecuteNonQuery();
                    insertCommand.Parameters.Clear();
                }
                this.GVcsv.DataBind();
                //GVcsv.DataSource = CSVDataSet;
                //GVcsv.DataBind();
                return CSVDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                //lblerror.Text = ex.Message;
                throw ex;
            }

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            readCsv("100");
        }
       
    }
}
