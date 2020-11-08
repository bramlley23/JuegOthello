using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;
using System.Xml.Linq;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Diagnostics;

namespace RegistroUsuario
{
    
    public partial class TableroJugador1_VRS_Jugador2 : System.Web.UI.Page
    {
       
        //clase para el cronometro
        Stopwatch osW = new Stopwatch();
    
        private int movimientoJuador1 = 1;
        private int movimientoJugador2 = 1;

        private int estado1 = 0;
        private int estado2 = 1;
        System.Drawing.Image img;
        int turno = 1;
        string colorBanco = "blanco";
        string colorNegro = "negro";


        Button seleccionado = null;
        private object blanco;

        //variables globales para uso del cronometro
        int duracion = 0;//para el cronometro miliSegundos
        int duracionSegunodos = 0; //para el cronometro segundos
        int duracionMinutos = 0; // para el cronometro en  minutos

        int duracion2 = 0;//para el cronometro miliSegundos
        int duracionSegunodos2 = 0; //para el cronometro segundos
        int duracionMinutos2 = 0; // para el cronometro en  minutos



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
            btnJugador1.BackColor = Color.GreenYellow;
            btnJugador2.BackColor = Color.Red;
        }

        public void turnoColorVerde()
        {
            btnJugador1.BackColor = Color.Red;
            btnJugador2.BackColor = Color.GreenYellow;

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
                D4.ForeColor = Color.Black;
         
                turnoColorRojo();
                
                parametro("blanco", "D", "4");
            }

            if (e.CommandName == "E4" && conteoNegro == 0)
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                turnoColorVerde();
               

