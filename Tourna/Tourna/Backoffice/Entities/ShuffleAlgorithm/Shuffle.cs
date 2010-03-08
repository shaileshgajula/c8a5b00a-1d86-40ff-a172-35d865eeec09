using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.BL.ShuffleAlgorithm
{
    public class Shuffle<T>
    {
        internal static IShuffle<T> TournamentFactory(ShuffleTypes st)
        {
            switch (st)
            {
                case ShuffleTypes.Random:
                    return new RandomShuffle<T>();
                case ShuffleTypes.Alphabetical:
                    return new AlphabeticalShuffle<T>();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}