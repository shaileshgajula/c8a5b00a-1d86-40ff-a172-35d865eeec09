using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.Entities;

namespace StrongerOrg.Backoffice
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string hostName = Request.Url.Host;
            this.Login1.TitleText = string.Format("{0} [Log In]",hostName);
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            Response.Cookies["OrganisationId"].Value = UsersManager.GetOrganisationId(this.Login1.UserName).ToString();
            Response.Cookies["OrganisationId"].Expires = DateTime.Now.AddDays(5);
        }
    }
}
