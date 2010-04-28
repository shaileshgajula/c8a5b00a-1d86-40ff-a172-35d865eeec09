using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StrongerOrg.BackOffice.PairsAlgorithm;
using StrongerOrg.Backoffice.DataLayer;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace StrongerOrg.Backoffice.Entities
{
    public class PlayerManager
    {
        public PairsMatchType MatchType
        {
            get; set;
        }

        public PairsAlgorithmType AlgoType
        {
            get; set;
        }
        
        public PlayerManager()
        {
            //get list of players
        }

        public IEnumerable<PlayersEntity> BuildPairs(Guid tournaId)
        {
            //check length of players
            List<MetaPlayer> playersList = PairsAlgo.GetPlayers(tournaId, this.AlgoType);
            //int count = playersList.Count();
            //int numOfRounds = 2;

           // if (count >= 32)
              int   numOfRounds = 1;

            return PairsAlgo.BuildPairs(tournaId, this.MatchType, playersList, numOfRounds);
        }
        public int DeleteTournamentPlayers(Guid tournamentId)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand delCmd = new SqlCommand("PlayersTournamentDelete", conn);
                delCmd.CommandType = CommandType.StoredProcedure;
                delCmd.Parameters.Add("@TournamentId", SqlDbType.UniqueIdentifier).Value = tournamentId;
                delCmd.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                conn.Open();
                delCmd.ExecuteNonQuery();
                int rowsEffected = int.Parse(delCmd.Parameters["@return_value"].Value.ToString());
                return rowsEffected;
            }
        }
    }
}
