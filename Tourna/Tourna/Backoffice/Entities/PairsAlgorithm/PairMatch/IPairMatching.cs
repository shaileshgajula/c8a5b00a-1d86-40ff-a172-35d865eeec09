using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.BackOffice.PairsAlgorithm
{
    internal interface IPairMatching
    {
        List<PlayersEntity> Execute(List<MetaPlayer> competitorList, int numOfRounds);
    }
}
