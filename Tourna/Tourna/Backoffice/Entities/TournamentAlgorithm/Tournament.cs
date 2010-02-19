using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.Backoffice.Entities.TournamentAlgorithm
{
    public class Tournament
    {
        internal static ITournament TournamentFactory(TournamentTypes tt)
        {
            switch (tt)
            {
                case TournamentTypes.SingleElimination:
                    return new SingleElimination();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}