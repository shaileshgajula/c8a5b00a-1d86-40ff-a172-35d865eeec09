using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StrongerOrg.BackOffice.PairsAlgorithm;

namespace StrongerOrg.Backoffice.Entities
{
    public class PlayerManager
    {
        public PairsMatchType MatchType
        {
            get; set;
        }

        public PairsAlgorithmType AlgoType
        {
            get; set;
        }
        
        public PlayerManager()
        {
            //get list of players
        }

        public IEnumerable<PlayersEntity> BuildPairs(Guid tournaId)
        {
            //check length of players
            List<MetaPlayer> playersList = PairsAlgo.GetPlayers(tournaId, this.AlgoType);
            int count = playersList.Count();
            int numOfRounds = 2;

            if (count >= 32)
                numOfRounds = 1;

            return PairsAlgo.BuildPairs(tournaId, this.MatchType, playersList, numOfRounds);
        }
    }
}
