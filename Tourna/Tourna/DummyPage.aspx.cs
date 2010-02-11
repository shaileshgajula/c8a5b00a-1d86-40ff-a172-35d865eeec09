﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TourneyLogic.Web.UI.WebControls;

namespace StrongerOrg
{
    public partial class DummyPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Competitor> compList = new List<Competitor>() { new Competitor() { Name = "A" }, new Competitor() { Name = "B" }, new Competitor() { Name = "C" },
                                                                new Competitor() { Name = "D" }, new Competitor() { Name = "E" }, new Competitor() { Name = "F" }, 
                                                                new Competitor() { Name = "G" }, new Competitor() { Name = "H" }, new Competitor() { Name = "I" },
                                                                new Competitor() { Name = "J" }};
            List<Matchup> mathcupList = this.Execute(compList);
            this.gvResults.DataSource = mathcupList;
            this.gvResults.DataBind();
        }

        protected void btnCreatPlayers_Click(object sender, EventArgs e)
        {
            int cnt = int.Parse(this.TextBox1.Text);
            List<Competitor> playerList = new List<Competitor>();
            for (int i = 0; i < cnt; i++)
            {
                string name = ((char)(65 + i)).ToString();
                playerList.Add(new Competitor() { Name = name, Id = i });
            }
            ViewState["PlayerArry"] = playerList;
            this.gvResults.DataSource = playerList;
            this.gvResults.DataBind();
        }

        protected void btnRandomize_Click(object sender, EventArgs e)
        {
            List<Competitor> playerList = ViewState["PlayerArry"] as List<Competitor>;

            List<Competitor> mixed = MixList(playerList);
            this.gvResults.DataSource = mixed;
            this.gvResults.DataBind();
            ViewState["PlayerArry"] = mixed;
        }
        private List<E> MixList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

        protected void btnSingle_Click(object sender, EventArgs e)
        {
            List<Competitor> playerList = ViewState["PlayerArry"] as List<Competitor>;
            double round = Math.Ceiling(Math.Log(playerList.Count, 2));
            double bye = Math.Pow(2, round) - playerList.Count;
            this.Label2.Text = string.Format("Rounds:{0}, Bye:{1}", round.ToString(), bye.ToString());
            SetBye(playerList, (int)bye);
            this.gvResults.DataSource = playerList;
            this.gvResults.DataBind();
            ViewState["PlayerArry"] = playerList;
        }

        private void SetBye(List<Competitor> playerList, int byeCnt)
        {
            for (int i = (playerList.Count - 1); i >= (playerList.Count - byeCnt); i--)
            {
                playerList[i].IsBye = true;
                playerList[i].Round = 2;
            }

        }


        protected void btnSinglePair_Click(object sender, EventArgs e)
        {
            List<Competitor> playerList = ViewState["PlayerArry"] as List<Competitor>;
            List<Matchup> mathcupList = this.Execute(playerList);
            this.gvResults.DataSource = mathcupList;
            this.gvResults.DataBind();

            //List<Matchup> matchups = new List<Matchup>();
            //for (int i = 0; i < playerList.Count; i++)
            //{
            //    Competitor competitor = playerList[i];

            //    if (competitor.IsBye)
            //    {
            //        Matchup match = new Matchup();
            //        match.PlayerA = competitor.Name;
            //        match.Round = competitor.Round;
            //        //match.MatchUpId = string.Format("MatchUp{0}", (matchups.Count + 1).ToString());
            //        matchups.Add(match);
            //    }
            //    else
            //    {
            //        Matchup match = new Matchup();
            //        match.PlayerA = competitor.Name;
            //        match.Round = competitor.Round;
            //        i++;
            //        //match.MatchUpId = string.Format("MatchUp{0}", (matchups.Count + 1).ToString());
            //        competitor = playerList[i];
            //        match.PlayerB = competitor.Name;
            //        matchups.Add(match);
            //    }
            //}
            //this.gvPairs.DataSource = matchups;
            //this.gvPairs.DataBind();
            //this.Bracket1.DataSource = playerList;
            //this.Bracket1.DataCompetitorNameField = "Name";
            //this.Bracket1.DataCompetitorIdField = "Id";
            //this.Bracket1.Results.Add(new BracketMatchupResult() { MatchupID = "MatchUp1", WinningCompetitorId = "1" });
            //this.Bracket1.Results.Add(new BracketMatchupResult() { MatchupID = "MatchUp2", WinningCompetitorId = "6" });
            //this.Bracket1.Results.Add(new BracketMatchupResult() { MatchupID = "MatchUp3", WinningCompetitorId = "0" });
            //this.Bracket1.DataBind();

        }

        public List<Matchup> Execute(List<Competitor> compList)
        {
            int compCount = compList.Count;
            int numberOfRounds = (int)Math.Ceiling(Math.Log(compCount, 2));
            List<Matchup> matchupList = new List<Matchup>();
            int nextMatch = 0;
            int matchUpCounter = 0;
            for (int r = 1; r <= numberOfRounds; r++)
            {
                int compInRound = 0;
                if (r == 1)
                {
                    compInRound = 2 * compCount - (int)Math.Pow(2, numberOfRounds);
                }
                else
                {
                    compInRound = (int)Math.Pow(2, numberOfRounds - r) * 2;
                }
                nextMatch += compInRound/2;
                int j = 0;
                int x = nextMatch;

                for (int i = 0; i < compInRound; i += 2)
                {
                    
                    x += (((j%2) == 0)? 1:0);
                    matchupList.Add(new Matchup() { MatchUpId = ++matchUpCounter,  Round = r, PlayerA = compList[i].Name, PlayerB = compList[i + 1].Name, NextMatchId = (r == numberOfRounds)?-1:x });
                    compList.Add(new Competitor());
                    j++;
                    
                }
                compList.RemoveRange(0, compInRound);
            }
            return matchupList;
        }
    }
    [Serializable]
    public class Competitor
    {
        int round = 1;
        public string Name { get; set; }
        public int Round { get { return round; } set { this.round = value; } }
        public bool IsBye { get; set; }
        public int Id { get; set; }

    }
    public class Matchup
    {
        public int MatchUpId { get; set; }
        public int Round { get; set; }
        public string PlayerA { get; set; }
        public string PlayerB { get; set; }
        public int NextMatchId { get; set; }
    }
}