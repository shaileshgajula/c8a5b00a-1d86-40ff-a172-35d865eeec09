using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace StrongerOrg.FrontSitePages.MiriMargolin
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.lblAbout.Text = TextContentManager.GetTextContent(new Guid(Master.OrgId), "AboutMiriMargolin");
            }
        }

        protected void lbNotify_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                string sql = string.Format("Insert into Newsletter (fullname,email)values('{0}','{1}')", this.txtName.Text, this.txtEmail.Text);
                SqlCommand command = new SqlCommand(sql, conn);
                command.CommandType = System.Data.CommandType.Text;
                conn.Open();
                command.ExecuteNonQuery();
                this.lblMsg.Text = "Thank you.";
                this.lblFeedbackHeader.Enabled = false;
            }
        }
    }
}