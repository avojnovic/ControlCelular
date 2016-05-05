using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.OleDb;
using System.Data;

namespace DAO
{
   public static class ClienteDAO
    {


        public static Dictionary<int, Cliente> get(string dbPath)
        {


            string connection = DAO.Properties.Settings.Default.ConnectionString;
            connection = connection.Replace("PATH", dbPath);


            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(@"SELECT * FROM Cliente", con);
            OleDbDataReader reader = cmd.ExecuteReader();


            Dictionary<int, Cliente> _dic = new Dictionary<int, Cliente>();
            while (reader.Read())
            {
                Cliente x = new Cliente();

                x.Id = reader.GetInt32(0);
                x.Nombre = reader.GetString(1);
                x.Apellido = reader.GetString(2);
                x.Descripcion = reader.GetString(3);
                x.Borrado = reader.GetBoolean(4);
                _dic.Add(x.Id, x);
            }
            reader.Close();

            return _dic;

        }


        private static void addParameters(Cliente x, OleDbCommand cmd, bool id)
        {
            cmd.Parameters.Add("@Nombre", OleDbType.Integer, 255).Value = x.Nombre;
            cmd.Parameters.Add("@Apellido", OleDbType.VarChar, 255).Value = x.Apellido;
            cmd.Parameters.Add("@Descripcion", OleDbType.VarChar, 255).Value = x.Descripcion;
            cmd.Parameters.Add("@Borrado", OleDbType.Boolean, 255).Value = x.Borrado;

            if (id)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer, 255).Value = x.Id;
            }
        }

        public static int insert(string dbPath, Cliente x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"INSERT INTO Cliente (Nombre,Apellido,Descripcion,Borrado) 
                                VALUES(@Nombre,@Apellido,@Descripcion,@Borrado)";


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


        public static void update(string dbPath, Cliente x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"UPDATE Cliente SET Nombre=@Nombre,Apellido=@Apellido,Descripcion=@Descripcion, Borrado=@Borrado WHERE ID=@ID";

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
