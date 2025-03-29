using System;

class Program
{
    static void Main(string[] args)
    {
        // USA Customer
        Address address1 = new Address("1530 Sunflower", "Apopka", "FL", "USA");
        Customer customer1 = new Customer("Silvia Ferran", address1);

        Product product1 = new Product("Eyeshadow Singles", "2616812", 9.00f, 1);
        Product product2 = new Product("Premium Round Cotton Pads", "2622001", 2.99f, 3);
        Product product3 = new Product("Round Eyelash Curler", "2621426", 16.00f, 1);
        Product product4 = new Product("Axolotl Bath Bomb Fizzer", "2620755", 8.00f, 5);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);
        order1.AddProduct(product4);

        // International Customer
        Address address2 = new Address("Calle 45 3 56", "Barranquilla", "AT", "Colombia");
        Customer customer2 = new Customer("Camila Camargo", address2);

        Product product5 = new Product("Dewy Glaze Setting Spray", "2623165", 12.00f, 2);
        Product product6 = new Product("Toleriane Double Repair Face Moisturizer with Niacinamide", "2509730", 18.74f, 2);
        Product product7 = new Product("Lash Sensational Sky High Mascara", " 2574523", 9.09f, 5);
        Product product8 = new Product("Ultra Hydra Source Deep Treatment Mask for Very Dry Hair", "2637880", 44.00f, 1);

        Order order2 = new Order(customer2);
        order2.AddProduct(product5);
        order2.AddProduct(product6);
        order2.AddProduct(product7);
        order2.AddProduct(product8);

        // Display orders
        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
            Console.WriteLine(new string('-', 50));
        }
    }
}