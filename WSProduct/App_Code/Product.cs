using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Data;

[WebService( Namespace = "http://null/parcial02/" )]
[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
public class Product : System.Web.Services.WebService
{
    private AccessDB cxnDB;

    public Product()
    {
        cxnDB = AccessDB.Instance;
    }

    #region WebMethods
    [WebMethod]
    public List<Producto> MostrarProductos()
    {
        List<Producto> listProducto = new List<Producto>();

        cxnDB.Conectar();
        cxnDB.MostrarProductos();
        
        int tamR = cxnDB.DataSet.Tables["Products"].Rows.Count;
        for ( int i = 0; i < tamR; ++i )
        {
            Producto producto = new Producto();
            producto.ProductId = Convert.ToInt32( cxnDB.DataSet.Tables["Products"].Rows[i]["product_id"] );
            producto.CategoryId = Convert.ToInt32( cxnDB.DataSet.Tables["Products"].Rows[i]["category_id"] );
            producto.ProductName = Convert.ToString( cxnDB.DataSet.Tables["Products"].Rows[i]["product_name"] );
            producto.ProductTotal = Convert.ToInt32( cxnDB.DataSet.Tables["Products"].Rows[i]["product_total"] );
            producto.ProductPrice = Convert.ToInt32( cxnDB.DataSet.Tables["Products"].Rows[i]["product_price"] );
            listProducto.Add( producto );
        }
        
        return listProducto;
    }

    [WebMethod]
    public List<Producto> BuscarProducto( string productName )
    {
        List<Producto> listProducto = new List<Producto>();

        cxnDB.Conectar();
        cxnDB.BuscarProducto( productName );

        int tamR = cxnDB.DataSet.Tables["Products"].Rows.Count;
        for ( int i = 0; i < tamR; ++i )
        {
            Producto producto = new Producto();
            producto.ProductId = Convert.ToInt32( cxnDB.DataSet.Tables["Products"].Rows[i]["product_id"] );
            producto.CategoryId = Convert.ToInt32( cxnDB.DataSet.Tables["Products"].Rows[i]["category_id"] );
            producto.ProductName = Convert.ToString( cxnDB.DataSet.Tables["Products"].Rows[i]["product_name"] );
            producto.ProductTotal = Convert.ToInt32( cxnDB.DataSet.Tables["Products"].Rows[i]["product_total"] );
            producto.ProductPrice = Convert.ToInt32( cxnDB.DataSet.Tables["Products"].Rows[i]["product_price"] );
            listProducto.Add( producto );
        }

        return listProducto;
    }

    [WebMethod]
    public void CrearProducto( Producto producto )
    {
        cxnDB.Conectar();
        cxnDB.CrearProducto( producto.CategoryId, producto.ProductName, producto.ProductTotal, producto.ProductPrice );
    }

    [WebMethod]
    public void GuardarProducto()
    { }

    [WebMethod]
    public void ActualizarProducto()
    { }

    [WebMethod]
    public void BorrarProducto()
    { }

    [WebMethod]
    public DataSet MostrarCategorias()
    {
        cxnDB.Conectar();
        cxnDB.MostrarCategorias();

        return cxnDB.DataSet;
    }
    #endregion
}