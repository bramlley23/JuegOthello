<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TableroDinamico.aspx.cs" Inherits="RegistroUsuario.TableroTorneo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Tabla Xtreme</title>
    <style>
        body
        {
            background-color:darkblue;
        }
    </style>
    <script runat="server">


        void Page_Load(object sender, EventArgs e)
        {
            //generando botones
            if (!IsPostBack)
            {
                Button1.Click += new EventHandler(Button1_Click);
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = true;
            }

        }
        public void mostar()
        {
            Table tbl = new Table();
            int cantidad = Convert.ToInt32(txtM.Text.Trim());
            Label botoncito = new Label();
            for(int i=1; i<= cantidad; i++)
            {
                botoncito.ID = "btn1" + i.ToString();
                botoncito.Text = "Aksksks";


                botoncito.Height = 40;
                botoncito.Width = 40;
                Page.Controls.Add(tbl);
                agregarBoton(tbl,botoncito);
            }

        }//fin metodo mostrar
        public void agregarBoton(Table t, Label b)
        {
            TableCell tc = new TableCell();
            TableRow tr = new TableRow();
            tc.Controls.Add(b);
            tr.Cells.Add(tc);
            t.Rows.Add(tr);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName== "Button1")
            {

                int maximo = 0;
                int minimo = 0;
                int numPanel = 0;
                maximo = Convert.ToInt32(txtM.Text);
                minimo = Convert.ToInt32(txtN.Text);
                numPanel = Convert.ToInt32(txtNumPanel.Text);
                string[] abcdario = new string[]{"A","B","C","D","E","F","G","H"};

                for (int i = 1; i <= maximo; i++)
                {   for (int j = 1; j <= minimo; j++)
                    {
                        Button boton = new Button();

                        if (numPanel == 6)
                        {

                            if (i == 1 && j == 1 || i == 1 && j == minimo)
                            {
                                boton.Text = ".";


                            }
                            else if (i == 1)
                            {
                                boton.Text = abcdario[j - 2];//j-1
                            }
                            else if (i == 2 && j == 1 || i == 2 && j == minimo || i == 3 && j == minimo
                                    || i == 3 && j == 1 || i == 4 && j == minimo
                                    || i == 4 && j == 1 || i == 5 && j == minimo
                                    || i == 5 && j == 1)
                            {
                                boton.Text = (i - 1).ToString();//i==1
                            }

                            else if (i == maximo && j == minimo || i == maximo && j == 1)
                            {
                                boton.Text = ".";

                            }
                            else if (i == maximo)
                            {
                                boton.Text = abcdario[j - 2];
                            }
                            else
                            {
                                boton.Text = ".";
                            }
                            boton.ID = "btnButon" + (j).ToString();

                            boton.Height = 40;
                            boton.Width = 40;
                            panel1.Controls.Add(boton);
                            panel1.Controls.Add(new LiteralControl(""));
                        }
                    } 





                }

            }

        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
     <asp:Button ID="Button1" runat="server" Width="70px" Height="30px"  Text ="Mostrar" BackColor="Yellow" CommandName="Button1" OnCommand="Button1_Command" />
     <asp:TextBox ID="txtM" runat="server" Width="30px" Height="30px"></asp:TextBox>
     <asp:TextBox ID="txtN" runat="server" Width="30px" Height="30px"></asp:TextBox>
       &nbsp;&nbsp;
        <asp:Label ID="lblPenelito" runat="server" ForeColor="White" Text="Ingrese Numero de Panel"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtNumPanel" runat="server" Height="29px" Width="25px"></asp:TextBox>
       <br />
        <asp:Panel ID="panel1" runat="server" 
       BackColor="GreenYellow" 
       Width="240px" 
       Height="240">
       </asp:Panel> 
       </form>
</body>
</html>
