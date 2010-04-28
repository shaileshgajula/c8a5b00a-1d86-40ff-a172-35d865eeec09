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
    public partial class MiriMargolin : System.Web.UI.MasterPage
    {
        private const string RECIPIENTS = "piniusha@gmail.com";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblPageTitle.Text = this.Page.Title;
        }
        public string OrgId
        {
            get { return this.lblOrganisationId.Text; }
        }

        protected void lbSendToFriend_Click(object sender, EventArgs e)
        {
            string url = Request.Url.AbsoluteUri;
            SmtpClient client = new SmtpClient(); //host and port picked from web.config
            client.EnableSsl = true;
            MailDefinition message = new MailDefinition();

            message.BodyFileName = @"~\EmailTemplate\MiriMargolinShareWithAFriend.htm";
            message.IsBodyHtml = true;
            message.From = "donotreply@strongerorg.com";
            message.Subject = "MiriMargolin - Share with a friend";

            ListDictionary replacements = new ListDictionary();
            replacements.Add("<% YourName %>", this.txtYourName.Text);
            replacements.Add("<% Message %>", this.txtMessage.Text);
            //MailMessage msgHtml = message.CreateMailMessage(this.txtFriendsEmail.Text, replacements, new LiteralControl());
            //msgHtml.Bcc.Add(new MailAddress(RECIPIENTS));
            try
            {
                //client.Send(msgHtml);
            }
            catch (Exception)
            {
                //this.lblMsg.Text = "There was a problem to send an email.";
            }
        }

        
    }
}