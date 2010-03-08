using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.FrontSitePages.MiriMargolin
{
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GalleryViewer1.ImageViewerUrl = "~\\FrontSitePages\\MiriMargolin\\ImageViewer.aspx?ImgId=";
            this.GalleryViewer1.OrgId = new Guid(this.Master.OrgId);
        }
    }
}