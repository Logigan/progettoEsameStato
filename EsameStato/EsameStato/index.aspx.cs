using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;

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
                if (txtCognome.Text != "" && txtNome.Text != "" && txtEmail.Text != "")
                {                 
                    if (!db.CercaMail(txtEmail.Text))
                    {
                        string pwd = db.creaPwd();
                        string cryptoPwd = db.sha256(pwd);
                        string email = txtEmail.Text;
                        string nome = txtNome.Text;
                        string cognome = txtCognome.Text;
                        db.InserisciUtente(cognome, nome, email, cryptoPwd);
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

        private void inviaMailPwd(string nome,string cognome,string email,string pwd)
        {
            try
            {
                MailMessage m = new MailMessage();
                m.From = new MailAddress("admin@goldengym.com");
                m.To.Add(new MailAddress(email)); //MailAddressCollection(....)
                //m.CC.Add(new MailAddress(txtCc.Text));
                //m.Bcc.Add(new MailAddress(txtBcc.Text));
                m.Subject = "Password temporanea";
                m.Body = "Gentile "+nome+" "+cognome+" ti diamo il benvenuto alla Golden Club Gym. Ti invitiamo a scaricare la nostra applicazione, per usufruire dei nostri servizi. Le sue credenziali sono: Username: "+email+" Password: "+pwd;
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

        protected void lnkReg2_Click(object sender, EventArgs e)
        {
            Response.Redirect("registrazione.aspx");
        }

        protected void lnkUtenti2_Click(object sender, EventArgs e)
        {
            Response.Redirect("utenti.aspx");
        }

        protected void lnkSrv2_Click(object sender, EventArgs e)
        {
            Response.Redirect("servizi.aspx");
        }
    }
}