using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace StrongerOrg.Backoffice.UserControls
{
    public partial class ImageViewer : System.Web.UI.UserControl
    {
        private string currentImgName;
        private int? currentImgId;
        private int? previousImgId;
        private int? nextImgId;
        private string imageFolder;
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

        public string ImageFolder
        {
            private get { 
                return string.IsNullOrEmpty(this.imageFolder) ? ViewState["ImageFolder"].ToString() : this.imageFolder; }
            set
            {
                ViewState["ImageFolder"] = value;
                this.imageFolder = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.CurrentImgId = int.Parse(Request.QueryString["ImgId"]);

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
                    conn.Open();
                    command.ExecuteNonQuery();

                }

                this.CurrentImgName = command.Parameters["@CurrentFileName"].Value.ToString();
                this.lblImgCaption.Text = (command.Parameters["@ImageCaption"].Value == DBNull.Value) ? string.Empty : command.Parameters["@ImageCaption"].Value.ToString();
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
    }
}