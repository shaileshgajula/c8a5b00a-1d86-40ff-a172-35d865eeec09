using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.Entities;
using TourneyLogic.Web.UI.WebControls;

namespace StrongerOrg.Backoffice.UserControls
{
    public partial class BracketsDisplay : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<StrongerOrg.Backoffice.TournamentAlgorithm.Matchup> matchups = TournamentMatchupManager.GetTournamentMatchups(this.TournamentId);
                int lastround = matchups.Max(m => m.Round);
                IEnumerable<StrongerOrg.Backoffice.TournamentAlgorithm.Matchup> playOffs = matchups.Where(m => m.Round == lastround - 3 && m.PlayerAId != Guid.Empty && m.PlayerBId != Guid.Empty);
                if (playOffs.Count() == 8)
                {
                    int i = 0;
                    foreach (var item in playOffs)
                    {
                        i++;
                        BracketTest.Competitors.Add(new TourneyLogic.Web.UI.WebControls.BracketCompetitor() { CompetitorName = item.PlayerA });
                        BracketTest.Competitors.Add(new TourneyLogic.Web.UI.WebControls.BracketCompetitor() { CompetitorName = item.PlayerB });
                        if (item.WinnerId.HasValue)
                        {

                            string BracketCompetitor = "BracketCompetitor" + ((item.WinnerId == item.PlayerAId) ? (i * 2 - 1).ToString() : (i * 2).ToString());
                            this.BracketTest.Results.Add(new BracketMatchupResult() { MatchupID = "MatchUp" + i.ToString(), WinningCompetitorId = BracketCompetitor });

                        }

                    }
                    IEnumerable<StrongerOrg.Backoffice.TournamentAlgorithm.Matchup> results = matchups.Where(m => m.Round > lastround - 3 && m.WinnerId.HasValue);
                    foreach (var item in results)
                    {
                        if (item.WinnerId.HasValue)
                        {
                            int pId = FindIndex(item.WinnerId.Value, playOffs);
                            string BracketCompetitor = "BracketCompetitor" + pId.ToString();
                            this.BracketTest.Results.Add(new BracketMatchupResult() { MatchupID = "MatchUp" + i.ToString(), WinningCompetitorId = BracketCompetitor });
                        }
                    }
                }
            }
        }
        public Guid TournamentId { get; set; }
        private int FindIndex(Guid winnderId, IEnumerable<TournamentAlgorithm.Matchup> playOffs)
        {
            int i = 1;
            foreach (var item in playOffs)
            {
                if (item.PlayerAId == winnderId)
                {
                    return i;
                }
                else if (item.PlayerBId == winnderId)
                {
                    return i + 1;
                }
                i = i + 2;
            }
            return 0;
        }
    }
}