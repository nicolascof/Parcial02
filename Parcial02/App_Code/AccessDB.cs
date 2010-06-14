using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

public class AccessDB
{
    private OleDbConnection conexion;
    private OleDbCommand command;
    private OleDbDataAdapter dataAdapter;
    private OleDbDataReader dataReader;
    private DataSet dataSet;
    private string stringConexion, stringError, stringSQL;

    private OleDbConnection Conexion
    {
        get { return conexion; }
        set { conexion = value; }
    }

    private OleDbCommand Command
    {
        get { return command; }
        set { command = value; }
    }

    private OleDbDataAdapter DataAdapter
    {
        get { return dataAdapter; }
        set { dataAdapter = value; }
    }

    public OleDbDataReader DataReader
    {
        get { return dataReader; }
        set { dataReader = value; }
    }

    public DataSet DataSet
    {
        get { return dataSet; }
        set { dataSet = value; }
    }

    private string StringConexion
    {
        get { return stringConexion; }
        set { stringConexion = value; }
    }

    public string StringError
    {
        get { return stringError; }
        set { stringError = value; }
    }

    public string StringSQL
    {
        get { return stringSQL; }
        set { stringSQL = value; }
    }

    public AccessDB()
    {
        Conexion = null;
        DataAdapter = null;
        DataReader = null;
        DataSet = null;
        StringConexion = null;
        StringError = null;
    }

    public bool Conectar()
    {
        StringConexion = ConfigurationManager.ConnectionStrings["Local"].ToString();
        try
        {
            Conexion = new OleDbConnection();
            Conexion.ConnectionString = StringConexion;
            Conexion.Open();
        }
        catch ( OleDbException e )
        {
            StringError = e.Message;
            return false;
        }
        return true;
    }

    public bool Cerrar()
    {
        try
        {
            Conexion.Close();
        }
        catch ( OleDbException e )
        {
            StringError = e.Message;
            return false;
        }
        return true;
    }

    public bool Login( string user, string password )
    {
        StringSQL = "SELECT user_id FROM Users WHERE user_name=@user AND user_password=@password;";
        try
        {
            Command = new OleDbCommand();
            Command.CommandType = CommandType.Text;
            Command.Parameters.Add( user, OleDbType.WChar ).Value = user;
            Command.Parameters.Add( password, OleDbType.WChar ).Value = password;
            Command.CommandText = StringSQL;
            Command.Connection = Conexion;

            DataReader = Command.ExecuteReader();
        }
        catch ( OleDbException e )
        {
            StringError = e.Message;
            return false;
        }
        return true;
    }

    public bool Registro( string user, string password )
    {
        StringSQL = "INSERT INTO Users([user_name], [user_password]) VALUES(@user, @password);";
        try
        {
            Command = new OleDbCommand();
            Command.CommandType = CommandType.Text;
            Command.Parameters.Add( user, OleDbType.WChar ).Value = user;
            Command.Parameters.Add( password, OleDbType.WChar ).Value = password;
            Command.CommandText = StringSQL;
            Command.Connection = Conexion;
            Command.ExecuteNonQuery();
        }
        catch ( OleDbException e )
        {
            StringError = e.Message;
            return false;
        }
        finally
        {
            this.Cerrar();
        }
        return true;
    }

    public bool ExisteUsuario( string user )
    {
        StringSQL = "SELECT user_id FROM Users WHERE user_name=@user;";
        try
        {
            Command = new OleDbCommand();
            Command.CommandType = CommandType.Text;
            Command.Parameters.Add( user, OleDbType.WChar ).Value = user;
            Command.CommandText = StringSQL;
            Command.Connection = Conexion;

            DataReader = Command.ExecuteReader();
        }
        catch ( OleDbException e )
        {
            StringError = e.Message;
            return false;
        }
        return true;
    }

    public bool Usuarios()
    {
        StringSQL = "SELECT user_name, user_password FROM Users;";
        try
        {
            Command = new OleDbCommand();
            Command.CommandType = CommandType.Text;
            Command.CommandText = StringSQL;
            Command.Connection = Conexion;

            DataAdapter = new OleDbDataAdapter( Command );
            DataSet = new DataSet();
            DataAdapter.Fill( DataSet, "Users" );
        }
        catch ( OleDbException e )
        {
            StringError = e.Message;
            return false;
        }
        finally
        {
            this.Cerrar();
        }
        return true;
    }

    public bool Consulta()
    {
        StringSQL = "SELECT ... FROM ...;";
        try
        {
            Command = new OleDbCommand();
            Command.CommandType = CommandType.Text;
            Command.CommandText = StringSQL;
            Command.Connection = Conexion;

            DataAdapter = new OleDbDataAdapter( Command );
            DataSet = new DataSet();
            DataAdapter.Fill( DataSet, "..." );
        }
        catch ( OleDbException e )
        {
            StringError = e.Message;
            return false;
        }
        finally
        {
            this.Cerrar();
        }
        return true;
    }   
}