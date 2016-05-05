using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.OleDb;

namespace DAO
{
 
    public static class SistemaOperativoDAO
    {
        public static Dictionary<int, SistemaOperativo> get(string dbPath)
        {
            string connection = DAO.Properties.Settings.Default.ConnectionString;
            connection = connection.Replace("PATH", dbPath);


            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM SistemaOperativo", con);
            OleDbDataReader reader = cmd.ExecuteReader();


            Dictionary<int, SistemaOperativo> _dic = new Dictionary<int, SistemaOperativo>();
            while (reader.Read())
            {
                SistemaOperativo x = new SistemaOperativo();

                x.Id = reader.GetInt32(0);
                x.Nombre = reader.GetString(1);
                x.Borrado = reader.GetBoolean(2);

                _dic.Add(x.Id, x);
            }
            reader.Close();

            return _dic;

        }

    }
}
