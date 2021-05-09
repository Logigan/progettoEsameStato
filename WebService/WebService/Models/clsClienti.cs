using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class clsClienti
    {
        public int idCliente { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string email { get; set; }
        public char pwd { get; set; }
        public int altezza { get; set; }
        public int peso { get; set; }
        public int pMassaGrassa { get; set; }
    }
}