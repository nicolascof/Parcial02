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
        localhostProduct.Producto[] listProducto = productWS.MostrarProductos();

        gv_Productos.DataSource = listProducto;
        gv_Productos.DataBind();
    }

    protected void btn_Buscar_Click( object sender, EventArgs e )
    {
        localhostProduct.Product productWS = new localhostProduct.Product();
        localhostProduct.Producto[] listProducto = productWS.BuscarProducto( tbx_Buscar.Text );

        gv_Productos.DataSource = listProducto;
        gv_Productos.DataBind();

        lbl_Info.Text = listProducto.Length + " producto(s) encontrado(s)";
    }
}