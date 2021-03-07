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

        public string sha256(string pwd)
        {
            string p = "";
            SHA256 mySHA256 = SHA256.Create();
            //calcolo codice hash 
            byte[] hashValue = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashValue.Length; i++)
            {
                builder.Append(hashValue[i].ToString("x2")); //converto in esadecimale
            }
            p = builder.ToString();
            return p;
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
    }
}