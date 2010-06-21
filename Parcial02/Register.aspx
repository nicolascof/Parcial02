<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Registro</title>
</head>
<body style='font:15px arial,sans-serif;'>
    <form id="frm_Registro" runat="server">
        <h2>Registro</h2>
        <hr />
        <table>
            <tr>
                <td align="right" style="width: 150px"><asp:Label ID="lbl_Usuario" runat="server" Text="Usuario"></asp:Label></td>
                <td style="width: 650px"><asp:TextBox ID="tbx_Usuario" runat="server" MaxLength="25" Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="tbx_Usuario" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator
                        ID="cv_Usuario" runat="server" ControlToValidate="tbx_Usuario" Display="Dynamic"
                        ErrorMessage="El usuario debe tener entre 5 y 25 caracteres" OnServerValidate="cv_Usuario_ServerValidate"
                        SetFocusOnError="True"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 150px"><asp:Label ID="lbl_Password" runat="server" Text="Password"></asp:Label></td>
                <td style="width: 650px"><asp:TextBox ID="tbx_Password" runat="server" MaxLength="30" Width="200px" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="tbx_Password" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator
                        ID="cv_Password" runat="server" ControlToValidate="tbx_Password" Display="Dynamic"
                        ErrorMessage="El password debe tener entre 5 y 30 caracteres" OnServerValidate="cv_Password_ServerValidate"
                        SetFocusOnError="True"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 150px">
                    <asp:Label ID="lbl_CPassword" runat="server" Text="Confirmar Password"></asp:Label></td>
                <td style="width: 650px">
                    <asp:TextBox ID="tbx_CPassword" runat="server" MaxLength="30" TextMode="Password"
                        Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="rfv_CPassword" runat="server"
                            ControlToValidate="tbx_CPassword" Display="Dynamic" ErrorMessage="Campo obligatorio"
                            SetFocusOnError="True"></asp:RequiredFieldValidator><asp:CompareValidator ID="cmpv_CPassword"
                                runat="server" ControlToCompare="tbx_Password" ControlToValidate="tbx_CPassword"
                                Display="Dynamic" ErrorMessage="Las password's deben coincidir" SetFocusOnError="True"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 150px"><asp:Label ID="lbl_Email" runat="server" Text="e-mail"></asp:Label></td>
                <td style="width: 650px"><asp:TextBox ID="tbx_Email" runat="server" MaxLength="30" Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="tbx_Email" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                        ID="rev_Email" runat="server" ControlToValidate="tbx_Email" Display="Dynamic"
                        ErrorMessage="Debe ingresar un e-mail válido" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 150px"></td>
                <td style="width: 650px"><asp:Button ID="btn_Registrar" runat="server" Text="Registrar" OnClick="btn_Registrar_Click" Width="80px" /></td>
            </tr>
            <tr>
                <td style="width: 150px"><asp:LinkButton ID="lbtn_Login" runat="server" OnClick="lbtn_Login_Click" CausesValidation="False">Login</asp:LinkButton></td>
                <td style="width: 650px; color: Red"><asp:Label ID="lbl_Error" runat="server"></asp:Label></td>
            </tr>
        </table>
    </form>
</body>
</html>