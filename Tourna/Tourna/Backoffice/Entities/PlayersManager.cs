using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;
using StrongerOrg.Backoffice.DataLayer;
using System.Linq;
using StrongerOrg.Backoffice.Entities.TournamentAlgorithm;
using System.Collections.Generic;

public class PlayersManager
{


    internal static void InsertPlayer(string organisationId, string name, string nickName, string email, string department, string tournamentId)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.CommandText = "PlayerInsert";
            command.Parameters.Add("@OrganisationId", SqlDbType.NVarChar, 150).Value = organisationId;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = name;
            command.Parameters.Add("@NickName", SqlDbType.NVarChar, 150).Value = nickName;
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = email;
            command.Parameters.Add("@Department", SqlDbType.NVarChar, 150).Value = department;
            command.Parameters.Add("@TournamentId", SqlDbType.NVarChar, 150).Value = tournamentId;
            conn.Open();
            int returnCount = command.ExecuteNonQuery();
        }
    }

    internal static List<Competitor> GetPlayers(Guid orgId, Guid tournamentId) 
    { 
        TournaDataContext tournamentDC = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString);
        var players = from p2t in tournamentDC.Players2Tournaments
                join p in tournamentDC.Players on p2t.PlayerId equals p.Id
                where p2t.TournamentId == tournamentId
                select new Competitor()
                {
                    Id = p2t.PlayerId,
                    Name= p.Name,
                };
        return players.ToList();
    }
}