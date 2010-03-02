using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using StrongerOrg.Backoffice.DataLayer;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
[DataObjectAttribute(true)]
public class TextContentManager
{
    internal static string GetTextContent(Guid organisationId, string contentType)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            SqlCommand command = new SqlCommand("TextContentGet", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OrganisationId", SqlDbType.UniqueIdentifier, 150).Value = organisationId;
            command.Parameters.Add("@ContentType", SqlDbType.NVarChar, 150).Value = contentType;
            conn.Open();
            object rules = command.ExecuteScalar();
            if (rules != null)
            {
                return rules.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    internal static void TextContentInsert(Guid orgId, string contentType, string caption, string content)
    {
        using (TournaDataContext db = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            db.TextContents.InsertOnSubmit(new TextContent() { Caption = caption, ContentType = contentType, Content = content, OrganisationId = orgId, CreateDate=DateTime.Now });
            db.SubmitChanges();
        }
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select)]
    public List<TextContentItem> GetTextContents(string orgId, string contentType)
    {
        Guid organisationId = new Guid(orgId);
        using (TournaDataContext db = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            var z = from tc in db.TextContents
                    where tc.OrganisationId == organisationId && tc.ContentType == contentType
                    orderby tc.CreateDate descending
                    select new TextContentItem { Id = tc.Id, Caption = tc.Caption, Content = tc.Content, 
                        CreateDate = tc.CreateDate.ToShortDateString() };
            return z.ToList();
        }
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Delete)]
    public void DeleteTextContents(int Id)
    {
        using (TournaDataContext db = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            db.ExecuteCommand("Delete from TextContent where id={0}", Id);
        }
    }

    public class TextContentItem
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Content { get; set; }
        public string CreateDate { get; set; }
    }
}