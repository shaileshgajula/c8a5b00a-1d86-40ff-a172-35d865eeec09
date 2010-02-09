using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.Entities;


namespace StrongerOrg.Backoffice.UserControls
{
    public partial class GalleryViewer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack && Request.QueryString["AlbumId"]!=null)
            {
                AlbumsDataContext albums = new AlbumsDataContext();
                var albumName = (from album in albums.Albums
                                where album.Id == int.Parse(Request.QueryString["AlbumId"].ToString())
                                select album.Title).SingleOrDefault<string>();
                this.lblAlbumTitle.Text = albumName;
            }
        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            this.lblMsg.Visible = (e.AffectedRows == 0);
        }

        internal void Refresh()
        {
            this.DataList1.DataBind();
        }
        public string ImageViewerUrl
        {
            get;set;
        }
        public string BuildNavigationUrl(object imgId)
        {
            return ImageViewerUrl + imgId.ToString(); 
        }
    }
}