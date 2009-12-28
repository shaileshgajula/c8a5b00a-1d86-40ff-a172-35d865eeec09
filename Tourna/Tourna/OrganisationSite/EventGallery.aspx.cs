using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.OrganisationSite
{
    public partial class EventGallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string orgId = Request.QueryString["OrgId"].ToString();
            this.lblOrganisationId.Text = orgId;
            this.GalleryViewer1.ImageViewerUrl = string.Format(@"~\OrganisationSite\ImageViewer.aspx?OrgId={0}&ImgId=",orgId); 
        }
    }
}