using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.Backoffice
{
    public partial class TeamPlayers : BasePage
    {
        public int i = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

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