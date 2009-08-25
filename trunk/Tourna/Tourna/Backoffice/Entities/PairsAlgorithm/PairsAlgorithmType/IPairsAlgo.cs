using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.BackOffice.PairsAlgorithm
{
    internal interface IPairsAlgo
    {
        List<MetaPlayer> Execute(Guid tournamentId);
    }

    public class PlayersEntity
    {
        public Guid PlayerAId { get; set; }
        public Guid PlayerBId { get; set; }
        public string PlayerAName { get; set; }
        public string PlayerBName { get; set; }
    }

    public enum PairsAlgorithmType
    {
        Alphabetical,
        Random
    }
}

