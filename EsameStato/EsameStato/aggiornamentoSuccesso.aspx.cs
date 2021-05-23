using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;

namespace EsameStato
{
    public partial class aggiornamentoSuccesso : System.Web.UI.Page
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
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                clsClienti c = JsonConvert.DeserializeObject<clsClienti>(readTask.Result);
                email = c.email;
                lblUsername.Text = email;
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx", false);
        }
    }
}