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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                txtRonda.Text = "1";

            }

        }

        protected void btnAvanzar_Click(object sender, EventArgs e)
        {
                 int empate = 0;
                 int perdido = 0;
                 int ganado = 0;
                 
                 //int r = 0;
                 // r = a + b;
                 //txtNombrEquipo2.Text = r.ToString();

                 //dt = (DataTable)ViewState["Record"];
                 //dt.Rows.Add(txtCampeonato.Text+"\n", txtIngresEquipos.Text, txtNomJugadores.Text, txtPuntos1.Text,empate,perdido,ganado);
                 //GridView1.DataSource = dt;
                 //GridView1.DataBind();
                 btnEquipo1.Text = txtNombrEquipo1.Text;
                 btnEquipo2.Text = txtNombrEquipo2.Text;
           
            
            


                 if (ViewState["rondas"] != null)
                 {
                     ronda = (int)ViewState["rondas"] + 1;
                 }
                  txtRonda.Text = ronda.ToString();
                  ViewState["rondas"] = ronda;
            int a = Convert.ToInt32(txtPuntos1.Text);
            int b = Convert.ToInt32(txtPuntos2.Text);
            
           
                btnPuts1.Text = txtPuntos1.Text;
                btnPts2.Text = txtPuntos2.Text;
                btnJG1.Text = ganado.ToString();
                btnJE1.Text = empate.ToString();
                btnJP1.Text = perdido.ToString();
                              
           

        }//fin boton avanzar

    }
    
}