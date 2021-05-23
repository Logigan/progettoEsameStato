using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net.Http;
using Newtonsoft.Json;

namespace EsameStato
{
    public partial class registrazione : System.Web.UI.Page
    {
        string uri = "http://localhost:55947/api/";
        protected void Page_Load(object sender, EventArgs e)
        {
            caricaDdl();
        }

        private void caricaDdl()
        {
            for (int i = 110; i < 220;i++)
            {
                ddlAltezza.Items.Add(i.ToString());
            }
            for (int i = 30; i < 200; i++)
            {
                ddlPeso.Items.Add(i.ToString());
            }
            for(int i=1;i<60;i++)
            {
                ddlPercentualeMassaGrassa.Items.Add(i.ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCognome.Text != "" && txtNome.Text != "" && txtEmail.Text != "")
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(uri);
                    //HTTP GET
                    var responseTask = client.GetAsync("clienti?Email=" + txtEmail.Text);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if(result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();
                        bool esiste = Convert.ToBoolean(readTask.Result);
                        if (!esiste)
                        {
                            responseTask = client.GetAsync("password");
                            responseTask.Wait();
                            result = responseTask.Result;
                            if(result.IsSuccessStatusCode)
                            {
                                readTask = result.Content.ReadAsStringAsync();
                                readTask.Wait();
                                var pwdJson = readTask.Result;
                                clsPwd p = JsonConvert.DeserializeObject<clsPwd>(pwdJson);
                                clsPwd pass = new clsPwd();
                                string passChiara = p.pwd;
                                pass.pwd = p.pwd;
                                var postTask = client.PostAsJsonAsync<clsPwd>("password", pass);
                                postTask.Wait();
                                result = postTask.Result;
                                if (result.IsSuccessStatusCode)
                                {
                                    readTask = result.Content.ReadAsStringAsync();
                                    readTask.Wait();
                                    pwdJson = readTask.Result;
                                    p = JsonConvert.DeserializeObject<clsPwd>(pwdJson);
                                    string cryptoPwd = p.pwd;
                                    string email = txtEmail.Text;
                                    string nome = txtNome.Text;
                                    string cognome = txtCognome.Text;
                                    int a;
                                    int pm, peso;
                                    a = Convert.ToInt32(ddlAltezza.Text);
                                    pm = Convert.ToInt32(ddlPercentualeMassaGrassa.Text);
                                    peso = Convert.ToInt32(ddlPeso.Text);
                                    clsClienti cliente = new clsClienti();
                                    cliente.nome = nome;
                                    cliente.cognome = cognome;
                                    cliente.email = email;
                                    cliente.pwd = cryptoPwd;
                                    cliente.altezza = a;
                                    cliente.pMassaGrassa = pm;
                                    cliente.peso = peso;
                                    postTask = client.PostAsJsonAsync<clsClienti>("clienti", cliente);
                                    result = postTask.Result;
                                    if (result.IsSuccessStatusCode)
                                    {
                                        readTask = result.Content.ReadAsStringAsync();
                                        readTask.Wait();
                                        lblMsg.Text = "Cliente inserito con successo!";
                                        inviaMailPwd(nome, cognome, email, passChiara);
                                    }
                                }
                                else
                                    lblMsg.Text = result.StatusCode.ToString();
                            }
                            else
                                lblMsg.Text = result.StatusCode.ToString();
                        }
                        else
                            lblMsg.Text = "ERRORE: account già esistente con questa mail";
                    }
                    else
                        lblMsg.Text = result.StatusCode.ToString();
                }
                else
                    lblMsg.Text = "ERRORE: i campi nome, cognome, email possono risultare incompleti";
            }
            catch (Exception ex)
            {
                lblMsg.Text = "ERRORE: " + ex.Message;
            }
        }

        private void inviaMailPwd(string nome, string cognome, string email, string pwd)
        {
            try
            {
                MailMessage m = new MailMessage();
                m.From = new MailAddress("admin@goldengym.com");
                m.To.Add(new MailAddress(email)); //MailAddressCollection(....)
                //m.CC.Add(new MailAddress(txtCc.Text));
                //m.Bcc.Add(new MailAddress(txtBcc.Text));
                m.Subject = "Password temporanea";
                m.Body = "Gentile " + nome + " " + cognome + " ti diamo il benvenuto alla Golden Club Gym. Ti invitiamo a scaricare la nostra applicazione, per usufruire dei nostri servizi. Le sue credenziali sono: Username: " + email + " Password: " + pwd;
                //
                //credenziali
                System.Net.NetworkCredential crd = new System.Net.NetworkCredential();
                crd.UserName = "goldengymclub0@gmail.com";
                crd.Password = "esamestato";
                //
                SmtpClient s = new SmtpClient();
                s.Host = "smtp.gmail.com";
                s.Port = 587; // 25;
                s.Credentials = crd;
                s.EnableSsl = true; //https
                s.Send(m);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
    }
}