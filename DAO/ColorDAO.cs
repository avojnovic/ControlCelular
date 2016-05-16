using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.OleDb;

namespace DAO
{
    public static class ColorDAO
    {
        public static Dictionary<int, ColorTelefono> get(string dbPath)
        {
            string connection = DAO.Properties.Settings.Default.ConnectionString;
            connection = connection.Replace("PATH", dbPath);


            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Color", con);
            OleDbDataReader reader = cmd.ExecuteReader();


            Dictionary<int, ColorTelefono> _list = new Dictionary<int, ColorTelefono>();
            while (reader.Read())
            {
                ColorTelefono x = new ColorTelefono();

                x.Id = reader.GetInt32(0);
                x.Nombre = reader.GetString(1);
                x.Borrado = reader.GetBoolean(2);
                _list.Add(x.Id, x);
            }
            reader.Close();

            return _list;

        }
    }
}
