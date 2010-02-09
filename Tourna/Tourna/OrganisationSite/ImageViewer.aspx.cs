using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.OrganisationSite
{
    public partial class ImageViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string orgId = Request.QueryString["OrgId"].ToString();
                this.hlViewAll.NavigateUrl = string.Format("~/OrganisationSite/EventGallery.aspx?OrgId={0}", orgId);
                this.ImageViewer1.ImageFolder = "~/OrganisationSite/ImageViewer.aspx?OrgId=" + orgId + "&ImgId={0}";
                this.ImageViewer1.IsEditMode = false;
            }
        }
    }
}