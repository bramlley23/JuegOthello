using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace RegistroUsuario
{
    public class BDComun
    {
        //metodo tipo static para obtener la conexion a la BD 
        public static SqlConnection obtenerConexion()
        {
            SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-0R2VF1J;Initial Catalog=RegistroJuego;Integrated Security=True");
            Conn.Open();
            return Conn;
        }
    }
}