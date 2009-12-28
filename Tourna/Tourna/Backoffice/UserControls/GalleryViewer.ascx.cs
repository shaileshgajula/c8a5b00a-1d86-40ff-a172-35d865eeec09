using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.Backoffice.UserControls
{
    public partial class GalleryViewer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            this.lblMsg.Visible = (e.AffectedRows == 0);
        }

        internal void Refresh()
        {
            this.DataList1.DataBind();
        }
        internal string ImageViewerUrl
        {
            get;set;
        }
        public string BuildNavigationUrl(object imgId)
        {
            return ImageViewerUrl + imgId.ToString(); 
        }
    }
}