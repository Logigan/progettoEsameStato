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

        public string creaPwd(int lunghezza = 16)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < lunghezza--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        internal object leggiServizi()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Servizi";
            dt = ado.EseguiQuery(cmd);
            return dt;
        }

        internal bool CercaMail(string email)
        {
            bool esiste;
            string ris;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Clienti WHERE email=@email";
            cmd.Parameters.AddWithValue("@email", email);
            ris = Convert.ToString(ado.EseguiScalar(cmd));
            if (ris== "")
                esiste = false;
            else
                esiste = true;
            return esiste;
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

        public void InserisciUtente(string cognome, string nome, string email,string pwd)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Clienti(nome, cognome, email,pwd) ";
            cmd.CommandText += "VALUES (@nome,@cognome,@email,@pwd) ";
            cmd.Parameters.AddWithValue("@cognome", cognome);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            ado.EseguiNonQuery(cmd);
        }

        internal void InserisciServizio(string tipologia, float prezzo, string percorsoDb)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Servizi(tipologia, prezzo, percorso) ";
            cmd.CommandText += "VALUES (@tipologia,@prezzo,@percorso) ";
            cmd.Parameters.AddWithValue("@tipologia", tipologia);
            cmd.Parameters.AddWithValue("@prezzo", prezzo);
            cmd.Parameters.AddWithValue("@percorso", percorsoDb);
            ado.EseguiNonQuery(cmd);
        }

        internal void EliminaServizio(int id)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Servizi WHERE idServizio=@id";
            cmd.Parameters.AddWithValue("@id", id);
            ado.EseguiNonQuery(cmd);
        }

        public DataTable leggiUtenti()
        {
            DataTable dt=new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Clienti";
            dt = ado.EseguiQuery(cmd);
            return dt;
        }

        internal void InserisciUtenteEInfo(string cognome, string nome, string email, int a, float pm, float p,string pwd)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Clienti(nome, cognome, email,pwd, altezza, peso, pMassaGrassa) ";
            cmd.CommandText += "VALUES (@nome,@cognome,@email,@pwd,@altezza,@peso,@pMassaGrassa) ";
            cmd.Parameters.AddWithValue("@cognome", cognome);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@altezza", a);
            cmd.Parameters.AddWithValue("@peso", p);
            cmd.Parameters.AddWithValue("@pMassaGrassa", pm);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            ado.EseguiNonQuery(cmd);
        }

        internal void EliminaUtente(int id)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Clienti WHERE idCliente=@id";
            cmd.Parameters.AddWithValue("@id", id);
            ado.EseguiNonQuery(cmd);
        }
    }
}