using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace EsameStato
{
    public partial class registrazione : System.Web.UI.Page
    {
        clsDB db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new clsDB("App_Data\\dbGoldenClub.mdf");
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
                    if (!db.CercaMail(txtEmail.Text))
                    {
                        string pwd = db.creaPwd();
                        string cryptoPwd = db.sha256(pwd);
                        string email = txtEmail.Text;
                        string nome = txtNome.Text;
                        string cognome = txtCognome.Text;
                        int a;
                        float pm, p;
                        a = Convert.ToInt32(ddlAltezza.Text);
                        pm = Convert.ToSingle(ddlPercentualeMassaGrassa.Text);
                        p = Convert.ToSingle(ddlPeso.Text);
                        db.InserisciUtenteEInfo(cognome, nome,email, a, pm, p,cryptoPwd);
                        inviaMailPwd(nome, cognome, email, pwd);
                        lblMsg.Text = "Utente inserito";
                    }
                    else
                        lblMsg.Text = "ERRORE: account già esistente con questa mail";
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