using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.GData.Photos;

namespace StrongerOrg.Backoffice
{
    public partial class EventGallery : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            {
                this.GalleryUploader1.NewImageAdded += new Action(GalleryUploader1_NewImageAdded);
                this.GalleryViewer1.ImageViewerUrl = @"~\BackOffice\ImageViewer.aspx?ImgId="; 
            }
        }

        void GalleryUploader1_NewImageAdded()
        {
             this.GalleryViewer1.Refresh();
        }
    }
}
