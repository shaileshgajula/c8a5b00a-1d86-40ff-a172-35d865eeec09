using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.FrontSitePages.MiriMargolin
{
    public partial class ShowCase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            mvShowCase.ActiveViewIndex = int.Parse(this.Menu1.SelectedValue);
        }
    }
}