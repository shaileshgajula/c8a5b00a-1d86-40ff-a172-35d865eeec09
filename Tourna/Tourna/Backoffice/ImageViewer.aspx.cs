using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace StrongerOrg.Backoffice
{
    public partial class ImageViewer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ImageViewer1.ImageFolder = "~/BackOffice/ImageViewer.aspx?ImgId={0}"; 
            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            DeleteFromFileSystem();
            DeletImgFromDB();
            RedirectPage();
        }

        private void DeleteFromFileSystem()
        {
            File.Delete(Server.MapPath("~\\OrganisationGalleryImages\\ThumbNail\\") + this.ImageViewer1.GetCurrentImgName);
            File.Delete(Server.MapPath("~\\OrganisationGalleryImages\\") + this.ImageViewer1.GetCurrentImgName);
        }

        private void RedirectPage()
        {
            string redirectString = string.Empty;
            if (this.ImageViewer1.GetNextImgId.HasValue)
            {
                redirectString = string.Format("~\\BackOffice\\ImageViewer.aspx?ImgId={0}", this.ImageViewer1.GetNextImgId.Value);
            }
            else if (this.ImageViewer1.GetPreviousImgId.HasValue)
            {
                redirectString = string.Format("~\\BackOffice\\ImageViewer.aspx?ImgId={0}", this.ImageViewer1.GetPreviousImgId.Value);
            }
            else
            {
                redirectString = "~\\BackOffice\\EventGallery.aspx";
            }
            Response.Redirect(redirectString);
        }

        private void DeletImgFromDB()
        {
            
                SqlCommand command = new SqlCommand(string.Format("delete from ImageGallery where Id = {0}",this.ImageViewer1.GetCurrentImgId));
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    conn.Open();
                    command.ExecuteNonQuery();
                }
        }



    }
}