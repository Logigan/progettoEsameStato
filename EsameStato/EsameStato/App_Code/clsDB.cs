using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using ADOSQLServer2017_ns;
using System.Data;
using System.Data.SqlClient;
//
using System.Security.Cryptography;
using System.Text;

namespace EsameStato
{
    public class clsDB
    {
        ADOSQLServer2017 ado;
        public clsDB(string nomeDB)
        {
            this.ado = new ADOSQLServer2017(nomeDB);
        }

        public void InserisciUtente(string cognome, string nome, string email)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Clienti(nome, cognome, email) ";
            cmd.CommandText += "VALUES (@nome,@cognome,@email) ";
            cmd.Parameters.AddWithValue("@cognome", cognome);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@email", email);
            ado.EseguiNonQuery(cmd);
        }

        internal void InserisciUtenteEInfo(string cognome, string nome, string email, int a, float pm, float p)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Clienti(nome, cognome, email, altezza, peso, pMassaGrassa) ";
            cmd.CommandText += "VALUES (@nome,@cognome,@email,@altezza,@peso,@pMassaGrassa) ";
            cmd.Parameters.AddWithValue("@cognome", cognome);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@altezza", a);
            cmd.Parameters.AddWithValue("@peso", p);
            cmd.Parameters.AddWithValue("@pMassaGrassa", pm);
            ado.EseguiNonQuery(cmd);
        }
    }
}