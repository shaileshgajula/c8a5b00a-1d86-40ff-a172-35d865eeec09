using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.FrontSitePages.MiriMargolin
{
    public partial class MiriMargolin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblPageTitle.Text = this.Page.Title;
        }
        public string OrgId
        {
            get { return this.lblOrganisationId.Text; }
        }
    }
}