using System;
using System.Net.Mail;

public class Mail
{
    private MailMessage Correo;
    private SmtpClient Smtp;
    private string emailOrigen,
        nombreOrigen,
        emailDestino,
        asunto,
        cuerpoMensaje,
        host,
        usuario,
        password,
        stringError;
    private int puerto;
    private bool sslHabilitado;
    public static bool exitoRegistro = false;

    public string EmailOrigen
    {
        set { emailOrigen = value; }
        get { return emailOrigen; }
    }

    public string NombreOrigen
    {
        set { nombreOrigen = value; }
        get { return nombreOrigen; }
    }

    public string EmailDestino
    {
        set { emailDestino = value; }
        get { return emailDestino; }
    }

    public string Asunto
    {
        set { asunto = value; }
        get { return asunto; }
    }

    public string CuerpoMensaje
    {
        set { cuerpoMensaje = value; }
        get { return cuerpoMensaje; }
    }

    public string Host
    {
        set { host = value; }
        get { return host; }
    }

    public int Puerto
    {
        set { puerto = value; }
        get { return puerto; }
    }

    public bool SslHabilitado
    {
        set { sslHabilitado = value; }
        get { return sslHabilitado; }
    }

    public string Usuario
    {
        set { usuario = value; }
        get { return usuario; }
    }

    public string Password
    {
        set { password = value; }
        get { return password; }
    }

    public string StringError
    {
        set { stringError = value; }
        get { return stringError; }
    }

    public Mail()
    {
        Correo = new MailMessage();
        Smtp = new SmtpClient();

        EmailOrigen = "nicolascba88@gmail.com";
        NombreOrigen = "Admin";
        EmailDestino = null;
        Asunto = null;
        CuerpoMensaje = null;

        Host = "smtp.gmail.com";
        Puerto = 587;
        SslHabilitado = true;
        Usuario = "nicolascba88@gmail.com";
        Password = "";
    }

    public bool Enviar()
    {
        try
        {
            Correo.From = new MailAddress( EmailOrigen, NombreOrigen );
            Correo.To.Add( EmailDestino );
            Correo.Subject = Asunto;
            Correo.Body = CuerpoMensaje;
            Correo.BodyEncoding = System.Text.Encoding.UTF8;
            Correo.Priority = System.Net.Mail.MailPriority.Normal;
            Correo.IsBodyHtml = true;

            Smtp.Host = Host;
            Smtp.Port = Puerto;
            Smtp.EnableSsl = SslHabilitado;
            Smtp.Credentials = new System.Net.NetworkCredential( Usuario, Password );

            Smtp.Send( Correo );

            return !exitoRegistro;
        }
        catch ( Exception e )
        {
            StringError = e.Message;
            return exitoRegistro;
        }
    }
}