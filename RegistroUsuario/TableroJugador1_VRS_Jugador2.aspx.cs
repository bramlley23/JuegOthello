using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Drawing;

namespace RegistroUsuario
{
    public partial class TableroJugador1_VRS_Jugador2 : System.Web.UI.Page
    {
        System.Drawing.Image img;
        int turno = 1;

        Button seleccionado = null;
        private object blanco;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void D4_Click(object sender, EventArgs e)
        {
            seleccionFichaBlanca(sender);
        }

        //Metodo para seleccionar ficha color Blanco
        public void seleccionFichaBlanca(object objeto)
        {
        
            Button ficha = (Button)objeto;
            seleccionado = ficha;
            ficha.Text = "\u26C0";
            seleccionado = ficha;
        }

        //metodo para seleccionar ficna color negra
        public void seleccionFichaNegra(object objeto)
        {

            Button ficha = (Button)objeto;
            seleccionado = ficha;
            ficha.Text = "\u26C2";
            seleccionado = ficha;
        }

        protected void E4_Click(object sender, EventArgs e)
        {
            seleccionFichaNegra(sender);
        }

        protected void D5_Click(object sender, EventArgs e)
        {
            seleccionFichaNegra(sender);
        }

        protected void E5_Click(object sender, EventArgs e)
        {
            seleccionFichaBlanca(sender);
        }
    }
}