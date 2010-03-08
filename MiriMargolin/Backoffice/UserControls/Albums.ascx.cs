using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.Backoffice.UserControls
{
    public partial class Albums : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string BaseNavigationUrl
        {
            set;
            private get;
        }

        public string BuildNavigateUrl(object id, string page)
        { 
            string url = string.Format("{0}/{1}", BaseNavigationUrl,page);
            return string.Format(url, id.ToString());
        }

        protected void dlAlbums_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                string albumId = ((System.Data.DataRowView)e.Item.DataItem).Row["Id"].ToString();
                SqlDataSource sqlDs = e.Item.FindControl("SqlDataSourceAlbumPreview") as SqlDataSource;
                sqlDs.SelectParameters["AlbumId"].DefaultValue = albumId;
            }
        }
    }
}