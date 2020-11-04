using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RegistroUsuario
{
    
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        private int ronda = 2;
        private int conteo = 1;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                txtRonda.Text = "0";

            }

        }
        //metodo para contar las rondas jugadas
        //public void contarRonda()
        //{
        //    if (ViewState["rondas"] != null)
        //    {
        //        ronda = (int)ViewState["rondas"] + 1;
        //    }
        //    txtRonda.Text = ronda.ToString();
        //    ViewState["rondas"] = ronda;
        //}

        protected void btnAvanzar_Click(object sender, EventArgs e)
        {

           

            //int r = 0;
            // r = a + b;
            //txtNombrEquipo2.Text = r.ToString();

            //dt = (DataTable)ViewState["Record"];
            //dt.Rows.Add(txtCampeonato.Text+"\n", txtIngresEquipos.Text, txtNomJugadores.Text, txtPuntos1.Text,empate,perdido,ganado);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }//fin boton avanzar


        protected void avanzar(object sender, CommandEventArgs e)
        {
            int a = Convert.ToInt32(txtPuntos1.Text);
            int b = Convert.ToInt32(txtPuntos2.Text);

            int empate = 0;//c solo uno gano
            int ptsEmpatados = 1;//ambos que daron empatados
            int perdido = 0;
            int ganado = 1;
            int ganado2 = 0;
            int rondaDeJuego = 1;
          
            int conteoRondasi = Convert.ToInt32(txtRonda.Text)+1;
            txtRonda.Text = conteoRondasi.ToString();
                        
            if (e.CommandName == "btnAvanzar")
            {
               // contarRonda();

                if (a > b && conteoRondasi==1)
                {
                    btnEquipo1.Text = txtNombrEquipo1.Text;
                    btnPuts1.Text = txtPuntos1.Text;
                    btnJG1.Text = Convert.ToString(ganado);
                    btnJP1.Text = Convert.ToString(perdido);
                    btnJE1.Text = Convert.ToString(empate);
                    btnR1.Text = Convert.ToString(rondaDeJuego);

                    perdido = perdido + 1;
                    btnEquipo2.Text = txtNombrEquipo2.Text;
                    btnPts2.Text = txtPuntos2.Text;
                    btnJG2.Text = Convert.ToString(ganado2);
                    btnJP2.Text = Convert.ToString(perdido);
                    btnJE2.Text = Convert.ToString(empate);
                    btnR2.Text = Convert.ToString(rondaDeJuego);
                }//fin de if a>b

                if (a < b && conteoRondasi == 1)
                {
                    btnEquipo2.Text = txtNombrEquipo2.Text;
                    btnPts2.Text = txtPuntos2.Text;
                    btnJG2.Text = Convert.ToString(ganado);
                    btnJP2.Text = Convert.ToString(perdido);
                    btnJE2.Text = Convert.ToString(empate);
                    btnR2.Text = Convert.ToString(rondaDeJuego);

                    perdido = perdido + 1;
                    btnEquipo1.Text = txtNombrEquipo1.Text;
                    btnPuts1.Text = txtPuntos1.Text;
                    btnJG1.Text = Convert.ToString(ganado2);
                    btnJP1.Text = Convert.ToString(perdido);
                    btnJE1.Text = Convert.ToString(empate);
                    btnR1.Text = Convert.ToString(rondaDeJuego);
                }//fin del if a<b

                if (a == b && conteoRondasi == 1)
                {
                    empate = empate + 1;
                    btnEquipo1.Text = txtNombrEquipo1.Text;
                    btnPuts1.Text = Convert.ToString(ptsEmpatados);
                    btnJG1.Text = Convert.ToString(ganado2);
                    btnJP1.Text = Convert.ToString(perdido);
                    btnJE1.Text = Convert.ToString(empate);
                    btnR1.Text = Convert.ToString(rondaDeJuego);

                    btnEquipo2.Text = txtNombrEquipo2.Text;
                    btnPts2.Text = Convert.ToString(ptsEmpatados); 
                    btnJG2.Text = Convert.ToString(ganado2);
                    btnJP2.Text = Convert.ToString(perdido);
                    btnJE2.Text = Convert.ToString(empate);
                    btnR2.Text = Convert.ToString(rondaDeJuego);
                }//fin if a==b

                //empieza turnos del equipo 3 y 4
                if (a > b && conteoRondasi == 2)
                {
                    rondaDeJuego = rondaDeJuego + 1;
                    btnEquipo3.Text = txtNombrEquipo1.Text;
                    btnPts3.Text = txtPuntos1.Text;
                    btnJG3.Text = Convert.ToString(ganado);
                    btnJP3.Text = Convert.ToString(perdido);
                    btnJE3.Text = Convert.ToString(empate);
                    btnR3.Text = Convert.ToString(rondaDeJuego);

                    perdido = perdido + 1;
                    btnEquipo4.Text = txtNombrEquipo2.Text;
                    btnPts4.Text = txtPuntos2.Text;
                    btnJG4.Text = Convert.ToString(ganado2);
                    btnJP4.Text = Convert.ToString(perdido);
                    btnJE4.Text = Convert.ToString(empate);
                    btnR4.Text = Convert.ToString(rondaDeJuego);
                }//fin de if a>b

                if (a < b && conteoRondasi == 2)
                {
                    rondaDeJuego = rondaDeJuego + 1;
                    btnEquipo4.Text = txtNombrEquipo2.Text;
                    btnPts4.Text = txtPuntos2.Text;
                    btnJG4.Text = Convert.ToString(ganado);
                    btnJP4.Text = Convert.ToString(perdido);
                    btnJE4.Text = Convert.ToString(empate);
                    btnR4.Text = Convert.ToString(rondaDeJuego);
                    
                    perdido = perdido + 1;
                    btnEquipo3.Text = txtNombrEquipo1.Text;
                    btnPts3.Text = txtPuntos1.Text;
                    btnJG3.Text = Convert.ToString(ganado2);
                    btnJP3.Text = Convert.ToString(perdido);
                    btnJE3.Text = Convert.ToString(empate);
                    btnR3.Text = Convert.ToString(rondaDeJuego);
                }//fin del if a<b

                if (a == b && conteoRondasi == 2)
                {
                    rondaDeJuego = rondaDeJuego + 1;
                    empate = empate + 1;
                    btnEquipo3.Text = txtNombrEquipo1.Text;
                    btnPts3.Text = Convert.ToString(ptsEmpatados);
                    btnJG3.Text = Convert.ToString(ganado2);
                    btnJP3.Text = Convert.ToString(perdido);
                    btnJE3.Text = Convert.ToString(empate);
                    btnR3.Text = Convert.ToString(rondaDeJuego);

                    btnEquipo4.Text = txtNombrEquipo2.Text;
                    btnPts4.Text = Convert.ToString(ptsEmpatados);
                    btnJG4.Text = Convert.ToString(ganado2);
                    btnJP4.Text = Convert.ToString(perdido);
                    btnJE4.Text = Convert.ToString(empate);
                    btnR4.Text = Convert.ToString(rondaDeJuego);
                }//fin if a==b

                //empieza turnos del equipo 5 y 6
                if (a > b && conteoRondasi == 3)
                {
                    rondaDeJuego = rondaDeJuego + 2;
                    btnEquipo5.Text = txtNombrEquipo1.Text;
                    btnPts5.Text = txtPuntos1.Text;
                    btnJG5.Text = Convert.ToString(ganado);
                    btnJP5.Text = Convert.ToString(perdido);
                    btnJE5.Text = Convert.ToString(empate);
                    btnR5.Text = Convert.ToString(rondaDeJuego);

                    perdido = perdido + 1;
                    btnEquipo6.Text = txtNombrEquipo2.Text;
                    btnPts6.Text = txtPuntos2.Text;
                    btnJG6.Text = Convert.ToString(ganado2);
                    btnJP6.Text = Convert.ToString(perdido);
                    btnJE6.Text = Convert.ToString(empate);
                    btnR6.Text = Convert.ToString(rondaDeJuego);
                }//fin de if a>b

                if (a < b && conteoRondasi == 3)
                {
                    rondaDeJuego = rondaDeJuego + 2;
                    btnEquipo6.Text = txtNombrEquipo2.Text;
                    btnPts6.Text = txtPuntos2.Text;
                    btnJG6.Text = Convert.ToString(ganado);
                    btnJP6.Text = Convert.ToString(perdido);
                    btnJE6.Text = Convert.ToString(empate);
                    btnR6.Text = Convert.ToString(rondaDeJuego);

                    perdido = perdido + 1;
                    btnEquipo5.Text = txtNombrEquipo1.Text;
                    btnPts5.Text = txtPuntos1.Text;
                    btnJG5.Text = Convert.ToString(ganado2);
                    btnJP5.Text = Convert.ToString(perdido);
                    btnJE5.Text = Convert.ToString(empate);
                    btnR5.Text = Convert.ToString(rondaDeJuego);
                }//fin del if a<b

                if (a == b && conteoRondasi == 3)
                {
                    rondaDeJuego = rondaDeJuego + 2;
                    empate = empate + 1;
                    btnEquipo5.Text = txtNombrEquipo1.Text;
                    btnPts5.Text = Convert.ToString(ptsEmpatados);
                    btnJG5.Text = Convert.ToString(ganado2);
                    btnJP5.Text = Convert.ToString(perdido);
                    btnJE5.Text = Convert.ToString(empate);
                    btnR5.Text = Convert.ToString(rondaDeJuego);

                    btnEquipo6.Text = txtNombrEquipo2.Text;
                    btnPts6.Text = Convert.ToString(ptsEmpatados);
                    btnJG6.Text = Convert.ToString(ganado2);
                    btnJP6.Text = Convert.ToString(perdido);
                    btnJE6.Text = Convert.ToString(empate);
                    btnR6.Text = Convert.ToString(rondaDeJuego);
                }//fin if a==b

            }//fin de if e.commandName btnAvanzar

            //evento para limpiar la tabla
            if (e.CommandName == "btnLimpiarTabla")
            {
                txtCampeonato.Text = "";
                txtIngresEquipo1.Text = "";
                txtIngresEquipo2.Text = "";
                txtNombreJugador1.Text = "";
                txtNombreJugador2.Text = "";
                txtNombreJugador3.Text = "";
                txtNobreJugador4.Text ="";
                txtNombreJugador5.Text = "";
                txtNombreJugador6.Text = "";

                btnPuts1.Text = "";
                btnPts2.Text = "";
                btnPts3.Text = "";
                btnPts4.Text = "";
                btnPts5.Text = "";
                btnPts6.Text = "";
                btnJG1.Text = "";
                btnJG2.Text = "";
                btnJG3.Text = "";
                btnJG4.Text = "";
                btnJG5.Text = "";
                btnJG6.Text = "";
                btnJE1.Text = "";
                btnJE2.Text = "";
                btnJE3.Text = "";
                btnJE4.Text = "";
                btnJE5.Text = "";
                btnJE6.Text = "";
                btnJP1.Text = "";
                btnJP2.Text = "";
                btnJP3.Text = "";
                btnJP4.Text = "";
                btnJP5.Text = "";
                btnJP6.Text = "";
                btnR1.Text = "";
                btnR2.Text = "";
                btnR3.Text = "";
                btnR4.Text = "";
                btnR5.Text = "";
                btnR6.Text = "";

                btnEquipo1.Text = "";
                btnEquipo2.Text = "";
                btnEquipo3.Text = "";
                btnEquipo4.Text = "";
                btnEquipo5.Text = "";
                btnEquipo6.Text = "";
                txtRonda.Text = "0";
                
                conteoRondasi = 0;

             

            }//fin if boton limpiar


        }//fin de metodo avanzar commandName

        protected void btnLimpiarTabla_Click(object sender, EventArgs e)
        {

        }
    }
    
}