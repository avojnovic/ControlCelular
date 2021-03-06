﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.OleDb;
using System.Data;

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

        private static void addParameters(Proveedor x, OleDbCommand cmd, bool id)
        {
            cmd.Parameters.Add("@Nombre", OleDbType.VarChar, 255).Value = x.Nombre;
            
            cmd.Parameters.Add("@Descripcion", OleDbType.VarChar, 255).Value = x.Descripcion;
            cmd.Parameters.Add("@Borrado", OleDbType.Boolean, 255).Value = x.Borrado;
           
            if (id)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer, 255).Value = x.Id;
            }
        }

        public static int insert(string dbPath, Proveedor x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"INSERT INTO Proveedor (Nombre,Descripcion,Borrado) 
                                VALUES(@Nombre,@Descripcion,@Borrado)";


            cmd.CommandType = CommandType.Text;

            addParameters(x, cmd, false);


            cmd.Connection = connection;
            connection.Open();
            //cmd.Transaction = connection.BeginTransaction();

            int rows = cmd.ExecuteNonQuery();

            string query2 = "Select @@Identity";
            int ID;

            cmd.CommandText = query2;
            ID = (int)cmd.ExecuteScalar();

            // cmd.Transaction.Commit();
            connection.Dispose();
            connection.Close();


            return ID;
        }


        public static void update(string dbPath, Proveedor x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"UPDATE Proveedor SET Nombre=@Nombre,Descripcion=@Descripcion, Borrado=@Borrado WHERE ID=@ID";

            cmd.CommandType = CommandType.Text;

            addParameters(x, cmd, true);




            cmd.Connection = connection;
            connection.Open();
            cmd.Transaction = connection.BeginTransaction();

            int rows = cmd.ExecuteNonQuery();


            cmd.Transaction.Commit();
            connection.Dispose();
            connection.Close();
        }


    }
}
