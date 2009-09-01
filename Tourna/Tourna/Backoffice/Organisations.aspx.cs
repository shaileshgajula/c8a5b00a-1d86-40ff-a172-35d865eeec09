using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using StrongerOrg.Backoffice.DataLayer;
using System.Globalization;

namespace StrongerOrg.Backoffice
{
    public partial class Organisations : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //this.DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string organisationName = this.GridView1.SelectedDataKey["Name"].ToString();
            string organisationId = this.GridView1.SelectedDataKey["Id"].ToString();
            Response.Cookies["OrganisationId"].Value = organisationId;
            this.Master.OrganisationName = organisationName;
            this.Master.OrganisationId = organisationId;
        }
    }
}
