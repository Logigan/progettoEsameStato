﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsameStato
{
    public partial class pagMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("registrazione.aspx");
        }
    }
}