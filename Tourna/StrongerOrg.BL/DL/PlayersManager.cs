using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrongerOrg.BL.TournamentAlgorithm;
using System.Configuration;

namespace StrongerOrg.BL.DL
{
    class PlayersManager
    {
        internal static List<Competitor> GetPlayers(Guid tournamentId)
        {
            TournamentsDataContext tournamentDC = new TournamentsDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString);
            var players = from p2t in tournamentDC.Players2Tournaments
                          join p in tournamentDC.Players on p2t.PlayerId equals p.Id
                          where p2t.TournamentId == tournamentId
                          select new Competitor()
                          {
                              Id = p2t.PlayerId,
                              Name = p.Name,
                          };
            return players.ToList();
        }
    }
}
