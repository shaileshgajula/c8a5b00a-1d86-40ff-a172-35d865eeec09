using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.Entities;
using System.Web.Caching;

namespace StrongerOrg.OrganisationSite
{
    public partial class OrgSite : System.Web.UI.MasterPage
    {
        string orgId;
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Request.QueryString["OrgId"].ToString();
            OrganisationManager.OrganisationBasicInfo orgBasicInfo;
            if (HttpContext.Current.Cache[orgId] != null)
            {
                orgBasicInfo = HttpContext.Current.Cache[orgId] as OrganisationManager.OrganisationBasicInfo;
            }
            else
            {
                orgBasicInfo = OrganisationManager.GetOrganisationInfo(new Guid(orgId));
                HttpContext.Current.Cache.Add(orgId, orgBasicInfo, null, DateTime.MaxValue, new TimeSpan(0, 35, 0), CacheItemPriority.Normal, null);
            }
            this.Page.Title = orgBasicInfo.Name;
            if (string.IsNullOrEmpty(orgBasicInfo.Logo))
            {
                this.imgOrgLogo.Visible = false;
                this.lblOrgLotoText.Text = orgBasicInfo.Name;
            }
            else
            {
                this.imgOrgLogo.ImageUrl = string.Format("~/OrganisationLogos/{0}", orgBasicInfo.Logo);
            }
        }

        protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            e.Item.NavigateUrl += string.Format("?OrgId={0}", orgId);
        }
    }
}
