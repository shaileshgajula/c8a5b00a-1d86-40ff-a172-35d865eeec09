using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


    public class RandomPairs : IPairsAlgo
    {
        #region IPairsAlgo Members

        public List<PlayersEntity> Execute(Guid tournamentId)
        {
            //argument check
            if (tournamentId == null)
                throw new ArgumentNullException("tournamentId");

            //use LINQ to order?
            //will we be using LINQ?
            //convert datareader to LINQ using yield keyword.

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

        #endregion
    }

    //public static class DataReaderExtension
    //{
    //    public static IEnumerable<Object[]> DataRecord(this System.Data.IDataReader source)
    //    {
    //        if (source == null)
    //            throw new ArgumentNullException("source");

    //        while (source.Read())
    //        {
    //            Object[] row = new Object[source.FieldCount];
    //            source.GetValues(row);
    //            yield return row;
    //        }
    //    }
    //}

