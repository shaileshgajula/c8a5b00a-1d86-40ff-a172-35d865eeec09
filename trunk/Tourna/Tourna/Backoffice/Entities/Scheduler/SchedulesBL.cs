using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace StrongerOrg.BackOffice.Scheduler
{
    public class SchedulesBL
    {
        internal static void ScheduleInsert(Guid tournamentId, Guid playerA, Guid playerB, DateTime sd, DateTime ed)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("ScheduleInseret", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@TournamentId", SqlDbType.UniqueIdentifier).Value = tournamentId;
                command.Parameters.Add("@PlayerA", SqlDbType.UniqueIdentifier).Value = playerA;
                command.Parameters.Add("@PlayerB", SqlDbType.UniqueIdentifier).Value = playerB;
                command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = sd;
                command.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = ed;
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}