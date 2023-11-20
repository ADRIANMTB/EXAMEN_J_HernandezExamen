<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="J_HernandezExamen.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
    <h1>Usuarios</h1>
</div>
 <div class="container text-center">
    <asp:GridView ID="datagrid" runat="server"></asp:GridView>
</div>
<div class="container text-center">
    <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" />
    <asp:Button ID="Button2" class="btn btn-outline-secondary" runat="server" Text="Borrar" />
    <asp:Button ID="Button3" runat="server" class="btn btn-outline-danger" Text="Modificar" />
    <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-danger" Text="Consultar" />
</div>
 

</asp:Content>
