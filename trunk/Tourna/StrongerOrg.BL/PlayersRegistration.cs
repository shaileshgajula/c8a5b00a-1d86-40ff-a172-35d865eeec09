using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using System.Configuration;
using System.Net.Mail;
using System.Collections;

namespace StrongerOrg.BL
{
    public class PlayersRegistration
    {
        public static void SendWelcomeEmail(string mailTo ,Guid orgId, string tournamentId, string orgLogo, string tournamentName, DateTime startDate)
        {
            ListDictionary replacements = new ListDictionary();
            replacements.Add("<% OrgId %>", orgId);
            replacements.Add("<% TournamentName %>", tournamentName);
            replacements.Add("<% StartDate %>", startDate);
            replacements.Add("<% TournamentId %>", tournamentId);

            string templatePath = Path.Combine(ConfigurationManager.AppSettings["EmailTemplatePath"].ToString(), "WelcomeEmail.htm");
            string matchUpReadyTemplate = File.ReadAllText(templatePath);
            SmtpClient client = new SmtpClient(); //host and port picked from web.config
            client.EnableSsl = true;
            

            foreach (DictionaryEntry item in replacements)
            {
                matchUpReadyTemplate = matchUpReadyTemplate.Replace(item.Key.ToString(), item.Value.ToString());
            }
            MailMessage message = new MailMessage();
            message.Subject = "Welcome Email";
            message.From = new MailAddress("donotreply@strongerorg.com");
            message.To.Add(mailTo);
            message.IsBodyHtml = true;
            message.Body = matchUpReadyTemplate;

            try
            {
                client.Send(message);
            }
            catch (Exception)
            {

            }
            
        }
    }
}
