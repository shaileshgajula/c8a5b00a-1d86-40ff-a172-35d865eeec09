﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Tourna.Backoffice
{
    public partial class Rules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.reRules.Content =TextContentManager.GetTextContent(new Guid(HttpContext.Current.Profile.GetPropertyValue("OrganisationId").ToString()), 1);
            }
        }

        protected void lbSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("TextContentInsert", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@OrganisationId", SqlDbType.UniqueIdentifier, 150).Value = new Guid(HttpContext.Current.Profile.GetPropertyValue("OrganisationId").ToString());
                command.Parameters.Add("@ContentType", SqlDbType.Int, 4).Value = 1;
                command.Parameters.Add("@Content", SqlDbType.Text).Value = this.reRules.Content;
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}