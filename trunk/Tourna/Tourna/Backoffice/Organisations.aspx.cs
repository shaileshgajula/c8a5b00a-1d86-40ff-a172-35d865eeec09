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
using StrongerOrg.Backoffice.DataLayer;
using System.Globalization;

namespace StrongerOrg.Backoffice
{
    public partial class Organisations : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string BuildUrl(object url, object id)
        {
            return (id == null) ? string.Empty : string.Format("{0}?OrgId={1}", url, id.ToString());
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            //this.SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            this.GridView1.DataBind();

        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            this.GridView1.DataBind();
        }

        protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            this.DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string organisationName = this.GridView1.SelectedDataKey["Name"].ToString();
            string organisationId = this.GridView1.SelectedDataKey["Id"].ToString();
            Response.Cookies["OrganisationId"].Value = organisationId;
            this.Master.OrganisationName = organisationName;
            this.Master.OrganisationId = organisationId;
        }
        private void SaveLogoFile(string newFileName)
        {
            FileUpload fu = (FileUpload)this.DetailsView1.FindControl("fuCompanyLogo");
            HttpPostedFile postedFile = fu.PostedFile;
            if (postedFile != null)
            {
                int contentLength = postedFile.ContentLength;
                string contentType = postedFile.ContentType;
                string fullFileName = Server.MapPath("~\\OrganisationLogos\\" + newFileName);
                //string fullFileName = string.Format(@"D:\Hosting\4756624\html\OrganisationLogos\{0}", newFileName);
                postedFile.SaveAs(fullFileName);
            }
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            //List<CultureInfo> x = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(c => c.Name.ToLower().Contains("uk")).ToList();

            if (e.Values["FileName"] != null)
            {
                string fileName = e.Values["FileName"].ToString();
                string newFileName = string.Format("{0}{1}{2}", Path.GetFileNameWithoutExtension(fileName),
                        Guid.NewGuid().ToString().Substring(0, 5), Path.GetExtension(fileName));
                e.Values["FileName"] = newFileName;
                SaveLogoFile(newFileName);
            }
            DropDownList cultures = this.DetailsView1.FindControl("ddlCountries") as DropDownList;
            string cultureInfoName = cultures.SelectedValue;
            e.Values["CultureInfoName"] = cultureInfoName;
            //using (TournaDataContext db = new TournaDataContext())
            //{
            //    Guid organisationId = Master.OrgBasicInfo.Id;
            //    IEnumerable<OrganisationHoliday> defaultHolidays = (from holidays in db.DefaultHolidays
            //                          where holidays.CultureInfoName == cultureInfoName
            //                                                            select holidays).ToList().Select
            //                                                            (holidays=> new OrganisationHoliday() { Name = holidays.Name, Date = holidays.Date, OrganisationId = organisationId });
                                      
            //    db.OrganisationHolidays.InsertAllOnSubmit(defaultHolidays);
            //    db.SubmitChanges();
            //}
        }

        protected void lbRemove_Click(object sender, EventArgs e)
        {
            Image orgLogo = this.DetailsView1.FindControl("Image1") as Image;
            File.Delete(Server.MapPath(orgLogo.ImageUrl));
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("OragnisationLogoRemove", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@OrganisationId", SqlDbType.UniqueIdentifier, 50).Value = new Guid(this.GridView1.SelectedDataKey[0].ToString());
                conn.Open();
                command.ExecuteNonQuery();
                orgLogo.Visible = false;
                LinkButton lb = sender as LinkButton;
                lb.Visible = false;
                FileUpload fileUpload = this.DetailsView1.FindControl("fuCompanyLogo") as FileUpload;
                fileUpload.Visible = true;
            }
        }

        public string SetCompanyLogo(object organisationLogo)
        {
            if (string.IsNullOrEmpty(organisationLogo.ToString()))
            {
                Image orgLogo = this.DetailsView1.FindControl("Image1") as Image;
                orgLogo.Visible = false;
                return string.Empty;
            }
            else
            {
                return string.Format("~/OrganisationLogos/{0}", organisationLogo.ToString());
            }
        }

        public string UpdateOrgLogo(object organisationLogo)
        {
            FileUpload fileUpload = this.DetailsView1.FindControl("fuCompanyLogo") as FileUpload;
            LinkButton linkButton = this.DetailsView1.FindControl("lbRemove") as LinkButton;
            Image orgLogo = this.DetailsView1.FindControl("Image1") as Image;
            if (string.IsNullOrEmpty(organisationLogo.ToString()))
            {
                orgLogo.Visible = false;
                fileUpload.Visible = true;
                linkButton.Visible = false;
                return string.Empty;
            }
            else
            {
                orgLogo.Visible = true;
                fileUpload.Visible = false;
                linkButton.Visible = true;
                return string.Format("~/OrganisationLogos/{0}", organisationLogo.ToString());
            }
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            if (e.NewValues["FileName"] != null)
            {
                string fileName = e.NewValues["FileName"].ToString();
                string newFileName = string.Format("{0}{1}{2}", Path.GetFileNameWithoutExtension(fileName),
                        Guid.NewGuid().ToString().Substring(0, 5), Path.GetExtension(fileName));
                e.NewValues["FileName"] = newFileName;
                SaveLogoFile(newFileName);
            }
        }
    }
}
