using System;

/**
* Tabla Products: product_id, category_id, product_name, product_total, product_price
* Tabla Category: category_id, category_name, category_active
*/
public class Producto
{
    private int productId;
    private int categoryId;
    private string productName;
    private int productTotal;
    private int productPrice;

    public int ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    public int CategoryId
    {
        get { return categoryId; }
        set { categoryId = value; }
    }

    public string ProductName
    {
        get { return productName; }
        set { productName = value; }
    }

    public int ProductTotal
    {
        get { return productTotal; }
        set { productTotal = value; }
    }

    public int ProductPrice
    {
        get { return productPrice; }
        set { productPrice = value; }
    }

    public Producto()
    {
        ProductId = 0;
        CategoryId = 0;
        ProductName = null;
        ProductTotal = 0;
        ProductPrice = 0;
    }
}