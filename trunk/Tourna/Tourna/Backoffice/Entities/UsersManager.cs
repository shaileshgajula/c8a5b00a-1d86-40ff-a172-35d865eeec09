using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Data;
namespace StrongerOrg.Backoffice.Entities
{
    [System.ComponentModel.DataObject]
    public class UsersManager
    {
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select)]
        public MembershipUserCollection FindUsers(string searchKey, string searchByKey) 
        {
            switch (searchByKey)
            {
                case "User":
                    return Membership.FindUsersByName(searchKey);
                case "Email":
                    return Membership.FindUsersByEmail(searchKey);
                case "OrganisationName":
                    return this.FindUsersByOrganisationName(searchKey);
                default:
                    return Membership.GetAllUsers();
            }
        }
        
        private MembershipUserCollection FindUsersByOrganisationName(string organisationNameToMatch)
        {
            MembershipUserCollection users = new MembershipUserCollection();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = conn;
                command.CommandText = "FindUsersByOrganisationName";
                command.Parameters.Add("@OrganisationNameToMatch", System.Data.SqlDbType.NVarChar, 150).Value = organisationNameToMatch;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    string nullableString = GetNullableString(reader, 0);
                    string email = GetNullableString(reader, 1);
                    string passwordQuestion = GetNullableString(reader, 2);
                    string comment = GetNullableString(reader, 3);
                    bool boolean = reader.GetBoolean(4);
                    DateTime creationDate = reader.GetDateTime(5).ToLocalTime();
                    DateTime lastLoginDate = reader.GetDateTime(6).ToLocalTime();
                    DateTime lastActivityDate = reader.GetDateTime(7).ToLocalTime();
                    DateTime lastPasswordChangedDate = reader.GetDateTime(8).ToLocalTime();
                    Guid providerUserKey = reader.GetGuid(9);
                    bool isLockedOut = reader.GetBoolean(10);
                    DateTime lastLockoutDate = reader.GetDateTime(11).ToLocalTime();
                    users.Add(new MembershipUser("CustomizedProvider", nullableString, providerUserKey, email, passwordQuestion, comment, boolean, isLockedOut, creationDate, lastLoginDate, lastActivityDate, lastPasswordChangedDate, lastLockoutDate));
                }
            }
            return users;
        }
        private static string GetNullableString(SqlDataReader reader, int col)
        {
            if (!reader.IsDBNull(col))
            {
                return reader.GetString(col);
            }
            return null;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete)]
        public void DeleteUser(string userName)
        {
            Membership.DeleteUser(userName);
        }

        public static Guid GetOrganisationId(string userName)
        {
            string organisationId = string.Empty;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("OrganisationIdByUserNameGet", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar, 255).Value = userName;
                conn.Open();
                organisationId = command.ExecuteScalar().ToString();
            }
            return new Guid(organisationId);
        }

        internal static void UpdateUserOrganisationId(string userName, Guid organisationId)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("UserOrganisationIdUpdate", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar, 256).Value = userName;
                command.Parameters.Add("@OrganisationId", System.Data.SqlDbType.UniqueIdentifier).Value = organisationId;
                conn.Open();
                int resultCount = command.ExecuteNonQuery();
                
            }
            
        }
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select)]
        public DataTable GetOrganisationUsers(string organisationId)
        { 
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                DataTable result = new DataTable();
                SqlCommand command = new SqlCommand("OrganisationUsersGet", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@OrganisationId", SqlDbType.VarChar).Value = organisationId;
                conn.Open();
                result.Load(command.ExecuteReader());
                return result;
            }
        }
    }

}