<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Authorized/Main.master" CodeFile="ShowProducts.aspx.cs" Inherits="Authorized_ShowProducts" Title="ShowProducts" %>

<asp:Content ID="ctn_VerProductos" ContentPlaceHolderID="cph_Main" Runat="Server">
    <asp:TextBox ID="tbx_Buscar" runat="server"></asp:TextBox><asp:Button ID="btn_Buscar" runat="server" Text="Buscar" OnClick="btn_Buscar_Click" />
    <asp:Label ID="lbl_Info" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <asp:GridView ID="gv_Productos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="ID" />
            <asp:BoundField DataField="CategoryId" HeaderText="Category" />
            <asp:BoundField DataField="ProductName" HeaderText="Name" />
            <asp:BoundField DataField="ProductTotal" HeaderText="Total" />
            <asp:BoundField DataField="ProductPrice" HeaderText="Price" />
        </Columns>
    </asp:GridView>
</asp:Content>