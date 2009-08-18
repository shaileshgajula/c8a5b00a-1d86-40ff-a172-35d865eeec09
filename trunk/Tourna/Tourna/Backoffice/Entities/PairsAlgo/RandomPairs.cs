using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Tourna.Backoffice.DataLayer;


    public class RandomPairs : IPairsAlgo
    {
        #region IPairsAlgo Members

        public List<PlayersEntity> Execute(Guid tournamentId)
        {
            //argument check
            if (tournamentId.Equals(Guid.Empty))
                throw new ArgumentNullException("tournamentId");

            //use LINQ to order?
            //will we be using LINQ?
            //convert datareader to LINQ using yield keyword.
            List<Guid> players;
            using (TournaDataContext db = new TournaDataContext())
            {
                players = db.PlayersGet(null, tournamentId).OrderBy(x => x.Id).Select( p => p.Id).ToList();
            }

            List<PlayersEntity> pairs = new List<PlayersEntity>();
            int length = players.Count;
            if (length % 2 != 0)
                players.Add(Guid.Empty);
            
            int halfLength = players.Count / 2;
            for (int i = 0; i < halfLength; i++)
            {
                PlayersEntity pair = new PlayersEntity()
                {
                    PlayerAId = players[i],
                    PlayerBId = players[i + halfLength]
                };

                pairs.Add(pair);
            }


            return pairs;
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

