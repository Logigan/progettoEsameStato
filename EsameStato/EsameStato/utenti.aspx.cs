using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace EsameStato
{
    public partial class utenti : System.Web.UI.Page
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
                dgv.DataSource = db.leggiUtenti();
                dgv.DataBind();
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
                        db.EliminaUtente(Convert.ToInt32(id));
                        popolaDgv();
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = "ERRORE: " + ex.Message;
                    }
                }
            }
        }
    }
}