<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
</head>
<body style='font:15px arial,sans-serif;'>
    <form id="frm_Login" runat="server">
        <h2>Login</h2>
        <hr />
        <table>
            <tr>
                <td align="right" style="width: 100px; height: 26px;"><asp:Label ID="lbl_Usuario" runat="server" Text="Usuario"></asp:Label></td>
                <td style="width: 650px; height: 26px;"><asp:TextBox ID="tbx_Usuario" runat="server" MaxLength="25" Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="rfv_Usuario" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="tbx_Usuario" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator
                        ID="cv_Usuario" runat="server" ControlToValidate="tbx_Usuario" Display="Dynamic"
                        ErrorMessage="El usuario debe tener entre 5 y 25 caracteres" OnServerValidate="cv_Usuario_ServerValidate"
                        SetFocusOnError="True"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 26px;"><asp:Label ID="lbl_Password" runat="server" Text="Password"></asp:Label></td>
                <td style="width: 650px; height: 26px;"><asp:TextBox ID="tbx_Password" runat="server" MaxLength="30" Width="200px" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="rfv_Password" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="tbx_Password" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator
                        ID="cv_Password" runat="server" ControlToValidate="tbx_Password" Display="Dynamic"
                        ErrorMessage="El password debe tener entre 5 y 30 caracteres" OnServerValidate="cv_Password_ServerValidate"
                        SetFocusOnError="True"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="width: 100px"></td>
                <td style="width: 650px"><asp:Button ID="btn_Ingresar" runat="server" Text="Ingresar" Width="80px" OnClick="btn_Ingresar_Click" /></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px;"><asp:LinkButton ID="lbtn_Registrarse" runat="server" OnClick="lbtn_Registrarse_Click" CausesValidation="False">Registrarse</asp:LinkButton></td>
                <td style="width: 650px; color: Red; height: 21px;"><asp:Label ID="lbl_Error" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gv_Usuarios" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="user_name" HeaderText="Name" />
                <asp:BoundField DataField="user_password" HeaderText="Password" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>