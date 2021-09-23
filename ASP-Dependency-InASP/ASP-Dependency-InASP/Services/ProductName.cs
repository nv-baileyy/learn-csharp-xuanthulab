using System.Collections.Generic;

public class ProductName
{
    public List<string> products { get; set; }
    public ProductName()
    {
        products = new List<string> {
            "IPhone", "Samsung", "ASUS", "MSI"
        };
    }
}