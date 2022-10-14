<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaPrincipala.aspx.cs" Inherits="Agenda_de_activitati___Proiect.PaginaPrincipala" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agenda de activitati</title>
    <style type="text/css">
        #form1 {
            height: 1134px;
        }
        .auto-style1 {
            text-align: center;
        }
        .auto-style4 {
            width: 225px;
            text-align: center;
        }
        .auto-style5 {
            width: 48%;
            background-color: #4D4DE8;
            height: 92px;
        }
        .auto-style6 {
            width: 325px;
            text-align: center;
        }
        .auto-style7 {
            width: 397px;
            text-align: center;
        }
        .auto-style9 {
            width: 267px;
            text-align: center;
        }
        .auto-style10 {
            margin-left: 75px;
            margin-right: 0px;
        }
        .auto-style11 {
            width: 364px;
        }
        .auto-style12 {
            width: 387px;
        }
        .auto-style13 {
            width: 58px;
            height: 119px;
        }
        .auto-style14 {
            margin-left: 0px;
        }
        .auto-style15 {
            width: 192px;
            text-align: center;
        }
    </style>
</head>
<body style="background:#cfd6e5">
   
    <form id="form1" runat="server">
            <div class="auto-style13">
    <h5 style="margin: auto auto auto 500px; align-self:center; font-family: 'Arial Black'; font-size: xx-large;" class="auto-style11">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Chanos.art</h5>
                <h5 style="margin: auto auto auto 500px; align-self:center; font-family: 'Arial Black'; font-size: xx-large;" class="auto-style12">- Articole handmade -</h5>
                <h5 style="margin: auto auto auto 500px; align-self:center; font-family: 'Arial Black'; font-size: xx-large;" class="auto-style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Image ID="Image1" runat="server" CssClass="auto-style14" Height="27px" ImageUrl="~/Poze/user.png" Width="28px" />
&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                </h5>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:Panel ID="Panel1" runat="server" Height="1093px" style="margin-left: 28px;">
                <br />
                <table class="auto-style5">
                    <tr>
                        <td class="auto-style15">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btnUtiliz" runat="server" Height="58px" ImageUrl="~/Poze/question.png" OnClick="btnUtiliz_Click" Width="79px" />
                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Small" Text="Deconectare"></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:ImageButton ID="btnAdd" runat="server" Height="61px" ImageUrl="~/Poze/sticker.png" OnClick="btnAdd_Click" Width="74px" />
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Small" Text="Adauga"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:ImageButton ID="btnCateg" runat="server" Height="61px" ImageUrl="~/Poze/categories.png" OnClick="btnCateg_Click" Width="74px" />
                            <br />
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Small" Text="Tip Produs"></asp:Label>
                        </td>
                        <td class="auto-style9">
                            <asp:ImageButton ID="btnEditDel" runat="server" Height="60px" ImageUrl="~/Poze/EditDel.png" OnClick="btnEditDel_Click" Width="69px" />
                            <br />
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Small" Text="Editare/Stergere"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:ImageButton ID="btnCos" runat="server" Height="60px" ImageUrl="~/Poze/trolley.png" OnClick="btnCos_Click" Width="69px" />
                            <br />
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Small" Text="Cumparaturi"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Large" ForeColor="Black" Text="Selecteaza tipul produsului:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="tip_produs" DataValueField="tip_produs" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MagazinVirtualDBConnectionString %>" SelectCommand="SELECT [tip_produs] FROM [Tip_produse]"></asp:SqlDataSource>
                <br />
                <asp:Label ID="id_tip" runat="server" Text="Label" Visible="False"></asp:Label>
                <br />
                <br />
                &nbsp;<table style="width:100%;">
                    <tr>
                        <td style="text-align: center; font-weight: 700; font-size: large">LISTA PRODUSE </td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div class="auto-style1">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Height="256px" OnRowDeleted="GridView2_RowDeleted" Width="1200px" CssClass="auto-style10" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="Gainsboro" />
                        <Columns>
                            <asp:BoundField DataField="Id_produs" HeaderText="Id Produs" />
                            <asp:BoundField DataField="Denumire_produs" HeaderText="Denumire produs" />
                            <asp:TemplateField HeaderText="Imagine">
                                <ItemTemplate>
                                    <img src="Poze/<%#Eval("Imagine") %>" style="width:300px;height:320px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Pret" HeaderText="Pret">
                            <ControlStyle Width="100px" />
                            <FooterStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Descriere" HeaderText="Descriere" />
                            <asp:CommandField ButtonType="Image" HeaderText="Adauga in cos" SelectImageUrl="~/Poze/carts.png" ShowSelectButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>
                </div>
                &nbsp;&nbsp;&nbsp;<br />
                <br />
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MagazinVirtualDBConnectionString %>" SelectCommand="SELECT * FROM [Produse] WHERE ([Id_tip_produs] = @Id_tip_produs)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="id_tip" Name="Id_tip_produs" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            </asp:Panel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
    </form>
</body>
</html>
