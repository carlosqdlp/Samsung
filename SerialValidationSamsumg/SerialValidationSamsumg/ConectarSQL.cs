using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialValidationSamsumg
{
   public class ConectarSQL
    {


        public SqlConnection conexionSQL()
        { //Pasar a  config
            string server = ConfigurationManager.AppSettings["SERVER"];
            string db = ConfigurationManager.AppSettings["DB"];
            string user = ConfigurationManager.AppSettings["USER"];
            string pass = ConfigurationManager.AppSettings["PASSWORD"];

           SqlConnection cnn = null;
            string conSQL = "Server=" + server + ";" + "Database=" + db + ";" + "UID=" + user + ";" + "Password=" + pass + ";";
            cnn = new SqlConnection(conSQL);
           
            
            cnn.Open();
            

            return cnn;
        }

        public DataTable Consultasql(string query)
        {
            SqlConnection cnn = conexionSQL();
           
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, cnn);
            adapter.Fill(dt);
            cnn.Close();
            return dt;
            
        }

        public bool validarconeccion()
        {
           
                if (true)
                {

                }


                return true;
            
        }
    }
}
