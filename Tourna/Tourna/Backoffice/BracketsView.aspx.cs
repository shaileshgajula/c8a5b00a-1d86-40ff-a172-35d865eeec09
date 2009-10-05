using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TourneyLogic.Web.UI.WebControls;

namespace StrongerOrg.Backoffice
{
    public partial class BracketsView : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void lbSwitchToEdit_Click(object sender, EventArgs e)
        {
            //if (this.Bracket1.DisplayMode == Bracket.BracketDisplayMode.ViewMode)
            //{
            //    this.lbSwitchToEdit.Text = "Switch to read only mode";
            //    this.Bracket1.DisplayMode = Bracket.BracketDisplayMode.AssignCompetitorMode;
            //}
            //else
            //{
            //    this.lbSwitchToEdit.Text = "Switch to edit mode";
            //    this.Bracket1.DisplayMode = Bracket.BracketDisplayMode.ViewMode;
            //}
        }
    }
}
