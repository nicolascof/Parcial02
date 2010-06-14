using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Registro : System.Web.UI.Page
{
    protected void Page_Load( object sender, EventArgs e )
    {
        
    }

    protected void btn_Registrar_Click( object sender, EventArgs e )
    {

        if ( Page.IsValid )
        {
            AccessDB CxnDB = new AccessDB();

            if ( CxnDB.Conectar() )
            {
                if ( CxnDB.ExisteUsuario( tbx_Usuario.Text ) )
                {
                    if ( !CxnDB.DataReader.Read() )
                    {
                        Mail oM = new Mail();
                        oM.EmailDestino = tbx_Email.Text;
                        oM.Asunto = "Registro";
                        oM.CuerpoMensaje = String.Format( "Bienvenido {0}, ¡Gracias por registrarse!<br /><br />"
                            + "<i>Usuario:</i> <b>{0}</b><br /><i>Password:</i> <b>{1}</b><br /><br />"
                            + "Visite <a href='http://aspspider.info/nicolascof/Login.aspx' target='_blank'>ASP.Net-Test</a>",
                            tbx_Usuario.Text, tbx_Password.Text );

                        if ( oM.Enviar() )
                        {
                            if ( CxnDB.Registro( tbx_Usuario.Text, tbx_Password.Text ) )
                            {
                                CxnDB.Cerrar();
                                this.Response.Redirect( "Default.aspx" ); 
                            }
                            else
                            {
                                lbl_Error.Text = CxnDB.StringError;
                                tbx_Usuario.Text = "";
                                tbx_Usuario.Focus();
                            }
                        }
                        else
                        {
                            lbl_Error.Text = oM.StringError;
                            tbx_Email.Text = "";
                            tbx_Password.Focus();
                        }
                    }
                    else
                    {
                        lbl_Error.Text = "Nombre de usuario no disponible";
                        tbx_Usuario.Text = "";
                        tbx_Usuario.Focus();
                    }
                }
                else
                {
                    lbl_Error.Text = CxnDB.StringError;
                    tbx_Usuario.Focus();
                }
                CxnDB.Cerrar();
            }
            else
            {
                lbl_Error.Text = CxnDB.StringError;
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