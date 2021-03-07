using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsameStato
{
    public partial class index : System.Web.UI.Page
    {
        clsDB db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new clsDB("App_Data\\dbGoldenClub.mdf");
        }

        protected void btnRegistraRapido_Click(object sender, EventArgs e)
        {
            try
            {
                db.InserisciUtente(txtCognome.Text, txtNome.Text, txtEmail.Text);
                azzera();
                lblMsg.Text = "Utente inserito";
            }
            catch (Exception ex)
            {
                lblMsg.Text = "ERRORE: " + ex.Message;
            }
        }

        private void azzera()
        {
            throw new NotImplementedException();
        }
    }
}