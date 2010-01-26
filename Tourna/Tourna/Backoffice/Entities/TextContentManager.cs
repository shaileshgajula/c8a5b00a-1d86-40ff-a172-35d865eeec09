using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
class TextContentManager
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
}