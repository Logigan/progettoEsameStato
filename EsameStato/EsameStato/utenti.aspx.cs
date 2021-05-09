using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Net.Http;
using System.Data;
using Newtonsoft.Json;

namespace EsameStato
{
    public partial class utenti : System.Web.UI.Page
    {
        clsDB db;
        string uri = "http://localhost:55947/api/";
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new clsDB("App_Data\\dbGoldenClub.mdf");
            popolaDgv();
            
        }

        private void popolaDgv()
        {
            try
            {
                /*dgv.DataSource = db.leggiUtenti();
                dgv.DataBind();*/
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(uri);
                var responseTask = client.GetAsync("clienti");
                responseTask.Wait();
                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<clsClienti[]>();
                    readTask.Wait();
                    var clienti = readTask.Result;
                    DataTable dt = new DataTable();
                    DataRow riga;
                    dt.Columns.Add("idCliente");
                    dt.Columns.Add("nome");
                    dt.Columns.Add("cognome");
                    dt.Columns.Add("email");
                    dt.Columns.Add("altezza");
                    dt.Columns.Add("peso");
                    dt.Columns.Add("pMassaGrassa");
                    foreach(var cliente in clienti)
                    {
                        riga = dt.NewRow();
                        riga["idCliente"] = cliente.idCliente;
                        riga["nome"] = cliente.nome;
                        riga["cognome"] = cliente.cognome;
                        riga["email"] = cliente.email;
                        riga["altezza"] = cliente.altezza;
                        riga["peso"] = cliente.peso;
                        riga["pMassaGrassa"] = cliente.pMassaGrassa;
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

        protected void dgv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;
            string id;
            index = Convert.ToInt32(e.CommandArgument);
            id = dgv.DataKeys[index].Value.ToString();
            Session["idUtente"] = id;
            if (e.CommandName == "aggiorna")
                Response.Redirect("aggiornaUtente.aspx", false);
            else
            {
                if(e.CommandName=="elimina")
                {
                    try
                    {
                        eliminaUtente(Convert.ToInt32(id));
                        popolaDgv();
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = "ERRORE: " + ex.Message;
                    }
                }
            }
        }

        private void eliminaUtente(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(uri);
                //HTTP GET
                var responseTask = client.DeleteAsync("clienti?idUtente=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //leggo eventuale risposta
                    //var readTask = result.Content.ReadAsStringAsync();
                    //readTask.Wait();
                    lblMsg.Text = "Record Eleminato";
                }
                else
                    lblMsg.Text = result.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Errore: " + ex.Message;
            }
        }
    }
}