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
using System.Web.Security;

namespace StrongerOrg.Backoffice
{
    public partial class Organisations : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string organisationName = this.GridView1.SelectedDataKey["Name"].ToString();
            string organisationId = this.GridView1.SelectedDataKey["Id"].ToString();
            Response.Cookies["OrganisationId"].Value = organisationId;
            this.Master.OrganisationName = organisationName;
            this.Master.OrganisationId = organisationId;
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            if (!((BasePage)this.Page).UserRole.Equals("Administrator"))
            {
                e.Cancel = true;
                this.GridView1.Visible = false;
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.className='SelectedRowStyle'");
                    e.Row.Attributes.Add("onmouseout", "this.className='AlternatingRow'");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.className='SelectedRowStyle'");
                    e.Row.Attributes.Add("onmouseout", "this.className='RowBackColor'");
                }
            }
        }
    }
}
