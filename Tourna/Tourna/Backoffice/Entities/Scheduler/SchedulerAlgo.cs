using System.Collections.Generic;
using System;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using StrongerOrg.BackOffice.PairsAlgorithm;
using StrongerOrg.Backoffice.Entities;
using StrongerOrg.Backoffice.DataLayer;
using System.Data.Linq;

namespace StrongerOrg.BackOffice.Scheduler
{
    public class SchedulerAlgo
    {
        //internal static void SchedulerGames(Guid tournamentId, List<PlayersEntity> playersPairs)
        //{
        //    TournamentInfo tournamentInfo = GetTournamentStartDate(tournamentId);
        //    DateTime dts = new DateTime(tournamentInfo.StartDate.Year, tournamentInfo.StartDate.Month, tournamentInfo.StartDate.Day, tournamentInfo.TimeWindowStart, 0, 0);

        //    int i = 0;
        //    int numberOfGamesPerDay = 3;
        //    foreach (PlayersEntity playerPair in playersPairs)
        //    {
        //        if ((i % numberOfGamesPerDay) == 0)
        //        {
        //            dts = GetNextDaye(dts);
        //            dts = new DateTime(dts.Year, dts.Month, dts.Day, tournamentInfo.TimeWindowStart, 0, 0);
        //        }
        //        DateTime dte = dts.AddMinutes(15);
        //        SchedulesBL.ScheduleInsert(tournamentId, playerPair.PlayerAId, playerPair.PlayerBId, dts, dte);
        //        dts = dte;
        //        i++;
        //    }
        //}
        internal static void ScheduleGames(ref List<StrongerOrg.Backoffice.Entities.TournamentAlgorithm.Matchup> matchups, DateTime dts, Guid orgId)
        {
            int numberOfGamesPerDay = 3;
            int numberOfGamesCounter = 0;
            CultureManager cultureManager = new CultureManager(orgId);
            IEnumerator<DateTime> dayEnumerator = cultureManager.GetNextBusinessDay(dts).GetEnumerator();
            DateTime dt;
            foreach (StrongerOrg.Backoffice.Entities.TournamentAlgorithm.Matchup mu in matchups)
            {
                if (numberOfGamesCounter % numberOfGamesPerDay == 0)
                {
                    dayEnumerator.MoveNext();
                    dts = dayEnumerator.Current;
                    dts = new DateTime(dts.Year, dts.Month, dts.Day, 12, 0, 0);
                }
                
                mu.StartDate = dts;
                numberOfGamesCounter++;
                dts = dts.AddMinutes(15);
            }
        }

        internal static void ScheduleGames(Guid tournaId, string pairAlgo, string matchType)
        {
            //get org id
            Guid orgId = Guid.Empty;
            DateTime startDate = new DateTime();
            using (TournaDataContext db = new TournaDataContext())
            {
                var data = db.Tournaments.Where(x => x.Id == tournaId)
                                          .Select(y => new
                                          {
                                              OrgId = y.OrganisationId,
                                              StartDate = y.StartDate
                                          }).FirstOrDefault();

                if (data == null)
                    throw new DataException("Could not generate data for tournament");

                 orgId = data.OrgId;
                 startDate = data.StartDate ?? new DateTime();

            }

            ScheduleGames(orgId, tournaId, startDate, (PairsMatchType)(Enum.Parse(typeof(PairsMatchType), matchType)),
                (PairsAlgorithmType)(Enum.Parse(typeof(PairsAlgorithmType), pairAlgo)));
        }

        //internal static void ScheduleGames(Guid orgId, Guid tournaId)
        //{
        //    //Get tourna startDate
        //    DateTime startDate = new DateTime();
        //    using (TournaDataContext db = new TournaDataContext())
        //    {
        //         startDate  = db.Tournaments.Where(x => x.Id == tournaId)
        //                                           .Select(y => y.StartDate)
        //                                           .FirstOrDefault() ?? new DateTime();
        //    }

        //    ScheduleGames(orgId, tournaId, startDate);
        //}
        internal static void ScheduleGames(Guid orgId, Guid tournaId, DateTime startDate, PairsMatchType matchType, PairsAlgorithmType pairAlgo)
        {
            TournamentInfo info = new TournamentInfo()
            {
                TournamentId = tournaId,
                OrganisationId = orgId,
                StartDate = startDate,
                MatchType = matchType,
                PairAlgo = pairAlgo
            };

            ScheduleGames(info);
        }
      
