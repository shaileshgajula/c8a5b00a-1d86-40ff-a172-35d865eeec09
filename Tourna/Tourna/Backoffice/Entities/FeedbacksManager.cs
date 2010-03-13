using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using StrongerOrg.Backoffice.DataLayer;
using System.Configuration;

namespace StrongerOrg.Backoffice.Entities
{
    [DataObjectAttribute(true)]
    public class FeedbacksManager
    {
        [DataObjectMethodAttribute(DataObjectMethodType.Select)]
        public List<FeedBack> GetFeedbacks(string orgId)
        {
            Guid organisationId = new Guid(orgId);
            using (TournaDataContext db = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                var z = from fb in db.FeedBacks
                        where fb.OrganisationId == organisationId
                        orderby fb.DateStamp descending
                        select fb;
                return z.ToList();
            }
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Delete)]
        public void DeleteFeedback(int Id)
        {
            using (TournaDataContext db = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                db.ExecuteCommand("Delete from feedBacks where id={0}", Id);
            }
        }

        internal static void FeedbackInsert(Guid orgId, string feedbackWriterName, string feedbackContent, string feedbackWriterEmail)
        {
            using (TournaDataContext db = new TournaDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                db.FeedBacks.InsertOnSubmit(new FeedBack() { FeedbackWriterName = feedbackWriterName, FeedbackContent = feedbackContent, FeedbackWriterEmail = feedbackWriterEmail, OrganisationId = orgId, DateStamp = DateTime.Now });
                db.SubmitChanges();
            }
        }
    }
}