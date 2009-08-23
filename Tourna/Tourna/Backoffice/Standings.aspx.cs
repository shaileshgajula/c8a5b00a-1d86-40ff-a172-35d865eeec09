using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.Entities;
using System.Collections;

namespace StrongerOrg.Backoffice
{
    public partial class Standings : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack && false)
            //{
            //    IEnumerable<StrongerOrg.Backoffice.Entities.Tournament> tournaments;
            //    if (Request.QueryString["TournamentId"] != null)
            //    {
            //        tournaments = this.GetTournamentsByTournamentId(new Guid(Request.QueryString["TournamentId"].ToString()));
            //    }
            //    else
            //    {
            //        tournaments = this.GetTournamentsByOrganisation(new Guid(HttpContext.Current.Profile.GetPropertyValue("OrganisationId").ToString()));

            //    }
            //    BuildData(tournaments);
            //}
        }

        //private IEnumerable<Tournament> GetTournamentsByOrganisation(Guid organisationId)
        //{
        //    StandingsDataContext sdc = new StandingsDataContext();
        //    var x = from a in sdc.Tournaments
        //            where a.OrganisationId == organisationId
        //            select a;
        //    return x;
        //}

        //private IEnumerable<Tournament> GetTournamentsByTournamentId(Guid tournamentId)
        //{
        //    StandingsDataContext sdc = new StandingsDataContext();
        //    var x = from a in sdc.Tournaments
        //            where a.Id == tournamentId
        //            select a;
        //    return x;
        //}

        //private void BuildData(IEnumerable<StrongerOrg.Backoffice.Entities.Tournament> tournaments)
        //{
        //    StandingsDataContext sdc = new StandingsDataContext();
        //    foreach (var tournament in tournaments)
        //    {
        //        GridView gvStanding = GetNewStandingGrid();
        //        Label l = new Label();
        //        l.Text = tournament.TournamentName;
        //        this.Panel1.Controls.Add(l);
        //        this.Panel1.Controls.Add(gvStanding);
        //        var s = from a in sdc.Schedules
        //                where a.TournamentId == tournament.Id
        //                select a;
        //        gvStanding.DataSource = s;
        //        gvStanding.DataBind();
        //    }
        //}

        //private GridView GetNewStandingGrid()
        //{
        //    GridView gv = new GridView();
        //    return gv;

        //}

        protected void dlTournaments_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                string tournamentId = ((System.Data.DataRowView)e.Item.DataItem).Row["Id"].ToString();
                SqlDataSource sqlDs = e.Item.FindControl("SqlDataSource1") as SqlDataSource;
                sqlDs.SelectParameters["TournamentId"].DefaultValue = tournamentId;
            }
        }

        public string ScoreDisplay(object scoreA, object scoreB)
        {
            if (string.IsNullOrEmpty(scoreA.ToString()) && string.IsNullOrEmpty(scoreB.ToString()))
            {
                return "N/A";
            }
            else
            {
                return string.Format("{0}:{1}", scoreA, scoreB);
            }
        }
    }
}
