﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.Backoffice.UserControls
{
    public partial class Feedbacks : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public bool IsEditMode { get; set; }

        public string OrganisationId { get; set; }

        public string TextContentName
        {
            get { return ViewState["TextContentName"].ToString(); }
            set { ViewState["TextContentName"] = value; }
        }

        protected void lbSend_Click(object sender, EventArgs e)
        {
            TextContentManager.TextContentInsert(new Guid(this.OrganisationId), TextContentName,this.txtName.Text, this.txtMessage.Text);
            this.txtName.Text = string.Empty;
            this.txtMessage.Text = string.Empty;
            //this.lblSendMsg.Text = "Thank you for your message. ";
            this.lvFeedbacks.DataBind();
            this.CollapsiblePanelExtender1.Collapsed = true;
            this.CollapsiblePanelExtender1.ClientState = "true";
        }

        protected void lbDelete_click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;
            string id = lb.CommandArgument;

        }
        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["orgId"] = this.OrganisationId;
            e.InputParameters["ContentType"] = this.TextContentName;
        }

        protected void lvFeedbacks_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            LinkButton lb = e.Item.FindControl("lbDelete") as LinkButton;
            lb.Visible = this.IsEditMode;
        }

       

    }
}