using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TourneyLogic.Web.UI.WebControls;
using StrongerOrg.Backoffice.Entities;


namespace StrongerOrg.Backoffice
{

    public partial class BracketsDisplay : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<StrongerOrg.Backoffice.TournamentAlgorithm.Matchup> matchups = TournamentMatchupManager.GetTournamentMatchups(new Guid("4ede643f-0d83-467a-b779-61744991a076"));
                int lastround = matchups.Max(m => m.Round);
                IEnumerable<StrongerOrg.Backoffice.TournamentAlgorithm.Matchup> playOffs = matchups.Where(m => m.Round == lastround - 3 && m.PlayerAId != Guid.Empty && m.PlayerBId != Guid.Empty);
                if (playOffs.Count() == 8)
                {
                    int i = 0;
                    foreach (var item in playOffs)
                    {
                        i++;
                        BracketTest.Competitors.Add(new TourneyLogic.Web.UI.WebControls.BracketCompetitor() { CompetitorName = item.PlayerA });
                        BracketTest.Competitors.Add(new TourneyLogic.Web.UI.WebControls.BracketCompetitor() { CompetitorName = item.PlayerB});
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
                //List<StrongerOrg.Backoffice.TournamentAlgorithm.Competitor> competitors = new List<TournamentAlgorithm.Competitor>();
                //foreach (StrongerOrg.Backoffice.TournamentAlgorithm.Matchup match in matchups)
                //{
                //    if (match.PlayerAId != Guid.Empty)
                //    {
                //        BracketTest.Competitors.Add(new TourneyLogic.Web.UI.WebControls.BracketCompetitor() { CompetitorName = match.PlayerA });
                //        //competitors.Add(new TournamentAlgorithm.Competitor() { Name = match.PlayerA });
                //    }
                //    if (match.PlayerBId != Guid.Empty)
                //    {
                //        BracketTest.Competitors.Add(new TourneyLogic.Web.UI.WebControls.BracketCompetitor() { CompetitorName = match.PlayerB });
                //        //competitors.Add(new TournamentAlgorithm.Competitor() { Name = match.PlayerB });
                //    }
                //}

                //List<StrongerOrg.Backoffice.TournamentAlgorithm.Matchup> orderedList = matchups.OrderBy(m => m.Round).ThenBy(m => m.Id).ToList();
                //BracketTest.Results.Clear();
                //BracketTest.Competitors.Clear();
                //for (int i = 65; i < 76; i++)
                //{
                //    char c = (char)(i);
                //    BracketTest.Competitors.Add(new TourneyLogic.Web.UI.WebControls.BracketCompetitor() { CompetitorId = i.ToString(), CompetitorName = c.ToString() });
                //}
            }
            //this.BracketTest.Results.Add(new BracketMatchupResult() { MatchupID = "MatchUp1", WinningCompetitorId = "BracketCompetitor1" });
        }

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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            //if (this.brackets.ReadOnly)
            //{
            //    this.LinkButton1.Text = "Switch to read only mode";
            //}
            //else
            //{
            //    this.LinkButton1.Text = "Switch to edit mode";
            //}
            //this.Bracket1.ReadOnly = !this.Bracket1.ReadOnly;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {


        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {

            foreach (BracketCompetitor bc in this.BracketTest.Competitors)
            {
                string matchup = ((BracketMatchup)bc.Parent).ID;
                string competitorId = bc.CompetitorId;
            }
            //foreach (BracketRound br in this.BracketTest.Rounds)
            //{

            //    foreach (BracketMatchup bm in br.Matchups)
            //    {
            //        string id = bm.ID;
            //    }
            //}
        }
    }
}
