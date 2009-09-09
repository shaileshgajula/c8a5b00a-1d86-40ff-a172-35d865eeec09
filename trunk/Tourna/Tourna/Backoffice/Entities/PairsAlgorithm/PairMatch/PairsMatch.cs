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
                case PairsMatchType.Bracket:
                    return new DefaultMatch();
                case PairsMatchType.MultiGame:
                    return new MultiMatch();
                default:
                    return new DefaultMatch();
            }
        }
    }

    public enum PairsMatchType
    {
        Bracket,
        MultiGame
    }
}
