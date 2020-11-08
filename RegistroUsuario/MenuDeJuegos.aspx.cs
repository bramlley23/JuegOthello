using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuario
{
    public partial class MenuDeJuegos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnJugador1vsJugador2_Click(object sender, EventArgs e)
        {
            TableroJugador1_VRS_Jugador2 j1VRsj2 = new TableroJugador1_VRS_Jugador2();
            Response.Redirect("TableroJugador1_VRS_Jugador2.aspx");

        }//fin de metodo btn jugador1 vrs jugador2

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("Hola Mundo");
            TableroContraMaquina gr = new TableroContraMaquina();
            Response.Redirect("TableroContraMaquina.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("Hola Mundo2");
            othelloXtreneNormal otrs = new othelloXtreneNormal();
            Response.Redirect("othelloXtreneNormal.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Write("Hola Mundo3");
            PerfilUsuario pfl = new PerfilUsuario();
            Response.Redirect("PerfilUsuario.aspx");

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Write("Hola Mundo4");
            DiagramaDeTorneos dgrtns = new DiagramaDeTorneos();
            Response.Redirect("DiagramaDeTorneos.aspx");

        }
    }
}