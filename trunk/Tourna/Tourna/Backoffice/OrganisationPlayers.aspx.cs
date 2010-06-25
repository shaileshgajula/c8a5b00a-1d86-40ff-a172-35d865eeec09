using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.Backoffice
{
    public partial class OrganisationPlayers : BasePage
    {
        public int i = 1;
        bool isTeamMode = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            isTeamMode = (Request.QueryString["Mode"] == "T");
            if (isTeamMode)
            {
                this.imgCompetitorMode.ImageUrl = "../Images/Icons/Group.gif";
                this.imgCompetitorMode.ToolTip = "Teams";
            }
            else
            {
                this.imgCompetitorMode.ImageUrl = "../Images/Icons/Male.gif";
                this.imgCompetitorMode.ToolTip = "Players";
            }


            if (Page.Request.QueryString["TournamentName"] != null)
            {

                this.hlTournamentTitle.Text = string.Format("{0}", Page.Request.QueryString["TournamentName"].ToString());
                this.hlTournamentTitle.NavigateUrl = "~/backoffice/Tournament.aspx?TournamentId=" + Page.Request.QueryString["TournamentId"].ToString();
            }
            else
            {
                this.hlTournamentTitle.Text = string.Format("{0} competitors [from all tournaments]", Master.OrgBasicInfo.Name);
                this.hlTournamentTitle.Enabled = false;
            }
        }
        protected string BuildUrl()
        {
            return string.Format(@"~\OrganisationSite\PlayerSubscription.aspx?OrgId={0}", Master.OrgBasicInfo.Id.ToString());
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
                HyperLink hl = e.Row.Cells[2].Controls[0] as HyperLink;
                hl.Enabled = isTeamMode;
            }
        }

    }
}
