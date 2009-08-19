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
            return BuildPairs(tournamentId, PairsAlgorithm.Alphabetical); //default to Alphabetical
        }
        public static List<PlayersEntity> BuildPairs(Guid tournamentId, PairsAlgorithm type)
        {
            return BuildPairs(tournamentId, type, PairsMatchType.Default);
        }

        public static List<PlayersEntity> BuildPairs(Guid tournamentId, PairsAlgorithm type, PairsMatchType pairsMatchingType)
        {
            return BuildPairs(tournamentId, type, PairsMatchType.Default, 1);
        }

        public static List<PlayersEntity> BuildPairs(Guid tournamentId, PairsAlgorithm type, PairsMatchType pairsMatchingType, int numOfRounds)
        {
            IPairsAlgo algorithm = PairsAlgo.PairsAlgorithmFactory(type);
            List<MetaPlayer> listPlayers = algorithm.Execute(tournamentId);
            
            //match up
            IPairMatching matcher = PairsMatch.MatchPlayersFactory(pairsMatchingType);
            List<PlayersEntity> playerPairs = matcher.Execute(listPlayers, numOfRounds);

            return playerPairs;
        }

        private static IPairsAlgo PairsAlgorithmFactory(PairsAlgorithm type)
        {
            switch (type)
            {
                case PairsAlgorithm.Alphabetical:
                    return new AlphabeticalPairs();
                case PairsAlgorithm.Random:
                    return new RandomPairs();
                default:
                    return new AlphabeticalPairs();
            }
        }

    }

    internal class MetaPlayer
    {
        public Guid Id { get; set; }
        public string PlayerName { get; set; }
    }

}