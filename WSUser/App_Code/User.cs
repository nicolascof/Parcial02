using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService( Namespace = "http://null/parcial02/" )]
[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
public class User : System.Web.Services.WebService
{
    public User()
    { }

    [WebMethod]
    public string IngresoUsuario( Usuario usuario )
    {
        string stringM = null;
        AccessDB cxnDB = new AccessDB();

        if ( String.IsNullOrEmpty( usuario.UserName ) 
            || String.IsNullOrEmpty( usuario.UserPassword ) )
        {
            stringM = "Falta ingresar datos";
        }
        else if ( usuario.UserName.Length < 5 || usuario.UserName.Length > 25 )
        {
            stringM = "Usuario: Longitud de caracteres incorrecto";
        }
        else if ( usuario.UserPassword.Length < 5 || usuario.UserPassword.Length > 30 )
        {
            stringM = "Password: Longitud de caracteres incorrecto";
        }
        else
        {
            if ( cxnDB.Conectar() )
            {
                if ( cxnDB.Login( usuario.UserName, usuario.UserPassword ) )
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
    public string RegistrarUsuario( Usuario usuario )
    {
        string stringM = null;
        AccessDB cxnDB = new AccessDB();

        if ( String.IsNullOrEmpty( usuario.UserName ) 
            || String.IsNullOrEmpty( usuario.UserPassword )
            || String.IsNullOrEmpty( usuario.UserEmail ) )
        {
            stringM = "Falta ingresar datos";
        }
        else if ( usuario.UserName.Length < 5 || usuario.UserName.Length > 25 )
        {
            stringM = "Usuario: Longitud de caracteres incorrecto";
        }
        else if ( usuario.UserPassword.Length < 5 || usuario.UserPassword.Length > 30 )
        {
            stringM = "Password: Longitud de caracteres incorrecto";
        }
        else
        {
            if ( cxnDB.Conectar() )
            {
                if ( cxnDB.ExisteUsuario( usuario.UserName ) )
                {
                    if ( !cxnDB.DataReader.Read() )
                    {
                        Mail oM = new Mail();
                        oM.EmailDestino = usuario.UserEmail;
                        oM.Asunto = "Registro";
                        oM.CuerpoMensaje = String.Format( "Bienvenido {0}, ¡Gracias por registrarse!<br /><br />"
                            + "<i>Usuario:</i> <b>{0}</b><br /><i>Password:</i> <b>{1}</b><br /><br />"
                            + "Visite <a href='http://null' target='_blank'>Parcial02</a>",
                            usuario.UserName, usuario.UserPassword );

                        if ( oM.Enviar() )
                        {
                            if ( cxnDB.Registro( usuario.UserEmail, usuario.UserPassword, usuario.UserEmail ) )
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