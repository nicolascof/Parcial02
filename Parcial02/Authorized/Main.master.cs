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

public partial class Authorized_Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    { }

    protected void lbtn_ShowProducts_Click( object sender, EventArgs e )
    {
        this.Server.Transfer( "~/Authorized/ShowProducts.aspx" );
    }

    protected void lbtn_AddProduct_Click( object sender, EventArgs e )
    {
        this.Server.Transfer( "~/Authorized/AddProduct.aspx" );
    }
}
