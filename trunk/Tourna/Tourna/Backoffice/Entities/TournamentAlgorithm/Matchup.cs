using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.Backoffice.Entities.TournamentAlgorithm
{
    [Serializable]
    public class Matchup
    {
        public int MatchUpId { get; set; }
        public int Round { get; set; }
        public string PlayerA { get; set; }
        public Guid PlayerAId { get; set; }
        public string PlayerB { get; set; }
        public Guid PlayerBId { get; set; }
        public int NextMatchId { get; set; }
        public int HouseSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ScoreA { get; set; }
        public int? ScoreB { get; set; }
        public int WinnerId { get; set; }
        public string MatchupId { get; set; }
    }
}