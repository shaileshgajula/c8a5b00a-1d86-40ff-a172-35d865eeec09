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
            Tournament tournamentInfo = GetTournamentInfo(tournamentId);
            List<Matchup> matchupList;
            if (tournamentInfo.MatchingAlgo == "Single Elimination")
            {
                 matchupList =
                    TournamentFactory.GetInstance(TournamentTypes.SingleElimination).Execute(competitorsList);
            }
            else
            {
                 matchupList =
                    TournamentFactory.GetInstance(TournamentTypes.RoundRobin).Execute(competitorsList);
            }
            ScheduleGames(ref matchupList, tournamentInfo.StartDate, tournamentInfo.TimeWindowStart, tournamentInfo.GamesPerDay.Value, orgId, tournamentInfo.OpenDays.Value);
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
            using (TournamentsDataContext tdc = new TournamentsDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                return tdc.Tournaments.Single(t => t.Id == tournamentId);
            }
        }
        internal static void ScheduleGames(ref List<Matchup> matchups, DateTime dts, TimeSpan timeWindowStart, int gamesPerDay, Guid orgId, int openDaysBitMask)
        {

            int numberOfGamesCounter = 1;
            int minutesPerGame = 15;
            CultureManager cultureManager = new CultureManager(orgId, openDaysBitMask);
            IEnumerator<DateTime> dayEnumerator = cultureManager.GetNextBusinessDay(dts).GetEnumerator();
            DateTime dt;
            int currentRound = 0;
            foreach (Matchup mu in matchups)
            {
                if (numberOfGamesCounter == gamesPerDay || mu.Round != currentRound)
                {
                    dayEnumerator.MoveNext();
                    dts = dayEnumerator.Current;
                    dts = new DateTime(dts.Year, dts.Month, dts.Day);
                    dts = dts.Add(timeWindowStart);
                    numberOfGamesCounter = 0;
                }

                mu.Start = dts;
                numberOfGamesCounter++;
                dts = dts.AddMinutes(minutesPerGame);
                mu.End = dts;
                currentRound = mu.Round;
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

            using (TournamentsDataContext tdc = new TournamentsDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
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
                List<MatchupsToNotifyGetResult> x = tdc.MatchupsToNotifyGet(null, true, null).ToList();
                return x;
            }
        }

        public static List<MatchupsToNotifyGetResult> GetMatchupsToNotify(Guid tournamentId)
        {
            using (TournamentsDataContext tdc = new TournamentsDataContext())
            {
                List<MatchupsToNotifyGetResult> x = tdc.MatchupsToNotifyGet(tournamentId, false, null).ToList();
                return x;
            }
        }

        public static List<MatchupsToNotifyGetResult> GetMatchupsToNotify(int tournamentMatchupId)
        {
            using (TournamentsDataContext tdc = new TournamentsDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ToString()))
            {
                List<MatchupsToNotifyGetResult> x = tdc.MatchupsToNotifyGet(null, false, tournamentMatchupId).ToList();
                return x;
            }
        }

        public static void NotifyPlayers(MatchupsToNotifyGetResult tm)
        {
            string opponetName;
            string opponetEmail;
            string message;
            if (string.IsNullOrEmpty(tm.PlayerBName))
            {
                opponetName = "??";
                opponetEmail = string.Empty;
                message = "Congratulation you were choosen to move to the next round. Read more about <a href='http://en.wikipedia.org/wiki/Bye_(sports)'>bye in sport</a>";
            }
            else
            {
                opponetName = tm.PlayerBName;
                opponetEmail = tm.PlayerBEmail;
                message = string.Empty;
            }
            string templatePath = Path.Combine(ConfigurationManager.AppSettings["EmailTemplatePath"].ToString(), "NotifyPlayers.htm");
            string matchUpReadyTemplate = File.ReadAllText(templatePath);

            ListDictionary replacements = new ListDictionary();
            replacements.Add("<% PlayerName %>", tm.PlayerAName);
            replacements.Add("<% TournamentName %>", tm.TournamentName);
            replacements.Add("<% Opponent %>", opponetName);
            replacements.Add("<% OpponentEmail %>", opponetEmail);
            replacements.Add("<% GameDate %>", string.Format("{0:f}", tm.Start));
            replacements.Add("<% Message %>", message);
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
            if (!string.IsNullOrEmpty(tm.PlayerBName))
            {
                replacements["<% PlayerName %>"] = tm.PlayerBName;
                replacements["<% PlayerId %>"] = tm.PlayerBId.ToString();
                replacements["<% Opponent %>"] = tm.PlayerAName;
                replacements["<% OpponentEmail %>"] = tm.PlayerAEmail;
                SendEmail(replacements, matchUpReadyTemplate, tm.PlayerBEmail, "Game matchup");
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


        public static void NotifyFinalMatchup(MatchupsToNotifyGetResult tm)
        {
            string templatePath = Path.Combine(ConfigurationManager.AppSettings["EmailTemplatePath"].ToString(), "FinalesNotify.htm");
            string matchUpReadyTemplate = File.ReadAllText(templatePath);

            ListDictionary replacements = new ListDictionary();
            replacements.Add("<% PlayerName %>", tm.PlayerAName);
            replacements.Add("<% TournamentName %>", tm.TournamentName);
            replacements.Add("<% Opponent %>", tm.PlayerBName);
            replacements.Add("<% GameDate %>", string.Format("{0:f}", tm.Start));
            replacements.Add("<% FinalesTitle %>", "Final Game");
            replacements.Add("<% TournamentId %>", tm.TournamentId.ToString());
            replacements.Add("<% OrgId %>", tm.OrganisationId.ToString());
            replacements.Add("<% Round %>", tm.Round.ToString());
            if (!string.IsNullOrEmpty(tm.Locations))
            {
                replacements.Add("<% Location %>", string.Format("[@{0}]", tm.Locations));
            }
            else
            {
                replacements.Add("<% Location %>", string.Empty);
            }
            List<Competitor> competitors = PlayersManager.GetPlayers(tm.TournamentId);
            string emails = competitors.Select(c => c.Email).Aggregate((c1, c2) => { return string.Format("{0},{1}", c1, c2); });

            SendEmail(replacements, matchUpReadyTemplate, emails, tm.TournamentName + " Final Game");
        }

        public static void GetMatchupsToSendUpdateScoreReminder(Guid tournamentId)
        {
            string templatePath = Path.Combine(ConfigurationManager.AppSettings["EmailTemplatePath"].ToString(), "UpdateScoreReminder.htm");
            string matchUpReadyTemplate = File.ReadAllText(templatePath);



            using (TournamentsDataContext tdc = new TournamentsDataContext())
            {
                var playersToNotify = from tm in tdc.TournamentMatchups
                                      join pA in tdc.Players on tm.PlayerA equals pA.Id
                                      join pB in tdc.Players on tm.PlayerB equals pB.Id
                                      join tr in tdc.Tournaments on tm.TournamentId equals tr.Id
                                      where tm.Winner == null && DateTime.Now.AddHours(-2) > tm.Start && (tm.TournamentId == tournamentId)
                                      select new { MatchupId = tm.Id, PlayerAId = pA.Id, PlayerA = pA.Name, PlayerAEmail = pA.Email, PlayerBId = pB.Id, PlayerB = pB.Name, PlayerBEmail = pB.Email, tm.Start, tr.TournamentName, tr.OrganisationId };
                foreach (var item in playersToNotify)
                {
                    ListDictionary replacements = new ListDictionary();
                    replacements.Add("<% PlayerName %>", item.PlayerA);
                    replacements.Add("<% Opponent %>", item.PlayerB);
                    replacements.Add("<% GameTime %>", item.Start);
                    replacements.Add("<% OrgId %>", item.OrganisationId);
                    replacements.Add("<% PlayerId %>", item.PlayerAId);
                    replacements.Add("<% MatchupId %>", item.MatchupId);
                    SendEmail(replacements, matchUpReadyTemplate, item.PlayerAEmail, "Score Update - " + item.TournamentName);
                    replacements["<% PlayerName %>"] = item.PlayerB;
                    replacements["<% Opponent %>"] = item.PlayerA;
                    replacements["<% PlayerId %>"] = item.PlayerBId;
                    SendEmail(replacements, matchUpReadyTemplate, item.PlayerAEmail, "Score Update - " + item.TournamentName);
                }

            }
        }
    }
}
