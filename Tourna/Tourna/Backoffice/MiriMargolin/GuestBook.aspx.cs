using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.Backoffice.MiriMargolin
{
    public partial class GuestBook : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.Page.IsPostBack)
            {
                this.Feedbacks1.OrganisationId = this.Master.OrgBasicInfo.Id.ToString();
            }
        }
    }
}