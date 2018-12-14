using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Ap_escuela
{
   public class BDComun
    {
        public static SqlConnection ObtenerCOnexion()
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-0QJF6HV8\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=True");
            conn.Open();
            return conn;
        }
    }
}