        internal static void ScheduleGames(TournamentInfo tournamentInfo)
        {
            
            //check arguments that are needed
            if (tournamentInfo == null)
                throw new ArgumentNullException("tournamentInfo");

            if (tournamentInfo.TournamentId == Guid.Empty)
                throw new ArgumentNullException("TorunamentId");

            if (tournamentInfo.OrganisationId == Guid.Empty)
                throw new ArgumentNullException("OrganisationId");

            if (tournamentInfo.StartDate == new DateTime())
                throw new ArgumentException("Incorrect tournament start date");
            
            //set up helpers.
            //need current culture.
            CultureManager cultManager = new CultureManager(tournamentInfo.OrganisationId);

            PlayerManager playerManager = new PlayerManager();
            playerManager.AlgoType = tournamentInfo.PairAlgo;
            playerManager.MatchType = tournamentInfo.MatchType;

            DateTime startDate = tournamentInfo.StartDate;

            IEnumerable<PlayersEntity> playerPairs = playerManager.BuildPairs( tournamentInfo.TournamentId);


            int i = 0;
            int numberOfGamesPerDay = 3;
            DateTime dts = startDate;
            List<StrongerOrg.Backoffice.DataLayer.Schedules> scheds = new List<StrongerOrg.Backoffice.DataLayer.Schedules>();
            //schedule 3 games per day within 15 min intervals
            
            IEnumerator<DateTime> dayEnumerator = cultManager.GetNextBusinessDay(startDate).GetEnumerator();
            
            foreach (PlayersEntity matches in playerPairs)
            {
                if ((i % numberOfGamesPerDay) == 0)
                {
                    dayEnumerator.MoveNext();
                    dts = dayEnumerator.Current;
                    dts = new DateTime(dts.Year, dts.Month, dts.Day, tournamentInfo.TimeWindowStart, 0, 0);
                }

                DateTime dte = dts.AddMinutes(15);
                //insert here
                scheds.Add(new StrongerOrg.Backoffice.DataLayer.Schedules()
                                {
                                    TournamentId = tournamentInfo.TournamentId,
                                    PlayerA = matches.PlayerAId,
                                    PlayerB = matches.PlayerBId,
                                    Start = dts,
                                    End = dts.AddMinutes(15) // i need end date, otherwise i cant insert.
                                });
                dts = dte;
                i++; 
            }

            using (TournaDataContext db = new TournaDataContext())
            {

                db.Schedules.DeleteAllOnSubmit(db.Schedules.Where(x => x.TournamentId == tournamentInfo.TournamentId));
                db.Schedules.InsertAllOnSubmit(scheds);
                db.SubmitChanges();
            }
            
        }

        private static DateTime GetNextDaye(DateTime dts)
        {
            DateTime newDate = dts.AddDays(1);
            if (newDate.DayOfWeek == DayOfWeek.Saturday)
            {
                return newDate.AddDays(2);
            }
            else if (newDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return newDate.AddDays(1);
            }
            else
            {
                return newDate;
            }
        }


        private static TournamentInfo GetTournamentStartDate(Guid tournamentId)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("TournamentInfo", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@TournamentId", SqlDbType.UniqueIdentifier).Value = tournamentId;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                TournamentInfo tournamentInfo = new TournamentInfo();
                while (reader.Read())
                {
                    tournamentInfo.TimeWindowStart = reader.GetInt32(8);
                    tournamentInfo.TimeWindowEnd = reader.GetInt32(9);
                    tournamentInfo.StartDate = reader.GetDateTime(14);
                }
                return tournamentInfo;
            }
        }

        public class TournamentInfo
        {
            public int Id { get; set; }
            public Guid OrganisationId { get; set; }
            public Guid TournamentId { get; set; }
            public string Abstract { get; set; }
            public string Locations { get; set; }
            public int NumberOfPlayersLimit { get; set; }
            public int GameId { get; set; }
            public int TimeWindowStart { get; set; }
            public int TimeWindowEnd { get; set; }
            public int FirstPrize { get; set; }
            public int SecondPrize { get; set; }
            public int ThirdPrize { get; set; }
            public DateTime StartDate { get; set; }
            public string EmailTemplate { get; set; }
            public bool IsApproved { get; set; }
            public PairsMatchType MatchType { get; set; }
            public PairsAlgorithmType PairAlgo { get; set; }
            public int NumberOfGamesPerPlayer { get; set; }

            
        }
    }
}