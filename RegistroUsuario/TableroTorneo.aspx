<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TableroTorneo.aspx.cs" Inherits="RegistroUsuario.TableroTorneo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<html xmlns="http://www.w3.org/1999/xhtml"> <head runat="server">
<title></title> </head>
<body> <form id="form1" runat="server"> <div>
<asp:Label ID="lblCantidad" runat="server" Text="Ingrese un numero"></asp:Label> <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox> <asp:Button ID="btnProceso" runat="server" Text="Button"
onclick="btnProceso_Click" /> </div>
</form> </body>
</html>

