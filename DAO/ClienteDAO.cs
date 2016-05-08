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
                if (!reader.IsDBNull(3))
                    x.Descripcion = reader.GetString(3);
                else
                    x.Descripcion = "";
                x.Borrado = reader.GetBoolean(4);
                if (!reader.IsDBNull(5))
                    x.Deuda = reader.GetDecimal(5);
                else
                    x.Deuda = 0;

                _dic.Add(x.Id, x);
            }
            reader.Close();

            return _dic;

        }


        private static void addParameters(Cliente x, OleDbCommand cmd, bool id)
        {
            cmd.Parameters.Add("@Nombre", OleDbType.VarChar, 255).Value = x.Nombre;
            cmd.Parameters.Add("@Apellido", OleDbType.VarChar, 255).Value = x.Apellido;
            cmd.Parameters.Add("@Descripcion", OleDbType.VarChar, 255).Value = x.Descripcion;
            cmd.Parameters.Add("@Borrado", OleDbType.Boolean, 255).Value = x.Borrado;
            cmd.Parameters.Add("@Deuda", OleDbType.Currency, 255).Value = x.Deuda;

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

            cmd.CommandText = @"INSERT INTO Cliente (Nombre,Apellido,Descripcion,Borrado,Deuda) 
                                VALUES(@Nombre,@Apellido,@Descripcion,@Borrado,@Deuda)";


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

            cmd.CommandText = @"UPDATE Cliente SET Nombre=@Nombre,Apellido=@Apellido,Descripcion=@Descripcion, Borrado=@Borrado, Deuda=@Deuda WHERE ID=@ID";

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
