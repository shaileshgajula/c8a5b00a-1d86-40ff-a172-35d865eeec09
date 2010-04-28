using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System;
using StrongerOrg.Backoffice.DataLayer;
using System.Linq;
public class TournamentManager
{
    //public static void BuildTournament()
    //{ 

    //}

    internal static string BuildTournament(Guid organisationId, string tournamentName, string tournamentAbstract, string locations,
        int numberOfPlayersLimit, int gameId, string matchingAlgo,int gamesPerDay, int timeWindowStart, int timeWindowEnd, bool isOpenAllDay,
        string firstPrize, string secondPrize, string thirdPrize, DateTime startDate, DateTime lastRegistrationDate)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            SqlCommand command = new SqlCommand("TournamentInsert", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@TournamentName", SqlDbType.NVarChar, 150).Value = tournamentName;
            command.Parameters.Add("@OrganisationId", SqlDbType.UniqueIdentifier).Value = organisationId;
            command.Parameters.Add("@Abstract", SqlDbType.NVarChar, 150).Value = tournamentAbstract;
            command.Parameters.Add("@Locations", SqlDbType.NVarChar, 150).Value = locations;
            command.Parameters.Add("@NumberOfPlayersLimit", SqlDbType.Int, 4).Value = numberOfPlayersLimit;
            command.Parameters.Add("@GameId", SqlDbType.Int, 4).Value = gameId;
            command.Parameters.Add("@MatchingAlgo", SqlDbType.NVarChar, 150).Value = matchingAlgo;
            command.Parameters.Add("@GamesPerDay", SqlDbType.Int).Value = gamesPerDay;
            command.Parameters.Add("@TimeWindowStart", SqlDbType.Int, 4).Value = timeWindowStart;
            command.Parameters.Add("@TimeWindowEnd", SqlDbType.Int, 4).Value = timeWindowEnd;
            command.Parameters.Add("@IsOpenAllDay", SqlDbType.Bit).Value = isOpenAllDay;
            command.Parameters.Add("@FirstPrize", SqlDbType.NVarChar, 150).Value = firstPrize;
            command.Parameters.Add("@SecondPrize", SqlDbType.NVarChar, 150).Value = secondPrize;
            command.Parameters.Add("@ThirdPrize", SqlDbType.NVarChar, 150).Value = thirdPrize;
            command.Parameters.Add("@LastRegistrationDate", SqlDbType.DateTime).Value = lastRegistrationDate;
            command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
           
            command.Parameters.Add("@TournamentId", SqlDbType.UniqueIdentifier).Direction = ParameterDirection.Output;
            conn.Open();
            command.ExecuteNonQuery();
            string tournamentId = command.Parameters["@TournamentId"].Value.ToString();
            return tournamentId;
        }
    }

    internal static string GetTournamentEmailTemplate(string tournamentId)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            SqlCommand command = new SqlCommand("Select EmailTemplate from Tournaments where Id='" + tournamentId + "'", conn);
            command.CommandType = System.Data.CommandType.Text;
            conn.Open();
            object result = command.ExecuteScalar();
            if (result != null)
            {
                return result.ToString();
            }
            else
            {
                return string.Empty;
            }

        }
    }
    //internal static string UpdateTournamentEmailTemplate(string tournamentId)
    //{
    //    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("Update Tournaments where Id='" + tournamentId + "'", conn);
    //        command.CommandType = System.Data.CommandType.Text;
    //        conn.Open();
    //        object result = command.ExecuteScalar();
    //        if (result != null)
    //        {
    //            return result.ToString();
    //        }
    //        else
    //        {
    //            return string.Empty;
    //        }

    //    }
    //}

    internal static void UpdateEmailTemplate(string tournamentId, string emailTemplate)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            SqlCommand command = new SqlCommand("TournamentEmailTemplateUpdate", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TournamentId", SqlDbType.NVarChar).Value = tournamentId;
            command.Parameters.Add("@EmailTemplate", SqlDbType.Text).Value = emailTemplate;
            conn.Open();
            command.ExecuteNonQuery();
        }
    }

    internal static bool IsTournamentOpen(Guid orgId, Guid tournamentId)
    {
        using (TournaDataContext db = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            Tournament tournament = db.Tournaments.Single(t => t.Id == tournamentId && t.StartDate >= DateTime.Now
                && t.IsTournamentOver == false
                && t.NumberOfPlayersLimit >= db.Players2Tournaments.Where(p2t => p2t.TournamentId == tournamentId).Count());
            return (tournament != null);
        }
    }

    internal static DateTime GetTournamentStartDate(Guid tournamentId)
    {
        using (TournaDataContext db = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            DateTime d = (from t in db.Tournaments
                          where t.Id == tournamentId
                          select t.StartDate).SingleOrDefault<DateTime>();
            return d;
        }
    }

    internal static string GetTournamentName(Guid tournamentId)
    {
        using (TournaDataContext db = new TournaDataContext())
        {
            string tournamentName = db.Tournaments.Single(t => t.Id == tournamentId).TournamentName;
            return tournamentName;
        }
    }
}