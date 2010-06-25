using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using StrongerOrg.Backoffice.DataLayer;
using System.ComponentModel;
using StrongerOrg.Backoffice.TournamentAlgorithm;
using System.Net.Mail;
using System.Web.Security;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

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
                             Id = y.Id,
                             Start = y.Start,
                             PlayerAId = y.PlayerA,
                             PlayerA = db.Players.Where(p => p.Id == y.PlayerA).Select(n => n.Name).First(),
                             PlayerBId = y.PlayerB,
                             PlayerB = db.Players.Where(p => p.Id == y.PlayerB).Select(n => n.Name).First(),
                             ScoreA = y.ScoreA,
                             ScoreB = y.ScoreB,
                             WinnerId = y.Winner,
                             //WinnerName = (y.Winner.HasValue) ? (y.PlayerA == y.Winner) ? db.Players.Where(p => p.Id == y.PlayerA).Select(n => n.Name).First() :
                             //db.Players.Where(p => p.Id == y.PlayerB).Select(n => n.Name).First() : string.Empty,
                             MatchupId = y.MatchUpId,
                             Round = y.Round,
                             NextMatchId = y.NextMatchId

                             //Score = (y.ScoreA.HasValue && y.ScoreB.HasValue) ? string.Format("{0}-{1}", y.ScoreA.Value.ToString(), y.ScoreB.Value.ToString()) : string.Empty
                         })
                     .ToList();
                matchups.ForEach(m =>
                {
                    if (m.WinnerId.HasValue)
                    {
                        m.WinnerName = (m.PlayerAId == m.WinnerId.Value) ? m.PlayerA : m.PlayerB;
                    }
                    else
                    {
                        m.WinnerName = "--";
                    }
                    m.PlayerA = (string.IsNullOrEmpty(m.PlayerA)) ? "--" : m.PlayerA;
                    m.PlayerB = (string.IsNullOrEmpty(m.PlayerB)) ? "--" : m.PlayerB;
                });
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
                // need to be fix
                //db.Players2Tournaments.DeleteAllOnSubmit(db.Players2Tournaments.Where(t => t.TournamentId == tournamentId));
                db.SubmitChanges();
            }
        }
        internal static void RemovePlayers2Tournament(Guid tournamentId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(string.Format("delete from Players2Tournaments where TournamentId = '{0}'", tournamentId.ToString()), connection);
                cmd.CommandType = System.Data.CommandType.Text;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal static void UpdateMatchup(Guid tournamentId, int matchUpId, DateTime newStartDate, Guid playerAId, Guid playerBId, Guid winnerId)
        {
            using (TournaDataContext db = new TournaDataContext())
            {
                TournamentMatchup tmu = db.TournamentMatchups.Single(tm => tm.TournamentId == tournamentId && tm.MatchUpId == matchUpId);
                tmu.Start = newStartDate;
                tmu.PlayerA = playerAId;
                tmu.PlayerB = playerBId;
                if (winnerId == Guid.Empty)
                {
                    tmu.Winner = null;
                }
                else
                {
                    tmu.Winner = winnerId;
                }
                db.SubmitChanges();
            }
        }
        internal static void SetNextMatchup(Guid tournamentId, int matchUpId, int nextMatchId, Guid winnerPlayerId)
        {
            using (TournaDataContext tdc = new TournaDataContext())
            {
                if (nextMatchId != 0)
                {
                    TournamentMatchup nextTm = tdc.TournamentMatchups.Single(tmu => tmu.TournamentId == tournamentId && tmu.MatchUpId == nextMatchId);
                    var nextMatchup2Players = tdc.TournamentMatchups.Where(tmu => tmu.TournamentId == tournamentId && tmu.NextMatchId == nextMatchId).Select(tmu => new { tmu.Id, tmu.MatchUpId }).OrderBy(t => t.Id);
                    if (nextMatchup2Players.Count() > 0)
                    {
                        if (nextMatchup2Players.First().MatchUpId == matchUpId)
                        {
                            nextTm.PlayerA = winnerPlayerId;
                        }
                        else
                        {
                            nextTm.PlayerB = winnerPlayerId;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("expected 2 matchups for next round id");
                    }
                    tdc.SubmitChanges();
                }
            }
        }
        internal static void ResetScore(int id)
        {
            using (TournaDataContext db = new TournaDataContext())
            {
                db.TournamentMatchups.Single(tm => tm.Id == id).Winner = null;
                db.SubmitChanges();
            }
        }

        internal static MatchupGetResult GetMatchupInfo(int matchupId)
        {
            using (TournaDataContext db = new TournaDataContext())
            {
                MatchupGetResult tmup = db.MatchupGet(matchupId).First();
                return tmup;
            }
        }

        internal static void RescheduleRequestNotifyModerator(string orgId,string playerName, string tournamentName, string matchupDate, string matchup, string reason, string comment)
        {
            DataTable moderatorsEmail = OrganisationManager.GetModeratorsEmail(orgId);
            SmtpClient client = new SmtpClient(); //host and port picked from web.config
            client.EnableSsl = true;
            ListDictionary replacements = new ListDictionary();
            replacements.Add("<% tournamentName %>", tournamentName);
            replacements.Add("<% matchupDate %>", matchupDate);
            replacements.Add("<% matchup %>", matchup);
            replacements.Add("<% reason %>", reason);
            replacements.Add("<% comment %>", comment);
            MailDefinition message = new MailDefinition();
            message.BodyFileName = @"~\EmailTemplate\RescheduleRequest.htm";
            MailMessage msgHtml = message.CreateMailMessage("aa@aa.com", replacements, new LiteralControl());
            msgHtml.To.Clear();
            foreach (DataRow row in moderatorsEmail.Rows)
            {
                msgHtml.To.Add(row["Email"].ToString());
            }

            msgHtml.Subject = playerName + " - Reschedule Request";
            msgHtml.IsBodyHtml = true;
            msgHtml.From = new MailAddress("donotreply@strongerorg.com");
            try
            {
                client.Send(msgHtml);
            }
            catch { }
        }
    }
}