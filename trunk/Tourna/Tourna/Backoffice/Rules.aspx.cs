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
    public partial class Rules : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.reRules.Content = TextContentManager.GetTextContent(this.Master.OrgBasicInfo.Id, "Rules");
            }
        }

        protected void lbSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("TextContentInsert", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@OrganisationId", SqlDbType.UniqueIdentifier, 150).Value = this.Master.OrgBasicInfo.Id;
                command.Parameters.Add("@ContentType", SqlDbType.VarChar, 50).Value = "Rules";
                command.Parameters.Add("@Content", SqlDbType.Text).Value = this.reRules.Content;
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
