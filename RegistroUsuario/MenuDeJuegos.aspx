<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuDeJuegos.aspx.cs" Inherits="RegistroUsuario.MenuDeJuegos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style >        body {
            background-color:darkslateblue;
        }
        .auto-style1 {
            top: 189px;
            left: 49px;
            position: absolute;
            height: 42px;
            width: 213px;
        }
        .auto-style2 {
            top: 44px;
            left: 53px;
            position: absolute;
            height: 48px;
            width: 207px;
        }
        .auto-style3 {
            top: 273px;
            left: 46px;
            position: absolute;
            height: 42px;
            width: 213px;
        }
        .auto-style4 {
            width: 205px;
            height: 43px;
            position: absolute;
            left: 50px;
            top: 354px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Panel ID="Panel1" runat="server" BackColor="#000066" Height="401px" Width="302px" HorizontalAlign="Center">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnJugador1vsJugador2" runat="server" Text="Jugador vrs Jugador" BackColor="#6600FF" BorderColor="White" Font-Size="Medium" ForeColor="White" style="top: 109px; left: 41px; position: absolute; height: 44px; width: 226px" OnClick="btnJugador1vsJugador2_Click" />
            <asp:Button ID="Button1" runat="server" BackColor="#6600FF" Font-Size="Medium" ForeColor="White" Text="Contra Maquina" OnClick="Button1_Click" BorderColor="White" CssClass="auto-style1" />
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" ForeColor="#FFFF66" Text="¡ Bienvenido !" CssClass="auto-style2"></asp:Label>
            <br />
            <asp:Button ID="btnInverso0" runat="server" BackColor="#6600FF" BorderColor="White" CssClass="auto-style3" Font-Size="Medium" ForeColor="White" OnClick="Button1_Click" Text="Juego Inverso" />
            <asp:Button ID="btnCampeonato" runat="server" BackColor="#6600FF" BorderColor="White" CssClass="auto-style4" Font-Size="Medium" ForeColor="White" OnClick="btnCampeonato_Click" Text="Campeonato" />
        </asp:Panel>
    </form>
</body>
</html>
