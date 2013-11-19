<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="personal.aspx.cs" Inherits="integradorRestaurante.personal1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="mensaje" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Cedula
        <asp:TextBox ID="txtci" runat="server" Height="25px" Width="97px"></asp:TextBox>
&nbsp; Nombre<asp:TextBox ID="txtnom" runat="server" Height="29px" Width="95px"></asp:TextBox>
&nbsp; Apellido<asp:TextBox ID="txtape" runat="server" Height="27px" Width="84px"></asp:TextBox>
&nbsp;
    Direccion
        <asp:TextBox ID="txtdir" runat="server" Height="26px" 
            style="margin-bottom: 0px" Width="88px"></asp:TextBox>
        Tel
        <asp:TextBox ID="txttel" runat="server" Height="26px" Width="87px"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Rol 
        <asp:DropDownList ID="ddlcajero" runat="server" Height="20px">
            <asp:ListItem>cajero</asp:ListItem>
            <asp:ListItem>gerente</asp:ListItem>
            <asp:ListItem>mozo</asp:ListItem>
            <asp:ListItem>recepcionista</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button9" runat="server" onclick="Button9_Click" 
            Text="Guardar" />
&nbsp;
&nbsp;
        <asp:Button ID="Button10" runat="server" Text="Modificar" 
            onclick="Button10_Click" />
&nbsp;
&nbsp;
        <asp:DropDownList ID="ddlmodif" runat="server" Visible="False" 
            AutoPostBack="True" Height="26px" 
            onselectedindexchanged="ddlmodif_SelectedIndexChanged" Width="125px">
        </asp:DropDownList>
&nbsp;
        <asp:Button ID="Button11" runat="server" Text="Dar baja" 
            onclick="Button11_Click" />
    </p>
    <p>
    </p>
</asp:Content>
