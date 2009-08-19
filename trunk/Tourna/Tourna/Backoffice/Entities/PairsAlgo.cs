using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;


namespace StrongerOrg.BackOffice.PairsAlgorithm
{
    public class PairsAlgo
    {
        public static List<PlayersEntity> BuildPairs(Guid tournamentId)
        {
            return BuildPairs(tournamentId, PairsAlgorithm.ALPHABETICAL); //default to Alphabetical
        }
        public static List<PlayersEntity> BuildPairs(Guid tournamentId, PairsAlgorithm type)
        {
            IPairsAlgo algorithm = PairsAlgo.PairsAlgorithmFactory(type);
            List<PlayersEntity> listPlayers = algorithm.Execute(tournamentId);

            return listPlayers;
        }

        private static IPairsAlgo PairsAlgorithmFactory(PairsAlgorithm type)
        {
            switch (type)
            {
                case PairsAlgorithm.ALPHABETICAL:
                    return new AlphabeticalPairs();
                case PairsAlgorithm.RANDOM:
                    return new RandomPairs();
                default:
                    return new AlphabeticalPairs();
            }
        }

    }
}