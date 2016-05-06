using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.OleDb;
using System.Data;

namespace DAO
{
   public static class VentaDAO
    {



        public static Dictionary<int, Venta> get(string dbPath, Dictionary<int, Telefono> _telefonos, Dictionary<int, Cliente> _clientes)
        {
            string connection = DAO.Properties.Settings.Default.ConnectionString;
            connection = connection.Replace("PATH", dbPath);


            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(@"SELECT * FROM Venta", con);
            OleDbDataReader reader = cmd.ExecuteReader();


            Dictionary<int, Venta> _list = new Dictionary<int, Venta>();
            while (reader.Read())
            {
                Venta x = new Venta();

                x.Id = reader.GetInt32(0);
                x.Fecha = reader.GetDateTime(1);
                x.Telefono = _telefonos[reader.GetInt32(2)];
                x.Monto = reader.GetDecimal(3);
                x.Cliente = _clientes[reader.GetInt32(4)];
                x.Borrado = reader.GetBoolean(5);
                x.Cobrado = reader.GetBoolean(6);
                x.FechaCobro = reader.GetDateTime(7);
              
                _list.Add(x.Id, x);
            }
            reader.Close();

            return _list;

        }

        public static int insert(string dbPath, Venta x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"INSERT INTO Venta (Fecha,Telefono,Monto,Cliente,Borrado,Cobrado,FechaCobro) 
                                VALUES(@Fecha,@Telefono,@Monto,@Cliente,@Borrado,@Cobrado,@FechaCobro)";

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

        private static void addParameters(Venta x, OleDbCommand cmd, bool id)
        {
            cmd.Parameters.Add("@Fecha", OleDbType.Date, 255).Value = x.Fecha;
            cmd.Parameters.Add("@Telefono", OleDbType.Integer, 255).Value = x.Telefono.Id;
            cmd.Parameters.Add("@Monto", OleDbType.Currency, 255).Value = x.Monto;
            cmd.Parameters.Add("@Cliente", OleDbType.Integer, 255).Value = x.Cliente.Id;
            cmd.Parameters.Add("@Borrado", OleDbType.Boolean, 255).Value = x.Borrado;
            cmd.Parameters.Add("@Cobrado", OleDbType.Boolean, 255).Value = x.Cobrado;
            cmd.Parameters.Add("@FechaCobro", OleDbType.Date, 255).Value = x.FechaCobro;



            if (id)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer, 255).Value = x.Id;
            }
        }

        public static void update(string dbPath, Venta x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"UPDATE Venta SET Fecha=@Fecha,Telefono=@Telefono,Monto=@Monto,Cliente=@Cliente,Borrado=@Borrado,Cobrado=@Cobrado,FechaCobro=@FechaCobro WHERE ID=@ID";
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
