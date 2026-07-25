namespace project;
internal class Order
{
    #region Properties
    public int Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; private set; }
    public OrderStatus Status { get; private set; }

    #endregion

    #region ctor
    public Order(int id , Product product , int quatity )
    {
        Id = id;
        Product = product;
        Quantity = GetQuantity(quatity);
        TotalPrice = GetTotalPrice();
    }
    #endregion

    #region Fild
    public double TotalPrice = 0;

    #endregion

    #region Method
    public int GetQuantity(int quantity)
    {
        if(quantity > 0) Quantity = quantity;
        return Quantity;
    }
    public double GetTotalPrice()
    {
        if(Status == OrderStatus.Canceled) return 0;

        return Product.Price * Quantity;
    }

    public void GetStatus(OrderStatus status)
    {
        Status = status;
    }

    #endregion

}
