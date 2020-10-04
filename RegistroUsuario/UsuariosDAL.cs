using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace RegistroUsuario
{
    public class UsuariosDAL
    {
        public static int agregar(Usuarios pUsuarios)
        {
            int retorno = 0;
            using (SqlConnection Conn = BDComun.obtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into JuegOthello (Nombre, Apellido, Usuario, Correo, Contraseña, Pais, FechaNacimiento) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                    pUsuarios.Nombre, pUsuarios.Apellido, pUsuarios.Usuario, pUsuarios.Correo, pUsuarios.Contraseña, pUsuarios.Pais, pUsuarios.FechaNacimiento), Conn);

                retorno = Comando.ExecuteNonQuery(); 
                    
            }
            return retorno;
        }
    }
}