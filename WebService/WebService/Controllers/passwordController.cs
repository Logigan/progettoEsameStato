using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class passwordController : ApiController
    {
        clsDB db = new clsDB("..\\App_Data\\dbGoldenClub.mdf");
        clsPwd pwd;

        public IHttpActionResult GetGeneraPwd()
        {
            IHttpActionResult ris;
            string pass = db.creaPwd();
            pwd = new clsPwd();
            pwd.pwd = pass;
            ris = Json(pwd);
            return ris;
        }

        public IHttpActionResult PostCriptaPwd(clsPwd pass)
        {
            IHttpActionResult ris;
            if (ModelState.IsValid)
            {
                try
                {
                    string p= pass.pwd;
                    string cryptoPass = db.sha256(p);
                    pwd = new clsPwd();
                    pwd.pwd = cryptoPass;
                    ris = Json(pwd);
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
