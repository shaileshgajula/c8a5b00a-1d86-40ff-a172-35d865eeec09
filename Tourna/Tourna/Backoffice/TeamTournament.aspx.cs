using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.Backoffice
{
    public partial class TeamTournament : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.UserRole != "Administrator" && this.Menu1.Items.Count > 4 && this.Menu1.Items.Contains(this.Menu1.Items[4]))
            {
                this.Menu1.Items.Remove(this.Menu1.Items[4]);
            }
            this.Feedbacks1.OrganisationId = this.TournamentId.ToString();
        }
        protected void navMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            mvTournament.ActiveViewIndex = int.Parse(this.Menu1.SelectedValue);
        }
        private Guid TournamentId
        {
            get { return new Guid(Request.QueryString["TournamentId"].ToString()); }
        }
    }
}