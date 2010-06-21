using System;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using localhostUser;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load( object sender, EventArgs e )
    { }

    protected void btn_Registrar_Click( object sender, EventArgs e )
    {
        string stringM;
        User userWS;

        if ( Page.IsValid )
        {
            userWS = new User();

            stringM = userWS.RegistrarUsuario( tbx_Usuario.Text, tbx_Password.Text, tbx_Email.Text );

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