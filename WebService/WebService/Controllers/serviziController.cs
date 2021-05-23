using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;
using System.Data;

namespace WebService.Controllers
{
    public class serviziController : ApiController
    {
        clsDB db = new clsDB("..\\App_Data\\dbGoldenClub.mdf");
        clsServizi servizio;
        List<clsServizi> listaServizi;

        public IEnumerable<clsServizi> GetLeggiServizi()
        {
            DataTable dt = db.leggiServizi();
            listaServizi = new List<clsServizi>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                servizio = new clsServizi();
                servizio.idServizio = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                servizio.tipologia = dt.Rows[i].ItemArray[1].ToString();
                servizio.prezzo = Convert.ToSingle(dt.Rows[i].ItemArray[2]);
                servizio.percorso= dt.Rows[i].ItemArray[3].ToString();
                listaServizi.Add(servizio);
            }
            return listaServizi;
        }

        public IHttpActionResult DeleteEliminaServizio(int idServizio)
        {
            //DELETE
            //URI api/alunni?IDAlunno=2
            IHttpActionResult ris;
            try
            {
                db.EliminaServizio(idServizio);
                ris = Ok();
            }
            catch (Exception)
            {
                ris = BadRequest("Errore");
            }
            return ris;
        }

        public IHttpActionResult PostNuovoServizio(clsServizi servizio)
        {
            //POST
            //URI api/alunni
            //BODY {"IDAlunno": 2,"Nome": "Romano","Cognome": "DeAmicis","IDClasse": 2}
            IHttpActionResult ris;
            if (ModelState.IsValid)
            {
                try
                {
                    db.InserisciServizio(servizio.tipologia, servizio.prezzo, servizio.percorso);
                    ris = Ok("Servizio inserito con successo");
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
    }
}
