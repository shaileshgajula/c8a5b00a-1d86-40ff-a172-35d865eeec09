using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tourna
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
    }
}
