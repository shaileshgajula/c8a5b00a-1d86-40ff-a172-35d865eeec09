using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;

namespace StrongerOrg.Backoffice
{
    public partial class BackOffice : System.Web.UI.MasterPage
    {
        OrganisationManager.OrganisationBasicInfo orgBasicInfo;
        protected override void OnInit(EventArgs e)
        {
            string orgId = string.Empty;
            if (Request.Cookies["OrganisationId"] != null)
            {
                orgId = Server.HtmlEncode(Request.Cookies["OrganisationId"].Value);
                if (HttpContext.Current.Cache[orgId] != null)
                {
                    orgBasicInfo = HttpContext.Current.Cache[orgId] as OrganisationManager.OrganisationBasicInfo;
                }
                else
                {
                    orgBasicInfo = OrganisationManager.GetOrganisationInfo(new Guid(orgId));
                    HttpContext.Current.Cache.Add(orgId, orgBasicInfo, null, DateTime.MaxValue, new TimeSpan(0, 35, 0), CacheItemPriority.Normal, null);
                }
                this.OrganisationId = orgId;
                this.lblOrganisationName.Text = orgBasicInfo.Name;
            }
            else
            {
                this.lblOrganisationId.Text = "Problem to read cookie";
                this.lblOrganisationId.ForeColor = System.Drawing.Color.Red;
            }
            this.lblRole.Text = ((BasePage)this.Page).UserRole;
            base.OnInit(e);
            this.lblTitle.Text = this.Page.Title;
        }
        public OrganisationManager.OrganisationBasicInfo OrgBasicInfo
        {
            get { return orgBasicInfo; }
        }
        public string OrganisationName
        {
            set
            {
                this.lblOrganisationName.Text = value;
            }
        }
        public string OrganisationId
        {
            set
            {
                this.lblOrganisationId.Text = value;
                this.hlOpenSite.NavigateUrl = string.Format("~/OrganisationSite/Default.aspx?OrgId={0}", value);
            }
        }
    }
}
