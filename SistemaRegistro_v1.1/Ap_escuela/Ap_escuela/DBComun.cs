using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ap_escuela
{

    public class DBComun
    {
        public static SqlConnection ObtnerCOnexion()
        {
  
        SqlConnection Conn = new SqlConnection("Data Source=CL-NB-ERRO\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=True");
         Conn.Open();

            return Conn;

            }

        }
    }

    