namespace project;
internal class Product
{
    #region Properties
    public string Name { get; set; }
    public double Price { get; private set; }

    #endregion

    #region Method
    public void GetPrice(double price)
    {
        if (price > 0) Price = price;
    }

    #endregion


}
