<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="regMesas.aspx.cs" Inherits="integradorRestaurante.regMesas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="Green"></asp:Label>
</p>
    <p>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:Button ID="Button9" runat="server" Text="Agregar" onclick="Button9_Click" />
&nbsp;<asp:Label ID="Label2" runat="server" ForeColor="Black" Text="Capacidad" 
            Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="txtcap" runat="server" Visible="False" Height="23px" 
            ontextchanged="txtcap_TextChanged" Width="50px"></asp:TextBox>
&nbsp;<asp:Button ID="elim" runat="server" Font-Bold="True" ForeColor="Red" 
            onclick="elim_Click" Text="Eliminar" Visible="False" />
        &nbsp;
    <asp:Button ID="Button10" runat="server" Text="Listar mesas ocupadas" 
            onclick="Button10_Click" />
&nbsp;
    <asp:Button ID="Button11" runat="server" Text="Listar mesas reservadas" 
            onclick="Button11_Click" />
&nbsp;&nbsp;
    <asp:Button ID="Button12" runat="server" Text="Listar mesas libres" 
            onclick="Button12_Click" />
</p>
    <p>
        &nbsp;</p>
<p>
    <asp:GridView ID="GridView1" runat="server" style="margin-left: 388px" 
        AutoGenerateSelectButton="True" CellPadding="3" CellSpacing="1" 
        GridLines="Horizontal" onselectedindexchanged="GridView1_SelectedIndexChanged">
        <HeaderStyle BackColor="#6699FF" />
        <SelectedRowStyle BackColor="#0099CC" />
    </asp:GridView>
</p>
</asp:Content>
