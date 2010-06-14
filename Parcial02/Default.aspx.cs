using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services.Description;
using localhost;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if ( Mail.exitoRegistro )
        {
            lbl_Error.Text = "Se ha registrado con exito, sus datos han sido enviado por mail.";
            Mail.exitoRegistro = false;
        }

        AccessDB cxnDB = new AccessDB();
        if ( cxnDB.Conectar() )
        {
            if ( cxnDB.Usuarios() )
            {
                gv_Usuarios.DataSource = cxnDB.DataSet.Tables["Users"];
                gv_Usuarios.DataBind();
            }
            cxnDB.Cerrar();
        }
    }

    protected void btn_Ingresar_Click( object sender, EventArgs e )
    {
        string stringM;
        User userWS;

        if ( Page.IsValid )
        {
            userWS = new User();
            
            stringM = userWS.VerificarUsuario( tbx_Usuario.Text, tbx_Password.Text );

            if ( stringM.Equals( "true" ) )
            {
                this.Server.Transfer( "Productos.aspx" ); // necesario para usar Page.PreviousPage
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
        this.Response.Redirect( "Registro.aspx" );
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