using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.Backoffice
{
    public partial class BracketsPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BracketsDisplay1.TournamentId = new Guid(Request.QueryString["TournamentId"].ToString());
        }
    }
}