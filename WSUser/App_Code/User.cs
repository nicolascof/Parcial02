using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService( Namespace = "http://aspspider.info/nicolascof/parcial02/" )]
[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
public class User : System.Web.Services.WebService
{
    public User()
    {
        // Constructor
    }

    [WebMethod]
    public string IngresoUsuario( string usuario, string password )
    {
        string stringM = null;
        AccessDB cxnDB = new AccessDB();

        if ( String.IsNullOrEmpty( usuario ) || String.IsNullOrEmpty( password ) )
        {
            stringM = "Falta ingresar datos";
        }
        else if ( ( usuario.Length < 5 || usuario.Length > 25 )
            && ( password.Length < 5 || password.Length > 30 ) )
        {
            stringM = "Longitud de caracteres incorrecto";
        }
        else
        {
            if ( cxnDB.Conectar() )
            {
                if ( cxnDB.Login( usuario, password ) )
                {
                    if ( cxnDB.DataReader.Read() )
                    {
                        stringM = "true";
                    }
                    else
                    {
                        stringM = "false";
                    }
                    cxnDB.Cerrar();
                }
                else
                {
                    stringM = cxnDB.StringError;
                }
            }
            else
            {
                stringM = cxnDB.StringError;
            }
        }
        return stringM;
    }

    [WebMethod]
    public string RegistrarUsuario( string usuario, string password, string email )
    {
        string stringM = null;
        AccessDB cxnDB = new AccessDB();

        if ( String.IsNullOrEmpty( usuario ) || String.IsNullOrEmpty( password )
            || String.IsNullOrEmpty( email ) )
        {
            stringM = "Falta ingresar datos";
        }
        else if ( ( usuario.Length < 5 || usuario.Length > 25 )
            && ( password.Length < 5 || password.Length > 30 ) )
        {
            stringM = "Longitud de caracteres incorrecto";
        }
        else
        {
            if ( cxnDB.Conectar() )
            {
                if ( cxnDB.ExisteUsuario( usuario ) )
                {
                    if ( !cxnDB.DataReader.Read() )
                    {
                        Mail oM = new Mail();
                        oM.EmailDestino = email;
                        oM.Asunto = "Registro";
                        oM.CuerpoMensaje = String.Format( "Bienvenido {0}, ¡Gracias por registrarse!<br /><br />"
                            + "<i>Usuario:</i> <b>{0}</b><br /><i>Password:</i> <b>{1}</b><br /><br />"
                            + "Visite <a href='http://aspspider.info/nicolascof/Login.aspx' target='_blank'>ASP.Net-Test</a>",
                            usuario, password );

                        if ( oM.Enviar() )
                        {
                            if ( cxnDB.Registro( usuario, password, email ) )
                            {
                                cxnDB.Cerrar();
                                stringM = "true";
                            }
                            else
                            {
                                stringM = cxnDB.StringError;
                            }
                        }
                        else
                        {
                            stringM = oM.StringError;
                        }
                    }
                    else
                    {
                        stringM = "Nombre de usuario no disponible";
                    }
                }
                else
                {
                    stringM = cxnDB.StringError;
                }
                cxnDB.Cerrar();
            }
            else
            {
                stringM = cxnDB.StringError;
            } 
        }
        return stringM;
    }
}