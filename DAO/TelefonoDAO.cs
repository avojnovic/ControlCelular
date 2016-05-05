using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.OleDb;
using System.Data;


namespace DAO
{
    public static class TelefonoDAO
    {

        public static Dictionary<int, Telefono> get(string dbPath, Dictionary<int, Modelo> _modelos, Dictionary<int, Proveedor> _proveedores)
        {
            string connection = DAO.Properties.Settings.Default.ConnectionString;
            connection = connection.Replace("PATH", dbPath);


            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(@"SELECT * FROM Telefono", con);
            OleDbDataReader reader = cmd.ExecuteReader();


            Dictionary<int, Telefono> _list = new Dictionary<int, Telefono>();
            while (reader.Read())
            {
                Telefono x = new Telefono();

                x.Id = reader.GetInt32(0);
                x.Imei = reader.GetString(1);
                x.Color = reader.GetString(2);
                x.Modelo = _modelos[reader.GetInt32(3)];
                x.Proveedor = _proveedores[reader.GetInt32(4)];
                x.Borrado = reader.GetBoolean(5);
                x.Costo = reader.GetDecimal(6);
                _list.Add(x.Id, x);
            }
            reader.Close();

            return _list;

        }

        public static int insert(string dbPath, Telefono x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"INSERT INTO TELEFONO (Imei,Color,Modelo,Proveedor,Borrado,Costo) 
                                VALUES(@Imei,@Color,@Modelo,@Proveedor,@Borrado,@Costo)";

            cmd.CommandType = CommandType.Text;
            addParameters(x, cmd,false);
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

        private static void addParameters(Telefono x, OleDbCommand cmd, bool id)
        {
            cmd.Parameters.Add("@Imei", OleDbType.VarChar, 255).Value = x.Imei;
            cmd.Parameters.Add("@Color", OleDbType.VarChar, 255).Value = x.Color;
            cmd.Parameters.Add("@Modelo", OleDbType.Integer, 255).Value = x.Modelo.Id;
            cmd.Parameters.Add("@Proveedor", OleDbType.Integer, 255).Value = x.Proveedor.Id;
            cmd.Parameters.Add("@Borrado", OleDbType.Boolean, 255).Value = x.Borrado;
            cmd.Parameters.Add("@Costo", OleDbType.Decimal, 255).Value = x.Costo;

            if (id)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer, 255).Value = x.Id; 
            }
        }

        public static void update(string dbPath, Telefono x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"UPDATE Telefono SET Imei=@Imei,Color=@Color,Modelo=@Modelo,Proveedor=@Proveedor,Borrado=@Borrado,Costo=@Costo WHERE ID=@ID";
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
