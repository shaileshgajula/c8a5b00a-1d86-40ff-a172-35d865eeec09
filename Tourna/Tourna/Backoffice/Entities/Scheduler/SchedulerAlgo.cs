using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using StrongerOrg.BackOffice.PairsAlgorithm;

namespace StrongerOrg.BackOffice.Scheduler
{
    public class SchedulerAlgo
    {
        internal static void SchedulerGames(Guid tournamentId, List<PlayersEntity> playersPairs)
        {
            TournamentInfo tournamentInfo = GetTournamentStartDate(tournamentId);
            DateTime dts = new DateTime(tournamentInfo.StartDate.Year, tournamentInfo.StartDate.Month, tournamentInfo.StartDate.Day, tournamentInfo.TimeWindowStart, 0, 0);

            int i = 0;
            int numberOfGamesPerDay = 3;
            foreach (PlayersEntity playerPair in playersPairs)
            {
                if ((i % numberOfGamesPerDay) == 0)
                {
                    dts = GetNextDaye(dts);
                    dts = new DateTime(dts.Year, dts.Month, dts.Day, tournamentInfo.TimeWindowStart, 0, 0);
                }
                DateTime dte = dts.AddMinutes(15);
                SchedulesBL.ScheduleInsert(tournamentId, playerPair.PlayerAId, playerPair.PlayerBId, dts, dte);
                dts = dte;
                i++;
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
            public string Abstract { get; set; }
            public string Locations { get; set; }
            public int NumberOfPlayersLimit { get; set; }
            public int GameId { get; set; }
            public string MatchingAlgo { get; set; }
            public int TimeWindowStart { get; set; }
            public int TimeWindowEnd { get; set; }
            public int FirstPrize { get; set; }
            public int SecondPrize { get; set; }
            public int ThirdPrize { get; set; }
            public DateTime StartDate { get; set; }
            public string EmailTemplate { get; set; }
            public bool IsApproved { get; set; }
        }
    }
}