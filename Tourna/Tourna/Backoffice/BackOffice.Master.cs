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
            string orgId;
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
                this.lblOrganisationId.Text = orgId;
                this.lblOrganisationName.Text = orgBasicInfo.Name;
            }
            else
            {
                this.lblOrganisationId.Text = "Problem to read cookie";
            }
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }
        public OrganisationManager.OrganisationBasicInfo OrgBasicInfo
        {
            get { return orgBasicInfo; }
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