                parametro("negro", "E", "4");

            }
            if (e.CommandName == "D5" && conteoNegro == 1)
            {
                //seleccionFichaNegra(sender);
                seleccionFichaBlanca(sender);
                contarMovimientosBlancos();
                
                turnoColorVerde();
            }
            if (e.CommandName == "E5" && conteoBlanco == 1)
            {
                //seleccionFichaBlanca(sender);
                seleccionFichaNegra(sender);
                contarMovimientosNegros();
                E5.ForeColor = Color.White;
                turnoColorRojo();
            }
            //******************* fin de fichas por defecto en tablero

            //empieza el juego de insertar fichas se empieza por ficha negra y luego blanca
            if (e.CommandName == "D3"  || e.CommandName == "C4" )
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.Text = "\u26C2";
                D4.ForeColor = Color.Black;
                turnoColorVerde();
            }
            if (e.CommandName == "E6" || e.CommandName == "F5" )
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E5.Text = "\u26C2";
                E5.ForeColor = Color.Black;
                turnoColorVerde();
            }
            if (e.CommandName == "E3" )
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E4.Text = "\u26C0";
                E4.ForeColor = Color.White;
                E3.ForeColor = Color.White;
               
                turnoColorRojo();
            }
            if (e.CommandName == "C5" )
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D5.Text = "\u26C0";
                D5.ForeColor = Color.White;
                C5.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "D6" )
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.Text = "\u26C0";
                D5.ForeColor = Color.White;
                D6.ForeColor = Color.White;
                turnoColorVerde();
            }
            if (e.CommandName == "F4" )
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E4.Text = "\u26C0";
                E4.ForeColor = Color.White;
                F4.ForeColor = Color.White;
               
                turnoColorVerde();
            }
            if (e.CommandName == "D6" )
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.Text = "\u26C0";//COLOR BLANCO
                D5.ForeColor = Color.White;
                D6.ForeColor = Color.White;
                turnoColorVerde();
            }
            if (e.CommandName == "F6")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E5.Text = "\u26C0";//COLOR BLANCO
                E5.ForeColor = Color.White;
                F6.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "D3" )
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D4.Text = "\u26C0";//COLOR NEGRO
                D4.ForeColor = Color.Black;
                D3.ForeColor = Color.Black;
                turnoColorRojo();
            }
            if (e.CommandName == "E3" )
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E4.Text = "\u26C0";//COLOR BLANCO
                E4.ForeColor = Color.White;
                E3.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "F3")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E3.Text = "\u26C2";//COLOR NEGRO
                E3.ForeColor = Color.Black;
                F3.ForeColor = Color.Black;
                turnoColorVerde();

            }
            if (e.CommandName == "E2")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E3.Text = "\u26C0";//COLOR BLANCO
                E3.ForeColor = Color.White;
                E2.ForeColor = Color.White;
                turnoColorVerde();

            }
            if (e.CommandName == "C4")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.Text = "\u26C0";//COLOR BLANCO
                D4.ForeColor = Color.White;
                C4.ForeColor = Color.White;
                turnoColorVerde();

            }
            if (e.CommandName == "C5")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D5.Text = "\u26C0";//COLOR BLANCO
                D5.ForeColor = Color.White;
                C5.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "F4")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E4.Text = "\u26C2";//COLOR NEGRO
                E4.ForeColor = Color.Black;
                F4.ForeColor = Color.Black;
                turnoColorVerde();

            }
            if (e.CommandName == "C3")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D3.Text = "\u26C0";//COLOR BLANCO
                D4.Text = "\u26C0";//COLOR BLANCO
                D3.ForeColor = Color.White;
                D4.ForeColor = Color.White;
                C3.ForeColor = Color.White;
                
                turnoColorVerde();

            }
            if (e.CommandName == "C5")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D5.Text = "\u26C0";//COLOR BLANCO
                D4.Text = "\u26C0";//COLOR BLANCO
                D5.ForeColor = Color.White;
                D4.ForeColor = Color.White;
                C5.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "D2")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.Text = "\u26C2";//COLOR NEGRO
                D3.Text = "\u26C2";//COLOR NEGRO
                D4.ForeColor = Color.Black;
                D3.ForeColor = Color.Black;
                D2.ForeColor = Color.Black;
                turnoColorVerde();

            }
            if (e.CommandName == "C4")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D4.Text = "\u26C0";//COLOR BLANCO
                D4.ForeColor = Color.Black;
                C4.ForeColor = Color.Black;
                turnoColorRojo();
            }
            if (e.CommandName == "F5")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E5.Text = "\u26C2";//COLOR NEGRO
                E5.ForeColor = Color.Black;
                F5.ForeColor = Color.Black;
                turnoColorVerde();

            }
            if (e.CommandName == "D6")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D4.Text = "\u26C2";//COLOR NEGRO
                D5.Text = "\u26C2";//COLOR NEGRO
                E5.Text = "\u26C2";//COLOR NEGRO
                D4.ForeColor = Color.Black;
                D5.ForeColor = Color.Black;
                E5.ForeColor = Color.Black;
                D6.ForeColor = Color.Black;
                turnoColorRojo();
            }
            if (e.CommandName == "F3")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E3.Text = "\u26C2";//COLOR NEGRO
                E3.ForeColor = Color.Black;
                F3.ForeColor = Color.Black;
                turnoColorVerde();

            }
            if (e.CommandName == "E2" )
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E3.Text = "\u26C0";//COLOR BLANCO
                E3.ForeColor = Color.White;
                E2.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "C4")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.Text = "\u26C0";//COLOR NEGRO
                D4.ForeColor = Color.White;
                C4.ForeColor = Color.White;
                turnoColorVerde();

            }
            if (e.CommandName == "C5")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D5.Text = "\u26C0";//COLOR BLANCO
                D5.ForeColor = Color.White;
                C5.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "E2")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E3.Text = "\u26C0";//COLOR BLANCO
                E3.ForeColor = Color.White;
                E2.ForeColor = Color.White;
                turnoColorVerde();

            }
            if (e.CommandName == "F5")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E5.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                E5.ForeColor = Color.White;
                E4.ForeColor = Color.White;
                F5.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "C4")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.Text = "\u26C0";//COLOR BLANCO
                D4.ForeColor = Color.White;
                C4.ForeColor = Color.White;
                turnoColorVerde();

            }
            if (e.CommandName == "E6" || e.CommandName=="F5")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E5.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                E5.ForeColor = Color.Black;
                E4.ForeColor = Color.Black;
                E6.ForeColor = Color.Black;
                turnoColorRojo();
            }
            if (e.CommandName == "C6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                D5.ForeColor = Color.Black;
                E4.ForeColor = Color.Black;
                C6.ForeColor = Color.Black;
                turnoColorVerde();

            }
            if (e.CommandName == "C5")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D5.Text = "\u26C0";//COLOR BLANCO
                D5.ForeColor = Color.White;
                C5.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "D6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.Text = "\u26C2";//COLOR NEGRO
                D5.ForeColor = Color.Black;
                D6.ForeColor = Color.Black;
                turnoColorVerde();

            }
            if (e.CommandName == "F4")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E4.Text = "\u26C2";//COLOR NEGRO
                E4.ForeColor = Color.Black;
                F4.ForeColor = Color.Black;
                
                turnoColorRojo();
            }
            if (e.CommandName == "E6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E5.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                E5.ForeColor = Color.Black;
                E4.ForeColor = Color.Black;
                E6.ForeColor = Color.Black;
                
                turnoColorVerde();

            }
            if (e.CommandName == "D2")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D3.Text = "\u26C0";//COLOR BLANCO
                D4.Text = "\u26C0";//COLOR BLANCO
                D3.ForeColor = Color.White;
                D4.ForeColor = Color.White;
                D2.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "G2")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F3.Text = "\u26C0";//COLOR BLANCO
                E4.Text = "\u26C0";//COLOR BLANCO
                F3.ForeColor = Color.White;
                E4.ForeColor = Color.White;
                G2.ForeColor = Color.White;
                turnoColorVerde();

            }
            if (e.CommandName == "E2")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E3.Text = "\u26C0";//COLOR BLANCO
                E4.Text = "\u26C0";//COLOR BLANCO
                E3.ForeColor = Color.White;
                E4.ForeColor = Color.White;
                E2.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "C3")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                
                D3.Text = "\u26C2";//COLOR NEGRO
                D3.ForeColor = Color.Black;
                C3.ForeColor = Color.Black;
                turnoColorVerde();

            }
            if (e.CommandName == "C4")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                
                D4.Text = "\u26C2";//COLOR NEGRO
                D4.ForeColor = Color.Black;
                C4.ForeColor = Color.Black;
                turnoColorRojo();
            }
            if (e.CommandName == "C6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.Text = "\u26C2";//COLOR NEGRO
                D5.ForeColor = Color.Black;
                turnoColorVerde();

            }
            if (e.CommandName == "E6")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E5.Text = "\u26C2";//COLOR NEGRO
                
                turnoColorRojo();
            }
            if (e.CommandName == "G2")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E4.Text = "\u26C0";//COLOR BLANCO
                F3.Text = "\u26C0";//COLOR BLANCO
                E4.ForeColor = Color.White;
                F3.ForeColor = Color.White;
                G2.ForeColor = Color.White;
                turnoColorVerde();

            }
            if (e.CommandName == "F2")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F3.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "D6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.Text = "\u26C2";//COLOR NEGRO
                E5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "E6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E5.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "G3")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                F3.Text = "\u26C2";//COLOR NEGRO
                turnoColorRojo();
            }
            if (e.CommandName == "")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D7.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "E2")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E3.Text = "\u26C0";//COLOR BLANCO
                E4.Text = "\u26C0";//COLOR BLANCO
                E3.ForeColor = Color.White;
                E4.ForeColor = Color.White;
                E2.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "C6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "D6")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D5.Text = "\u26C0";//COLOR NEGRO
                E5.Text = "\u26C0";//COLOR NEGRO
                turnoColorRojo();
            }
            if (e.CommandName == "F6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "F5")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E4.Text = "\u26C2";//COLOR NEGRO
                turnoColorRojo();
            }
            if (e.CommandName == "F5")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "C3")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D4.Text = "\u26C0";//COLOR BLANCO
                D3.Text = "\u26C0";//COLOR BLANCO
                D4.ForeColor = Color.White;
                D3.ForeColor = Color.White;
                C3.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "G5")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F5.Text = "\u26C0";//COLOR BLANCO
                F4.Text = "\u26C0";//COLOR BLANCO
                F5.ForeColor = Color.White;
                F4.ForeColor = Color.White;
                G5.ForeColor = Color.White;
                turnoColorVerde();

            }
            if (e.CommandName == "G3")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                F4.Text = "\u26C0";//COLOR BLANCO
                F3.Text = "\u26C0";//COLOR BLANCO
                F4.ForeColor = Color.White;
                F3.ForeColor = Color.White;
                G3.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "C3")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.Text = "\u26C0";//COLOR BLACO
                D3.Text = "\u26C0";//COLOR BLANCO
                D4.ForeColor = Color.White;
                D3.ForeColor = Color.White;
                C3.ForeColor = Color.White;
                turnoColorVerde();

            }
            if (e.CommandName == "B3")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                C3.Text = "\u26C2";//COLOR NEGRO
                D3.Text = "\u26C2";//COLOR NEGRO
                E3.Text = "\u26C2";//COLOR NEGRO
                F3.Text = "\u26C2";//COLOR NEGRO
                turnoColorRojo();
            }
            if (e.CommandName == "C4")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "C6")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D5.Text = "\u26C2";//COLOR NEGRO
                turnoColorRojo();
            }
            if (e.CommandName == "E6")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E5.Text = "\u26C2";//COLOR NEGRO
                turnoColorRojo();
            }
            if (e.CommandName == "G5")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F5.Text = "\u26C0";//COLOR BLANCO
                F4.Text = "\u26C0";//BLANCO
                F5.ForeColor = Color.White;
                F4.ForeColor = Color.White;
                G5.ForeColor = Color.White;
                turnoColorVerde();

            }
            if (e.CommandName == "B3" )
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                C3.Text = "\u26C2";//COLOR NEGRO
                D3.Text = "\u26C2";//COLOR NEGRO
                E3.Text = "\u26C2";//COLOR NEGRO
                F3.Text = "\u26C2";//COLOR NEGRO
                turnoColorRojo();
            }
            if (e.CommandName == "C4")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "C6")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D5.Text = "\u26C2";//COLOR NEGRO
                turnoColorRojo();
            }
            if (e.CommandName == "F6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F4.Text = "\u26C2";//COLOR NEGRO
                F5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "G3")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                F3.Text = "\u26C0";//COLOR BLANCO
                F4.Text = "\u26C0";//COLOR BLANCO
                F3.ForeColor = Color.White;
                F4.ForeColor = Color.White;
                G3.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "C2")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D3.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "C4")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "E6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "G4")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "C5")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.Text = "\u26C2";//COLOR NEGRO
                E5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "F1")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F2.Text = "\u26C2";//COLOR NEGRO
                F3.Text = "\u26C2";//COLOR NEGRO
                F4.Text="\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "G2")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E3.Text = "\u26C2";//COLOR NEGRO
                F3.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                D5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "E7")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E6.Text = "\u26C2";//COLOR NEGRO
                E5.Text = "\u26C2";//COLOR NEGRO
                E7.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "C2")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D3.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "D1")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D2.Text = "\u26C2";//COLOR NEGRO
                D3.Text = "\u26C2";//COLOR NEGRO
                D4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "H3")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                G3.Text = "\u26C2";//COLOR NEGRO
                F3.Text = "\u26C2";//COLOR NEGRO
                E3.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "G5")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                G4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "E6")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E4.Text = "\u26C0";//COLOR BLANCO
                E5.Text = "\u26C0";//COLOR BLANCO
                C5.Text = "\u26C0";//COLOR BLANCO
                E4.ForeColor = Color.White;
                E5.ForeColor = Color.White;
                C5.ForeColor = Color.White;
                E6.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "G4")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                B4.Text = "\u26C0";//COLOR BLANCO
                F4.Text = "\u26C0";//COLOR BLANCO
                F3.Text = "\u26C0";//COLOR BLANCO
                B4.ForeColor = Color.White;
                F4.ForeColor = Color.White;
                F3.ForeColor = Color.White;
                G4.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "H2")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                G2.Text = "\u26C0";//COLOR BLANCO
                F2.Text = "\u26C0";//COLOR BLANCO
                F3.Text = "\u26C0";//COLOR BLANCO
                G2.ForeColor = Color.White;
                F2.ForeColor = Color.White;
                F3.ForeColor = Color.White;
                H2.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "E8")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E7.Text = "\u26C0";//COLOR BLANCO
                E6.Text = "\u26C0";//COLOR BLANCO
                E5.Text = "\u26C0";//COLOR BLANCO
                E4.Text = "\u26C0";//COLOR BLANCO
                E7.ForeColor = Color.White;
                E6.ForeColor = Color.White;
                E5.ForeColor = Color.White;
                E4.ForeColor = Color.White;
                E8.ForeColor = Color.White;

                turnoColorRojo();
            }
            if (e.CommandName == "D2")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D3.Text = "\u26C0";//COLOR BLANCO
                D3.ForeColor = Color.White;
                D2.ForeColor = Color.White;

                turnoColorRojo();
            }
            if (e.CommandName == "C4")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D4.Text = "\u26C0";//COLOR BLANCO
                E4.Text = "\u26C0";//COLOR BLANCO
                D4.ForeColor = Color.White;
                E4.ForeColor = Color.White;
                C4.ForeColor = Color.White;

                turnoColorRojo();
            }
            if (e.CommandName == "C1")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                D2.Text = "\u26C0";//COLOR BLANCO
                E3.Text = "\u26C0";//COLOR BLANCO
                D2.ForeColor = Color.White;
                E3.ForeColor = Color.White;
                C1.ForeColor = Color.White;

                turnoColorRojo();
            }
            if (e.CommandName == "H1")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                H2.Text = "\u26C2";//COLOR NEGRO
                G2.Text = "\u26C2";//COLOR NEGRO
                F2.Text = "\u26C2";//COLOR NEGRO
                D2.Text = "\u26C2";//COLOR NEGRO
                E2.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "B3")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                C3.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "E1")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D2.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "B1")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                C2.Text = "\u26C2";//COLOR NEGRO
                D3.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                
                turnoColorVerde();

            }
            if (e.CommandName == "A2")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                B3.Text = "\u26C2";//COLOR NEGRO
                C3.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "B5")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                C5.Text = "\u26C2";//COLOR NEGRO
                D5.Text = "\u26C2";//COLOR NEGRO
                E5.Text = "\u26C2";//COLOR NEGRO
                
                turnoColorVerde();

            }
            if (e.CommandName == "H4")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D4.Text = "\u26C2";//COLOR NEGRO
                F4.Text = "\u26C2";//COLOR NEGRO
                G4.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "H6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                H3.Text = "\u26C2";//COLOR NEGRO
                H4.Text = "\u26C2";//COLOR NEGRO
                H5.Text = "\u26C2";//COLOR NEGRO
                G5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "D6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                D5.Text = "\u26C2";//COLOR NEGRO
                D4.Text = "\u26C2";//COLOR NEGRO
                E5.Text = "\u26C2";//COLOR NEGRO
                F4.Text = "\u26C2";//COLOR NEGRO
                G4.Text = "\u26C2";//COLOR NEGRO

                turnoColorVerde();

            }
            if (e.CommandName == "C7")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                G3.Text = "\u26C2";//COLOR NEGRO
                G4.Text = "\u26C2";//COLOR NEGRO
                G5.Text = "\u26C2";//COLOR NEGRO
                
                turnoColorVerde();

            }
            if (e.CommandName == "A4")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                B4.Text = "\u26C2";//COLOR NEGRO
                C4.Text = "\u26C2";//COLOR NEGRO
                D4.Text = "\u26C2";//COLOR NEGRO
                E4.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "F7")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F6.Text = "\u26C2";//COLOR NEGRO
                F5.Text = "\u26C2";//COLOR NEGRO
                G6.Text = "\u26C2";//COLOR NEGRO
                E6.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "B6")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                B5.Text = "\u26C2";//COLOR NEGRO
                C5.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "D7")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                E7.Text = "\u26C2";//COLOR NEGRO
                C6.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "A7")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                B7.Text = "\u26C2";//COLOR NEGRO
                C7.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "H7")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                G7.Text = "\u26C2";//COLOR NEGRO
                turnoColorVerde();

            }
            if (e.CommandName == "F8")
            {
                seleccionFichaNegra(sender);
                contarMovimientosBlancos();
                F7.Text = "\u26C2";//COLOR NEGRO
                F6.Text = "\u26C2";//COLOR NEGRO
                G7.Text = "\u26C2";//COLOR NEGRO
                E7.Text = "\u26C2";//COLOR NEGRO
                D6.Text = "\u26C2";//COLOR NEGRO

                turnoColorVerde();

            }
            if (e.CommandName == "G1")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                G2.Text = "\u26C0";//COLOR BLANCO
                G3.Text = "\u26C0";//COLOR BLANCO
                G4.Text = "\u26C0";//COLOR BLANCO
                G5.Text = "\u26C0";//COLOR BLANCO
                F2.Text = "\u26C0";//COLOR BLANCO
                H2.Text = "\u26C0";//COLOR BLANCO

                G2.ForeColor = Color.White;
                G3.ForeColor = Color.White;
                G4.ForeColor = Color.White;
                G5.ForeColor = Color.White;
                F2.ForeColor = Color.White;
                H2.ForeColor = Color.White;

                turnoColorRojo();
            }
            if (e.CommandName == "B2")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                C2.Text = "\u26C0";//COLOR BLANCO
                D2.Text = "\u26C0";//COLOR BLANCO
                E2.Text = "\u26C0";//COLOR BLANCO
                
                C2.ForeColor = Color.White;
                D2.ForeColor = Color.White;
                E2.ForeColor = Color.White;
                
                turnoColorRojo();
            }
            if (e.CommandName == "A3")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                B3.Text = "\u26C0";//COLOR BLANCO
                C3.Text = "\u26C0";//COLOR BLANCO
                D3.Text = "\u26C0";//COLOR BLANCO
                
                B3.ForeColor = Color.White;
                C3.ForeColor = Color.White;
                D3.ForeColor = Color.White;
                
                turnoColorRojo();
            }
            if (e.CommandName == "A1")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                B1.Text = "\u26C0";//COLOR BLANCO

                B1.ForeColor = Color.White;

                turnoColorRojo();
            }
            if (e.CommandName == "B7")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                C6.Text = "\u26C0";//COLOR BLANCO
                D5.Text = "\u26C0";//COLOR BLANCO
                E4.Text = "\u26C0";//COLOR BLANCO
                F3.Text = "\u26C0";//COLOR BLANCO
                
                C6.ForeColor = Color.White;
                D5.ForeColor = Color.White;
                E4.ForeColor = Color.White;
                F3.ForeColor = Color.White;
                B7.ForeColor = Color.White;
                
                turnoColorRojo();
            }
            if (e.CommandName == "A5")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                B5.Text = "\u26C0";//COLOR BLANCO
                C5.Text = "\u26C0";//COLOR BLANCO
                D5.Text = "\u26C0";//COLOR BLANCO
                E5.Text = "\u26C0";//COLOR BLANCO
                F5.Text = "\u26C0";//COLOR BLANCO
                

                B5.ForeColor = Color.White;
                C5.ForeColor = Color.White;
                D5.ForeColor = Color.White;
                E5.ForeColor = Color.White;
                F5.ForeColor = Color.White;
                A5.ForeColor = Color.White;

                turnoColorRojo();
            }
            if (e.CommandName == "H5")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                H3.Text = "\u26C0";//COLOR BLANCO
                H4.Text = "\u26C0";//COLOR BLANCO
                G4.Text = "\u26C0";//COLOR BLANCO
                
                H3.ForeColor = Color.White;
                H4.ForeColor = Color.White;
                G4.ForeColor = Color.White;
                H5.ForeColor = Color.White;
                
                turnoColorRojo();
            }
            if (e.CommandName == "B4")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                E5.Text = "\u26C0";//COLOR BLANCO
                D4.Text = "\u26C0";//COLOR BLANCO
                
                E5.ForeColor = Color.White;
                D4.ForeColor = Color.White;
                B4.ForeColor = Color.White;
                
                turnoColorRojo();
            }
            if (e.CommandName == "C8")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                C7.Text = "\u26C0";//COLOR BLANCO
                C6.Text = "\u26C0";//COLOR BLANCO
                C5.Text = "\u26C0";//COLOR BLANCO
                C4.Text = "\u26C0";//COLOR BLANCO
                C3.Text = "\u26C0";//COLOR BLANCO
                C2.Text = "\u26C0";//COLOR BLANCO

                C7.ForeColor = Color.White;
                C6.ForeColor = Color.White;
                C5.ForeColor = Color.White;
                C4.ForeColor = Color.White;
                C3.ForeColor = Color.White;
                C2.ForeColor = Color.White;
                C8.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "G7")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                G6.Text = "\u26C0";//COLOR BLANCO
                G5.Text = "\u26C0";//COLOR BLANCO
                F6.Text = "\u26C0";//COLOR BLANCO
                
                G6.ForeColor = Color.White;
                G5.ForeColor = Color.White;
                F6.ForeColor = Color.White;
                G7.ForeColor = Color.White;
                
                turnoColorRojo();
            }
            if (e.CommandName == "A6")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                B6.Text = "\u26C0";//COLOR BLANCO
                C6.Text = "\u26C0";//COLOR BLANCO
                D6.Text = "\u26C0";//COLOR BLANCO
                B5.Text = "\u26C0";//COLOR BLANCO
                C4.Text = "\u26C0";//COLOR BLANCO
                D3.Text = "\u26C0";//COLOR BLANCO

                B6.ForeColor = Color.White;
                C6.ForeColor = Color.White;
                D6.ForeColor = Color.White;
                B5.ForeColor = Color.White;
                C4.ForeColor = Color.White;
                D3.ForeColor = Color.White;
                A6.ForeColor = Color.White;
                turnoColorRojo();
            }
            if (e.CommandName == "A8")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                A7.Text = "\u26C0";//COLOR BLANCO
                A7.ForeColor = Color.White;
                A8.ForeColor = Color.White;
                

                turnoColorRojo();
            }
            if (e.CommandName == "B8")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                B7.Text = "\u26C0";//COLOR BLANCO
                C7.Text = "\u26C0";//COLOR BLANCO
                D7.Text = "\u26C0";//COLOR BLANCO
                E7.Text = "\u26C0";//COLOR BLANCO
                F7.Text = "\u26C0";//COLOR BLANCO
                
                B7.ForeColor = Color.White;
                C7.ForeColor = Color.White;
                D7.ForeColor = Color.White;
                E7.ForeColor = Color.White;
                F7.ForeColor = Color.White;
                B8.ForeColor = Color.White;

                turnoColorRojo();
            }
            if (e.CommandName == "G8")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                F8.Text = "\u26C0";//COLOR BLANCO
                F7.Text = "\u26C0";//COLOR BLANCO
                F8.ForeColor = Color.White;
                F7.ForeColor = Color.White;
                G8.ForeColor = Color.White;

                turnoColorRojo();
            }
            if (e.CommandName == "H8")
            {
                seleccionFichaBlanca(sender);
                contarMovimientosNegros();
                G7.Text = "\u26C0";//COLOR BLANCO
                F6.Text = "\u26C0";//COLOR BLANCO
                G7.ForeColor = Color.White;
                F6.ForeColor = Color.White;
                H8.ForeColor = Color.White;
                turnoColorRojo();
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


        //boton para guardar xml del partido jugador contra jugador

        protected void Button102_Click(object sender, EventArgs e)
        {
           
        }
            public void parametro(string color, string columna, string fila)
            {
                    XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", null));
                    XElement nodoRaiz = new XElement("tablero");
                    document.Add(nodoRaiz);
                    XElement ficha = new XElement("ficha");


        ficha.Add(new XElement("color", color));
                ficha.Add(new XElement("columna", columna));
                ficha.Add(new XElement("fila", fila));
                nodoRaiz.Add(ficha);
                

                document.Save(@"C:\Users\nefar\Desktop\BDSQLOthelo\juego.xml");
            }
        
     
        //metodo para cargar juego del tablero jugador1 vrs jugador2
        protected void Button103_Click(object sender, EventArgs e)
        {

            TableroJugador1_VRS_Jugador2 ir = new TableroJugador1_VRS_Jugador2();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath(@"C:\Users\nefar\Desktop\BDSQLOthelo\juego.xml"));
            
        }

        protected void btnJugador1_Click(object sender, EventArgs e)
        {

        }
        //-----------------------------------------------------------------------------------
        //--------------------   Tablero Xtreme Inverso   ------------------
        //-----------------------------------------------------------------------------------


       //metodo para el cronometro del jugador 1
        public void cronometro1()
        {
            Timer1.Enabled = true;
            Timer2.Enabled = false;
        }
        //cronometro 2 para el jugador 2
        public void cronometro2()
        {
            osW.Start();
            Timer2.Enabled = true;
            Timer1.Enabled = false;
        }
        //*********************************************************************************
        //*********************************************************************************
        //metodo para utilizar el command name
        protected void eventoExtremo(object sender, CommandEventArgs e)
        {
            int conteoBlanco = Convert.ToInt32(txtJugador1.Text);
            int conteoNegro = Convert.ToInt32(txtJugador2.Text);

            if (e.CommandName == "D4" && conteoBlanco==0)
            {
                seleccionFichaNegra(sender);
                D4.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();

            }   
            
            if (e.CommandName == "E4" && conteoNegro==0)
            {
                seleccionFichaNegra(sender);
                E4.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();
                
            }
            if (e.CommandName == "D5" && conteoBlanco == 2 && conteoNegro==1)
            {
                seleccionFichaNegra(sender);
                D5.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();
            }
            if (e.CommandName == "E5" && conteoBlanco==1)
            {
                seleccionFichaNegra(sender);
                E5.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            //****************************************************************
            //movimientos con el contador == 2 ficha blanca
            if (e.CommandName == "D3" && conteoBlanco == 2)
            {
                seleccionFichaNegra(sender);
                D3.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
                            }
            if (e.CommandName == "C4" && conteoBlanco == 2)
            {
                seleccionFichaNegra(sender);
                C4.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "E6" && conteoBlanco == 2)
            {
                seleccionFichaNegra(sender);
                E6.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "F5" && conteoBlanco == 2)
            {
                seleccionFichaNegra(sender);
                F5.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            //**********************************************************
            //movimiento con el contador == 2 ficha negra
            if (e.CommandName == "E3" && conteoNegro == 2)
            {
                seleccionFichaNegra(sender);
                E3.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "C5" && conteoNegro == 2)
            {
                seleccionFichaNegra(sender);
                C5.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "D6" && conteoNegro == 2)
            {
                seleccionFichaNegra(sender);
                D6.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "F4" && conteoNegro == 2)
            {
                seleccionFichaNegra(sender);
                F4.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            //movimiento con el contador == 3 ficha roja(blanca)
            if (e.CommandName == "D3" && conteoBlanco == 3)
            {
                seleccionFichaNegra(sender);
                D3.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "C3" && conteoBlanco == 3)
            {
                seleccionFichaNegra(sender);
                C3.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B4" && conteoBlanco == 3)
            {
                seleccionFichaNegra(sender);
                B4.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "F6" && conteoBlanco == 3)
            {
                seleccionFichaNegra(sender);
                F6.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "F5" && conteoBlanco == 3)
            {
                seleccionFichaNegra(sender);
                F5.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "F3" && conteoBlanco == 3)
            {
                seleccionFichaNegra(sender);
                F3.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "C4" && conteoBlanco == 3)
            {
                seleccionFichaNegra(sender);
                C4.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "C6" && conteoBlanco == 3)
            {
                seleccionFichaNegra(sender);
                C6.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "E6" && conteoBlanco == 3)
            {
                seleccionFichaNegra(sender);
                E6.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "G5" && conteoBlanco == 3)
            {
                seleccionFichaNegra(sender);
                G5.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            //*****************************************************************
            //CONTEO MOVIEMIENTOS CONTADOR == 3 FICHA NEGRA(VERDE)
            if (e.CommandName == "B5" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                B5.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "B6" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                B6.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
           
            if (e.CommandName == "D6" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                D6.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
         
           
            if (e.CommandName == "F4" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                F4.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
          
           
            if (e.CommandName == "C5" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                C5.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
           
            if (e.CommandName == "G6" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                G6.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "G4" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                G4.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "G3" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                G3.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "E3" && conteoNegro == 3)
            {
                seleccionFichaNegra(sender);
                E3.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            //************************************************************
            //movimientos con contador == 4 fichas blancas
            if (e.CommandName == "C3" && conteoBlanco == 4)
            {
                seleccionFichaNegra(sender);
                C3.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B3" && conteoBlanco == 4)
            {
                seleccionFichaNegra(sender);
                B3.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B4" && conteoBlanco == 4)
            {
                seleccionFichaNegra(sender);
                B4.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "F6" && conteoBlanco == 4)
            {
                seleccionFichaNegra(sender);
                F6.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "G6" && conteoBlanco == 4)
            {
                seleccionFichaNegra(sender);
                G6.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "G5" && conteoBlanco == 4)
            {
                seleccionFichaNegra(sender);
                G5.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            //********************************************************
            //movimientos con contaodor == 4 ficha color negra
            if (e.CommandName == "B2" && conteoNegro == 4)
            {
                seleccionFichaNegra(sender);
                B2.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "B5" && conteoNegro == 4)
            {
                seleccionFichaNegra(sender);
                B5.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "B6" && conteoNegro == 4)
            {
                seleccionFichaNegra(sender);
                B6.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "C6" && conteoNegro == 4)
            {
                seleccionFichaNegra(sender);
                C6.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "G4" && conteoNegro == 4)
            {
                seleccionFichaNegra(sender);
                G4.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "G3" && conteoNegro == 4)
            {
                seleccionFichaNegra(sender);
                G3.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "F3" && conteoNegro == 4)
            {
                seleccionFichaNegra(sender);
                F3.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "F4" && conteoNegro == 4)
            {
                seleccionFichaNegra(sender);
                F4.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            //************************************************************
            //movimientos con contador == 5 fichas blancas(roja)
            if (e.CommandName == "C3" && conteoBlanco == 5)
            {
                seleccionFichaNegra(sender);
                C3.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B3" && conteoBlanco == 5)
            {
                seleccionFichaNegra(sender);
                B3.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B4" && conteoBlanco == 5)
            {
                seleccionFichaNegra(sender);
                B4.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "F6" && conteoBlanco == 5)
            {
                seleccionFichaNegra(sender);
                F6.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "G6" && conteoBlanco == 5)
            {
                seleccionFichaNegra(sender);
                G6.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "G5" && conteoBlanco == 5)
            {
                seleccionFichaNegra(sender);
                G5.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            //**************************************************
            //movimiento con contador == 5 ficha negra
            if (e.CommandName == "B2" && conteoNegro == 5)
            {
                seleccionFichaNegra(sender);
                B2.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "B5" && conteoNegro == 5)
            {
                seleccionFichaNegra(sender);
                B5.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "B6" && conteoNegro == 5)
            {
                seleccionFichaNegra(sender);
                B6.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "C6" && conteoNegro == 5)
            {
                seleccionFichaNegra(sender);
                C6.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "G4" && conteoNegro == 5)
            {
                seleccionFichaNegra(sender);
                G4.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "G3" && conteoNegro == 5)
            {
                seleccionFichaNegra(sender);
                G3.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "F3" && conteoNegro == 5)
            {
                seleccionFichaNegra(sender);
                F3.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            //************************************************************
            //movimientos con contador == 6 fichas blancas
            if (e.CommandName == "B2" && conteoBlanco == 6)
            {
                seleccionFichaNegra(sender);
                B2.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "A2" && conteoBlanco == 6)
            {
                seleccionFichaNegra(sender);
                A2.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "A3" && conteoBlanco == 6)
            {
                seleccionFichaNegra(sender);
                A3.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "A4" && conteoBlanco == 6)
            {
                seleccionFichaNegra(sender);
                A4.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B4" && conteoBlanco == 6)
            {
                seleccionFichaNegra(sender);
                B4.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "F6" && conteoBlanco == 6)
            {
                seleccionFichaNegra(sender);
                F6.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "G5" && conteoBlanco == 6)
            {
                seleccionFichaNegra(sender);
                G5.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "C3" && conteoBlanco == 6)
            {
                seleccionFichaNegra(sender);
                C3.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            //**************************************************
            //movimiento con contador == 6 ficha negra(VERDE)
            if (e.CommandName == "B5" && conteoNegro == 6)
            {
                seleccionFichaNegra(sender);
                B5.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "B6" && conteoNegro == 6)
            {
                seleccionFichaNegra(sender);
                B6.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "C6" && conteoNegro == 6)
            {
                seleccionFichaNegra(sender);
                C6.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "G6" && conteoNegro == 6)
            {
                seleccionFichaNegra(sender);
                G6.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "G4" && conteoNegro == 6)
            {
                seleccionFichaNegra(sender);
                G4.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "G3" && conteoNegro == 6)
            {
                seleccionFichaNegra(sender);
                G3.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "G2" && conteoNegro == 6)
            {
                seleccionFichaNegra(sender);
                G2.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "F2" && conteoNegro == 6)
            {
                seleccionFichaNegra(sender);
                F2.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "E2" && conteoNegro == 6)
            {
                seleccionFichaNegra(sender);
                E2.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            //************************************************************
            //movimientos con contador == 7 fichas blancas(rojo)
            if (e.CommandName == "C2" && conteoBlanco == 7)
            {
                seleccionFichaNegra(sender);
                C2.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B2" && conteoBlanco == 7)
            {
                seleccionFichaNegra(sender);
                B2.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "A3" && conteoBlanco == 7)
            {
                seleccionFichaNegra(sender);
                A3.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "A4" && conteoBlanco == 7)
            {
                seleccionFichaNegra(sender);
                A4.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B4" && conteoBlanco == 7)
            {
                seleccionFichaNegra(sender);
                B4.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "F6" && conteoBlanco == 7)
            {
                seleccionFichaNegra(sender);
                F6.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "G6" && conteoBlanco == 7)
            {
                seleccionFichaNegra(sender);
                G6.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "G5" && conteoBlanco == 7)
            {
                seleccionFichaNegra(sender);
                G5.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "G2" && conteoBlanco == 7)
            {
                seleccionFichaNegra(sender);
                G2.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "H3" && conteoBlanco == 7)
            {
                seleccionFichaNegra(sender);
                H3.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            //**************************************************
            //movimiento con contador == 7 ficha negra
            if (e.CommandName == "B5" && conteoNegro == 7)
            {
                seleccionFichaNegra(sender);
                B5.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "B6" && conteoNegro == 7)
            {
                seleccionFichaNegra(sender);
                B6.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "C6" && conteoNegro == 7)
            {
                seleccionFichaNegra(sender);
                C6.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "F2" && conteoNegro == 7)
            {
                seleccionFichaNegra(sender);
                F2.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "H2" && conteoNegro == 7)
            {
                seleccionFichaNegra(sender);
                H2.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "H4" && conteoNegro == 7)
            {
                seleccionFichaNegra(sender);
                H4.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            //************************************************************
            //movimientos con contador == 8 fichas blancas
            if (e.CommandName == "C2" && conteoBlanco == 8)
            {
                seleccionFichaNegra(sender);
                B2.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "A3" && conteoBlanco == 8)
            {
                seleccionFichaNegra(sender);
                A3.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B4" && conteoBlanco == 8)
            {
                seleccionFichaNegra(sender);
                B4.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B6" && conteoBlanco == 8)
            {
                seleccionFichaNegra(sender);
                B6.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "F6" && conteoBlanco == 8)
            {
                seleccionFichaNegra(sender);
                F6.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "G2" && conteoBlanco == 8)
            {
                seleccionFichaNegra(sender);
                G2.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            //**************************************************
            //movimiento con contador == 8 ficha negra(VERDE)
            if (e.CommandName == "D2" && conteoNegro == 8)
            {
                seleccionFichaNegra(sender);
                D2.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "A4" && conteoNegro == 8)
            {
                seleccionFichaNegra(sender);
                A4.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "B5" && conteoNegro == 8)
            {
                seleccionFichaNegra(sender);
                B5.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "C7" && conteoNegro == 8)
            {
                seleccionFichaNegra(sender);
                C7.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "G4" && conteoNegro == 8)
            {
                seleccionFichaNegra(sender);
                G4.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "H3" && conteoNegro == 8)
            {
                seleccionFichaNegra(sender);
                H3.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "H2" && conteoNegro == 8)
            {
                seleccionFichaNegra(sender);
                H2.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "F2" && conteoNegro == 8)
            {
                seleccionFichaNegra
                    (sender);
                F2.ForeColor = Color.GreenYellow;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            //************************************************************
            //movimientos con contador == 9 fichas blancas
            if (e.CommandName == "C1" && conteoBlanco == 9)
            {
                seleccionFichaNegra(sender);
                C1.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B1" && conteoBlanco == 9)
            {
                seleccionFichaNegra(sender);
                B1.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B6" && conteoBlanco == 9)
            {
                seleccionFichaNegra(sender);
                B6.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "F6" && conteoBlanco == 9)
            {
                seleccionFichaNegra(sender);
                F6.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "A2" && conteoBlanco == 9)
            {
                seleccionFichaNegra(sender);
                A2.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B2" && conteoBlanco == 9)
            {
                seleccionFichaNegra(sender);
                B2.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B4" && conteoBlanco == 9)
            {
                seleccionFichaNegra(sender);
                B4.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B7" && conteoBlanco == 9)
            {
                seleccionFichaNegra(sender);
                B7.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "G6" && conteoBlanco == 9)
            {
                seleccionFichaNegra(sender);
                G6.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "H5" && conteoBlanco == 9)
            {
                seleccionFichaNegra(sender);
                H5.ForeColor = Color.Red;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            //**************************************************
            //movimiento con contador == 9 ficha negra
            if (e.CommandName == "B5" && conteoNegro == 9)
            {
                seleccionFichaNegra(sender);
                B5.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "C8" && conteoNegro == 9)
            {
                seleccionFichaNegra(sender);
                C8.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "D7" && conteoNegro == 9)
            {
                seleccionFichaNegra(sender);
                D7.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "D2" && conteoNegro == 9)
            {
                seleccionFichaNegra(sender);
                D2.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "E2" && conteoNegro == 9)
            {
                seleccionFichaNegra(sender);
                E2.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "F2" && conteoNegro == 9)
            {
                seleccionFichaNegra(sender);
                F2.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "G2" && conteoNegro == 9)
            {
                seleccionFichaNegra(sender);
                G2.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "H3" && conteoNegro == 9)
            {
                seleccionFichaNegra(sender);
                H3.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            if (e.CommandName == "H4" && conteoNegro == 9)
            {
                seleccionFichaNegra(sender);
                H4.ForeColor = Color.Black;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }
            //************************************************************
            //movimientos con contador == 10 fichas blancas
            if (e.CommandName == "C1" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                C1.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "E2" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                E2.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B1" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                B1.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B2" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                B2.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "A2" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                A2.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "A4" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                A4.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "B4" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                B4.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "C7" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                C7.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "C8" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                C8.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "D8" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                D8.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "D7" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                D7.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "F6" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                F6.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "G6" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                G6.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "H5" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                H5.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            if (e.CommandName == "H4" && conteoBlanco == 10)
            {
                seleccionFichaNegra(sender);
                H4.ForeColor = Color.White;
                cronometro2();
                contarMovimientosNegros();
                turnoColorVerde();
            }
            //**************************************************
            //movimiento con contador == 10 ficha negra()VERDE
            if (e.CommandName == "D3" && conteoNegro == 10 && e.CommandName=="D2" && e.CommandName=="D4")
            {
                seleccionFichaNegra(sender);
                D3.ForeColor = Color.Red;
                cronometro1();
                contarMovimientosBlancos();
                turnoColorRojo();

            }






        }
        //fin metodo para controlar los cammand name (nombre de comando)
        //**********************************************************************************
        //**********************************************************************************
        protected void btnBlanco_Click(object sender, EventArgs e)
        {


           

        }
        //metodo para el cronometro uno 
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan tsi = new TimeSpan(0, 0, 0, 0, (int)osW.ElapsedMilliseconds);
            //txtMinutos.Text = tsi.Minutes.ToString().Length<2 ? "0"+ tsi.Minutes.ToString() : tsi.Minutes.ToString();
            //txtSegundos.Text = tsi.Seconds.ToString().Length<2 ? "0"+ tsi.Seconds.ToString() : tsi.Seconds.ToString();
            //txtMili.Text = tsi.Milliseconds.ToString();
            
            //cronometro uno
            duracion++;
            duracionSegunodos++;
            duracionMinutos++;
            duracion = Convert.ToInt32(lblMiliSegundo.Text)+1;
            lblMiliSegundo.Text = duracion.ToString();

            if (duracion == 60)
            {
                duracion = 0;
                duracion = Convert.ToInt32(lblMiliSegundo.Text) -60;
                lblMiliSegundo.Text = duracion.ToString();

                duracionSegunodos = Convert.ToInt32(lblSegundos.Text) + 1;
                lblSegundos.Text = duracionSegunodos.ToString();
                   
            }
            if (duracionSegunodos == 60)
            {
                duracionSegunodos = 0;
                duracionSegunodos = Convert.ToInt32(lblSegundos.Text) -60;
                lblSegundos.Text = duracionSegunodos.ToString();

                duracionMinutos = Convert.ToInt32(lblMinutos.Text) + 1;
                lblMinutos.Text = duracionMinutos.ToString();

            }
             
        }//fin metodo Timer1_Tick

      
        protected void btnVerde_Click(object sender, EventArgs e)
        {
        
           

        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            duracion2++;
            duracionSegunodos2++;
            duracionMinutos2++;

            duracion2 = Convert.ToInt32(lblMiliSegundo2.Text) + 1;
            lblMiliSegundo2.Text = duracion2.ToString();

            if (duracion2 == 60)
            {
                duracion2 = 0;
                duracion2 = Convert.ToInt32(lblMiliSegundo2.Text) - 60;
                lblMiliSegundo2.Text = duracion2.ToString();

                duracionSegunodos2 = Convert.ToInt32(lblSegundos2.Text) + 1;
                lblSegundos2.Text = duracionSegunodos2.ToString();

            }
            if (duracionSegunodos2 == 60)
            {
                duracionSegunodos2 = 0;
                duracionSegunodos2 = Convert.ToInt32(lblSegundos2.Text) -60;
                lblSegundos2.Text = duracionSegunodos2.ToString();

                duracionMinutos2 = Convert.ToInt32(lblMinutos2.Text) + 1;
                lblMinutos2.Text = duracionMinutos2.ToString();
            }
        }

        protected void Button104_Click(object sender, EventArgs e)
        {
            Response.Write("hola");
        }

       
    }
}