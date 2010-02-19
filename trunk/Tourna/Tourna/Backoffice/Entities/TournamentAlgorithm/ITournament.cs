using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongerOrg.Backoffice.Entities.TournamentAlgorithm
{
    interface ITournament
    {
        List<Matchup> Execute(List<Competitor> compList);
    }
}
