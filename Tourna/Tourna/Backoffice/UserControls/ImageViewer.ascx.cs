using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;

namespace StrongerOrg.Backoffice.UserControls
{
    public partial class ImageViewer : System.Web.UI.UserControl
    {
        private string currentImgName;
        private int? currentImgId;
        private int? previousImgId;
        private int? nextImgId;
        private string imageFolder;
        private int albumId;
        private const int thumbHight = 48;
        private const int thumbHWidth = 72;

        private const int fullSizeHight = 300;
        private const int fullSizeHWidth = 450;

        private string CurrentImgName
        {
            get { return this.currentImgName; }
            set { this.currentImgName = value; ViewState["CurrentImgName"] = value; }
        }
        internal string GetCurrentImgName
        {
            get { return ViewState["CurrentImgName"].ToString(); }
        }
        private int? CurrentImgId
        {
            get { return this.currentImgId; }
            set { this.currentImgId = value; ViewState["CurrentImgId"] = value; }
        }

        internal int GetCurrentImgId
        {
            get
            {
                int result;
                int.TryParse(ViewState["CurrentImgId"].ToString(), out result);
                return result;
            }
        }

        private int? PreviousImgId
        {
            get { return this.previousImgId; }
            set { this.previousImgId = value; ViewState["PreviousImgId"] = value; }
        }
        internal int? GetPreviousImgId
        {
            get
            {
                int result;
                if (ViewState["PreviousImgId"] != null && int.TryParse(ViewState["PreviousImgId"].ToString(), out result))
                {
                    return result;
                }
                else
                {
                    return new Nullable<int>();
                }

            }
        }

        private int? NextImgId
        {
            get { return this.nextImgId; }
            set { this.nextImgId = value; ViewState["NextImgId"] = value; }
        }
        internal int? GetNextImgId
        {
            get
            {
                int result;
                if (ViewState["NextImgId"] != null && int.TryParse(ViewState["NextImgId"].ToString(), out result))
                {
                    return result;
                }
                else
                {
                    return new Nullable<int>();
                }

            }
        }
        public bool IsEditMode
        {
            get { return bool.Parse(ViewState["IsEditMode"].ToString()); }
            set { ViewState["IsEditMode"] = value; }
        }
        public string ImageFolder
        {
            private get
            {
                return string.IsNullOrEmpty(this.imageFolder) ? ViewState["ImageFolder"].ToString() : this.imageFolder;
            }
            set
            {
                ViewState["ImageFolder"] = value;
                this.imageFolder = value;
            }
        }
        public int AlbumId
        { get { return this.albumId; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CurrentImgId = int.Parse(Request.QueryString["ImgId"]);
            if (this.IsEditMode)
            {
                this.lnkPopupAdd.Visible = true;
                this.txtCaption.Visible = true;
                this.btnDeleteAssociatedImage.Visible = true;
                this.btnUpdateAssociatedImage.Visible = true;
                this.lblAssociatedCaption.Visible = false;
                this.txtImgCaption.Visible = true;
                this.lblImgCaption.Visible = false;
                this.ddlAlbums.Visible = true;
                this.hlAlbum.Visible = false;
                this.tbStory.Visible = true;
                this.lblStory.Visible = false;
                this.txtSizes.Visible = true;
                this.lblSizes.Visible = false;
                this.lbUpdateTicket.Visible = true;
                this.lblImageOrder.Visible = true;
                this.ddlImageOrder.Visible = true;
                this.txtPrice.Visible = true;
                this.lblPrice.Visible = true;
            }
            else
            {
                this.lnkPopupAdd.Visible = false;
                this.txtCaption.Visible = false;
                this.btnDeleteAssociatedImage.Visible = false;
                this.btnUpdateAssociatedImage.Visible = false;
                this.lblAssociatedCaption.Visible = true;
            }
            if (!this.IsPostBack)
            {


                SqlCommand command = new SqlCommand("GetImage");
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@CurrentImgId", SqlDbType.Int).Value = this.CurrentImgId.Value;
                    command.Parameters.Add("@ImageCaption", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@CurrentFileName", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@PreviousImgId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@NextImgId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@AlbumTitle", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@ImageStory", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@ImageSizes", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@AlbumId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@ImageOrder", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@Price", SqlDbType.Int).Direction = ParameterDirection.Output;
                    conn.Open();
                    command.ExecuteNonQuery();

                }

                this.CurrentImgName = command.Parameters["@CurrentFileName"].Value.ToString();
                //this.lblAlbumTitle.Text = GetOutputValue(command, "@AlbumTitle");
                this.albumId = int.Parse(command.Parameters["@AlbumId"].Value.ToString());
                if (this.IsEditMode)
                {
                    this.txtImgCaption.Text = GetOutputValue(command, "@ImageCaption");
                    string albumTitle = GetOutputValue(command, "@AlbumTitle");

                    this.tbStory.Text = GetOutputValue(command, "@ImageStory");
                    this.txtSizes.Text = GetOutputValue(command, "@ImageSizes");
                    this.txtPrice.Text = GetOutputValue(command, "@Price");
                    ListItem liImageOrder = this.ddlImageOrder.Items.FindByValue(GetOutputValue(command, "@ImageOrder"));

                    if (liImageOrder != null)
                    {
                        liImageOrder.Selected = true;
                    }
                }
                else
                {
                    this.lblImgCaption.Text = GetOutputValue(command, "@ImageCaption");
                    this.hlAlbum.Text = GetOutputValue(command, "@AlbumTitle");
                    this.hlAlbum.NavigateUrl = string.Format(@"~/FrontSitePages/MiriMargolin/Gallery.aspx?AlbumId={0}", command.Parameters["@AlbumId"].Value.ToString());
                    this.lblStory.Text = GetOutputValue(command, "@ImageStory");
                    this.lblSizes.Text = GetOutputValue(command, "@ImageSizes");
                }

                imgBigDisplay.ImageUrl = @"~\OrganisationGalleryImages\" + this.CurrentImgName;

                if (command.Parameters["@PreviousImgId"].Value == System.DBNull.Value)
                {
                    this.hlPrevious.Enabled = false;
                    this.hlPrevious.CssClass = "DisabledImage";
                }
                else
                {
                    this.PreviousImgId = int.Parse(command.Parameters["@PreviousImgId"].Value.ToString());
                    this.hlPrevious.Enabled = true;
                    this.hlPrevious.NavigateUrl = string.Format(this.ImageFolder, command.Parameters["@PreviousImgId"].Value);
                }
                if (command.Parameters["@NextImgId"].Value == System.DBNull.Value)
                {
                    this.hlNext.Enabled = false;
                    this.hlNext.CssClass = "DisabledImage";
                }
                else
                {
                    this.NextImgId = int.Parse(command.Parameters["@NextImgId"].Value.ToString());
                    this.hlNext.Enabled = true;
                    this.hlNext.NavigateUrl = string.Format(this.ImageFolder, command.Parameters["@NextImgId"].Value);
                }
            }
        }

