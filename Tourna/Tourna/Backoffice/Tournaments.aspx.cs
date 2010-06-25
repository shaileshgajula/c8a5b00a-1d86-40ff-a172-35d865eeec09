﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.DataLayer;
using TourneyLogic.Web.UI.WebControls;
using TourneyLogic.Web.UI.WebControls.Collections;

namespace StrongerOrg.Backoffice
{
    public partial class Tournaments : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.className='SelectedRowStyle'");
                    e.Row.Attributes.Add("onmouseout", "this.className='AlternatingRow'");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.className='SelectedRowStyle'");
                    e.Row.Attributes.Add("onmouseout", "this.className='RowBackColor'");
                }
              
            }
        }

        protected string GetCompetitorType(object competitorType)
        {
            char c = Convert.ToChar(competitorType);
            if (c == 'P')
                return "../Images/Icons/Male.gif";
            else
            {
                return "../Images/Icons/Group.gif";
            }
        }
        public string BuildNavigationLink(object competitorType, object id)
        {
            char c = Convert.ToChar(competitorType);
            if (c == 'P')
            {
                return string.Format("Tournament.aspx?TournamentId={0}", id);
            }
            else
            {
                return string.Format("TeamTournament.aspx?TournamentId={0}", id);
            }
        }
        //Eval("Id", "Tournament.aspx?TournamentId={0}")
        //protected void schedDatesGrid_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    schedDatesGrid.EditIndex = e.NewEditIndex;
        //    //binddata();
        //}

        //protected void schedDatesGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    schedDatesGrid.EditIndex = -1;
        //}
    }
}
