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

    /**
     * Tabla Products: product_id, category_id, product_name, product_total, product_price
     * Tabla Category: category_id, category_name, category_active
     */
    public void CrearProducto()
    { }

    public void BuscarProductos()
    { }

    public void GuardarProductos()
    { }

    public void BorrarProducto()
    { }

    public bool MostrarProductos()
    {
        /*StringSQL = "SELECT C.category_name AS Categoria, P.product_name AS Producto, "
                + "P.product_total AS Cantidad, P.product_price AS Precio "
                + "FROM Categories AS C INNER JOIN Products AS P ON C.category_id = P.category_id;";
        */
        StringSQL = "SELECT product_id, category_id, product_name, product_total, product_price FROM Products";
        try
        {
            Command = new OleDbCommand();
            Command.CommandType = CommandType.Text;
            Command.CommandText = StringSQL;
            Command.Connection = Conexion;

            DataAdapter = new OleDbDataAdapter( Command );
            DataSet = new DataSet();
            DataAdapter.Fill( DataSet, "Products" );
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