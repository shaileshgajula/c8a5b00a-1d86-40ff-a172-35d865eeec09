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
    public partial class TextContent : System.Web.UI.UserControl
    {

        public string TextContentName
        {
            get { return ViewState["TextContentName"].ToString(); }
            set { ViewState["TextContentName"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.reRules.Content = TextContentManager.GetTextContent(((BackOffice)this.Page.Master).OrgBasicInfo.Id, TextContentName);
            }
        }

        protected void lbSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("TextContentInsert", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@OrganisationId", SqlDbType.UniqueIdentifier, 150).Value = ((BackOffice)this.Page.Master).OrgBasicInfo.Id;
                command.Parameters.Add("@ContentType", SqlDbType.VarChar, 50).Value = TextContentName;
                command.Parameters.Add("@Content", SqlDbType.Text).Value = this.reRules.Content;
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}