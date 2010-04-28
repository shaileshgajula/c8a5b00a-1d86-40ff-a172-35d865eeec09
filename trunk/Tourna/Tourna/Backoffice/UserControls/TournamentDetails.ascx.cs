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
            e.NewValues["Abstract"] = tbAbstract.Text;
            e.NewValues["LastRegistrationDate"] = tbLastRegistrationDate.Text;
            e.NewValues["StartDate"] = tbStartDate.Text;
        }
    }
}