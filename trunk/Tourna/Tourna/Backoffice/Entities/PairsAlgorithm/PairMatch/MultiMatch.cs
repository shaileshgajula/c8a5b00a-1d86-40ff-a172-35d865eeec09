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
            int numOfCompetitors = playerList.Count;

            if (playerList == null)
                throw new ArgumentNullException("competitorList is null");
            if (numOfCompetitors == 0)
                throw new ArgumentException("Players list is too small");
            if (numOfRounds > numOfCompetitors / 2)
                throw new ArgumentException("Number of rounds exceeds given players list");


            if (numOfCompetitors % 2 != 0)
                playerList.Add(new MetaPlayer() { Id = Guid.Empty, PlayerName = "Computer" });

            //split the list in half.
            int halfPlayerCount = numOfCompetitors / 2;
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
