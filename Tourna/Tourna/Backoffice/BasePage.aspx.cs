using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace StrongerOrg.Backoffice
{
    public partial class BasePage :Page
    {

        protected override void OnPreInit(EventArgs e)
        {
            if (Context.User.IsInRole("Administrator"))
            {
                this.UserRole = "Administrator";
                this.Theme = "Administrator";
            }
            else if (Context.User.IsInRole("Moderator"))
            {
                this.UserRole = "Moderator";
                this.Theme = "Moderator";
            }
            else if (Context.User.IsInRole("Accountants"))
            {
                this.UserRole = "Accountants";
                this.Theme = "Accountants";
            }
            else if (Context.User.IsInRole("LockSmithUser"))
            {
                this.UserRole = "Lock Smith User";
                this.Theme = "Moderator";
            }
            else if (Context.User.IsInRole("MiriMargolinDelegate"))
            {
                this.UserRole = "Miri Margolin Delegate";
                this.Theme = "Moderator";
            }
            base.OnPreInit(e);
        }
        public string UserRole { get; set; }
        
    }
}
