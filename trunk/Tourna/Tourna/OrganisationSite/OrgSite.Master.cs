using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tourna.Backoffice.Entities;
using System.Web.Caching;

namespace Tourna.OrganisationSite
{
    public partial class OrgSite : System.Web.UI.MasterPage
    {
        string orgId;
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Request.QueryString["OrgId"].ToString();
            OrganisationInfo.OrganisationEntityRow orgInfo;
            if (HttpContext.Current.Cache[orgId] != null)
            {
                orgInfo = HttpContext.Current.Cache[orgId] as OrganisationInfo.OrganisationEntityRow;
            }
            else
            {
                orgInfo = OrganisationManager.GetOrganisationInfo(new Guid(orgId));
                HttpContext.Current.Cache.Add(orgId, orgInfo, null, DateTime.MaxValue, new TimeSpan(0, 35, 0), CacheItemPriority.Normal, null);
            }
            //this.Page.Title = orgInfo.Name;
            if (string.IsNullOrEmpty(orgInfo.CompanyLogo))
            {
                this.imgOrgLogo.Visible = false;
                this.lblOrgLotoText.Text = orgInfo.Name;
            }
            else
            {
                this.imgOrgLogo.ImageUrl = string.Format("~/OrganisationLogos/{0}", orgInfo.CompanyLogo);
            }
        }

        protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            e.Item.NavigateUrl += string.Format("?OrgId={0}", orgId);
        }
    }
}
