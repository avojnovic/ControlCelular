using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.OleDb;
using System.Data;

namespace DAO
{
    public static class ModeloDAO
    {


        public static Dictionary<int, Modelo> get(string dbPath, Dictionary<int, SistemaOperativo> _sisOp, Dictionary<int, Marca> _marcas)
        {

            
            string connection = DAO.Properties.Settings.Default.ConnectionString;
            connection = connection.Replace("PATH", dbPath);


            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(@"SELECT * FROM Modelo t", con);
            OleDbDataReader reader = cmd.ExecuteReader();


            Dictionary<int, Modelo> _dic = new Dictionary<int, Modelo>();
            while (reader.Read())
            {
                Modelo x = new Modelo();

                x.Id = reader.GetInt32(0);
                x.Marca = _marcas[reader.GetInt32(1)];
                x.Modelo1 = reader.GetString(2);
                x.Nombre = reader.GetString(3);
                x.Procesador = reader.GetString(4);
                x.SistemaOperativo =_sisOp[reader.GetInt32(5)];
                x.Descripcion = reader.GetString(6);
                x.Borrado = reader.GetBoolean(7);
                _dic.Add(x.Id, x);
            }
            reader.Close();

            return _dic;

        }


        private static void addParameters(Modelo x, OleDbCommand cmd, bool id)
        {
            cmd.Parameters.Add("@Marca", OleDbType.Integer, 255).Value = x.Marca.Id;
            cmd.Parameters.Add("@Modelo", OleDbType.VarChar, 255).Value = x.Modelo1;
            cmd.Parameters.Add("@Nombre", OleDbType.VarChar, 255).Value = x.Nombre;
            cmd.Parameters.Add("@Procesador", OleDbType.VarChar, 255).Value = x.Procesador;
            cmd.Parameters.Add("@SistemaOperativo", OleDbType.Integer, 255).Value = x.SistemaOperativo.Id;
            cmd.Parameters.Add("@Descripcion", OleDbType.VarChar, 255).Value = x.Descripcion;
            cmd.Parameters.Add("@Borrado", OleDbType.Boolean, 255).Value = x.Borrado;

            if (id)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer, 255).Value = x.Id;
            }
        }

        public static int insert(string dbPath, Modelo x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"INSERT INTO Modelo (Marca,Modelo,Nombre,Procesador,SistemaOperativo,Descripcion,Borrado) 
                                VALUES(@Marca,@Modelo,@Nombre,@Procesador,@SistemaOperativo,@Descripcion,@Borrado)";

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


        public static void update(string dbPath, Modelo x)
        {
            string strconnection = DAO.Properties.Settings.Default.ConnectionString;
            strconnection = strconnection.Replace("PATH", dbPath);
            OleDbConnection connection = new OleDbConnection(strconnection);
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = @"UPDATE Modelo SET Marca=@Marca,Modelo=@Modelo,Nombre=@Nombre,Procesador=@Procesador,SistemaOperativo=@SistemaOperativo,Descripcion=@Descripcion, Borrado=@Borrado WHERE ID=@ID";

            cmd.CommandType = CommandType.Text;

            addParameters(x, cmd,true);
            



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
