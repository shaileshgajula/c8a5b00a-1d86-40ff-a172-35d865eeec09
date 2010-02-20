using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Collections.Specialized;

namespace StrongerOrg.FrontSitePages.MiriMargolin
{
    public partial class ContactUs : System.Web.UI.Page
    {
        private const string RECIPIENTS = "piniusha@gmail.com";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbSend_Click(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient(); //host and port picked from web.config
            client.EnableSsl = true;
            MailDefinition message = new MailDefinition();
            message.BodyFileName = @"~\EmailTemplate\MiriMargolinContact.htm";
            message.IsBodyHtml = true;
            message.From = "donotreply@strongerorg.com";
            message.Subject = "MiriMargolin - Contact Us Form";
            ListDictionary replacements = new ListDictionary();
            replacements.Add("<% Name %>", this.txtName.Text);
            replacements.Add("<% PhoneOrEmail %>", this.txtPhoneOrEmail.Text);
            replacements.Add("<% Message %>", this.txtMessage.Text);
            MailMessage msgHtml = message.CreateMailMessage(RECIPIENTS, replacements, new LiteralControl());
            try
            {
                client.Send(msgHtml);
                this.lblMsg.Text = "Your message has been send and will be adress shortly";
                this.lbSend.Enabled = false;
            }
            catch (Exception)
            {
                this.lblMsg.Text = "There was a problem to send an email.";
            }
        }
    }
}