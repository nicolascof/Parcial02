using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services.Description;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load( object sender, EventArgs e )
    {
        localhostUser.User userWS = new localhostUser.User();
        localhostUser.Usuario[] listUsuario = userWS.MostrarUsuarios();

        gv_Usuarios.DataSource = listUsuario;
        gv_Usuarios.DataBind();
    }

    protected void btn_Ingresar_Click( object sender, EventArgs e )
    {
        string stringM;
        localhostUser.User userWS;
        localhostUser.Usuario usuario;

        if ( Page.IsValid )
        {
            userWS = new localhostUser.User();

            usuario = new localhostUser.Usuario();
            usuario.UserName = tbx_Usuario.Text;
            usuario.UserPassword = tbx_Password.Text; 

            stringM = userWS.IngresoUsuario( usuario );

            if ( stringM.Equals( "true" ) )
            {
                this.Server.Transfer( "~/Authorized/ShowProducts.aspx" ); // necesario para usar Page.PreviousPage
            }
            else if ( stringM.Equals( "false" ) )
            {
                lbl_Error.Text = "Usuario no registrado";
                tbx_Usuario.Text = "";
                tbx_Password.Text = "";
                tbx_Usuario.Focus();
            }
            else
            {
                lbl_Error.Text = stringM;
                tbx_Usuario.Focus();
            }
        }
    }

    protected void lbtn_Registrarse_Click( object sender, EventArgs e )
    {
        this.Response.Redirect( "Register.aspx" );
    }

    protected void cv_Usuario_ServerValidate( object source, ServerValidateEventArgs args )
    {
        if ( args.Value.Length < 5 || args.Value.Length > 25 )
            args.IsValid = false;
        else
            args.IsValid = true;
    }

    protected void cv_Password_ServerValidate( object source, ServerValidateEventArgs args )
    {
        if ( args.Value.Length < 5 || args.Value.Length > 30 )
            args.IsValid = false;
        else
            args.IsValid = true;
    }
}