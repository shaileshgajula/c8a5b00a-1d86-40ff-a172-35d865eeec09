using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace StrongerOrg.Backoffice
{
    public partial class WhoIsOnline : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.NumOnline.Text = Membership.GetNumberOfUsersOnline().ToString();
            }
        }

        protected void CurrentActivityDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.Parameters["@ApplicationName"].Value = Membership.ApplicationName;
            e.Command.Parameters["@MinutesSinceLastInActive"].Value = Membership.UserIsOnlineTimeWindow;
            e.Command.Parameters["@CurrentTimeUtc"].Value = DateTime.UtcNow;
        }
    }
}
