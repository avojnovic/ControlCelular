using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.OleDb;

namespace DAO
{
    public static class MarcaDAO
    {
        public static Dictionary<int, Marca> get(string dbPath)
        {
            string connection = DAO.Properties.Settings.Default.ConnectionString;
            connection = connection.Replace("PATH", dbPath);


            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Marca", con);
            OleDbDataReader reader = cmd.ExecuteReader();


            Dictionary<int, Marca> _marcas = new Dictionary<int, Marca>();
            while (reader.Read())
            {
                Marca m = new Marca();

                m.Id = reader.GetInt32(0);
                m.Nombre = reader.GetString(1);
                
                _marcas.Add(m.Id, m);
            }
            reader.Close();

            return _marcas;

        }

    }
}
