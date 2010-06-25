using System;
using System.Data.SqlClient;
using System.Configuration;
using StrongerOrg.Backoffice.Entities.OrganisationInfoTableAdapters;
using StrongerOrg.Backoffice.Entities;
using StrongerOrg.Backoffice.DataLayer;
using System.Linq;
using System.Web.Security;
using System.Data;
public class OrganisationManager
{
    internal static OrganisationBasicInfo GetOrganisationInfo(Guid organisationId)
    {
        using (TournaDataContext db = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            IQueryable<OrganisationBasicInfo> orgBasicInfo = (from org in db.Organisations
                                                              where org.Id == organisationId
                                                              select new OrganisationBasicInfo { Id = org.Id, Name = org.Name, Active = org.Active, Logo = org.CompanyLogo });

            return orgBasicInfo.SingleOrDefault();
        }

    }
    public class OrganisationBasicInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Logo { get; set; }

    }

    internal static DataTable GetModeratorsEmail(string orgId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("OrgModeratorsEmailGet", connection);
            cmd.CommandType= System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrganisationId",System.Data.SqlDbType.UniqueIdentifier).Value = new Guid(orgId);
            connection.Open();
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            return tbl;  
        }
       
    }
}