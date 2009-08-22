using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace StrongerOrg.BackOffice.PairsAlgorithm
{
    internal class PairsMatch
    {
        internal static IPairMatching MatchPlayersFactory(PairsMatchType type)
        {
            switch(type)
            {
                case PairsMatchType.Default:
                    return new DefaultMatch();
                default:
                    return new DefaultMatch();
            }
        }
    }

    public enum PairsMatchType
    {
        Default
    }
}
