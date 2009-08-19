using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.OrganisationSite
{
    public partial class Standings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void dlTournaments_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                string tournamentId = ((System.Data.DataRowView)e.Item.DataItem).Row["Id"].ToString();
                SqlDataSource sqlDs = e.Item.FindControl("SqlDataSource1") as SqlDataSource;
                sqlDs.SelectParameters["TournamentId"].DefaultValue = tournamentId;
            }
        }
        public string ScoreDisplay(object scoreA, object scoreB)
        {
            if (string.IsNullOrEmpty(scoreA.ToString()) && string.IsNullOrEmpty(scoreB.ToString()))
            {
                return "N/A";
            }
            else
            {
                return string.Format("{0}:{1}", scoreA, scoreB);
            }
        }
    }
}
