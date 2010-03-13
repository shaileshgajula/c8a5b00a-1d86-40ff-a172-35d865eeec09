using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrongerOrg.Backoffice.DataLayer;


namespace StrongerOrg.BL.TournamentAlgorithm
{
    interface ITournament
    {
        List<Matchup> Execute(List<Competitor> compList);
    }
}
