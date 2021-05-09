using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace EsameStato
{
    public partial class aggiornaUtente : System.Web.UI.Page
    {
        clsDB db;
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new clsDB("App_Data\\dbGoldenClub.mdf");
            string id = Session["idUtente"].ToString();
            email=db.cercaUtente(id);
            lblUsername.Text = email;
            caricaDdl();
        }

        private void caricaDdl()
        {
            for (int i = 110; i < 220; i++)
            {
                ddlAltezza.Items.Add(i.ToString());
            }
            for (int i = 30; i < 200; i++)
            {
                ddlPeso.Items.Add(i.ToString());
            }
            for (int i = 1; i < 60; i++)
            {
                ddlPercentualeMassaGrassa.Items.Add(i.ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCognome.Text != "" && txtNome.Text != "")
                {
                    string nome = txtNome.Text;
                    string cognome = txtCognome.Text;
                    int a;
                    float pm, p;
                    a = Convert.ToInt32(ddlAltezza.Text);
                    pm = Convert.ToSingle(ddlPercentualeMassaGrassa.Text);
                    p = Convert.ToSingle(ddlPeso.Text);
                    db.aggiornaUtente(cognome, nome, a, pm, p,email);
                    Response.Redirect("aggiornamentoSuccesso.aspx", false);
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