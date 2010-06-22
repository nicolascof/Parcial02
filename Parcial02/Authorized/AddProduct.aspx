<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Authorized/Main.master" CodeFile="AddProduct.aspx.cs" Inherits="Authorized_AddProduct"  Title="AddProduct" %>

<asp:Content ID="ctn_AgregarProducto" ContentPlaceHolderID="cph_Main" Runat="Server">
    <table>
        <tr>
            <td align="right" style="width: 100px; height: 26px;"><asp:Label ID="lbl_Categoria" runat="server" Text="Categoria"></asp:Label></td>
            <td style="width: 650px; height: 26px;"><asp:DropDownList ID="ddl_Categoria" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; height: 26px;"><asp:Label ID="lbl_ProductName" runat="server" Text="Nombre"></asp:Label></td>
            <td style="width: 650px; height: 26px;"><asp:TextBox ID="tbx_ProductName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; height: 26px;"><asp:Label ID="lbl_ProductTotal" runat="server" Text="Total"></asp:Label></td>
            <td style="width: 650px; height: 26px;"><asp:TextBox ID="tbx_ProductTotal" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; height: 26px;"><asp:Label ID="lbl_ProductPrice" runat="server" Text="Precio"></asp:Label></td>
            <td style="width: 650px; height: 26px;"><asp:TextBox ID="tbx_ProductPrice" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; height: 26px;"></td>
            <td style="width: 650px; height: 26px;"><asp:Button ID="btn_Agregar" runat="server" Text="Agregar" OnClick="btn_Agregar_Click" /></td>
        </tr>
    </table>
</asp:Content>