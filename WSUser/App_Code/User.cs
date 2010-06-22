using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService( Namespace = "http://null/parcial02/" )]
[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
public class User : System.Web.Services.WebService
{
    #region Variables
    private AccessDB cxnDB;
    #endregion

    #region Constructores
    public User()
    {
        cxnDB = AccessDB.Instance;
    }
    #endregion

    #region WebMethods
    [WebMethod]
    public string IngresoUsuario( Usuario usuario )
    {
        string stringM = null;
        
        /*if ( String.IsNullOrEmpty( usuario.UserName ) 
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
        }*/
        A a = new A( usuario.UserPassword );
        if ( !a.checkPassword() )
            stringM = "Falta ingresar datos o longitud incorrecta";
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
    public string IngresoUsuarioTest( string usuario, string password )
    {
        string stringM = null;

        /*if ( String.IsNullOrEmpty( usuario.UserName ) 
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
        }*/
        A a = new A( password );
        if ( !a.checkPassword() )
            stringM = "Falta ingresar datos o longitud incorrecta";
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
    public string RegistrarUsuario( Usuario usuario )
    {
        string stringM = null;

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

    [WebMethod]
    public List<Usuario> MostrarUsuarios()
    {
        List<Usuario> listUsuario = new List<Usuario>();

        cxnDB.Conectar();
        cxnDB.MostrarUsuarios();

        int tamR = cxnDB.DataSet.Tables["Users"].Rows.Count;
        for ( int i = 0; i < tamR; ++i )
        {
            Usuario usuario = new Usuario();
            usuario.UserId = Convert.ToInt32( cxnDB.DataSet.Tables["Users"].Rows[i]["user_id"] );
            usuario.UserName = Convert.ToString( cxnDB.DataSet.Tables["Users"].Rows[i]["user_name"] );
            usuario.UserPassword = Convert.ToString( cxnDB.DataSet.Tables["Users"].Rows[i]["user_password"] );
            usuario.UserEmail = Convert.ToString( cxnDB.DataSet.Tables["Users"].Rows[i]["user_email"] );
            listUsuario.Add( usuario );
        }

        return listUsuario;
    }
    #endregion

    #region Chain of Responsibility
    public abstract class Password
    {
        //string password;
        abstract public bool checkPassword();
    }

    public class A : Password
    {
        string password = "";

        public A( string password )
        {
            this.password = password;
            checkPassword();
        }

        public override bool checkPassword()
        {
            if ( !String.IsNullOrEmpty( password ) )
            {
                B b = new B( password );//Next Chain
                return b.checkPassword();
            }
            else
            {
                return false;
            }
        }
    }

    public class B : Password
    {
        string password = "";

        public B( string password )
        {
            this.password = password;
            checkPassword();
        }

        public override bool checkPassword()
        {
            if ( password.Length > 5 )
            {
                C c = new C( password );//Next Chain
                return c.checkPassword();
            }
            else
            {
                return false;
            }
        }
    }

    public class C : Password
    {
        string password = "";

        public C( string password )
        {
            this.password = password;
            checkPassword();
        }

        public override bool checkPassword()
        {
            if ( password.Length < 30 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
}