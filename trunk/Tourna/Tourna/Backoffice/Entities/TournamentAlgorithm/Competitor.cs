using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.Backoffice.TournamentAlgorithm
{
    [Serializable]
    public class Competitor
    {
        int round = 1;
        public string Name { get; set; }
        public int Round { get { return round; } set { this.round = value; } }
        public bool IsBye { get; set; }
        public Guid Id { get; set; }

    }
}