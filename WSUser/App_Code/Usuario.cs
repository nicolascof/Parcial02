using System;

public class Usuario
{
    #region Variables
    private int userId;
    private string userName;
    private string userPassword;
    private string userEmail;
    #endregion

    #region Propiedades
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
    #endregion

    #region Constructores
    public Usuario()
    {
        UserId = 0;
        UserName = null;
        UserPassword = null;
        UserEmail = null;
    }
    #endregion
}