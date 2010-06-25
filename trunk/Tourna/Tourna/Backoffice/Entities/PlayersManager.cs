using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;
using StrongerOrg.Backoffice.DataLayer;
using System.Linq;
using System.Collections.Generic;

public class PlayersManager
{


    internal static void InsertPlayer(string organisationId, string name, char competitorType, string email, string department, string tournamentId)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.CommandText = "PlayerInsert";
            command.Parameters.Add("@OrganisationId", SqlDbType.NVarChar, 150).Value = organisationId;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = name;
            command.Parameters.Add("@CompetitorType", SqlDbType.Char).Value = competitorType;
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = email;
            command.Parameters.Add("@Department", SqlDbType.NVarChar, 150).Value = department;
            command.Parameters.Add("@TournamentId", SqlDbType.NVarChar, 150).Value = tournamentId;
            conn.Open();
            int returnCount = command.ExecuteNonQuery();
        }
    }
    internal static void InsertTeamPlayer(string organisationId, string name, char competitorType, string email, string tournamentId, string teamId)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.CommandText = "TeamPlayerInsert";
            command.Parameters.Add("@OrganisationId", SqlDbType.NVarChar, 150).Value = organisationId;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = name;
            command.Parameters.Add("@CompetitorType", SqlDbType.Char).Value = competitorType;
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = email;
            command.Parameters.Add("@TeamId", SqlDbType.VarChar,150).Value = teamId;
            command.Parameters.Add("@TournamentId", SqlDbType.NVarChar, 150).Value = tournamentId;
            conn.Open();
            int returnCount = command.ExecuteNonQuery();
        }
    }

    internal static void InsertTeam(string organisationId, string name, char competitorType, string tournamentId )
    {
          using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.CommandText = "TeamInsert";
            command.Parameters.Add("@OrganisationId", SqlDbType.NVarChar, 150).Value = organisationId;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = name;
            command.Parameters.Add("@CompetitorType", SqlDbType.Char).Value = competitorType;
            command.Parameters.Add("@TournamentId", SqlDbType.NVarChar, 150).Value = tournamentId;
            conn.Open();
            int returnCount = command.ExecuteNonQuery();
        }
    }
}