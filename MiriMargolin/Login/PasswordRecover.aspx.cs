using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Web.Security;
using System.Collections.Specialized;

namespace StrongerOrg.Login
{
    public partial class PasswordRecover : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string userName = Membership.GetUserNameByEmail(this.txtEmail.Text);

            if (!string.IsNullOrEmpty(userName))
            {
                MembershipUser membershipUser = Membership.GetUser(userName);
                bool isLockedOut = membershipUser.IsLockedOut;
                if (isLockedOut)
                {
                    membershipUser.UnlockUser();
                }
                Random r = new Random();
                string newPassword = string.Format("{0}{1}", userName, r.Next(1, 10));
                membershipUser.ChangePassword(membershipUser.ResetPassword(), newPassword);
                SmtpClient client = new SmtpClient(); //host and port picked from web.config
                client.EnableSsl = true;
                MailDefinition message = new MailDefinition();
                message.BodyFileName = @"~\EmailTemplate\RecoverPassword.htm";
                message.IsBodyHtml = true;
                message.From = "donotreply@strongerorg.com";
                message.Subject = "StrongerOrg - Password recovery";
                ListDictionary replacements = new ListDictionary();
                replacements.Add("<% UserName %>", userName);
                replacements.Add("<% NewPassword %>", newPassword);
                MailMessage msgHtml = message.CreateMailMessage(this.txtEmail.Text, replacements, new LiteralControl());
                try
                {
                    client.Send(msgHtml);
                    this.lblMsg.Text = "Your new password has been sent to your email";
                    this.btnSend.Enabled = false;
                }

                catch (Exception ex)
                {
                    this.lblMsg.Text = "There was a problem to send an email.";
                    throw ex; //or return the error by some other means, say on a label
                    
                }
            }
            else
            {
                this.lblMsg.Text = "No email found, please try different email";
            }

        }


    }
}
