using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.OleDb;

namespace DAO
{
    public static class ProveedorDAO
    {
        public static Dictionary<int, Proveedor> get(string dbPath)
        {
            string connection = DAO.Properties.Settings.Default.ConnectionString;
            connection = connection.Replace("PATH", dbPath);


            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Proveedor", con);
            OleDbDataReader reader = cmd.ExecuteReader();


            Dictionary<int, Proveedor> _list = new Dictionary<int, Proveedor>();
            while (reader.Read())
            {
                Proveedor x = new Proveedor();

                x.Id = reader.GetInt32(0);
                x.Nombre = reader.GetString(1);
                x.Descripcion = reader.GetString(2);
                x.Borrado = reader.GetBoolean(3);
                _list.Add(x.Id, x);
            }
            reader.Close();

            return _list;

        }
    }
}
