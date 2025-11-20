class Program
{
    static void Main(string[] args)
    {
            // ---------- ORDER 1 ----------
        Address address1 = new Address("123 Ocean View", "Newark", "NJ", "USA");
        Customer customer1 = new Customer("Carlos Rivera", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM100", 25.99, 2));
        order1.AddProduct(new Product("Keyboard", "KB200", 45.50, 1));

    // ---------- ORDER 2 ----------
        Address address2 = new Address("5489 Las americas st", "San Pedro Sula", "Cortés", "Honduras");
        Customer customer2 = new Customer("Ana Lopez", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("USB-C Charger", "UC300", 18.75, 3));
        order2.AddProduct(new Product("Laptop Stand", "LS400", 29.99, 1));

    // ---------- DISPLAY RESULTS ----------
        DisplayOrder(order1);
        Console.WriteLine("-------------------------------------");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
    }
}