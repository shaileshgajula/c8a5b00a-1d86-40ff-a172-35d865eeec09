using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
public class PairsAlgo
{
    public static List<PlayersEntity> BuildPairs(Guid tournamentId)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
        {
            SqlCommand command = new SqlCommand("PlayersGet", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TournamentId", SqlDbType.UniqueIdentifier, 150).Value = tournamentId;
            command.Parameters.Add("@OrganisationId", SqlDbType.UniqueIdentifier, 150).Value = DBNull.Value;
            conn.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
            List<PlayersEntity> pairs = new List<PlayersEntity>(32);
            while (reader.Read())
            {
                Guid playerA = reader.GetGuid(0);
                string playerAName = reader.GetString(1);

                if (reader.Read())
                {
                    Guid playerB = reader.GetGuid(0);
                    string playerBName = reader.GetString(1);
                    pairs.Add(new PlayersEntity() { PlayerAId = playerA, PlayerBId = playerB, PlayerAName = playerAName, PlayerBName = playerBName });
                }
                else
                {
                    pairs.Add(new PlayersEntity() { PlayerAId = playerA, PlayerBId = Guid.Empty, PlayerAName = playerAName, PlayerBName = "Computer" });
                }
            }
            return pairs;

        }
    }
    public class PlayersEntity
    {
        public Guid PlayerAId { get; set; }
        public Guid PlayerBId { get; set; }
        public string PlayerAName { get; set; }
        public string PlayerBName { get; set; }
    }
}