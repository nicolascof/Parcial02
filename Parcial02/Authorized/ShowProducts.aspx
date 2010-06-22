<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Authorized/Main.master" CodeFile="ShowProducts.aspx.cs" Inherits="Authorized_ShowProducts" Title="ShowProducts" %>

<asp:Content ID="ctn_VerProductos" ContentPlaceHolderID="cph_Main" Runat="Server">
    <asp:GridView ID="gv_Productos" runat="server"></asp:GridView>
</asp:Content>