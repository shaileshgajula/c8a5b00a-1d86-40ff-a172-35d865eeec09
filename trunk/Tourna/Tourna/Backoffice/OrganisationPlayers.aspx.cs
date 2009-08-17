using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tourna.Backoffice
{
    public partial class OrganisationPlayers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && Page.Request.QueryString["TournamentName"] != null)
            {
                this.lblTitle.Text = string.Format("Tournament name : {0}", Page.Request.QueryString["TournamentName"].ToString());
            }
            else
            {
                this.lblTitle.Text = string.Format("{0} Players[from all tournaments]", Master.OrganisationName);
            }
        }
        protected string BuildUrl()
        {
            return string.Format(@"~\OrganisationSite\PlayerSubscription.aspx?OrgId={0}", HttpContext.Current.Profile.GetPropertyValue("OrganisationId").ToString());
        }


    }
}
