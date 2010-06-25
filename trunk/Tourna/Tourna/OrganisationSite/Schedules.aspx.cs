using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.OrganisationSite
{
    public partial class Schedules : System.Web.UI.Page
    {
        bool isTeamMode;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Feedbacks1.OrganisationId = Request.QueryString["TournamentId"].ToString();
            isTeamMode = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int round = int.Parse(e.Row.Cells[1].Text);
                if ((round % 2) == 0)
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0FC");
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                }
                HyperLink hl = e.Row.Cells[2].Controls[0] as HyperLink;
                hl.Enabled = isTeamMode;
            }
        }

      

        protected void dvGameDetails_DataBinding(object sender, EventArgs e)
        {
            
        }

        protected void dvGameDetails_DataBound(object sender, EventArgs e)
        {
            if (this.dvGameDetails.Rows.Count > 0)
            {
                string x = this.dvGameDetails.Rows[0].Cells[1].Text;
                this.lblTournamentTitle.Text = x;
            }
        }

       
    }
}
