using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.BackOffice.PairsAlgorithm
{
    public class MultiMatch : IPairMatching
    {
        #region IPairMatching Members

        public List<PlayersEntity> Execute(List<MetaPlayer> playerList, int numOfRounds)
        {
            int numOfPlayers = playerList.Count;

            if (playerList == null)
                throw new ArgumentNullException("playerList");
            if (numOfPlayers == 0)
                throw new ArgumentException("Players list is too small");
            if (numOfRounds > numOfPlayers / 2)
                throw new ArgumentException("Number of rounds exceeds given players list");


            if (numOfPlayers % 2 != 0)
                playerList.Add(new MetaPlayer() { Id = Guid.Empty, PlayerName = "Computer" });

            //split the list in half.
            int halfPlayerCount = numOfPlayers / 2;
            IEnumerable<MetaPlayer> topHalf = playerList.Take(halfPlayerCount);
            MetaPlayer[] bottomHalf = playerList.Skip(halfPlayerCount).Take(halfPlayerCount).ToArray();

            List<PlayersEntity> pairs = new List<PlayersEntity>();
            for (int i = 0; i < numOfRounds; i++)
            {
                pairs.AddRange(topHalf.Select(
                                                (x, index) => new PlayersEntity()
                                                                  {
                                                                      PlayerAId = x.Id,
                                                                      PlayerAName = x.PlayerName,
                                                                      PlayerBId = bottomHalf[index].Id,
                                                                      PlayerBName = bottomHalf[index].PlayerName
                                                                  }
                                              ));
                bottomHalf = ShiftRight(bottomHalf);
            }

            return pairs;
        }

        private T[] ShiftRight<T>(T[] array)
        {
            //shift to the right
            T tempItem = array[array.Length - 1];
            Array.Copy(array, 0, array, 1, array.Length - 1);
            array[0] = tempItem;

            return array;
        }

        #endregion
    }
}
