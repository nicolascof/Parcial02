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
    public string VerificarUsuario( string usuario, string password )
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
                    return cxnDB.StringError;
                }
            }
            else
            {
                stringM = cxnDB.StringError;
            }
        }
        return stringM;
    }
}