<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="J_HernandezExamen.Equipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
    <h1>Equipos</h1>
</div>
    <div class="container text-center">
    <asp:GridView ID="datagrid" Class="mydatagrid" runat="server"></asp:GridView>

</div>
<div class="container text-center">
    <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" />
    <asp:Button ID="Button2" class="btn btn-outline-secondary" runat="server" Text="Borrar" />
    <asp:Button ID="Button3" runat="server" class="btn btn-outline-danger" Text="Modificar" />
    <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-danger" Text="Consultar" />
    <asp:TextBox ID="tcodigo" runat="server"></asp:TextBox>
    <asp:TextBox ID="tdescripcion" runat="server"></asp:TextBox>
</div>

</asp:Content>
