<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pedidos.aspx.cs" Inherits="integradorRestaurante.pedidos1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        PEDIDOS</p>
    <p>
        <asp:Label ID="mesanje" runat="server" 
            Font-Size="Medium" ForeColor="Red"></asp:Label>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp; Mesas ocupadas | Categoria platos</p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;<asp:DropDownList ID="ddmesas" runat="server" Height="19px" Width="85px" 
            AutoPostBack="True" onselectedindexchanged="ddmesas_SelectedIndexChanged">
            <asp:ListItem>Mesas Ocu.</asp:ListItem>
        </asp:DropDownList>
&nbsp;
        <asp:DropDownList ID="cmbcategoria" runat="server" Height="21px" 
            onselectedindexchanged="cmbcategoria_SelectedIndexChanged" 
            style="margin-left: 9px" Width="102px" AutoPostBack="True">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:ListBox ID="platosXca" runat="server" Height="178px" 
             
            style="margin-left: 28px; margin-top: 0px;" Width="285px"></asp:ListBox>
        &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Height="35px" 
            style="margin-left: 17px; margin-bottom: 66px; top: 282px; left: 319px;" Text="Agregar &gt;&gt;" 
            Width="98px" onclick="Button1_Click" />
        &nbsp;
&nbsp;<asp:Button ID="Button3" runat="server" Height="23px" onclick="Button3_Click" 
            Text="&lt;" Width="50px" />
        <asp:Label ID="cant" runat="server" Font-Size="Large" ForeColor="Black"></asp:Label>
        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="&gt;" 
            Height="24px" Width="45px" />
        <asp:Button ID="Button2" runat="server" Height="32px" 
            style="margin-left: 1px; margin-bottom: 67px" Text="&lt;&lt; Quitar" 
            Width="92px" onclick="Button2_Click" />
        <asp:ListBox ID="cmbPlatos" runat="server" Height="179px" 
            style="margin-left: 50px" Width="188px"></asp:ListBox>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="Button5" runat="server" Height="36px" onclick="Button5_Click" 
            Text="Confirmar" Width="102px" />
    </p>
    <p>
    </p>
</asp:Content>
