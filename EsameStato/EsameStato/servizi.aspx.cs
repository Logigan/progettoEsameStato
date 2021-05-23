using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Http;
using System.Data;

namespace EsameStato
{
    public partial class servizi : System.Web.UI.Page
    {
        string uri = "http://localhost:55947/api/";
        protected void Page_Load(object sender, EventArgs e)
        {
            popolaDgv();
        }

        private void popolaDgv()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(uri);
                var responseTask = client.GetAsync("servizi");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<clsServizi[]>();
                    readTask.Wait();
                    var servizi = readTask.Result;
                    DataTable dt = new DataTable();
                    DataRow riga;
                    dt.Columns.Add("idServizio");
                    dt.Columns.Add("tipologia");
                    dt.Columns.Add("prezzo");
                    dt.Columns.Add("percorso");
                    foreach(var servizio in servizi)
                    {
                        riga = dt.NewRow();
                        riga["idServizio"] = servizio.idServizio;
                        riga["tipologia"] = servizio.tipologia;
                        riga["prezzo"] = servizio.prezzo;
                        riga["percorso"] = servizio.percorso;
                        dt.Rows.Add(riga);
                    }
                    dgv.DataSource = dt;
                    dgv.DataBind();
                }
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
                            clsServizi servizio = new clsServizi();
                            servizio.tipologia = tipologia;
                            servizio.prezzo = prezzo;
                            servizio.percorso = percorsoDb;
                            HttpClient client = new HttpClient();
                            client.BaseAddress = new Uri(uri);
                            var postTask = client.PostAsJsonAsync<clsServizi>("servizi", servizio);
                            var result = postTask.Result;
                            if(result.IsSuccessStatusCode)
                            {
                                var readTask = result.Content.ReadAsStringAsync();
                                readTask.Wait();
                                fup.SaveAs(Server.MapPath(percorso) + fup.FileName);
                                lblMsg.Text = "Servizio inserito";
                                popolaDgv();
                            }
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
                    eliminaInDb(Convert.ToInt32(id));
                    eliminaFile(percorso);
                    popolaDgv();
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "ERRORE: " + ex.Message;
                }
            }
        }

        private void eliminaInDb(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(uri);
                //HTTP GET
                var responseTask = client.DeleteAsync("servizi?idServizio=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //leggo eventuale risposta
                    //var readTask = result.Content.ReadAsStringAsync();
                    //readTask.Wait();
                    lblMsg.Text = "Servizio Eliminato";
                }
                else
                    lblMsg.Text = result.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Errore: " + ex.Message;
            }
        }

        private void eliminaFile(string percorso)
        {
            string map = Convert.ToString(Server.MapPath(percorso));
            File.Delete(map);
        }
    }
}