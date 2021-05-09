using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsameStato
{
    public partial class aggiornamentoSuccesso : System.Web.UI.Page
    {
        clsDB db;
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new clsDB("App_Data\\dbGoldenClub.mdf");
            string id = Session["idUtente"].ToString();
            email = db.cercaUtente(id);
            lblUsername.Text = email;
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx", false);
        }
    }
}