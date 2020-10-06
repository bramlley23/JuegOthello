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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TableroContraMaquina tableroMaquina = new TableroContraMaquina();
            Response.Redirect("TableroContraMaquina.aspx");
        }
    }
}