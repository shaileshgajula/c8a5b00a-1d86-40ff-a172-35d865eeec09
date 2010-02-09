using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.OrganisationSite
{
    public partial class Leagues : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {

        }

        public string BuildNavigaionUrl(string pageName ,string tournamentId)
        {
            string organisationId = Request.QueryString["OrgId"];
            return string.Format("{0}?OrgId={1}&TournamentId={2}",pageName, organisationId, tournamentId);
        }
    }
}
