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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["TournamentName"] != null)
            {
                this.hlTournamentTitle.Text = string.Format("{0}", Page.Request.QueryString["TournamentName"].ToString());
                this.hlTournamentTitle.NavigateUrl = "~/backoffice/Tournament.aspx?TournamentId=" + Page.Request.QueryString["TournamentId"].ToString();
            }
            else
            {
                this.hlTournamentTitle.Text = string.Format("{0} Players[from all tournaments]", Master.OrgBasicInfo.Name);
            }
        }
        protected string BuildUrl()
        {
            return string.Format(@"~\OrganisationSite\PlayerSubscription.aspx?OrgId={0}", Master.OrgBasicInfo.Id.ToString());
        }


    }
}
