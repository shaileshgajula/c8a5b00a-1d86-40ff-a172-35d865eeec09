using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System;
namespace StrongerOrg.Backoffice.Entities
{
    [System.ComponentModel.DataObject]
    public class ManageUsers
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
    }

}