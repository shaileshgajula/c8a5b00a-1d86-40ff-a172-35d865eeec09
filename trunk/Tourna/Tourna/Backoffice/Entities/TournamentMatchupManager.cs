using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using StrongerOrg.Backoffice.DataLayer;
using System.ComponentModel;
using StrongerOrg.Backoffice.TournamentAlgorithm;

namespace StrongerOrg.Backoffice.Entities
{
    [DataObjectAttribute(true)]
    public class TournamentMatchupManager
    {
        [DataObjectMethodAttribute(DataObjectMethodType.Select)]
        public static List<Matchup> GetTournamentMatchups(Guid tournamentId)
        {

            using (TournaDataContext db = new TournaDataContext())
            {
                List<Matchup> matchups = db.TournamentMatchups.Where(y => y.TournamentId == tournamentId).
                     Select(y =>
                         new Matchup
                         {

                             Start = y.Start,
                             PlayerAId = y.PlayerA,
                             PlayerA = db.Players.Where(p => p.Id == y.PlayerA).Select(n => n.Name).First(),
                             PlayerBId = y.PlayerB,
                             PlayerB = db.Players.Where(p => p.Id == y.PlayerB).Select(n => n.Name).First(),
                             ScoreA = y.ScoreA,
                             ScoreB = y.ScoreB,
                             WinnerId = (y.ScoreA.HasValue && y.ScoreB.HasValue) ?
                                    (y.ScoreA > y.ScoreB) ? 0 : 1 : -1,
                             MatchupId = y.MatchUpId,
                             Round = y.Round,
                             NextMatchId = y.NextMatchId
                             //Score = (y.ScoreA.HasValue && y.ScoreB.HasValue) ? string.Format("{0}-{1}", y.ScoreA.Value.ToString(), y.ScoreB.Value.ToString()) : string.Empty
                         })
                     .ToList();
                return matchups;
            }
        }

        
        public static void Save(Guid tournamentId, List<Matchup> matchupList)
        {
            using (TournaDataContext db = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                IEnumerable<TournamentMatchup> e = matchupList.Select(ml => new TournamentMatchup()
                {
                    MatchUpId = ml.MatchupId,
                    Start = ml.Start,
                    PlayerA = ml.PlayerAId,
                    PlayerB = ml.PlayerBId,
                    TournamentId = tournamentId,
                    End = ml.End,
                    Round = ml.Round,
                    NextMatchId = ml.NextMatchId
                });
                //db.Tournaments.Single(t => t.Id == tournamentId).IsOpen = false; 
                db.TournamentMatchups.InsertAllOnSubmit(e);
                db.SubmitChanges();
            }
        }

        internal static void Delete(Guid tournamentId)
        {
            using (TournaDataContext db = new TournaDataContext())
            {
                db.TournamentMatchups.DeleteAllOnSubmit(
                    db.TournamentMatchups.Where(t => t.TournamentId == tournamentId));
                db.SubmitChanges();
            }
        }

        internal static void UpdateStartDate(Guid tournamentId, int matchUpId, DateTime newStartDate)
        {
            using (TournaDataContext db = new TournaDataContext())
            {
                db.TournamentMatchups.Single(tm => tm.TournamentId == tournamentId && tm.MatchUpId == matchUpId).Start = newStartDate;
                db.SubmitChanges();
            }
        }
    }
}