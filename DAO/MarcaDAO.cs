﻿using System;
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


            Dictionary<int, Marca> _list = new Dictionary<int, Marca>();
            while (reader.Read())
            {
                Marca x = new Marca();

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
