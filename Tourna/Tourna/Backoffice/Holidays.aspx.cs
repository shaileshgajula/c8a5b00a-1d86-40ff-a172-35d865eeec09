using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongerOrg.Backoffice.Entities;

namespace StrongerOrg.Backoffice
{
    public partial class Holidyas : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Deleted(object sender, SqlDataSourceStatusEventArgs e)
        {
            CultureManager cm = new CultureManager(this.Master.OrgBasicInfo.Id);
            cm.ClearCache();
        }

        protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            CultureManager cm = new CultureManager(this.Master.OrgBasicInfo.Id);
            cm.ClearCache();
        }
    }
}