        private string GetOutputValue(SqlCommand command, string paramName)
        {
            return (command.Parameters[paramName].Value == DBNull.Value) ? string.Empty : command.Parameters[paramName].Value.ToString();
        }

        protected void btnAddAssociatedImage_Click(object sender, EventArgs e)
        {
            string imageCaption = this.txtAssociatedImgCaption.Text;
            string fileName = this.fuAssociatedImage.PostedFile.FileName.ToString();
            string newFileName = string.Format("{0}{1}{2}", Path.GetFileNameWithoutExtension(fileName),
                    Guid.NewGuid().ToString().Substring(0, 5), Path.GetExtension(fileName));
            HttpPostedFile postedFile = this.fuAssociatedImage.PostedFile;
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
                this.txtAssociatedImgCaption.Text = string.Empty;

            }
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("AssociatedImageInsert", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ParentImageId", SqlDbType.Int).Value = this.CurrentImgId.Value;
                command.Parameters.Add("@ImageCaption", SqlDbType.NVarChar, 100).Value = imageCaption;
                command.Parameters.Add("@FileName", SqlDbType.VarChar, 150).Value = newFileName;
                conn.Open();
                command.ExecuteNonQuery();
            }
            this.DataList1.DataBind();
        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            string albumTitle = this.hlAlbum.Text;
            ListItem selectedItem = this.ddlAlbums.Items.FindByText(albumTitle);
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
            }
            this.lblNoAssociatedImagesFound.Visible = (e.AffectedRows == 0);
        }
        public string BuildCommandArgument(object id, object fileName, object caption)
        {
            return string.Format("{0}*{1}*{2}", id.ToString(), fileName.ToString(), caption.ToString());
        }
        protected void ibAssociatedImage_Command(object sender, CommandEventArgs e)
        {
            string[] imgParams = ((string)e.CommandArgument).Split('*');
            this.imgAssiciatedFullSizeImage.ImageUrl = string.Format(@"~\OrganisationGalleryImages\{0}", imgParams[1]);
            this.txtCaption.Text = imgParams[2];
            this.lblAssociatedCaption.Text = imgParams[2];
            ViewState["AssociatedImageId"] = imgParams[0];
            this.ModalPopupExtender1.Show();
        }

        protected void btnUpdateAssociatedImage_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(string.Format("update AssociatedImages set Caption = '{0}' where id ={1}",
                    this.txtCaption.Text, ViewState["AssociatedImageId"].ToString()), conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            this.DataList1.DataBind();
        }

        protected void btnDeleteAssociatedImage_Click(object sender, EventArgs e)
        {
            string fullFileName = System.IO.Path.GetFileName(this.imgAssiciatedFullSizeImage.ImageUrl);
            string thumbnailImagePath = Server.MapPath("~\\OrganisationGalleryImages\\").ToString() + fullFileName;
            string fullSizeImagePath = Server.MapPath("~\\OrganisationGalleryImages\\ThumbNail\\").ToString() + fullFileName;
            File.Delete(fullFileName);
            File.Delete(thumbnailImagePath);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(string.Format("delete from AssociatedImages  where id ={0}",
                    ViewState["AssociatedImageId"].ToString()), conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            this.DataList1.DataBind();
        }

        protected void lbUpdateTicket_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("UpdateImageTicket", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = this.CurrentImgId.Value;
                command.Parameters.Add("@AlbumId", SqlDbType.Int).Value = this.ddlAlbums.SelectedValue;
                command.Parameters.Add("@ImageCaption", SqlDbType.NVarChar, 150).Value = this.txtImgCaption.Text;
                command.Parameters.Add("@ImageStory", SqlDbType.VarChar, 512).Value = this.tbStory.Text;
                command.Parameters.Add("@sizes", SqlDbType.VarChar, 50).Value = this.txtSizes.Text;
                command.Parameters.Add("@ImageOrder", SqlDbType.Int).Value = this.ddlImageOrder.SelectedValue;
                if (!string.IsNullOrEmpty(this.txtPrice.Text))
                {
                    command.Parameters.Add("@Price", SqlDbType.Money).Value = this.txtPrice.Text;
                }
                conn.Open();
                command.ExecuteNonQuery();
            }
        }




    }
}