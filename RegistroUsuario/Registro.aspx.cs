using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace RegistroUsuario
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MenuDeJuegos menu = new MenuDeJuegos();
            Response.Redirect("MenuDeJuegos.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Usuario = txtUsuario.Text;
            usuario.Correo = txtCorreo.Text;
            usuario.Contraseña = txtContraseña.Text;
            usuario.Pais = txtPais.Text;
            usuario.FechaNacimiento = txtFechaNacimiento.Text;

           int resultado = UsuariosDAL.agregar(usuario);

            if (resultado > 0)
            {
                MessageBox.Show("Registro Guardado con Exito", "Registo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("!!! ERROR AL REGISTRAR ¡¡¡", " PROBLEMA AL GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}