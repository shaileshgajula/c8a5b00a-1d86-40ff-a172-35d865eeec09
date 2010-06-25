using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.Entities;
using TourneyLogic.Web.UI.WebControls;
using System.Text;

namespace StrongerOrg.Backoffice.UserControls
{
    public partial class BracketsDisplay : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<StrongerOrg.Backoffice.TournamentAlgorithm.Matchup> matchups = TournamentMatchupManager.GetTournamentMatchups(this.TournamentId);
            if (matchups.Count == 0) { this.Div1.Visible = true; return; }
            int currentRoundId = 1;
            int previousRound = 1;
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("<div id='r{0}' class='round'><div class='header'>Round {0}&nbsp;</div>",1));
            int count = 0;
            bool isFirstInRound = false;
            bool flag = true;
            foreach (var mu in matchups)
            {
                currentRoundId = mu.Round;
                if (previousRound != currentRoundId)
                {
                    builder.Append(string.Format("</div><div id='r{0}' class='round'><div class='header'>Round {0}&nbsp;</div>", currentRoundId.ToString()));
                    count = 0;
                    previousRound = currentRoundId;
                    isFirstInRound = true;
                }
               
                if (count % 2 == 0)
                {
                    if (isFirstInRound)
                    {
                        builder.Append(string.Format("<div class='top'><p>{0}</p></div>", mu.PlayerA));
                        isFirstInRound = false;
                    }
                    else
                    {
                        builder.Append(string.Format("<div><p>{0}</p></div>", mu.PlayerA));
                    }
                    
                }
                else
                {
                    builder.Append(string.Format("<div class='odd'><p>{0} <span style='font-size:9px;color:gray'>[{1}]</span></p></div>", mu.PlayerA, mu.Start.ToString("MM/dd")));
                }
                count++;
                if (count % 2 == 0)
                {
                    builder.Append(string.Format("<div><p>{0}</p></div>", mu.PlayerB));
                }
                else
                {
                    builder.Append(string.Format("<div class='odd'><p>{0}  <span style='font-size:9px;color:gray'>[{1}]</span></p></div>", mu.PlayerB, mu.Start.ToString("MM/dd")));
                }
                count++;
            }
            currentRoundId++;
            StrongerOrg.Backoffice.TournamentAlgorithm.Matchup lastMatchUp = matchups.Last();
            string champName = lastMatchUp.WinnerName;
            builder.Append(string.Format("</div><div id='r{0}' class='round'><div class='header'>Champion&nbsp;</div>", currentRoundId.ToString()));
            builder.Append(string.Format("<div class='champ'><p>{0}</p></div></div>", champName));
            
            Literal literal = new Literal();
            literal.Text = builder.ToString();
            this.bracket_base.Style.Add(HtmlTextWriterStyle.Height, string.Format("{0}px",Math.Pow(2, currentRoundId-1)*26 +50 ));
            this.bracket_body.Controls.Add(literal);
        
            
            
            
            //if (!Page.IsPostBack && false)
            //{
            //    List<StrongerOrg.Backoffice.TournamentAlgorithm.Matchup> matchups = TournamentMatchupManager.GetTournamentMatchups(this.TournamentId);
            //    int lastround = matchups.Max(m => m.Round);
            //    IEnumerable<StrongerOrg.Backoffice.TournamentAlgorithm.Matchup> playOffs = matchups.Where(m => m.Round == lastround - 3 && m.PlayerAId != Guid.Empty && m.PlayerBId != Guid.Empty);
            //    if (playOffs.Count() == 8)
            //    {
            //        int i = 0;
            //        foreach (var item in playOffs)
            //        {
            //            i++;
            //            BracketTest.Competitors.Add(new TourneyLogic.Web.UI.WebControls.BracketCompetitor() { CompetitorName = item.PlayerA });
            //            BracketTest.Competitors.Add(new TourneyLogic.Web.UI.WebControls.BracketCompetitor() { CompetitorName = item.PlayerB });
            //            if (item.WinnerId.HasValue)
            //            {

            //                string BracketCompetitor = "BracketCompetitor" + ((item.WinnerId == item.PlayerAId) ? (i * 2 - 1).ToString() : (i * 2).ToString());
            //                this.BracketTest.Results.Add(new BracketMatchupResult() { MatchupID = "MatchUp" + i.ToString(), WinningCompetitorId = BracketCompetitor });

            //            }

            //        }
            //        IEnumerable<StrongerOrg.Backoffice.TournamentAlgorithm.Matchup> results = matchups.Where(m => m.Round >= lastround - 3 && m.WinnerId.HasValue);
            //        foreach (var item in results)
            //        {
            //            if (item.WinnerId.HasValue)
            //            {
            //                int pId = FindIndex(item.WinnerId.Value, playOffs);
            //                string BracketCompetitor = "BracketCompetitor" + pId.ToString();
            //                this.BracketTest.Results.Add(new BracketMatchupResult() { MatchupID = "MatchUp" + i.ToString(), WinningCompetitorId = BracketCompetitor });
            //            }
            //        }
            //    }
            //}
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