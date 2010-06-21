using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;

[WebService( Namespace = "http://null/parcial02/" )]
[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
public class Product : System.Web.Services.WebService
{
    public Product()
    { }

    [WebMethod]
    public void MostrarProductos()
    { }

    [WebMethod]
    public void BuscarProducto()
    { }

    [WebMethod]
    public void CrearProducto()
    { }

    [WebMethod]
    public void GuardarProducto()
    { }

    [WebMethod]
    public void ActualizarProducto()
    { }

    [WebMethod]
    public void BorrarProducto()
    { }
}