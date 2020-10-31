<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuCampeonato.aspx.cs" Inherits="RegistroUsuario.MenuCampeonato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 299px;
        }
        .auto-style2 {
            left: 377px;
            top: 110px;
            position: absolute;
        }
        body{
            
            background-color:#ff6a00;
        }
        #panel1{
            opacity:0.5;
            border-color:darkcyan;
            border:15px;
            opacity: 0.5;
            filter:  alpha(opacity=50);
        }
        .auto-style3 {
            width: 319px;
            height: 273px;
            position: absolute;
            left: 759px;
            top: 44px;
        }
        .auto-style4 {
            position: absolute;
            left: 369px;
            top: 388px;
        }
        .auto-style5 {
            position: absolute;
            left: 369px;
            top: 297px;
        }
        .auto-style6 {
            position: absolute;
            left: 373px;
            top: 204px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <asp:Panel ID="Panel1" runat="server" BackColor="#333300" CssClass="auto-style1" Height="434px" Width="374px"  BorderColor="#006699">
            &nbsp;&nbsp;
            <br />
            &nbsp;&nbsp; &nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEquipo4" runat="server" BackColor="Yellow" BorderColor="White" CssClass="auto-style2" Font-Size="X-Large" ForeColor="#FF9900" Height="71px" Text="Equipos DE Cuatro" Width="251px" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEquipo8" runat="server" BackColor="Yellow" BorderColor="White" Font-Size="X-Large" ForeColor="#FF9900" Height="70px" Text="Eipos De Ocho" Width="254px" CssClass="auto-style6" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" BackColor="Yellow" BorderColor="White" Font-Size="X-Large" ForeColor="#FF9900" Height="68px" Text="Equipos De Dieciseis" Width="259px" CssClass="auto-style5" />
            &nbsp;&nbsp;
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEsquema" runat="server" BackColor="Yellow" BorderColor="White" Font-Size="XX-Large" ForeColor="#FF9900" Height="71px" Text="Esquema" Width="258px" CssClass="auto-style4" />
            <br />
            <br />
        </asp:Panel>
        <div>
            <br />
        </div>
    </form>
</body>
</html>
