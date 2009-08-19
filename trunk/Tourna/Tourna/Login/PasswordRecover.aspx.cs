using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Web.Security;

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
                bool isLockedOut= membershipUser.IsLockedOut;
                if (isLockedOut)
                {
                    membershipUser.UnlockUser();
                }
                string newPassword = "123456";
                membershipUser.ChangePassword(membershipUser.ResetPassword(), newPassword);
                SmtpClient client = new SmtpClient(); //host and port picked from web.config
                client.EnableSsl = true;
                MailAddress from = new MailAddress("piniusha@gmail.com", "Pini Usha The Master");
                MailAddress to = new MailAddress(this.txtEmail.Text);
                MailMessage message = new MailMessage(from, to);
                message.Body = "the body comes here. your new password is:" + newPassword;
                message.Subject = "LMP - Password recovery";
                client.Host = "smtp.gmail.com";
                //following not required if username and password specified in web.config. username does not require @gmail.com
                NetworkCredential myCreds = new NetworkCredential("piniusha@gmail.com", "waliaysm", "");
                client.Credentials = myCreds;
                try
                {
                    client.Send(message);
                }

                catch (Exception ex)
                {
                    throw ex; //or return the error by some other means, say on a label
                }
            }
            else
            {
                // no email found
            }

        }


    }
}
