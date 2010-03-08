using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace  StrongerOrg.BL.TournamentAlgorithm
{
    public class TournamentFactory
    {
        internal static ITournament GetInstance(TournamentTypes tt)
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