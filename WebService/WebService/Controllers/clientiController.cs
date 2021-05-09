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
        ADOSQLServer2017 ado;
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
                cliente.altezza =Convert.ToInt32(dt.Rows[i].ItemArray[5]);
                cliente.peso = Convert.ToInt32(dt.Rows[i].ItemArray[6]);
                cliente.pMassaGrassa = Convert.ToInt32(dt.Rows[i].ItemArray[7]);
                listaClienti.Add(cliente);
            }
            return listaClienti;       
        }

        public IHttpActionResult EliminaUtente(int idUtente)
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
    }
}
