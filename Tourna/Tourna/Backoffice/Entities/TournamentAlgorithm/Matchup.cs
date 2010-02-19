using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.Backoffice.Entities.TournamentAlgorithm
{
    public class Matchup
    {
        public int MatchUpId { get; set; }
        public int Round { get; set; }
        public string PlayerA { get; set; }
        public string PlayerB { get; set; }
        public int NextMatchId { get; set; }
        public int HouseSize { get; set; }
        public DateTime StartDate { get; set; }
    }
}