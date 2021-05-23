using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Net.Http;
using Newtonsoft.Json;

namespace EsameStato
{
    public partial class aggiornaUtente : System.Web.UI.Page
    {
        string email;
        string uri = "http://localhost:55947/api/";
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Session["idUtente"].ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            var responseTask = client.GetAsync("clienti?idUtente=" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if(result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                clsClienti c = JsonConvert.DeserializeObject<clsClienti>(readTask.Result);
                email = c.email;
                lblUsername.Text = email;
                caricaDdl();
            }
            else
                lblMsg.Text = result.StatusCode.ToString();
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
                    int pm, p;
                    string id = Session["idUtente"].ToString();
                    a = Convert.ToInt32(ddlAltezza.Text);
                    pm = Convert.ToInt32(ddlPercentualeMassaGrassa.Text);
                    p = Convert.ToInt32(ddlPeso.Text);
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(uri);
                    clsClienti cliente = new clsClienti();
                    cliente.nome = nome;
                    cliente.idCliente = Convert.ToInt32(id);
                    cliente.cognome = cognome;
                    cliente.altezza = a;
                    cliente.peso = p;
                    cliente.pMassaGrassa = pm;
                    var postTask = client.PostAsJsonAsync<clsClienti>("clienti", cliente);
                    var result = postTask.Result;
                    if(result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();
                        Response.Redirect("aggiornamentoSuccesso.aspx", false);
                    }
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