using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

public class AccessDB
{
    #region Variables
    private OleDbConnection conexion;
    private OleDbCommand command;
    private OleDbDataAdapter dataAdapter;
    private OleDbDataReader dataReader;
    private DataSet dataSet;
    private string stringConexion, stringError, stringSQL;

    static readonly AccessDB instance = new AccessDB();
    #endregion

    #region Propiedades
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

    public static AccessDB Instance
    {
        get { return instance; }
    }
    #endregion

    #region Constructores
    public AccessDB()
    {
        Conexion = null;
        DataAdapter = null;
        DataReader = null;
        DataSet = null;
        StringConexion = null;
        StringError = null;
    }
    #endregion

    #region MetodosDB
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
    #endregion
    
    #region Metodos Producto
    public bool CrearProducto( int categoryId, string productName, int productTotal, int productPrice )
    {
        StringSQL = "INSERT INTO Products([category_id], [product_name], [product_total], [product_price])"
                   + " VALUES(@categoryId, @productName, @productTotal, @productPrice);";
        try
        {
            Command = new OleDbCommand();
            Command.CommandType = CommandType.Text;
            Command.Parameters.Add( Convert.ToString( categoryId ), OleDbType.Integer ).Value = categoryId;
            Command.Parameters.Add( productName, OleDbType.WChar ).Value = productName;
            Command.Parameters.Add( Convert.ToString( productTotal ), OleDbType.Integer ).Value = productTotal;
            Command.Parameters.Add( Convert.ToString( productPrice ), OleDbType.Integer ).Value = productPrice;
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

    public bool BuscarProducto( string productName )
    {
        StringSQL = "SELECT product_id, category_id, product_name, product_total, product_price " 
            + "FROM Products "
            + "WHERE product_name LIKE '%" + productName + "%';";
        try
        {
            Command = new OleDbCommand();
            Command.CommandType = CommandType.Text;
            //Command.Parameters.Add( productName, OleDbType.WChar ).Value = productName;
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
        StringSQL = "SELECT product_id, category_id, product_name, product_total, product_price FROM Products;";
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
    #endregion

    #region Metodos Categoria
    public bool MostrarCategorias()
    {
        StringSQL = "SELECT category_id, category_name, category_active FROM Categories;";
        try
        {
            Command = new OleDbCommand();
            Command.CommandType = CommandType.Text;
            Command.CommandText = StringSQL;
            Command.Connection = Conexion;

            DataAdapter = new OleDbDataAdapter( Command );
            DataSet = new DataSet();
            DataAdapter.Fill( DataSet, "Category" );
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
    #endregion
}