<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="RegistroUsuario.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Juego Othello</title>
    <link href="estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 452px">
           
            <br />
            <br />
            <br />
            Nombre&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Apellido&nbsp;&nbsp;
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
&nbsp;&nbsp; Fecha Nacimiento&nbsp;
            <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <br />
            Usuario&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Correo&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            Contraseña&nbsp;
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" Width="122px"></asp:TextBox>
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnGuardar" runat="server" BackColor="#00CC00" BorderColor="White" BorderStyle="Solid" Font-Size="Medium" ForeColor="White" Height="38px" Text="Guardar" Width="131px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" BackColor="#00CC00" BorderColor="White" Font-Size="Medium" ForeColor="White" Height="38px" Text="Menu De Juegos" Width="144px" />
            <br />
            <br />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" BackColor="#0099CC" style="top: 18px; left: 3px; position: absolute; height: 381px; width: 823px; z-index: -1">
            </asp:Panel>
        </div>
    </form>
</body>
</html>
