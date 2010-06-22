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

public partial class Authorized_AddProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        localhostProduct.Product productWS = new localhostProduct.Product();
        ddl_Categoria.DataSource = productWS.MostrarCategorias();
        ddl_Categoria.DataTextField = "category_name";
        ddl_Categoria.DataValueField = "category_id";
        ddl_Categoria.DataBind();
    }

    protected void btn_Agregar_Click( object sender, EventArgs e )
    {
        localhostProduct.Product productWS = new localhostProduct.Product();
        localhostProduct.Producto producto = new localhostProduct.Producto();
        producto.CategoryId = Convert.ToInt32( ddl_Categoria.SelectedItem.Value );
        producto.ProductName = tbx_ProductName.Text;
        producto.ProductTotal = Convert.ToInt32( tbx_ProductTotal.Text );
        producto.ProductPrice = Convert.ToInt32( tbx_ProductPrice.Text );
        productWS.CrearProducto( producto );
    }
}
