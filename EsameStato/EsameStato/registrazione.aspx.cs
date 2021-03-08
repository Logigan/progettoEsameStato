using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsameStato
{
    public partial class registrazione : System.Web.UI.Page
    {
        clsDB db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new clsDB("App_Data\\dbGoldenClub.mdf");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCognome.Text != "" && txtNome.Text != "" && txtEmail.Text != "" && txtAltezza.Text!="" && txtPercentualeMassaGrassa.Text!="" && txtPeso.Text!="")
                {
                    int a;
                    float pm, p;
                    a = Convert.ToInt32(txtAltezza.Text);
                    pm = Convert.ToSingle(txtPercentualeMassaGrassa.Text);
                    p = Convert.ToSingle(txtPeso.Text);
                    db.InserisciUtenteEInfo(txtCognome.Text, txtNome.Text, txtEmail.Text, a,pm,p);
                    lblMsg.Text = "Utente inserito";
                }
                else
                    lblMsg.Text = "ERRORE: i campi nome, cognome, email possono risultare incompleti";
            }
            catch (Exception ex)
            {
                lblMsg.Text = "ERRORE: " + ex.Message;
            }
        }
    }
}