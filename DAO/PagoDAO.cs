using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using BusinessObjects;
using System.Data;

namespace DAO
{
    public static class PagoDAO
    {


        public static Dictionary<int, Pago> get(string dbPath, Dictionary<int, Cliente> _clientes)
        {
            string connection = DAO.Properties.Settings.Default.ConnectionString;
            connection = connection.Replace("PATH", dbPath);


            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Pagos", con);
            OleDbDataReader reader = cmd.ExecuteReader();


            Dictionary<int, Pago> _list = new Dictionary<int, Pago>();
            while (reader.Read())
            {
                Pago x = new Pago();

                x.Id = reader.GetInt32(0);
                x.Cliente = _clientes[reader.GetInt32(1)];
                x.MontoPago = reader.GetDecimal(2);
                x.Fecha = reader.GetDateTime(3);
                
                _list.Add(x.Id, x);
            }
            reader.Close();

            return _list;

        }


        public static decimal get(string dbPath, Cliente _cliente)
        {
            string connection = DAO.Properties.Settings.Default.ConnectionString;
            connection = connection.Replace("PATH", dbPath);
            decimal monto = 0;

            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT sum(Pago) as pago FROM Pagos where Cliente="+_cliente.Id.ToString(), con);
            OleDbDataReader reader = cmd.ExecuteReader();


            Dictionary<int, Pago> _list = new Dictionary<int, Pago>();
            while (reader.Read())
            {
                if (reader["pago"].ToString() != string.Empty)
                    monto = reader.GetDecimal(0);
                else
                    monto = 0;
            }
            reader.Close();

            return monto;

        }


        private static void addParameters(Pago x, OleDbCommand cmd, bool id)
        {
            cmd.Parameters.Add("@Cliente", OleDbType.Integer, 255).Value = x.Cliente.Id;
            cmd.Parameters.Add("@Pago", OleDbType.Currency, 255).Value = x.MontoPago;
            cmd.Parameters.Add("@Fecha", OleDbType.Date, 255).Value = x.Fecha;
 
            if (id)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer, 255).Value = x.Id;
            }
        }

        public static int insert(string dbPath, Pago x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"INSERT INTO Pagos (Cliente,Pago,Fecha) 
                                VALUES(@Cliente,@Pago,@Fecha)";


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


        public static void update(string dbPath, Pago x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"UPDATE Pagos SET Cliente=@Cliente,Pago=@Pago, Fecha=@Fecha WHERE ID=@ID";

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
