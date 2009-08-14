using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Caching;
using System.Net;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Tourna
{
    public class Global : System.Web.HttpApplication
    {
        private const string DummyPageUrl = "/dummypage.aspx";
        private const string CacheItemKey = "GagaGuguGigi";


        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterCacheEntry();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // If the dummy page is hit, then it means we want to add another item
            // in cache
            if (HttpContext.Current.Request.Url.AbsolutePath.ToLower() == DummyPageUrl)
            {
                // Add the item in cache and when succesful, do the work.
                RegisterCacheEntry();
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private void RegisterCacheEntry()
        {
            // Prevent duplicate key addition
            if (null != HttpContext.Current.Cache[CacheItemKey]) return;

            HttpContext.Current.Cache.Add(CacheItemKey, "value", null, DateTime.MaxValue,
                TimeSpan.FromHours(12), CacheItemPriority.NotRemovable,
                new CacheItemRemovedCallback(CacheItemRemovedCallback));
        }

        public void CacheItemRemovedCallback(
            string key,
            object value,
            CacheItemRemovedReason reason
            )
        {
            // Do the service works
            DoWork();

            // We need to register another cache item which will expire again in one
            // minute. However, as this callback occurs without any HttpContext, we do not
            // have access to HttpContext and thus cannot access the Cache object. The
            // only way we can access HttpContext is when a request is being processed which
            // means a webpage is hit. So, we need to simulate a web page hit and then 
            // add the cache item.
            HitPage();
        }
        private void HitPage()
        {
            WebClient client = new WebClient();
            client.DownloadData("http://localhost:21106"+DummyPageUrl);
        }

        /// <summary>
        /// Asynchronously do the 'service' works
        /// </summary>
        private void DoWork()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = conn;
                command.CommandText = "Insert into JobsLog (jobtitle)values('Scheduler')";
                conn.Open();
                command.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
            }
        }



    }
}