<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuDeJuegos.aspx.cs" Inherits="RegistroUsuario.MenuDeJuegos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style >        body {
            background-color:darkslateblue;
        }
        .auto-style3 {
            top: 358px;
            left: 45px;
            position: absolute;
            height: 44px;
            width: 226px;
            margin-top: 0px;
        }
        .auto-style4 {
            width: 211px;
            height: 36px;
            position: absolute;
            left: 55px;
            top: 300px;
            right: 777px;
        }
        .auto-style5 {
            width: 203px;
            position: absolute;
            left: 58px;
            top: 248px;
            height: 34px;
        }
        .auto-style6 {
            width: 197px;
            height: 42px;
            position: absolute;
            left: 64px;
            top: 188px;
        }
        .auto-style7 {
            width: 183px;
            height: 34px;
            position: absolute;
            left: 73px;
            top: 136px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Panel ID="Panel1" runat="server" BackColor="#000066" Height="401px" Width="302px" HorizontalAlign="Center">
             <asp:Button ID="btnJugador1vsJugador2" runat="server" Text="Jugador vrs Jugador" BackColor="#6600FF" BorderColor="White" Font-Size="Medium" ForeColor="White" OnClick="btnJugador1vsJugador2_Click" CssClass="auto-style3" />
              <asp:Button ID="Button1" runat="server" BackColor="#6600FF" BorderColor="White" CssClass="auto-style4" Font-Size="Medium" ForeColor="White" OnClick="Button1_Click" Text="Vrs Maquina" />
             <asp:Button ID="Button2" runat="server" BackColor="#6600FF" BorderColor="White" CssClass="auto-style5" Font-Size="Small" ForeColor="White" OnClick="Button2_Click" Text="Othellos Xtreme" />
             <asp:Button ID="Button3" runat="server" BackColor="#6600FF" BorderColor="White" CssClass="auto-style6" Font-Size="Medium" ForeColor="White" OnClick="Button3_Click" Text="Gestor De Partidas" />
             <asp:Button ID="Button4" runat="server" BackColor="#6600FF" BorderColor="White" CssClass="auto-style7" Font-Size="Medium" ForeColor="White" OnClick="Button4_Click" Text="Esquema De Juego" />
            </asp:Panel>
    </form>
</body>
</html>
