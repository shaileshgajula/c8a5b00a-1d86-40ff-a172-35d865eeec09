using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using StrongerOrg.Backoffice.DataLayer;

namespace StrongerOrg.Backoffice
{
    public partial class InvitToTournament : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.lblMsg.Text = GetEmailBody();
            }

        }

        private string GetEmailBody()
        {
          
            ListDictionary replacements = new ListDictionary();
            using (TournaDataContext db = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                var tournametInfo = (from t in db.Tournaments
                                     join g in db.Games on t.GameId equals g.Id
                                     where t.Id == new Guid(Request.QueryString["TournamentId"].ToString())
                                     select new
                                     {
                                         t.TournamentName,
                                         t.StartDate,
                                         t.TimeWindowStart,
                                         t.TimeWindowEnd,
                                         t.Locations,
                                         g.Title,
                                         g.ConsoleName,
                                         t.FirstPrize,
                                         t.SecondPrize,
                                         t.ThirdPrize,
                                         t.Abstract
                                     }).Single();

                replacements.Add("<% OrgId %>", this.Master.OrgBasicInfo.Id.ToString());
                replacements.Add("<% TournamentName %>", tournametInfo.TournamentName);
                replacements.Add("<% When %>", tournametInfo.StartDate.ToString("D"));
                replacements.Add("<% StartTime %>", tournametInfo.TimeWindowStart.ToString());
                replacements.Add("<% EndTime %>", tournametInfo.TimeWindowEnd.ToString());
                replacements.Add("<% Where %>", tournametInfo.Locations);
                replacements.Add("<% GameName %>", tournametInfo.Title);
                replacements.Add("<% FirstPrize %>", string.IsNullOrEmpty(tournametInfo.FirstPrize) ? "N/A" : tournametInfo.FirstPrize);
                replacements.Add("<% SecondPrize %>", string.IsNullOrEmpty(tournametInfo.SecondPrize) ? "N/A" : tournametInfo.SecondPrize);
                replacements.Add("<% ThirdPrize %>", string.IsNullOrEmpty(tournametInfo.ThirdPrize) ? "N/A" : tournametInfo.ThirdPrize);
                replacements.Add("<% TournamentId %>", Request.QueryString["TournamentId"].ToString());
                replacements.Add("<% Abstract %>", tournametInfo.Abstract);
                replacements.Add("<% ConsoleName %>", tournametInfo.ConsoleName);
            }


            MailDefinition message = new MailDefinition();
            message.BodyFileName = @"~\EmailTemplate\TournamentInvintation.htm";
            MailMessage msgHtml = message.CreateMailMessage("a@a.com", replacements, new LiteralControl());
            return msgHtml.Body;
        }

        protected void lbSend_Click(object sender, EventArgs e)
        {
              string moderatorEmail = Membership.GetUser().Email;
            SmtpClient client = new SmtpClient(); //host and port picked from web.config
            client.EnableSsl = true;
            MailMessage msgHtml = new MailMessage("donotreply@strongerorg.com", moderatorEmail);
            msgHtml.Subject = "StrongerOrg - Tournament Invitation";
            msgHtml.Body = this.lblMsg.Text;
            msgHtml.IsBodyHtml = true;
            try
            {
                client.Send(msgHtml);
                this.lblResult.Text = "An email has been sent to " + moderatorEmail;
                this.lbSend.Visible = false;
            }
            catch (Exception ex)
            {
                this.lblResult.Text = "There was a problem to send the email.";
                throw ex; //or return the error by some other means, say on a label
            }
        }
    }
}
