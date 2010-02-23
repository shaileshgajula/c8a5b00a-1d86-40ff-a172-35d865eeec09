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
        private Guid orgId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack && Request.QueryString["AlbumId"] != null)
            {
                int albumId = int.Parse(Request.QueryString["AlbumId"].ToString());
               
                AlbumsDataContext albums = new AlbumsDataContext();
                string path = this.Request.FilePath.Substring(0, this.Request.FilePath.LastIndexOf('/'));
                var albumList = (from album in albums.Albums
                                 where album.OrganisationId == this.orgId
                                 select new MenuItem { Value = album.Id.ToString(), Text = album.Title, 
                                     Selected = (albumId == album.Id), 
                                     NavigateUrl =  string.Format("~/{0}/Gallery.aspx?AlbumId={1}",path, album.Id.ToString())}).ToList();
                foreach (var item in albumList)
                {
                    mGalleries.Items.Add(item);
                }
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
            get;
            set;
        }
        public string BuildNavigationUrl(object imgId)
        {
            return ImageViewerUrl + imgId.ToString();
        }
        
        public Guid OrgId
        {
            set { this.orgId = value; }
            private get { return this.orgId; }
        }
    }
}