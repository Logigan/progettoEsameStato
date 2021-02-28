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

        public DataTable leggiProdotto(string idProdotto)
        {
            DataTable dt;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Prodotti.idProdotto, Marca, prezzo, Nome, Descrizione FROM Prodotti, TipoProdotto ";
            cmd.CommandText += "WHERE Prodotti.idTipoProdotto=TipoProdotto.idTipoProdotto AND idProdotto=@idProdotto ";
            cmd.Parameters.AddWithValue("@idProdotto", idProdotto);
            dt = ado.EseguiQuery(cmd);
            return dt;
        }

        public DataTable caricaProdotti()
        {
            DataTable dt;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM TipoProdotto";
            dt = ado.EseguiQuery(cmd);
            return dt;
        }

        public DataTable leggiArticoli(string idTipoProdotto)
        {
            DataTable dt;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Prodotti.idProdotto, Marca, prezzo, Nome, Descrizione FROM Prodotti, TipoProdotto ";
            cmd.CommandText += "WHERE Prodotti.idTipoProdotto=TipoProdotto.idTipoProdotto ";
            if (idTipoProdotto!="-1")
            {
                cmd.CommandText += "AND Prodotti.idTipoProdotto=@idTipoProdotto ";
                cmd.Parameters.AddWithValue("@idTipoProdotto", idTipoProdotto);
            }
            dt = ado.EseguiQuery(cmd);
            return dt;
        }

        public DataTable cercaUtente(string email, string pwd)
        {
            DataTable dt;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT idUtente, idAutorizzazione FROM Utenti ";
            cmd.CommandText += "WHERE email=@email AND pwd=@pwd ";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            dt = ado.EseguiQuery(cmd);
            return dt;
        }

        public void InserisciUtente(string cognome, string nome, string dataNascita, string citta, string telefono, string email, string pwd, string iban, int idAutorizzazione)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Utenti(cognome, nome, dataNascita, citta, telefono, email, pwd, iban, idAutorizzazione) ";
            cmd.CommandText += "VALUES (@cognome, @nome, @dataNascita, @citta, @telefono, @email, @pwd, @iban, @idAutorizzazione) ";
            cmd.Parameters.AddWithValue("@cognome", cognome);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@dataNascita", dataNascita);
            cmd.Parameters.AddWithValue("@citta", citta);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            cmd.Parameters.AddWithValue("@iban", iban);
            cmd.Parameters.AddWithValue("@idAutorizzazione", idAutorizzazione);
            ado.EseguiNonQuery(cmd);
        }

        public int EmailPwdPresenti(string email)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT COUNT(*)
                            FROM Utenti
                            WHERE email = @email";
            cmd.Parameters.AddWithValue("@email", email);
            return Convert.ToInt32(ado.EseguiScalar(cmd));
        }
    }
}