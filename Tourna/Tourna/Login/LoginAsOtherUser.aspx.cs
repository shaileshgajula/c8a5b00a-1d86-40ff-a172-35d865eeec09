using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Tourna.Login
{
    public partial class LoginAsOtherUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(this.AdminUserName.Text, this.AdminPassword.Text))
            {
                if (Roles.IsUserInRole(this.AdminUserName.Text, "Administrator"))
                {
                    MembershipUser loginAsUser = Membership.GetUser(this.LogInAsUserName.Text);
                    if (loginAsUser != null)
                    {
                        LoginUser();
                        Response.Redirect("~/Backoffice/default.aspx");
                    }
                    else
                    {
                        this.FailureText.Text = string.Format("The user {0} does not exist in the Membership database.", this.AdminUserName.Text);
                    }
                }
                else
                {
                    this.FailureText.Text = "Only Admins can log into the site as another user. To login as yourself, please visit the standard Login page.";
                }
            }
            else
            {
                //The Admin username/password are invalid
                this.FailureText.Text = "Your login attempt was not successful. Please try again.";
            }
        }

        private void LoginUser()
        {
            // Create the cookie that contains the forms authentication ticket
            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(LogInAsUserName.Text, false);

            // Get the FormsAuthenticationTicket out of the encrypted cookie
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            // Create a new FormsAuthenticationTicket that includes our custom User Data
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate,
                ticket.Expiration, ticket.IsPersistent, AdminUserName.Text);

            // Update the authCookie's Value to use the encrypted version of newTicket
            authCookie.Value = FormsAuthentication.Encrypt(newTicket);

            //' Manually add the authCookie to the Cookies collection 
            Response.Cookies.Add(authCookie);

            
        }
    }
}
