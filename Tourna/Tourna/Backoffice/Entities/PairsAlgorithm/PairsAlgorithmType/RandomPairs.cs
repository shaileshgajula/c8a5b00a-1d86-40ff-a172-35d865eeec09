using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using StrongerOrg.Backoffice.DataLayer;


namespace StrongerOrg.BackOffice.PairsAlgorithm
{
    internal class RandomPairs : IPairsAlgo
    {
        #region IPairsAlgo Members

        public List<MetaPlayer> Execute(Guid tournamentId)
        {
            //argument check
            if (tournamentId.Equals(Guid.Empty))
                throw new ArgumentNullException("tournamentId");

            //use LINQ to order?
            //will we be using LINQ?
            //convert datareader to LINQ using yield keyword.
            List<MetaPlayer> players = null;
            using (TournaDataContext db = new TournaDataContext())
            {
                players = db.PlayersGet(null, tournamentId)
                            .OrderBy(x => x.Id)
                            .Select(p => new MetaPlayer(){
                                                            Id = p.Id,
                                                            PlayerName = p.Name
                                                         }).ToList();
            }

            return players;
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

}