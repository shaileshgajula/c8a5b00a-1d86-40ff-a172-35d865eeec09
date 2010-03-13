using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrongerOrg.BL.ShuffleAlgorithm;
using StrongerOrg.BL.TournamentAlgorithm;
using StrongerOrg.BL.DL;
using StrongerOrg.BL.Entities;
using System.Configuration;
using System.Net.Mail;
using System.IO;
using System.Diagnostics;

namespace StrongerOrg.BL.Jobs
{
    public class TournamentMatchup
    {
        public static void Build(Guid tournamentId, Guid orgId)
        {
            IShuffle<Competitor> shuffleAlgo = Shuffle<Competitor>.TournamentFactory(ShuffleTypes.Random);
            List<Competitor> competitorsList =
                shuffleAlgo.Execute(PlayersManager.GetPlayers(tournamentId));
            List<Matchup> matchupList =
                TournamentFactory.GetInstance(TournamentTypes.SingleElimination).Execute(competitorsList);
            DateTime startDate = GetTournamentStartDate(tournamentId);
            ScheduleGames(ref matchupList, startDate, orgId);
            SaveMatchUps(tournamentId, matchupList);
            SendModeratorNotification(orgId);
        }

        private static void SendModeratorNotification(Guid orgId)
        {
            
        }

        private static void SaveMatchUps(Guid tournamentId, List<Matchup> matchupList)
        {
            using (TournamentsDataContext db = new TournamentsDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                IEnumerable<StrongerOrg.BL.DL.TournamentMatchup> e = matchupList.Select(ml => new StrongerOrg.BL.DL.TournamentMatchup()
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
                db.TournamentMatchups.InsertAllOnSubmit(e);
                db.SubmitChanges();
            }
        }
        private static DateTime GetTournamentStartDate(Guid tournamentId)
        {
            using (TournamentsDataContext tdc = new TournamentsDataContext())
            {
                return tdc.Tournaments.Single(t => t.Id == tournamentId).StartDate;
            }
        }
        internal static void ScheduleGames(ref List<Matchup> matchups, DateTime dts, Guid orgId)
        {
            int numberOfGamesPerDay = 3;
            int numberOfGamesCounter = 0;
            int minutesPerGame = 15;
            CultureManager cultureManager = new CultureManager(orgId);
            IEnumerator<DateTime> dayEnumerator = cultureManager.GetNextBusinessDay(dts).GetEnumerator();
            DateTime dt;
            foreach (Matchup mu in matchups)
            {
                if (numberOfGamesCounter % numberOfGamesPerDay == 0)
                {
                    dayEnumerator.MoveNext();
                    dts = dayEnumerator.Current;
                    dts = new DateTime(dts.Year, dts.Month, dts.Day, 12, 0, 0);
                }

                mu.Start = dts;
                numberOfGamesCounter++;
                dts = dts.AddMinutes(minutesPerGame);
                mu.End = dts;
            }
        }
        public static List<TournamentOrganisation> GetTournamentForMatchups()
        {
            using (TournamentsDataContext tdc = new TournamentsDataContext())
            {
                return tdc.Tournaments.Where(t => t.LastRegistrationDate.Date == DateTime.Now.Date && t.TournamentMatchups.Count(tm => tm.TournamentId == t.Id) == 0).
                    Select(t => new TournamentOrganisation() { TournamentId = t.Id, OrganisationId = t.OrganisationId }).ToList();
            }
        }
        public static void NotifiModerator(Guid tournamentId, Guid organisationId)
        {
            using (TournamentsDataContext tdc = new TournamentsDataContext())
            { 
            
            }
            string moderatorName = string.Empty;
            SmtpClient client = new SmtpClient(); //host and port picked from web.config
            client.EnableSsl = true;
            string executablePath = Process.GetCurrentProcess().MainModule.FileName;
            string templatePath = string.Format("{0}\\EmailTemplate\\MatchupsReady.htm", Path.GetDirectoryName(executablePath));
            MailMessage message = new MailMessage();
            string matchUpReady = File.ReadAllText(templatePath);
            matchUpReady = matchUpReady.Replace("<% ModeratorName %>", moderatorName);
            matchUpReady = matchUpReady.Replace("<% TournamentName %>", moderatorName);
            matchUpReady = matchUpReady.Replace("<% StartDate %>", moderatorName);
            matchUpReady = matchUpReady.Replace("<% TournamentId %>", moderatorName);

            message.Body = "test from winservice";
            message.IsBodyHtml = true;
            message.From = new MailAddress("donotreply@strongerorg.com");
            message.Subject = "MiriMargolin - Contact Us Form";
            message.To.Add(new MailAddress("piniusha@gmail.com"));
            try
            {
                client.Send(message);
            }
            catch (Exception)
            {
               
            }
        }
    }
}
