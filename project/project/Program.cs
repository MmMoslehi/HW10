using project;

Order[] orders = new Order[100];

OrderManager manager = new OrderManager(orders);

int want = 0;
do
{
    Console.Clear();
    Console.Write(" 1.Add Order\n 2.Show Orders By Status\n 3.Cencel Order\n 4.Exit \n");
    Console.Write("Enter a item : ");
    want = int.Parse(Console.ReadLine());

    switch (want)
    {
        case 1:

            Console.Clear();

            Console.Write("Enter Id : ");
            int Id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name Product : ");
            string NameProduct = Console.ReadLine();

            Console.Write("Enter Price Product : ");
            double PriceProduct = double.Parse(Console.ReadLine());

            Product product = new Product()
            {
                Name = NameProduct
            };

            product.GetPrice(PriceProduct);

            Console.Write($"Enter Quantity {product.Name} : ");
            int quantiy = int.Parse(Console.ReadLine());

            Console.Write($"Enter Status Order {Id} : ");
            int statusP = int.Parse(Console.ReadLine());

            OrderStatus status = (OrderStatus)(statusP - 1);

            Order order = new Order(Id, product, quantiy);

            switch (status)
            {
                case OrderStatus.Canceled:
                    Console.Write($"{order.Id} Status : {status} ");
                    break;
                case OrderStatus.pending:
                    Console.Write($"{order.Id} Status : {status} ");
                    break;
                case OrderStatus.Processing:
                    Console.Write($"{order.Id} Status : {status} ");
                    break;
                case OrderStatus.Shipped:
                    Console.Write($"{order.Id} Status : {status} ");
                    break;
            }

            order.GetStatus(status);

            manager.AddOrder(order);

            break;

        case 2:

            Console.Clear();

            Console.Write("Enter OrderStatus : ");
            int Status = int.Parse(Console.ReadLine());

            OrderStatus status1 = (OrderStatus)(Status - 1);

            manager.ShowOrderByStatus(status1);

            break;

        case 3:

            Console.Clear();

            Console.Write("Enter Id for Status Cancel : ");
            int id = int.Parse(Console.ReadLine());

            manager.CancelOrder(id);

            break;
    }

} while (want > 0 && want < 4);