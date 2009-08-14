using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tourna.Backoffice
{
    public partial class BackOffice : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.OrganisationName = HttpContext.Current.Profile.GetPropertyValue("OrganisationName").ToString();
                this.OrganisationId = HttpContext.Current.Profile.GetPropertyValue("OrganisationId").ToString();
                this.hlOrganisationSite.NavigateUrl = string.Format("~/OrganisationSite/default.aspx?OrgId={0}", this.OrganisationId);
            }

        }
        public string OrganisationName
        {
            get
            {
                return this.lblOrganisationName.Text;
            }
            set
            {
                this.lblOrganisationName.Text = value;
            }
        }
        public string OrganisationId
        {
            get
            { return this.lblOrganisationId.Text; }
            set
            { this.lblOrganisationId.Text = value; }
        }
    }
}
