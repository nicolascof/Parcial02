using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class Authorized_ShowProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        localhostProduct.Product productWS = new localhostProduct.Product();
        localhostProduct.Producto[] productoList = productWS.MostrarProductos();

        gv_Productos.DataSource = productoList;
        gv_Productos.DataBind();
    }
}