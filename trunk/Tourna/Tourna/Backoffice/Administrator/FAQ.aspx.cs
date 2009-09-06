using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.Backoffice.Administrator
{
    public partial class FAQ : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FormView1.ChangeMode(FormViewMode.Edit);
        }

        protected void lbNewFAQ_Click(object sender, EventArgs e)
        {
            //this.SqlDataSource1.SelectParameters["Id"]
            this.FormView1.ChangeMode(FormViewMode.Insert);
        }

        protected void FormView1_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            this.GridView1.DataBind();
        }

        protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            this.GridView1.DataBind();
        }

       
    }
}
