using System;
using System.Collections.Generic;

namespace EggstasyApp
{
    class Program
    {
        static List<Dish> Menu = new List<Dish>
        {
            new Dish("Scrambled Eggs", 5),
            new Dish("Omelette", 6),
            new Dish("Egg Sandwich", 4),
            new Dish("Egg Tart", 3),
            new Dish("Eggnog", 2)
        };

        static List<Order> Orders = new List<Order>();
        static int orderCounter = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nEggstasy Menu System");
                Console.WriteLine("1. Create order");
                Console.WriteLine("5. View all orders");
                Console.WriteLine("0. Exit");
                Console.Write("Select: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": CreateOrder(); break;
                    case "5": ViewOrders(); break;
                    case "0":
                        Console.WriteLine("Press Enter to exit...");
                        Console.ReadLine();
                        return;
                    default: Console.WriteLine("Invalid input."); break;
                }
            }
        }

        static void CreateOrder()
        {
            Order order = new Order { OrderNumber = orderCounter++ };
            Orders.Add(order);
            Console.WriteLine($"Created Order #{order.OrderNumber}");
        }

        static void ViewOrders()
        {
            if (Orders.Count == 0)
            {
                Console.WriteLine("No orders yet.");
                return;
            }

            foreach (var o in Orders)
            {
                Console.WriteLine($"Order #{o.OrderNumber} - {o.Status}");
            }
        }
    }
}
