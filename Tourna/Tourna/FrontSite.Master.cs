﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using StrongerOrg.Backoffice.DataLayer;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Profile;

namespace StrongerOrg
{
    public partial class FrontSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ActiveHomeHyperLink()
        {
            this.hlHome.CssClass = "NavigaionSelected";
        }
        public void ActiveProductsHyperLink()
        {
            this.hlProducts.CssClass = "NavigaionSelected";
        }
        public void ActiveCustomersHyperLink()
        {
            this.hlCustomers.CssClass = "NavigaionSelected";
        }
        public void ActiveJoinHyperLink()
        {
            this.hlJoin.CssClass = "NavigaionSelected";
        }
        public void ActiveAboutHyperLink()
        {
            this.hlAbout.CssClass = "NavigaionSelected";
        }
        public void ActiveContactHyperLink()
        {
            this.hlContact.CssClass = "NavigaionSelected";
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            string userName = this.txtUserName.Text;
            string pws = this.txtPassword.Text;
            bool validateUser = Membership.ValidateUser(userName, pws);

            if (validateUser)
            {
                this.LoginUser(userName);
                Response.Redirect("~/backoffice/default.aspx");
            }
            else
            {
                this.lblLoginMessage.Text = "User name or password are incorrect";
            }
        }
        private void LoginUser(string userName)
        {
            
                // Create the cookie that contains the forms authentication ticket
                HttpCookie authCookie = FormsAuthentication.GetAuthCookie(userName, false);

                // Get the FormsAuthenticationTicket out of the encrypted cookie
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                // Update the authCookie's Value to use the encrypted version of newTicket
                authCookie.Value = FormsAuthentication.Encrypt(ticket);
                
                //Manually add the authCookie to the Cookies collection 
                Response.Cookies.Add(authCookie);

            //    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            //    {
            //        SqlCommand command = new SqlCommand("OrganisationInfoByUserNameGet", conn);
            //        command.CommandType = System.Data.CommandType.StoredProcedure;
            //        command.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar, 255).Value = userName;
            //        conn.Open();
            //        SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            //        while (reader.Read())
            //        {
            //            Guid organisationId = reader.GetGuid(0);
            //            OrganisationManager.GetOrganisationInfo(organisationId);
                        
            //            //HttpContext.Current.Profile.SetPropertyValue("OrganisationId", x);
            //            //HttpContext.Current.Profile.SetPropertyValue("OrganisationName", reader[1]);

            //        }

            //}
        }
    }
}
