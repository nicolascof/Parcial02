using System;

/**
* Tabla Users: user_id, user_name, user_password, user_email
*/
public class Usuario
{
    private int userId;
    private string userName;
    private string userPassword;
    private string userEmail;

    public int UserId
    {
        get { return userId; }
        set { userId = value; }
    }

    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }

    public string UserPassword
    {
        get { return userPassword; }
        set { userPassword = value; }
    }

    public string UserEmail
    {
        get { return userEmail; }
        set { userEmail = value; }
    }

    public Usuario()
    {
        UserId = 0;
        UserName = null;
        UserPassword = null;
        UserEmail = null;
    }

    public Usuario( int userId, string userName, string userPassword, string userEmail )
    {
        UserId = userId;
        UserName = userName;
        UserPassword = userPassword;
        UserEmail = userEmail;
    }
}