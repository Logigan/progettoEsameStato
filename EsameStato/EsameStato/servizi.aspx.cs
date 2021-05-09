using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace EsameStato
{
    public partial class servizi : System.Web.UI.Page
    {
        clsDB db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new clsDB("App_Data\\dbGoldenClub.mdf");
            popolaDgv();
        }

        private void popolaDgv()
        {
            try
            {
                dgv.DataSource = db.leggiServizi();
                dgv.DataBind();
            }
            catch (Exception ex)
            {
                string errore;
                errore = ex.Message;
            }
        }

        public string percorso = "App_Data/schede/";
        protected void btnRegistrazioneServizio_Click(object sender, EventArgs e)
        {
            if (fup.HasFile)
                try
                {
                    string percorsoDb = percorso + fup.FileName;
                    if(Regex.Match(txtPrezzo.Text, "^[0-9]+,[0-9]{2}$").Success|| Regex.Match(txtPrezzo.Text, "^[0-9]*$").Success)
                    {
                        if (txtPrezzo.Text != "" && txtTipologia.Text != "")
                        {
                            string tipologia;
                            float prezzo;
                            prezzo = float.Parse(txtPrezzo.Text);
                            tipologia = Convert.ToString(txtTipologia.Text);
                            fup.SaveAs(Server.MapPath(percorso) + fup.FileName);
                            db.InserisciServizio(tipologia, prezzo, percorsoDb);
                            lblMsg.Text = "Servizio inserito";
                            popolaDgv();
                        }
                        else
                            lblMsg.Text = "ERRORE: i campi tipologia o prezzo possno risultare incompleti";
                    }
                    else
                        lblMsg.Text = "ERRORE: il campo prezzo è errato";
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "ERROR: " + ex.Message.ToString();
                }
            else
            {
                lblMsg.Text = "Non hai specificato nessun file";
            }
        }

        protected void dgv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;
            string id;
            index = Convert.ToInt32(e.CommandArgument);
            string percorso = dgv.Rows[index].Cells[3].Text;
            id = dgv.DataKeys[index].Value.ToString();
            if (e.CommandName == "elimina")
            {
                try
                {
                    db.EliminaServizio(Convert.ToInt32(id));
                    eliminaFile(percorso);
                    popolaDgv();
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "ERRORE: " + ex.Message;
                }
            }
        }

        private void eliminaFile(string percorso)
        {
            string map = Convert.ToString(Server.MapPath(percorso));
            File.Delete(map);
        }
    }
}