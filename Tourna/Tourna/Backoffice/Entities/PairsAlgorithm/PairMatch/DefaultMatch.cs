using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.BackOffice.PairsAlgorithm
{
    internal class DefaultMatch : IPairMatching
    {
        #region IPairMatching Members

        public List<PlayersEntity> Execute(List<MetaPlayer> playerList, int numOfRounds)
        {
            //
            //pair up the standard way. A - B - C - D - E - F = A-B, C-D, D-E, E-F
            int length = playerList.Count;
            
            //add a player to make it even
            if (length % 2 != 0)
                playerList.Add(new MetaPlayer() { Id = Guid.Empty, PlayerName = "Computer" });


            

            List<PlayersEntity> pairs = new List<PlayersEntity>();
            for (int i = 0; i < length; i += 2)
            {
                PlayersEntity pairUp = new PlayersEntity()
                {
                    PlayerAId = playerList[i].Id,
                    PlayerAName = playerList[i].PlayerName,
                    PlayerBId = playerList[i + 1].Id,
                    PlayerBName = playerList[i + 1].PlayerName
                };
                pairs.Add(pairUp);
            }


            return pairs;
        }

        #endregion
    }
}
