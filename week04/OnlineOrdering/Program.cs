using System;

class Program
{
    static void Main(string[] args)
    {
        // First Customer (USA)
        Address address1 = new Address(
            "123 Main Street",
            "Phoenix",
            "AZ",
            "USA");

        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P101", 850.00, 1));
        order1.AddProduct(new Product("Wireless Mouse", "P102", 25.50, 2));
        order1.AddProduct(new Product("Keyboard", "P103", 45.00, 1));

        // Second Customer (Canada)
        Address address2 = new Address(
            "456 Maple Road",
            "Toronto",
            "Ontario",
            "Canada");

        Customer customer2 = new Customer("Sarah Johnson", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Monitor", "P201", 250.00, 2));
        order2.AddProduct(new Product("HDMI Cable", "P202", 15.00, 3));

        // Display Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}");

        Console.WriteLine("\n-------------------------------------\n");

        // Display Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
    }
}