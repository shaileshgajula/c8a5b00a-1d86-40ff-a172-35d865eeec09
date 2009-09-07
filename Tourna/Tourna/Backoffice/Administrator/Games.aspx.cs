using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace StrongerOrg.Backoffice.Administrator
{
    public partial class Games : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void SaveLogoFile(string newFileName)
        {
            FileUpload fu = (FileUpload)this.DetailsView1.FindControl("fuGameImage");
            HttpPostedFile postedFile = fu.PostedFile;
            if (postedFile != null)
            {
                int contentLength = postedFile.ContentLength;
                string contentType = postedFile.ContentType;
                string fullFileName = Server.MapPath("~\\Images\\GamesImages\\" + newFileName);
                postedFile.SaveAs(fullFileName);
            }
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            if (e.Values["FileName"] != null)
            {
                string fileName = e.Values["FileName"].ToString();
                string newFileName = string.Format("{0}{1}{2}", Path.GetFileNameWithoutExtension(fileName),
                        Guid.NewGuid().ToString().Substring(0, 5), Path.GetExtension(fileName));
                e.Values["GameImage"] = newFileName;
                SaveLogoFile(newFileName);
            }
        }
    }
}
