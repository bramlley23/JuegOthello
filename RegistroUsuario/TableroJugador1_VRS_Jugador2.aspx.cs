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
        private int movimientoJuador1 = 1;
        private int movimientoJugador2 = 1;

        private int estado1 = 0;
        private int estado2 = 1;
        System.Drawing.Image img;



        Button seleccionado = null;
        private object blanco;

        //metodo page_load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtJugador1.Text = "0";


            }
        }

        //metodo para contar los movimentos de los jugadores
        public void contarMovimientosBlancos()
        {

            if (ViewState["juga1"] != null)
            {
                movimientoJugador2 = (int)ViewState["juga1"] + 1;
            }
            txtJugador2.Text = movimientoJugador2.ToString();
            ViewState["juga1"] = movimientoJugador2;
        }

        protected void D4_Click(object sender, EventArgs e)
        {
            seleccionFichaBlanca(sender);
            if (ViewState["click"] != null)
            {
                movimientoJuador1 = (int)ViewState["click"] + 1;
            }
            txtJugador1.Text = movimientoJuador1.ToString();
            ViewState["click"] = movimientoJuador1;

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
            contarMovimientosBlancos();


        }

        protected void D5_Click(object sender, EventArgs e)
        {
            seleccionFichaNegra(sender);
        }

        protected void E5_Click(object sender, EventArgs e)
        {
            seleccionFichaBlanca(sender);
        }
        //***********************************************************
        //*********    Metodo para dar turnos de la fichas    *******
        //***********************************************************

        protected void turnoDeJuego(object sender, CommandEventArgs e)
        {
            int fichaNegra = 1;   //  primer turno 1
            int fichaBlanca = 0;   //  segundo turno 2

            bool primero = true;  // esto es para definir quien va primero
            bool segundo = false;  // esto para el segundo atirar

            //******************************************************************************
            if (e.CommandName == "C4" || e.CommandName == "D3")
            {

                seleccionFichaNegra(sender);

            }
            //*******************************************************************************
            if (e.CommandName == "C5" || e.CommandName == "D3")
            {

                seleccionFichaBlanca(sender);
                D6.Text= "\u26C2";


            }
        }
    }
}