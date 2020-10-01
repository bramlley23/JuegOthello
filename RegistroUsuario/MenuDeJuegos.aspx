<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuDeJuegos.aspx.cs" Inherits="RegistroUsuario.MenuDeJuegos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style >        body {
            background-color:darkslateblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Panel ID="Panel1" runat="server" BackColor="#000066" Height="261px" Width="302px">
            <asp:Button ID="btnJugador1vsJugador2" runat="server" Text="Jugador vrs Jugador" BackColor="#6600FF" BorderColor="White" Font-Size="Medium" ForeColor="White" style="top: 109px; left: 41px; position: absolute; height: 44px; width: 226px" />
            <asp:Button ID="Button1" runat="server" BackColor="#6600FF" Font-Size="Medium" ForeColor="White" style="top: 189px; left: 49px; position: absolute; height: 42px; width: 213px" Text="Contra Maquina" />
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" ForeColor="#FFFF66" style="top: 34px; left: 56px; position: absolute; height: 48px; width: 207px" Text="¡ Bienvenido !"></asp:Label>
        </asp:Panel>
    </form>
</body>
</html>
