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
        int turno = 1;



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

        public void contarMovimientosNegros()
        {
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
            ficha.Text = "\u26C0";//COLOR BLANCO
            seleccionado = ficha;

        }

        //metodo para seleccionar ficna color negra
        public void seleccionFichaNegra(object objeto)
        {

            Button ficha = (Button)objeto;
            seleccionado = ficha;
            ficha.Text = "\u26C2";//COLOR NEGRO
            seleccionado = ficha;
        }
        //método para mostrar el turno de cada jugador cambia de color los botones rojo y verde
        public void turnoColorRojo()
        {
            btnJugador1.BackColor = Color.Red;
            btnJugador2.BackColor = Color.GreenYellow;
        }

        public void turnoColorVerde()
        {
            btnJugador1.BackColor = Color.GreenYellow;
            btnJugador2.BackColor = Color.Red;

        }
   
        //***********************************************************
        //*********    Metodo para dar turnos de la fichas    *******
        //***********************************************************

        protected void turnoDeJuego(object sender, CommandEventArgs e)
        {
            //e.CommandName == "C4" 

            int fichaNegra = 1;   //  primer turno 1
            int fichaBlanca = 1;   //  segundo turno 2

            bool primero = true;  // esto es para definir quien va primero
            bool segundo = false;  // esto para el segundo atirar
            int i = 0;
           
            int contador = 1;


            int conteoBlanco = Convert.ToInt32(txtJugador1.Text);
            int conteoNegro = Convert.ToInt32(txtJugador2.Text);
           
            //estos son las fichas que se pornen por defecto D4, E4, D5 y E5
                if (e.CommandName == "D4" && conteoBlanco==0 )
                {
                    seleccionFichaBlanca(sender);
                    contarMovimientosNegros();
                    turnoColorRojo();
                   
                }
                if (e.CommandName == "E4" && conteoNegro==0)
                {
                    seleccionFichaNegra(sender);
                    contarMovimientosBlancos();
                    turnoColorVerde();

                }
                if (e.CommandName == "D5" && conteoNegro==1 )
                {
                    seleccionFichaNegra(sender);
                    contarMovimientosBlancos();
                    turnoColorVerde();
                }
                if (e.CommandName == "E5" && conteoBlanco==1 )
                {
                    seleccionFichaBlanca(sender);
                    contarMovimientosNegros();
                    turnoColorRojo();
                }
            //******************* fin de fichas por defecto en tablero

            //empieza el juego de insertar fichas se empieza por ficha negra y luego blanca
            if (e.CommandName == "D3" && conteoNegro == 2)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.Text = "\u26C2";
                turnoColorVerde();
            }
            if (e.CommandName == "E6" && conteoNegro == 2)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E5.Text = "\u26C2";
                turnoColorVerde();
            }
            if (e.CommandName == "C5" && conteoBlanco == 2)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D5.Text= "\u26C0";
                turnoColorRojo();
            }
            if (e.CommandName == "E3" && conteoBlanco == 2)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E4.Text = "\u26C0";
                turnoColorRojo();
            }
            if (e.CommandName == "F5" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E4.Text = "\u26C2";//COLOR NEGRO
                E5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();
            }
            if (e.CommandName == "F3" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E3.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();
            }
            if (e.CommandName == "F4" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();
            }
            if (e.CommandName == "E2" && conteoBlanco == 3)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E3.Text = "\u26C0";//COLOR BLANCO
                E4.Text = "\u26C0";//COLOR BLANCO
                E5.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "C3" && conteoBlanco == 3)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D4.Text = "\u26C0";//COLOR BLANCO
                E5.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "C5" && conteoBlanco == 3)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D5.Text = "\u26C0";//COLOR BLANCO
                E5.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }





        }
    }
}