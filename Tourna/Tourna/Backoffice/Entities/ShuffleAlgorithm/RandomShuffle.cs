using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StrongerOrg.Backoffice.Entities.TournamentAlgorithm;

namespace StrongerOrg.Backoffice.Entities.ShuffleAlgorithm
{
    public class RandomShuffle<T>:IShuffle<T>
    {
        public List<T> Execute(List<T> list)
        {
            Random rnd = new Random();
            List<T> randomizedList = (from item in list
                                 orderby rnd.Next()
                                 select item).ToList();
            return randomizedList;
        }
    }
}