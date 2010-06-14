using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService( Namespace = "http://aspspider.info/nicolascof/parcial02/" )]
[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
public class Product : System.Web.Services.WebService
{
    public Product()
    {
        // Constructor
    }

    [WebMethod]
    public void BuscarProductos()
    { }

    [WebMethod]
    public void CrearProducto()
    { }

    [WebMethod]
    public void GuardarProductos()
    { }

    [WebMethod]
    public void BorrarProducto()
    { }
}