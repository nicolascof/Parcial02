using System;

/**
* Tabla Products: product_id, category_id, product_name, product_total, product_price
* Tabla Category: category_id, category_name, category_active
*/
public class Categoria
{
    private int categoryId; 
    private string categoryName;
    private bool categoryActive;

    public int CategoryId
    {
        get { return categoryId; }
        set { categoryId = value; }
    }
    
    public string CategoryName
    {
        get { return categoryName; }
        set { categoryName = value; }
    }

    public bool CategoryActive
    {
        get { return categoryActive; }
        set { categoryActive = value; }
    }

	public Categoria()
	{
        CategoryId = 0;
        CategoryName = null;
        CategoryActive = false;
    }
}