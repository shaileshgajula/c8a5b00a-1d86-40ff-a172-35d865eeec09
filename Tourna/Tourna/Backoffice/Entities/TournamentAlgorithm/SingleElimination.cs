using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.Backoffice.Entities.TournamentAlgorithm
{
    public class SingleElimination: ITournament
    {
        public List<Matchup> Execute(List<Competitor> compList)
        {
            int compCount = compList.Count;
            int numberOfRounds = (int)Math.Ceiling(Math.Log(compCount, 2));
            List<Matchup> matchupList = new List<Matchup>();
            int matchUpCounter = 0;
            for (int r = 1; r <= numberOfRounds; r++)
            {
                int competitorsInRound = 0;
                if (r == 1)
                {
                    competitorsInRound = 2 * compCount - (int)Math.Pow(2, numberOfRounds);
                }
                else
                {
                    competitorsInRound = (int)Math.Pow(2, numberOfRounds - r) * 2;
                }

                for (int i = 0; i < competitorsInRound; i += 2)
                {
                    matchupList.Add(new Matchup()
                    {
                        MatchUpId = ++matchUpCounter,
                        Round = r,
                        PlayerA = compList[i].Name,
                        PlayerAId = compList[i].Id,
                        PlayerB = compList[i + 1].Name,
                        PlayerBId = compList[i + 1].Id,
                        HouseSize = (string.IsNullOrEmpty(compList[i].Name) ? 0 : 1) + (string.IsNullOrEmpty(compList[i + 1].Name) ? 0 : 1)
                    });
                    compList.Add(new Competitor());

                }
                compList.RemoveRange(0, competitorsInRound);
            }
            foreach (Matchup matchUp in matchupList)
            {
                Matchup mup = matchupList.Find(m =>
                {
                    return (m.Round == (matchUp.Round + 1)) &&
                        (string.IsNullOrEmpty(m.PlayerA) || string.IsNullOrEmpty(m.PlayerB)) &&
                        m.HouseSize < 2;
                });
                if (mup != null)
                {
                    matchUp.NextMatchId = mup.MatchUpId;
                    mup.HouseSize++;
                }

            }
            return matchupList;
        }
    }
}