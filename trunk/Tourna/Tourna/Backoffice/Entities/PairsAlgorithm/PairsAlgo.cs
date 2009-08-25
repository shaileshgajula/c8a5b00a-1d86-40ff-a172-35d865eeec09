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
            return BuildPairs(tournamentId, PairsAlgorithmType.Alphabetical); //default to Alphabetical
        }
        public static List<PlayersEntity> BuildPairs(Guid tournamentId, PairsAlgorithmType type)
        {
            return BuildPairs(tournamentId, type, PairsMatchType.Default);
        }

        public static List<PlayersEntity> BuildPairs(Guid tournamentId, PairsAlgorithmType type, PairsMatchType pairsMatchingType)
        {
            return BuildPairs(tournamentId, type, PairsMatchType.Default, 1);
        }

        public static List<PlayersEntity> BuildPairs(Guid tournamentId, PairsAlgorithmType type, PairsMatchType pairsMatchingType, int numOfRounds)
        {

            List<MetaPlayer> listPlayers = GetPlayers(tournamentId, type);
            List<PlayersEntity> pairs = BuildPairs(tournamentId, pairsMatchingType, listPlayers, numOfRounds);
            //match up

            return pairs;
        }

        public static List<PlayersEntity> BuildPairs(Guid tournamentId, PairsMatchType type, List<MetaPlayer> players, int numOfRounds)
        {
            IPairMatching matcher = PairsMatch.MatchPlayersFactory(type);
            List<PlayersEntity> playerPairs = matcher.Execute(players, numOfRounds);

            return playerPairs;
        }

        public static List<MetaPlayer> GetPlayers(Guid tournamentId, PairsAlgorithmType type)
        {
            IPairsAlgo algorithm = PairsAlgo.PairsAlgorithmFactory(type);
            List<MetaPlayer> listPlayers = algorithm.Execute(tournamentId);

            return listPlayers;
        }

       

        private static IPairsAlgo PairsAlgorithmFactory(PairsAlgorithmType type)
        {
            switch (type)
            {
                case PairsAlgorithmType.Alphabetical:
                    return new AlphabeticalPairs();
                case PairsAlgorithmType.Random:
                    return new RandomPairs();
                default:
                    return new AlphabeticalPairs();
            }
        }

    }

    public class MetaPlayer
    {
        public Guid Id { get; set; }
        public string PlayerName { get; set; }
    }

}