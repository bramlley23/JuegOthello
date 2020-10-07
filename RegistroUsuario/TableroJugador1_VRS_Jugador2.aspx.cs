using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;

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
            if (e.CommandName == "D4" && conteoBlanco == 0)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                turnoColorRojo();

            }
            if (e.CommandName == "E4" && conteoNegro == 0)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                turnoColorVerde();

            }
            if (e.CommandName == "D5" && conteoNegro == 1)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                turnoColorVerde();
            }
            if (e.CommandName == "E5" && conteoBlanco == 1)
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
                D5.Text = "\u26C0";
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
            if (e.CommandName == "C6" && conteoNegro == 4)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "E6" && conteoNegro == 4)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "D6" && conteoNegro == 4)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "C7" && conteoBlanco == 4)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                C6.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "B6" && conteoNegro == 5)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                C5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "B7" && conteoNegro == 5)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                C6.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "A7" && conteoBlanco == 5)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                B7.Text = "\u26C0";//COLOR BLANCO
                C7.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "A8" && conteoNegro == 6)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                B7.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "C3" && conteoBlanco == 6)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D4.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "C4" && conteoNegro == 7)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.Text = "\u26C2";//COLOR NEGRO
                C5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "E2" && conteoBlanco == 7)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E3.Text = "\u26C0";//COLOR BLANCO
                E4.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "D1" && conteoNegro == 8)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E2.Text = "\u26C2";//COLOR NEGRO
                F3.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "C2" && conteoBlanco == 8)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D3.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "D2" && conteoNegro == 9)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D3.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "C1" && conteoBlanco == 9)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D2.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "B1" && conteoNegro == 10)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                C1.Text = "\u26C2";//COLOR NEGRO
                C2.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "B2" && conteoBlanco == 10)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                C2.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "A1" && conteoNegro == 11)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                B2.Text = "\u26C2";//COLOR NEGRO
                C3.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "E1" && conteoBlanco == 11)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E2.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "F2" && conteoNegro == 12)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                C2.Text = "\u26C2";//COLOR NEGRO
                D2.Text = "\u26C2";//COLOR NEGRO
                E2.Text = "\u26C2";//COLOR NEGRO
                E3.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "G2" && conteoBlanco == 11)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                F3.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "A6" && conteoNegro == 13)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                A7.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "A2" && conteoBlanco == 12)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                B2.Text = "\u26C0";//COLOR BLANCO
                C2.Text = "\u26C0";//COLOR BLANCO
                D2.Text = "\u26C0";//COLOR BLANCO
                E2.Text = "\u26C0";//COLOR BLANCO
                F2.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "F1" && conteoNegro == 14)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E1.Text = "\u26C2";//COLOR NEGRO
                E2.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "B3" && conteoBlanco == 13)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                C3.Text = "\u26C0";//COLOR BLANCO
                D3.Text = "\u26C0";//COLOR BLANCO
                E3.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "A3" && conteoNegro == 15)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                A2.Text = "\u26C2";//COLOR NEGRO
                B2.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "B4" && conteoBlanco == 14)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                C4.Text = "\u26C0";//COLOR BLANCO
                D4.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "A4" && conteoNegro == 16)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                C2.Text = "\u26C2";//COLOR NEGRO
                B3.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "B5" && conteoBlanco == 15)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                C5.Text = "\u26C0";//COLOR BLANCO
                D5.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "A5" && conteoNegro == 17)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                C3.Text = "\u26C2";//COLOR NEGRO
                B4.Text = "\u26C2";//COLOR NEGRO
                D2.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "D7" && conteoBlanco == 16)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                C6.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "B6" && conteoNegro == 18)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                B5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "G1" && conteoNegro == 19)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F2.Text = "\u26C2";//COLOR NEGRO
                E3.Text = "\u26C2";//COLOR NEGRO
                D4.Text = "\u26C2";//COLOR NEGRO
                C5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "C8" && conteoNegro == 20)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                C6.Text = "\u26C2";//COLOR NEGRO
                C7.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "D6" && conteoNegro == 21)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "E6" && conteoBlanco == 17)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D5.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "D8" && conteoNegro == 22)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D7.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "B8" && conteoBlanco == 18)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                C7.Text = "\u26C0";//COLOR BLANCO
                D6.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "E7" && conteoNegro == 23)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D6.Text = "\u26C2";//COLOR NEGRO
                E6.Text = "\u26C2";//COLOR NEGRO
                E5.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "E8" && conteoBlanco == 19)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D8.Text = "\u26C0";//COLOR BLANCO
                C8.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "F8" && conteoNegro == 24)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D8.Text = "\u26C2";//COLOR NEGRO
                E8.Text = "\u26C2";//COLOR NEGRO
                C8.Text = "\u26C2";//COLOR NEGRO
                B8.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "F4" && conteoBlanco == 20)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D4.Text = "\u26C0";//COLOR BLANCO
                E4.Text = "\u26C0";//COLOR BLANCO
                D6.Text = "\u26C0";//COLOR BLANCO
                E5.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "H1" && conteoNegro == 25)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                G2.Text = "\u26C2";//COLOR NEGRO
                F3.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                D5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "G3" && conteoBlanco == 20)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                F3.Text = "\u26C0";//COLOR BLANCO
                E3.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "H2" && conteoNegro == 26)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                G3.Text = "\u26C2";//COLOR NEGRO
                F4.Text = "\u26C2";//COLOR NEGRO
                E5.Text = "\u26C2";//COLOR NEGRO
                D6.Text = "\u26C2";//COLOR NEGRO
                C7.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "G4" && conteoBlanco == 21)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                F4.Text = "\u26C0";//COLOR BLANCO
                E4.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "H4" && conteoNegro == 27)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                G4.Text = "\u26C2";//COLOR NEGRO
                F4.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                D4.Text = "\u26C2";//COLOR NEGRO
                C4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "F5" && conteoBlanco == 22)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                F4.Text = "\u26C0";//COLOR BLANCO
                E4.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "F6" && conteoNegro == 28)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F5.Text = "\u26C2";//COLOR NEGRO
                F4.Text = "\u26C2";//COLOR NEGRO
                F3.Text = "\u26C2";//COLOR NEGRO
                F2.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "H3" && conteoBlanco == 23)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                F3.Text = "\u26C0";//COLOR BLANCO
                G3.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "F7" && conteoBlanco == 24)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                F6.Text = "\u26C0";//COLOR BLANCO
                F5.Text = "\u26C0";//COLOR BLANCO
                F4.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "G8" && conteoNegro == 28)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F7.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "G5" && conteoBlanco == 25)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                G4.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "G7" && conteoNegro == 29)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F6.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "H5" && conteoBlanco == 26)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                H4.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "G6" && conteoNegro == 30)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                G5.Text = "\u26C2";//COLOR NEGRO
                G4.Text = "\u26C2";//COLOR NEGRO
                G3.Text = "\u26C2";//COLOR NEGRO
                F5.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                D3.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "H6" && conteoBlanco == 27)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                G5.Text = "\u26C0";//COLOR BLANCO
                turnoColorRojo();
            }
            if (e.CommandName == "H7" && conteoNegro == 31)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                H6.Text = "\u26C2";//COLOR NEGRO
                H5.Text = "\u26C2";//COLOR NEGRO
                H4.Text = "\u26C2";//COLOR NEGRO
                H3.Text = "\u26C2";//COLOR NEGRO
                H2.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }

            //****************************************************************************

        }

        //==================================================================================
        //========                Metodo para jugar contra la Maquina             ==========
        //==================================================================================

        protected void juegoContraMaquina(object sender, CommandEventArgs e)
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
            if (e.CommandName == "D4" && conteoBlanco == 0)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D4.ForeColor = Color.White;
                turnoColorRojo();

            }
            if (e.CommandName == "E4" && conteoNegro == 0)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E4.ForeColor = Color.Black;
                turnoColorVerde();

            }
            if (e.CommandName == "D5" && conteoNegro == 1)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.ForeColor = Color.Black;
                turnoColorVerde();
            }
            if (e.CommandName == "E5" && conteoBlanco == 1)
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E5.ForeColor = Color.White;
                turnoColorRojo();
            }
            //**************************** fin de fichas por defecto

            if (e.CommandName == "D3" && conteoNegro == 2)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.ForeColor = Color.Black;

                E4.ForeColor = Color.White;
                E3.Text = "\u26C0";//COLOR BLANCO
                E3.ForeColor = Color.White;
                turnoColorVerde();
                turnoColorRojo();
            }
           
            if (e.CommandName == "E6" && conteoNegro == 2)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E4.ForeColor = Color.Black;
                E5.ForeColor = Color.Black;
                E6.ForeColor = Color.Black;
                D5.ForeColor = Color.White;
                D4.ForeColor = Color.White;
                D6.Text = "\u26C0";//COLOR BLANCO
                D6.ForeColor = Color.White;
                turnoColorVerde();
                turnoColorRojo();
            }
        
            if (e.CommandName == "C4" && conteoNegro == 2)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                C4.ForeColor = Color.Black;
                E4.ForeColor = Color.Black;
                D4.ForeColor = Color.Black;
                C3.Text = "\u26C0";//COLOR BLANCO
                C3.ForeColor = Color.White;
                D4.ForeColor = Color.White;
                E5.ForeColor = Color.White;
                turnoColorVerde();
                turnoColorRojo();
                
            }
            if (e.CommandName == "F5" && conteoNegro == 2)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                
                E5.ForeColor = Color.Black;
                F5.ForeColor = Color.Black;
                F6.Text = "\u26C0";//COLOR BLANCO
                F6.ForeColor = Color.White;
                E5.ForeColor = Color.White;
                C3.ForeColor = Color.White;
                C3.Text = "\u26C0";//COLOR BLANCO
                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "D3" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                D4.ForeColor = Color.Black;
                D3.ForeColor = Color.Black;
                F4.Text = "\u26C0";//COLOR BLANCO
                F4.ForeColor = Color.White;
                F5.ForeColor = Color.White;
                
                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "G4" && conteoNegro == 4)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                G4.ForeColor = Color.Black;
                F4.ForeColor = Color.Black;

                H3.Text = "\u26C0";//COLOR BLANCO
                H3.ForeColor = Color.White;
                G4.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "F7" && conteoNegro == 5)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                F7.ForeColor = Color.Black;
                F6.ForeColor = Color.Black;
                F5.ForeColor = Color.Black;

                C4.Text = "\u26C0";//COLOR BLANCO
                C4.ForeColor = Color.White;
                D4.ForeColor = Color.White;
                E4.ForeColor = Color.White;
                F4.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "F3" && conteoNegro == 6)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                F3.ForeColor = Color.Black;
                F4.ForeColor = Color.Black;
                E4.ForeColor = Color.Black;

                D6.Text = "\u26C0";//COLOR BLANCO
                D6.ForeColor = Color.White;
                D5.ForeColor = Color.White;
                E5.ForeColor = Color.White;
                

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "B4" && conteoNegro == 7)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                B4.ForeColor = Color.Black;
                C4.ForeColor = Color.Black;
                D4.ForeColor = Color.Black;
                E4.ForeColor = Color.Black;
                F4.ForeColor = Color.Black;
                

                A4.Text = "\u26C0";//COLOR BLANCO
                A4.ForeColor = Color.White;
                B4.ForeColor = Color.White;
                C4.ForeColor = Color.White;
                D4.ForeColor = Color.White;
                E4.ForeColor = Color.White;
                F4.ForeColor = Color.White;


                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "D7" && conteoNegro == 8)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                D7.ForeColor = Color.Black;
                D6.ForeColor = Color.Black;
                D5.ForeColor = Color.Black;
                D4.ForeColor = Color.Black;
                D3.ForeColor = Color.Black;

                F8.Text = "\u26C0";//COLOR BLANCO
                F8.ForeColor = Color.White;
                F7.ForeColor = Color.White;
                F6.ForeColor = Color.White;
                F5.ForeColor = Color.White;
                F4.ForeColor = Color.White;
                
                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "H4" && conteoNegro == 9)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                H4.ForeColor = Color.Black;
                G4.ForeColor = Color.Black;
                F4.ForeColor = Color.Black;
                E4.ForeColor = Color.Black;
                

                H5.Text = "\u26C0";//COLOR BLANCO
                H5.ForeColor = Color.White;
                H4.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "G6" && conteoNegro == 10)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
 
                G6.ForeColor = Color.Black;
                F5.ForeColor = Color.Black;

                H6.Text = "\u26C0";//COLOR BLANCO
                H6.ForeColor = Color.White;
                G6.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "G7" && conteoNegro == 11)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                G7.ForeColor = Color.Black;
                E5.ForeColor = Color.Black;

                E6.Text = "\u26C0";//COLOR BLANCO
                E6.ForeColor = Color.White;
                F5.ForeColor = Color.White;
                G4.ForeColor = Color.White;
                F6.ForeColor = Color.White;
                G6.ForeColor = Color.White;
                F7.ForeColor = Color.White;
                F8.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "H7" && conteoNegro == 12)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                G6.ForeColor = Color.Black;
                F5.ForeColor = Color.Black;

                H8.Text = "\u26C0";//COLOR BLANCO
                H8.ForeColor = Color.White;
                H7.ForeColor = Color.White;
                G7.ForeColor = Color.White;
                
                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "G8" && conteoNegro == 13)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                G8.ForeColor = Color.Black;
                G7.ForeColor = Color.Black;
                G6.ForeColor = Color.Black;

                D8.Text = "\u26C0";//COLOR BLANCO
                D8.ForeColor = Color.White;
                D7.ForeColor = Color.White;
                D6.ForeColor = Color.White;
                D5.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "E7" && conteoNegro == 14)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                E7.ForeColor = Color.Black;
                E6.ForeColor = Color.Black;

                E8.Text = "\u26C0";//COLOR BLANCO
                E8.ForeColor = Color.White;
                G6.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "G5" && conteoNegro == 15)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                G5.ForeColor = Color.Black;
                G6.ForeColor = Color.Black;

                G7.Text = "\u26C0";//COLOR BLANCO
                G7.ForeColor = Color.White;
                F6.ForeColor = Color.White;
                E5.ForeColor = Color.White;
                D4.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "C5" && conteoNegro == 16)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                D5.ForeColor = Color.Black;
                E6.ForeColor = Color.Black;
                C5.ForeColor = Color.Black;
                E5.ForeColor = Color.Black;

                C6.Text = "\u26C0";//COLOR BLANCO
                C6.ForeColor = Color.White;
                E6.ForeColor = Color.White;
                D6.ForeColor = Color.White;
                C5.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "C8" && conteoNegro == 17)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                C8.ForeColor = Color.Black;
                D8.ForeColor = Color.Black;
                F8.ForeColor = Color.Black;
                E8.ForeColor = Color.Black;
                D7.ForeColor = Color.Black;
                E6.ForeColor = Color.Black;

                C3.Text = "\u26C0";//COLOR BLANCO
                C3.ForeColor = Color.White;
                D3.ForeColor = Color.White;
                E3.ForeColor = Color.White;
                F4.ForeColor = Color.White;
                G4.ForeColor = Color.White;
                G5.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "C2" && conteoNegro == 18)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                C2.ForeColor = Color.Black;
                D3.ForeColor = Color.Black;
               

                E3.Text = "\u26C0";//COLOR BLANCO
                E3.ForeColor = Color.White;
                C2.ForeColor = Color.White;
                C1.ForeColor = Color.White;
                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "E2" && conteoNegro == 19)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                E2.ForeColor = Color.Black;
                E3.ForeColor = Color.Black;


                F1.Text = "\u26C0";//COLOR BLANCO
                F1.ForeColor = Color.White;
                E2.ForeColor = Color.White;
                D3.ForeColor = Color.White;
                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "D2" && conteoNegro == 20)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                D1.Text = "\u26C0";//COLOR BLANCO
                D1.ForeColor = Color.White;
                D2.ForeColor = Color.White;
                D3.ForeColor = Color.White;
                D4.ForeColor = Color.White;
                D5.ForeColor = Color.White;
                D6.ForeColor = Color.White;
                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "C7" && conteoNegro == 21)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                B8.Text = "\u26C0";//COLOR BLANCO
                B8.ForeColor = Color.White;
                C8.ForeColor = Color.White;
                D8.ForeColor = Color.White;
                E8.ForeColor = Color.White;
                F8.ForeColor = Color.White;
                G8.ForeColor = Color.White;
                E5.ForeColor = Color.White;
                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "B7" && conteoNegro == 22)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                C7.ForeColor = Color.Black;
                C6.ForeColor = Color.Black;
                D5.ForeColor = Color.Black;


                B7.Text = "\u26C0";//COLOR BLANCO
                B7.ForeColor = Color.White;
                A6.ForeColor = Color.White;
                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "G3" && conteoNegro == 23)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                G3.ForeColor = Color.Black;
                G4.ForeColor = Color.Black;
                G5.ForeColor = Color.Black;


                G3.Text = "\u26C0";//COLOR BLANCO
                G3.ForeColor = Color.White;
                C7.ForeColor = Color.White;
                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "B1" && conteoNegro == 24)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                C2.ForeColor = Color.Black;
                D3.ForeColor = Color.Black;
              


                A1.Text = "\u26C0";//COLOR BLANCO
                A1.ForeColor = Color.White;
                B1.ForeColor = Color.White;
                C1.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "G2" && conteoNegro == 25)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                G3.ForeColor = Color.Black;
                G2.ForeColor = Color.Black;



                F3.Text = "\u26C0";//COLOR BLANCO
                F3.ForeColor = Color.White;
                E4.ForeColor = Color.White;
                D5.ForeColor = Color.White;
                C6.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "B5" && conteoNegro == 26)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                C6.ForeColor = Color.Black;
                C4.ForeColor = Color.Black;
                B5.ForeColor = Color.Black;



                A5.Text = "\u26C0";//COLOR BLANCO
                A5.ForeColor = Color.White;
                F5.ForeColor = Color.White;
                G5.ForeColor = Color.White;
              

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "B6" && conteoNegro == 27)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                B6.ForeColor = Color.Black;
                C5.ForeColor = Color.Black;
                D4.ForeColor = Color.Black;



                B3.Text = "\u26C0";//COLOR BLANCO
                B3.ForeColor = Color.White;
                
                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "A8" && conteoNegro == 28)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                A8.ForeColor = Color.Black;
               
                A7.Text = "\u26C0";//COLOR BLANCO
                A7.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "B2" && conteoNegro == 29)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                B2.ForeColor = Color.Black;

                A3.Text = "\u26C0";//COLOR BLANCO
                A3.ForeColor = Color.White;
                B2.ForeColor = Color.White;
                C2.ForeColor = Color.White;

                turnoColorVerde();
                turnoColorRojo();

            }
            if (e.CommandName == "A2" && conteoNegro == 30)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();

                A2.ForeColor = Color.Black;
                A3.ForeColor = Color.Black;
                A4.ForeColor = Color.Black;
                A5.ForeColor = Color.Black;
                A6.ForeColor = Color.Black;
                A7.ForeColor = Color.Black;
                B3.ForeColor = Color.Black;
                B5.ForeColor = Color.Black;

                F2.Text = "\u26C0";//COLOR BLANCO
                F2.ForeColor = Color.White;
                
                turnoColorVerde();
                turnoColorRojo();

            }



        }//fin de metodo juego contra matquina


        //-----------------------------------------------------------------------------------
        //--------------------   metodos para regresar al menu de juegos   ------------------
        //-----------------------------------------------------------------------------------

        //boton para volver al  menu de juegos
        protected void Button12_Click(object sender, EventArgs e)
            {

                MenuDeJuegos volverAlMenu = new MenuDeJuegos();
                Response.Redirect("MenuDeJuegos.aspx");
            }

            protected void Button12_Click1(object sender, EventArgs e)
            {
                MenuDeJuegos volverAlMenu = new MenuDeJuegos();
                Response.Redirect("MenuDeJuegos.aspx");
            }
        
    }
}