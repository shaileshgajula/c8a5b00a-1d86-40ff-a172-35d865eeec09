using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg
{
    public partial class DummyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 30; i++)
            {
                this.Calendar1.SelectedDates.Add(new DateTime(2009, 9, i));
            }
            for (int i = 1; i < 30; i++)
            {
                this.Calendar1.SelectedDates.Add(new DateTime(2009, 10, i));
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
