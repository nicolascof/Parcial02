using System;
using System.Xml.Serialization;

public class Producto
{
    #region Variables
    private int productId;
    private int categoryId;
    private string productName;
    private int productTotal;
    private int productPrice;
    #endregion

    #region Propiedades
    [XmlAttribute()]
    public int ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    [XmlAttribute()]
    public int CategoryId
    {
        get { return categoryId; }
        set { categoryId = value; }
    }

    [XmlAttribute()]
    public string ProductName
    {
        get { return productName; }
        set { productName = value; }
    }

    [XmlAttribute()]
    public int ProductTotal
    {
        get { return productTotal; }
        set { productTotal = value; }
    }

    [XmlAttribute()]
    public int ProductPrice
    {
        get { return productPrice; }
        set { productPrice = value; }
    }
    #endregion

    #region Constructores
    public Producto()
    {
        ProductId = 0;
        CategoryId = 0;
        ProductName = null;
        ProductTotal = 0;
        ProductPrice = 0;
    }
    #endregion
}