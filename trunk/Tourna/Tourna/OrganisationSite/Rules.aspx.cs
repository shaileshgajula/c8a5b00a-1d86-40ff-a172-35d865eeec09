using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.OrganisationSite
{
    public partial class Rules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.divRules.InnerHtml = TextContentManager.GetTextContent(new Guid(Request.QueryString["OrgId"].ToString()), 1);
            }
        }
    }
}
