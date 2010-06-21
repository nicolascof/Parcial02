using System;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load( object sender, EventArgs e )
    { }

    protected void btn_Registrar_Click( object sender, EventArgs e )
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
            usuario.UserEmail = tbx_Email.Text;

            stringM = userWS.RegistrarUsuario( usuario );

            if ( stringM.Equals( "true" ) )
            {
                this.Response.Redirect( "Default.aspx" );
            }
            else
            {
                lbl_Error.Text = stringM;
                tbx_Usuario.Focus();
            }
        }
    }

    protected void lbtn_Login_Click( object sender, EventArgs e )
    {
        this.Response.Redirect( "Default.aspx" );
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