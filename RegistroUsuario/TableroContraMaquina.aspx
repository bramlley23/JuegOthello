<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TableroJugador1_VRS_Jugador2.aspx.cs" Inherits="RegistroUsuario.TableroJugador1_VRS_Jugador2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <style >        body {
            background-color:#0094ff;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style4">

            <table>

                <!-- fila 0 -->  
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" BackColor="#666666" Height="40px" Text="." Width="40px" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" BackColor="#666666" Height="40px" Text="A" Width="40px" />
                    </td>
                      <td>
                        <asp:Button ID="Button3" runat="server" BackColor="#666666" Height="40px" Text="B" Width="40px" />
                    </tD>
                      <td>
                        <asp:Button ID="Button4" runat="server" BackColor="#666666" Height="40px" Text="C" Width="40px" />
                    </tD>
                      <td>
                        <asp:Button ID="Button5" runat="server" BackColor="#666666" Height="40px" Text="D" Width="40px" />
                    </tD>
                      <td>
                        <asp:Button ID="Button6" runat="server" BackColor="#666666" Height="40px" Text="E" Width="40px" />
                    </tD>
                      <td>
                        <asp:Button ID="Button7" runat="server" BackColor="#666666" Height="40px" Text="F" Width="40px" />
                    </td>
                      <td>
                        <asp:Button ID="Button8" runat="server" BackColor="#666666" Height="40px" Text="G" Width="40px" />
                    </td>
                      <td>
                        <asp:Button ID="Button9" runat="server" BackColor="#666666" Height="40px" Text="H" Width="40px" />
                    </td>
                      <td>
                        <asp:Button ID="Button10" runat="server" BackColor="#666666" Height="40px" Text="." Width="40px" />
                    </td>
                      <td style="background-color: #FFFF00">
                    </td>
                      <td style="background-color: #FFFF00" >
                        <asp:Button ID="Button12" runat="server" BackColor="#6600FF" Height="40px" Text="Volver al Menu" Width="248px" BorderColor="#FF0066" Font-Size="Large" ForeColor="White" OnClick="Button12_Click1" />
                    </tD>
                   
                  
                </tr>

                <!-- fila 1 -->
                <tr>
                    <td>
                        <asp:Button ID="Button11" runat="server" BackColor="#666666" Height="40px" Text="1" Width="40px" />
                    </td>

                    <td>
                        <asp:Button ID="A1" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="A1" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="B1" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="B1" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="C1" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="C1" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="D1" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="D1" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="E1" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="E1" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="F1" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="F1" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="G1" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="G1" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="H1" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="H1" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="Button21" runat="server" BackColor="#666666" Height="40px" Text="1" Width="40px" />
                    </tD>
                    <td style="background-color: #FFFF00"></td>
                    <td style="background-color: #FFFF00">&nbsp;&nbsp;
                        <asp:Button ID="btnJugador1" runat="server" BackColor="Red" Font-Size="Medium" Text="Jugador 1" BorderColor="#0033CC" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnJugador2" runat="server" BackColor="Lime" Font-Size="Medium" Text="Jugador 2" BorderColor="#0033CC" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    </tr>


                <!-- fila 2 -->
                 <tr>
                    <td>
                        <asp:Button ID="Button22" runat="server" BackColor="#666666" Height="40px" Text="2" Width="40px" />
                    </td>
                    <td>
                        <asp:Button ID="A2" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="A2" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="B2" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="B2" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="C2" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="C2" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="D2" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="D2" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="E2" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="E2" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="F2" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="F2" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="G2" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="G2" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="H2" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="H2" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="Button31" runat="server" BackColor="#666666" Height="40px" Text="2" Width="40px" />
                    </tD>
                     <td style="background-color: #FFFF00"></td>
                     <td style="background-color: #FFFF00">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Movimiento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Movimiento</td>
                    </tr>


                <!-- fila 3 -->
                 <tr>
                    <td>
                        <asp:Button ID="Button32" runat="server" BackColor="#666666" Height="40px" Text="3" Width="40px" />
                    </td>
                    <td>
                        <asp:Button ID="A3" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="A3" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="B3" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="B3" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="C3" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="C3" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="D3" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="D3" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="E3" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="E3" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="F3" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="F3" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="G3" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="G3" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="H3" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="H3" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="Button41" runat="server" BackColor="#666666" Height="40px" Text="3" Width="40px" />
                    </tD>
                     <td style="background-color: #FFFF00"></td>
                     <td style="background-color: #FFFF00">
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="txtJugador1" runat="server" Width="61px" ForeColor="Black">0</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="txtJugador2" runat="server" Width="61px">0</asp:TextBox>
                     </td>
                    </tr>


                <!-- fila 4 -->
                 <tr>
                    <td>
                        <asp:Button ID="Button42" runat="server" BackColor="#666666" Height="40px" Text="4" Width="40px" />
                    </td>
                    <td>
                        <asp:Button ID="A4" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="A4" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="B4" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="B4" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="C4" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="C4" OnCommand="juegoContraMaquina"  Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="D4" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="D4" Font-Size="Medium" OnCommand="juegoContraMaquina" ForeColor="Black" />
                    </tD>
                      <td>
                        <asp:Button ID="E4" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="E4" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="F4" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="F4" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="G4" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="G4" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="H4" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="H4" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="Button51" runat="server" BackColor="#666666" Height="40px" Text="4" Width="40px" />
                    </tD>
                     <td style="background-color: #FFFF00"></td>
                     <td style="background-color: #FFFF00">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ficha Blanca&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fichas Negra</td>
                    </tr>


                <!-- fila 5 -->
                 <tr>
                    <td>
                        <asp:Button ID="Button52" runat="server" BackColor="#666666" Height="40px" Text="5" Width="40px" />
                    </td>
                    <td>
                        <asp:Button ID="A5" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="A5" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="B5" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="B5" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="C5" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="C5" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="D5" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="D5" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="E5" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="E5" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="F5" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="F5" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="G5" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="G5" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="H5" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="H5" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="Button61" runat="server" BackColor="#666666" Height="40px" Text="5" Width="40px" />
                    </tD>
                     <td style="background-color: #FFFF00"></td>
                     <td style="background-color: #FFFF00">
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="txtFicha1" runat="server" Width="61px">0</asp:TextBox>

                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                         <asp:TextBox ID="txtFicha2" runat="server" Width="61px">0</asp:TextBox>
                     </td>
                    </tr>


                <!-- fila 6 -->
                 <tr>
                    <td>
                        <asp:Button ID="Button62" runat="server" BackColor="#666666" Height="40px" Text="6" Width="40px" />
                    </td>
                    <td>
                        <asp:Button ID="A6" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="A6" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="B6" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="B6" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="C6" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="C6" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="D6" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="D6" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="E6" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="E6" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="F6" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="F6" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="G6" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="G6" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="H6" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="H6" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="Button71" runat="server" BackColor="#666666" Height="40px" Text="6" Width="40px" />
                    </tD>
                     <td style="background-color: #FFFF00"></td>
                     <td style="background-color: #FFFF00"></td>
                    </tr>


                <!-- fila 7 -->
                 <tr>
                    <td>
                        <asp:Button ID="Button72" runat="server" BackColor="#666666" Height="40px" Text="7" Width="40px" />
                    </td>
                    <td>
                        <asp:Button ID="A7" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="A7" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="B7" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="B7" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="C7" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="C7" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="D7" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="D7" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="E7" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="E7" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="F7" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="F7" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="G7" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="G7" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="H7" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="H7" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="Button81" runat="server" BackColor="#666666" Height="40px" Text="7" Width="40px" />
                    </tD>
                    </tr>


                <!-- fila 8 -->
                 <tr>
                    <td>
                        <asp:Button ID="Button82" runat="server" BackColor="#666666" Height="40px" Text="8" Width="40px" />
                    </td>
                    <td>
                        <asp:Button ID="A8" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="A8" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="B8" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="B8" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="C8" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="C8" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="D8" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="D8" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="E8" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="E8" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="F8" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="F8" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </td>
                      <td>
                        <asp:Button ID="G8" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="G8" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="H8" runat="server" BackColor="#006600" Height="40px" Text="." Width="40px" CommandName="H8" OnCommand="juegoContraMaquina" Font-Size="Medium"/>
                    </tD>
                      <td>
                        <asp:Button ID="Button91" runat="server" BackColor="#666666" Height="40px" Text="8" Width="40px" />
                    </td>
                    </tr>


                <!-- fila 9 -->
                   <tr>
                    <td>
                        <asp:Button ID="Button92" runat="server" BackColor="#666666" Height="40px" Text="." Width="40px" />
                    </td>
                    <td>
                        <asp:Button ID="Button93" runat="server" BackColor="#666666" Height="40px" Text="A" Width="40px" />
                    </td>
                      <td>
                        <asp:Button ID="Button94" runat="server" BackColor="#666666" Height="40px" Text="B" Width="40px" />
                    </td>
                      <td>
                        <asp:Button ID="Button95" runat="server" BackColor="#666666" Height="40px" Text="C" Width="40px" />
                    </tD>
                      <td>
                        <asp:Button ID="Button96" runat="server" BackColor="#666666" Height="40px" Text="D" Width="40px" />
                    </td>
                      <td>
                        <asp:Button ID="Button97" runat="server" BackColor="#666666" Height="40px" Text="E" Width="40px" />
                    </td>
                      <td>
                        <asp:Button ID="Button98" runat="server" BackColor="#666666" Height="40px" Text="F" Width="40px" />
                    </td>
                      <td>
                        <asp:Button ID="Button99" runat="server" BackColor="#666666" Height="40px" Text="G" Width="40px" />
                    </td>
                      <td>
                        <asp:Button ID="Button100" runat="server" BackColor="#666666" Height="40px" Text="H" Width="40px" />
                    </td>
                      <td>
                        <asp:Button ID="Button101" runat="server" BackColor="#666666" Height="40px" Text="." Width="40px" />
                    </td>
                                  
                    </tr>

            </table>
        </div>
        <br />
&nbsp;<asp:Button ID="Button102" runat="server" Height="37px" Text="Guardar" Width="173px" BackColor="Blue" BorderColor="Yellow" Font-Size="Medium" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button103" runat="server" Height="37px" Text="Cargar Juego" Width="168px" BackColor="#0033CC" BorderColor="Yellow" Font-Size="Medium" ForeColor="White" />
    </form>
</body>
</html>
