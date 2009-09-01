using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.FrontSitePages
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.ActiveContactHyperLink();
        }

        protected void ibClear_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibSend_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
