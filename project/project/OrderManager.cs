namespace project;
internal class OrderManager
{
    #region Properties
    public Order[] Orders { get; set; } = new Order[100];

    #endregion

    #region Fild
    private int Index = 0;

    #endregion

    #region Ctor
    public OrderManager(Order[] order)
    {
        Orders = order;
        Index = IndexOf();
    }

    #endregion

    #region Method

    public void AddOrder(Order order)
    {
        Orders[Index] = order;
        Index++;
    }

    public void ShowOrderByStatus(OrderStatus status)
    {
        Console.Clear();
        foreach (var item in Orders)
        {
            if (item is null) break;
            if(item.Status == status)
            {
                Console.Write($"Order ID : {item.Id}\nOrder Product : {item.Product}\nOrder Quantity : {item.Quantity}\nOrder Status : {item.Status} \n");
                Console.Write("-------------------\n");
            }
        }
        Console.ReadKey();
    }

    public void CancelOrder(int Id)
    {
        foreach (var item in Orders)
        {
            if (item is null) break;
            OrderStatus status = (OrderStatus)(3);
            item.GetStatus(status);
        }
    }

    #endregion

    #region Private Method 
    private int IndexOf()
    {
        foreach (Order item in Orders)
        {
            if (item is null) break;
            Index++;
        }
        return Index;
    }

    #endregion
}
