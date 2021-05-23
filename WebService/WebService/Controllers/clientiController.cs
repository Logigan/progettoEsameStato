using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using ADOSQLServer2017_ns;
using System.Data.SqlClient;
using WebService.Models;

namespace WebService.Controllers
{
    public class clientiController : ApiController
    {
        clsDB db=new clsDB("..\\App_Data\\dbGoldenClub.mdf");
        clsClienti cliente;
        List<clsClienti> listaClienti;

        public IEnumerable<clsClienti> GetLeggiUtenti()
        {
            DataTable dt = db.leggiUtenti();
            listaClienti = new List<clsClienti>();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                cliente = new clsClienti();
                cliente.idCliente = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                cliente.nome = dt.Rows[i].ItemArray[1].ToString();
                cliente.cognome = dt.Rows[i].ItemArray[2].ToString();
                cliente.email = dt.Rows[i].ItemArray[3].ToString();
                try
                {
                    cliente.altezza = Convert.ToInt32(dt.Rows[i].ItemArray[5]);
                    cliente.peso = Convert.ToInt32(dt.Rows[i].ItemArray[6]);
                    cliente.pMassaGrassa = Convert.ToInt32(dt.Rows[i].ItemArray[7]);
                }
                catch (Exception)
                {

                }
                listaClienti.Add(cliente);
            }
            return listaClienti;       
        }

        public bool GetTrovaMail(string Email)
        {
            bool ris=false;
            if(db.CercaMail(Email))
            {
                ris = true;
            }
            return ris;

            /*IHttpActionResult ris;
            if (db.CercaMail(Email))
            {
                ris = Ok(true);
            }
            else
                ris = Ok(false);
            return ris;*/
        }

        public IHttpActionResult DeleteEliminaUtente(int idUtente)
        {
            //DELETE
            //URI api/alunni?IDAlunno=2
            IHttpActionResult ris;
            try
            {
                db.EliminaUtente(idUtente);
                ris = Ok();
            }
            catch (Exception)
            {
                ris = BadRequest("Errore");
            }
            return ris;
        }

        public IHttpActionResult PostNuovoCliente(clsClienti cliente)
        {
            //POST
            //URI api/alunni
            //BODY {"IDAlunno": 2,"Nome": "Romano","Cognome": "DeAmicis","IDClasse": 2}
            IHttpActionResult ris;
            if (ModelState.IsValid)
            {
                try
                {
                    if (cliente.peso==0 && cliente.pMassaGrassa==0 && cliente.altezza==0)
                    {
                        db.InserisciUtente(cliente.cognome, cliente.nome, cliente.email, cliente.pwd);
                        ris = Ok("Cliente inserito con successo");
                    }
                    else
                    {
                        if(cliente.email==null)
                        {
                            db.aggiornaUtente(cliente.cognome, cliente.nome, cliente.altezza, cliente.pMassaGrassa, cliente.peso,cliente.idCliente);
                            ris = Ok("Cliente aggiornato con successo");
                        }
                        else
                        {
                            db.InserisciUtenteEInfo(cliente.cognome, cliente.nome, cliente.email, cliente.altezza, cliente.pMassaGrassa, cliente.peso, cliente.pwd);
                            ris = Ok("Cliente inserito con successo");
                        }
                    }
                }
                catch (Exception)
                {
                    ris = BadRequest("Errore");
                }
            }
            else
            {
                ris = BadRequest("Invalid data");
            }
            return ris;
        }

        public IHttpActionResult GetLeggiMail(string idUtente)
        {
            IHttpActionResult ris;
            try
            {
                string email = db.cercaUtente(idUtente);
                cliente = new clsClienti();
                cliente.email = email;
                ris = Json(cliente);
            }
            catch (Exception)
            {
                ris = BadRequest("Errore");
            }
            return ris;
        }
    }
}
