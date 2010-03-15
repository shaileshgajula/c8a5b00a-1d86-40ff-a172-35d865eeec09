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
using System.Collections.Specialized;
using System.Collections;

namespace StrongerOrg.BL.Jobs
{
    public class TournamentMatchupManager
    {

        private const string STRONGER_ORG_ADMINISTRATOR = "piniusha@gmail.com";

        public static void Build(Guid tournamentId, Guid orgId)
        {
            IShuffle<Competitor> shuffleAlgo = Shuffle<Competitor>.TournamentFactory(ShuffleTypes.Random);
            List<Competitor> competitorsList =
                shuffleAlgo.Execute(PlayersManager.GetPlayers(tournamentId));
            List<Matchup> matchupList =
                TournamentFactory.GetInstance(TournamentTypes.SingleElimination).Execute(competitorsList);
            Tournament tournamentInfo = GetTournamentInfo(tournamentId);
            ScheduleGames(ref matchupList, tournamentInfo.StartDate, orgId);
            SaveMatchUps(tournamentId, matchupList);
            NotifiModerator(tournamentId, orgId, tournamentInfo.TournamentName, tournamentInfo.StartDate);
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
        private static Tournament GetTournamentInfo(Guid tournamentId)
        {
            using (TournamentsDataContext tdc = new TournamentsDataContext())
            {
                return tdc.Tournaments.Single(t => t.Id == tournamentId);
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
        public static void NotifiModerator(Guid tournamentId, Guid organisationId, string tournamentName, DateTime startDate)
        {

            using (TournamentsDataContext tdc = new TournamentsDataContext())
            {
                var moderators = tdc.OrganisationUsersGet(organisationId).Where(ou => ou.RoleName == "Moderator").Select(ou => new { ou.Email, ou.Name });
                
                string templatePath = Path.Combine(ConfigurationManager.AppSettings["EmailTemplatePath"].ToString(), "MatchupsAreReady.htm");
                string matchUpReadyTemplate = File.ReadAllText(templatePath);
                foreach (var moderator in moderators)
                {
                    ListDictionary replacements = new ListDictionary();
                    replacements.Add("<% ModeratorName %>", moderator.Name);
                    replacements.Add("<% TournamentName %>", tournamentName);
                    replacements.Add("<% StartDate %>", string.Format("{0:ddd, MMM d, yyyy}", startDate));
                    replacements.Add("<% TournamentId %>", tournamentId.ToString());
                    SendEmail(replacements, matchUpReadyTemplate.Clone().ToString(), moderator.Email, "Matchups are ready for your review");
                }
            }
        }

        public static List<MatchupsToNotifyGetResult> GetMatchupsToNotify()
        {
            using (TournamentsDataContext tdc = new TournamentsDataContext())
            {
                List<MatchupsToNotifyGetResult> x = tdc.MatchupsToNotify().ToList();
                return x;
            }
        }

        public static void NotifyPlayers(MatchupsToNotifyGetResult tm)
        {
            if (!string.IsNullOrEmpty(tm.PlayerBName))
            {
                string templatePath = Path.Combine(ConfigurationManager.AppSettings["EmailTemplatePath"].ToString(), "NotifyPlayers.htm");
                string matchUpReadyTemplate = File.ReadAllText(templatePath);

                ListDictionary replacements = new ListDictionary();
                replacements.Add("<% PlayerName %>", tm.PlayerAName);
                replacements.Add("<% TournamentName %>", tm.TournamentName);
                replacements.Add("<% Opponent %>", tm.PlayerBName);
                replacements.Add("<% OpponentEmail %>", tm.PlayerBEmail);
                replacements.Add("<% GameDate %>", string.Format("{0:f}", tm.Start));
                replacements.Add("<% TournamentId %>", tm.TournamentId.ToString());
                replacements.Add("<% OrgId %>", tm.OrganisationId.ToString());
                replacements.Add("<% PlayerId %>", tm.PlayerAId.ToString());
                replacements.Add("<% MatchupId %>", tm.Id.ToString());
                replacements.Add("<% Round %>", tm.Round.ToString());
                if (!string.IsNullOrEmpty(tm.Locations))
                {
                    replacements.Add("<% Location %>", string.Format("[@{0}]", tm.Locations));
                }
                else
                {
                    replacements.Add("<% Location %>", string.Empty);
                }
                SendEmail(replacements, matchUpReadyTemplate, tm.PlayerAEmail, "Game matchup");

                replacements["<% PlayerName %>"] = tm.PlayerBName;
                replacements["<% PlayerId %>"]= tm.PlayerBId.ToString();
                replacements["<% Opponent %>"] = tm.PlayerAName;
                replacements["<% OpponentEmail %>"] = tm.PlayerAEmail;
                SendEmail(replacements, matchUpReadyTemplate, tm.PlayerBEmail, "Game matchup");
            }
            else
            {
               // bye game
            }

        }
        private static void SendEmail(ListDictionary replacements, string matchUpReadyTemplate, string matilTo, string messageSubject)
        {
            SmtpClient client = new SmtpClient(); //host and port picked from web.config
            client.EnableSsl = true;

            foreach (DictionaryEntry item in replacements)
            {
                matchUpReadyTemplate = matchUpReadyTemplate.Replace(item.Key.ToString(), item.Value.ToString());
            }
            MailMessage message = new MailMessage();
            message.Subject = messageSubject;
            message.From = new MailAddress("donotreply@strongerorg.com");
            message.To.Add(matilTo);
            //message.Bcc.Add(STRONGER_ORG_ADMINISTRATOR);
            message.IsBodyHtml = true;
            message.Body = matchUpReadyTemplate;

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
