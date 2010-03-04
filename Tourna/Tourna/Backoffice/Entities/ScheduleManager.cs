using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using StrongerOrg.Backoffice.DataLayer;

namespace StrongerOrg.Backoffice.Entities
{
    public class ScheduleManager
    {
        public static void Save(Guid tournamentId, List<StrongerOrg.Backoffice.Entities.TournamentAlgorithm.Matchup> matchupList)
        {
            using (TournaDataContext db = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                IEnumerable<Schedule> e = matchupList.Select(ml => new Schedule()
                {
                    MatchUpId = ml.MatchUpId,
                    Start = ml.StartDate,
                    PlayerA = ml.PlayerAId,
                    PlayerB = ml.PlayerBId,
                    TournamentId = tournamentId,
                    End = ml.EndDate,
                    Round = ml.Round,
                    NextRound = ml.NextMatchId
                });
                db.Schedules.InsertAllOnSubmit(e);
                db.SubmitChanges();
            }
        }
    }
}