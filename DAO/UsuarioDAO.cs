using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.OleDb;
using System.Data;

namespace DAO
{
   public static class UsuarioDAO
    {

        public static Dictionary<int, Usuario> get(string dbPath)
        {


            string connection = DAO.Properties.Settings.Default.ConnectionString;
            connection = connection.Replace("PATH", dbPath);


            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(@"SELECT * FROM Usuario", con);
            OleDbDataReader reader = cmd.ExecuteReader();


            Dictionary<int, Usuario> _dic = new Dictionary<int, Usuario>();
            while (reader.Read())
            {
                Usuario x = new Usuario();

                x.Id = reader.GetInt32(0);
                x.NombreUsuario = reader.GetString(1);
                x.Password = reader.GetString(2);
                              

                _dic.Add(x.Id, x);
            }
            reader.Close();

            return _dic;

        }


        private static void addParameters(Usuario x, OleDbCommand cmd, bool id)
        {
            cmd.Parameters.Add("@NombreUsuario", OleDbType.VarChar, 255).Value = x.NombreUsuario;
            cmd.Parameters.Add("@Password", OleDbType.VarChar, 255).Value = x.Password;
            if (id)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer, 255).Value = x.Id;
            }
        }

        public static int insert(string dbPath, Usuario x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"INSERT INTO Usuario (NombreUsuario,Password) 
                                VALUES(@NombreUsuario,@Password)";


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


        public static void update(string dbPath, Usuario x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"UPDATE Usuario SET NombreUsuario=@NombreUsuario,Password=@Password WHERE ID=@ID";

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
