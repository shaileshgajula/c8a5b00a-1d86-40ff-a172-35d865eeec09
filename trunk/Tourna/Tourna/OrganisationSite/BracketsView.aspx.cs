using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.OrganisationSite
{
    public partial class BracketsView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid tournamentId = new Guid(Request.QueryString["TournamentId"].ToString());
                this.BracketsDisplay1.TournamentId = tournamentId;
                string tournamentName = TournamentManager.GetTournamentName(tournamentId);
                this.lblTournamentTitle.Text = tournamentName;
            }
        }
    }
}