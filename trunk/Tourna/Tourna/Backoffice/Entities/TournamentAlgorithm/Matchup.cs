using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.Backoffice.TournamentAlgorithm
{
    [Serializable]
    public class Matchup
    {
        public Guid TournamentId { get; set; }
        public int MatchupId { get; set; }
        public int Round { get; set; }
        public string PlayerA { get; set; }
        public Guid PlayerAId { get; set; }
        public string PlayerB { get; set; }
        public Guid PlayerBId { get; set; }
        public int NextMatchId { get; set; }
        public int HouseSize { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int? ScoreA { get; set; }
        public int? ScoreB { get; set; }
        public int WinnerId { get; set; }
        
    }
}