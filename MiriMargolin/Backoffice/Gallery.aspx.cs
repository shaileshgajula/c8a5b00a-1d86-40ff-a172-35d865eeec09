﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.Backoffice
{
    public partial class Gallery : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GalleryViewer1.OrgId = this.Master.OrgBasicInfo.Id;
        }

      
    }
}