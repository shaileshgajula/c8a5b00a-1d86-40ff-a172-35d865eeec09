using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.FrontSitePages.MiriMargolin
{
    public partial class Albums : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void dlAlbums_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                string tournamentId = ((System.Data.DataRowView)e.Item.DataItem).Row["Id"].ToString();
                SqlDataSource sqlDs = e.Item.FindControl("SqlDataSourceAlbumPreview") as SqlDataSource;
                sqlDs.SelectParameters["AlbumId"].DefaultValue = tournamentId;
            }
        }
    }
}