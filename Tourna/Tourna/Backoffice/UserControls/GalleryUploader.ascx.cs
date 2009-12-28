using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

namespace StrongerOrg.Backoffice.UserControls
{
    public partial class GalleryUploader : System.Web.UI.UserControl
    {
        public event Action NewImageAdded;
        private const  int  thumbHight = 96;
        private const int thumbHWidth = 128;

        private const int fullSizeHight = 600;
        private const int fullSizeHWidth = 800;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbUpload_Click(object sender, EventArgs e)
        {
            string imageCaption = this.txtCaption.Text;
            string fileName = fuImage.PostedFile.FileName.ToString();
            string newFileName = string.Format("{0}{1}{2}", Path.GetFileNameWithoutExtension(fileName),
                    Guid.NewGuid().ToString().Substring(0, 5), Path.GetExtension(fileName));
            HttpPostedFile postedFile = fuImage.PostedFile;
            if (postedFile != null)
            {
                int contentLength = postedFile.ContentLength;
                string contentType = postedFile.ContentType;
                string fullFileName = Server.MapPath("~\\OrganisationGalleryImages\\" + newFileName);
                //postedFile.SaveAs(fullFileName);
                Stream imgStream = postedFile.InputStream;

                Bitmap bmThumb = new Bitmap(imgStream);
                System.Drawing.Image im;
                // if it is smaller then thumbnail size
                if ((bmThumb.Height > thumbHight && bmThumb.Width > thumbHWidth) || (bmThumb.Height > thumbHWidth && bmThumb.Width > thumbHight))
                {
                    // determine if it is landscape or portrait image
                    if (bmThumb.Height > bmThumb.Width)
                    {
                        im = bmThumb.GetThumbnailImage(thumbHight, thumbHWidth, null, IntPtr.Zero);
                    }
                    else
                    {
                        im = bmThumb.GetThumbnailImage(thumbHWidth, thumbHight, null, IntPtr.Zero);
                    }
                    im.Save(Server.MapPath("~\\OrganisationGalleryImages\\ThumbNail\\") + newFileName);

                    if ((bmThumb.Height > fullSizeHight && bmThumb.Width > fullSizeHWidth) || (bmThumb.Height > fullSizeHWidth && bmThumb.Width > fullSizeHight))
                    {
                        if (bmThumb.Height > bmThumb.Width)
                        {
                            im = bmThumb.GetThumbnailImage(fullSizeHight, fullSizeHWidth, null, IntPtr.Zero);
                        }
                        else
                        {
                            im = bmThumb.GetThumbnailImage(fullSizeHWidth, fullSizeHight, null, IntPtr.Zero);
                        }
                        im.Save(Server.MapPath("~\\OrganisationGalleryImages\\") + newFileName);
                    }
                    else
                    {
                        postedFile.SaveAs(fullFileName);
                    }
                }
                else
                {
                    
                    postedFile.SaveAs(Server.MapPath("~\\OrganisationGalleryImages\\ThumbNail\\").ToString() + fullFileName);
                }
                this.txtCaption.Text = string.Empty;
                
            }
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("ImageGalleryInsert", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@OrganisationId", SqlDbType.UniqueIdentifier, 150).Value = ((StrongerOrg.Backoffice.BackOffice)this.Page.Master).OrgBasicInfo.Id;
                command.Parameters.Add("@FileName", SqlDbType.VarChar, 150).Value = newFileName;
                command.Parameters.Add("@ImageCaption", SqlDbType.NVarChar,100).Value = imageCaption;
                conn.Open();
                command.ExecuteNonQuery();
            }
            if (this.NewImageAdded != null) { this.NewImageAdded(); }
        }


    }
}