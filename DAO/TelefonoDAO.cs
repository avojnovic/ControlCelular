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

        public static Dictionary<int, Telefono> get(string dbPath)
        {
            string connection = DAO.Properties.Settings.Default.ConnectionString;
            connection = connection.Replace("PATH", dbPath);


            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT t.Id,t.Imei FROM Telefono t", con);
            OleDbDataReader reader = cmd.ExecuteReader();


            Dictionary<int, Telefono> _telefonos = new Dictionary<int, Telefono>();
            while (reader.Read())
            {
                Telefono m = new Telefono();

                m.Id = reader.GetInt32(0);
                m.Imei = reader.GetString(1);
                

                _telefonos.Add(m.Id, m);
            }
            reader.Close();

            return _telefonos;

        }

        public static int insert(string dbPath, Telefono x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"INSERT INTO TELEFONO (IMEI,COLOR) 
                                VALUES(@IMEI,@COLOR)";

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@IMEI", OleDbType.VarChar, 255).Value = x.Imei;
            cmd.Parameters.Add("@COLOR", OleDbType.VarChar, 255).Value = x.Color;

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

        public static void update(string dbPath, Telefono x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"UPDATE CONTACTOS SET IMEI=@IMEI,COLOR=@COLOR WHERE ID=@ID";

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@IMEI", OleDbType.VarChar, 255).Value = x.Imei;
            cmd.Parameters.Add("@COLOR", OleDbType.VarChar, 255).Value = x.Color;
            //cmd.Parameters.Add("@FECHANACIMIENTO", OleDbType.Date, 255).Value = x.FechaNacimiento.ToShortDateString();
            //cmd.Parameters.Add("@EMAIL", OleDbType.VarChar, 255).Value = x.Email;
            //cmd.Parameters.Add("@FechaModificacion", OleDbType.Date, 255).Value = x.FechaModificacion.Value.ToString();
            cmd.Parameters.Add("@ID", OleDbType.Integer, 255).Value = x.Id;



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
