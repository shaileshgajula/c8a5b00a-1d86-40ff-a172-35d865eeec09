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
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            object orgIdObj = Request.QueryString["OrgId"];

            if (orgIdObj != null && !string.IsNullOrEmpty(orgIdObj.ToString()))
            {
                string orgId = orgIdObj.ToString();
                if (HttpContext.Current.Cache[orgId] != null)
                {
                    this.OrgBasicInfo = HttpContext.Current.Cache[orgId] as OrganisationManager.OrganisationBasicInfo;
                }
                else
                {
                    this.OrgBasicInfo = OrganisationManager.GetOrganisationInfo(new Guid(orgId));
                    HttpContext.Current.Cache.Add(orgId, this.OrgBasicInfo, null, DateTime.MaxValue, new TimeSpan(0, 35, 0), CacheItemPriority.Normal, null);
                }
                this.Page.Title = this.OrgBasicInfo.Name;
                if (string.IsNullOrEmpty(this.OrgBasicInfo.Logo))
                {
                    this.imgOrgLogo.Visible = false;
                    this.lblOrgLotoText.Text = this.OrgBasicInfo.Name;
                }
                else
                {
                    this.imgOrgLogo.ImageUrl = string.Format("~/OrganisationLogos/{0}", this.OrgBasicInfo.Logo);
                }
            }
            else
            {
                Response.Redirect("http:\\www.ynet.co.il");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public OrganisationManager.OrganisationBasicInfo OrgBasicInfo { get; set; }

        protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            e.Item.NavigateUrl += string.Format("?OrgId={0}", this.OrgBasicInfo.Id);
        }
    }
}
