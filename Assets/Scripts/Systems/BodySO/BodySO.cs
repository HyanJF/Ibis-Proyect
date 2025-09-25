using System.Collections.Generic;

public class BodySO
{
    public BodyType bodyType;
    public List<Product> products;

    public BodySO(BodyType type)
    {
        bodyType = type;
        products = new List<Product>();
    }
}
