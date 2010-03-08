using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.FrontSitePages.MiriMargolin
{
    public partial class GuestBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Feedbacks1.OrganisationId = this.Master.OrgId;
        }
    }
}