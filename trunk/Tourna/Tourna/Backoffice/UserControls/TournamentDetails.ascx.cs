using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.Backoffice.UserControls
{
    public partial class TournamentDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            int rowIndex = DetailsView1.DataItemIndex;
            TextBox tbAbstract = DetailsView1.Rows[rowIndex].FindControl("txtAbstract") as TextBox;
            TextBox tbLastRegistrationDate = DetailsView1.Rows[rowIndex].FindControl("txtLastRegistrationDate") as TextBox;
            TextBox tbStartDate = DetailsView1.Rows[rowIndex].FindControl("txtStartDate") as TextBox;
            TextBox tbTimeWindowStart = DetailsView1.Rows[rowIndex].FindControl("txtTimeWindowStart") as TextBox;
            TextBox tbTimeWindowEnd = DetailsView1.Rows[rowIndex].FindControl("txtTimeWindowEnd") as TextBox;
            e.NewValues["Abstract"] = tbAbstract.Text;
            e.NewValues["LastRegistrationDate"] = tbLastRegistrationDate.Text;
            e.NewValues["StartDate"] = tbStartDate.Text;
            TimeSpan tsStart = TimeSpan.Parse(tbTimeWindowStart.Text);
            DateTime dtStart = new DateTime(2000, 1, 1, tsStart.Hours, tsStart.Minutes, 0);
            TimeSpan tsEnd = TimeSpan.Parse(tbTimeWindowEnd.Text);
            DateTime dtEnd = new DateTime(2000, 1, 1, tsEnd.Hours, tsEnd.Minutes, 0);
            e.NewValues["TimeWindowStart"] = dtStart;
            e.NewValues["TimeWindowEnd"] = dtEnd;
        }
    }
}