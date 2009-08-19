using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using StrongerOrg.Backoffice.DataLayer;

namespace StrongerOrg.BackOffice.PairsAlgorithm
{
    internal class AlphabeticalPairs : IPairsAlgo
    {
        #region IPairsAlgo Members

        public List<MetaPlayer> Execute(Guid tournamentId)
        {
            //argument check
            if (tournamentId.Equals(Guid.Empty))
                throw new ArgumentNullException("tournamentId");

            List<MetaPlayer> players = null;
            using (TournaDataContext db = new TournaDataContext())
            {
                players = db.PlayersGet(null, tournamentId)
                            .Select(p => new MetaPlayer()
                            {
                                Id = p.Id,
                                PlayerName = p.Name
                            }).ToList();
            }

            return players;
        }

        #endregion
    }

}