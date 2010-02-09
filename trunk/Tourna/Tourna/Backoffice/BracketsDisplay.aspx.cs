using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TourneyLogic.Web.UI.WebControls;

namespace StrongerOrg.Backoffice
{
    public partial class BracketsDisplay : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BracketTest.Results.Clear();
                BracketTest.Competitors.Clear();
                for (int i = 65; i < 76; i++)
                {
                    char c = (char)(i);
                    BracketTest.Competitors.Add(new TourneyLogic.Web.UI.WebControls.BracketCompetitor() { CompetitorId = i.ToString(), CompetitorName = c.ToString() });    
                }
            }
            //this.BracketTest.Results.Add(new BracketMatchupResult() { MatchupID = "MatchUp1", WinningCompetitorId = "BracketCompetitor1" });
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
