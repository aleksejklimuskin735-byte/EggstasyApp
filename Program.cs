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
                Console.WriteLine("2. Add dish to order");
                Console.WriteLine("3. Remove dish from order");
                Console.WriteLine("5. View all orders");
                Console.WriteLine("0. Exit");
                Console.Write("Select: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": CreateOrder(); break;
                    case "2": ModifyOrder(true); break;
                    case "3": ModifyOrder(false); break;
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

        static void ModifyOrder(bool add)
        {
            var order = SelectOrder();
            if (order == null) return;

            Console.WriteLine("Menu:");
            for (int i = 0; i < Menu.Count; i++)
                Console.WriteLine($"{i + 1}. {Menu[i].Name} - ${Menu[i].Price}");

            Console.WriteLine("0. Back");
            Console.Write("Choose dish number: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > Menu.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }
            if (choice == 0) return;

            if (add)
                order.Dishes.Add(Menu[choice - 1]);
            else
                order.Dishes.RemoveAt(choice - 1);
        }

        static Order SelectOrder()
        {
            if (Orders.Count == 0)
            {
                Console.WriteLine("No orders available.");
                return null;
            }

            Console.WriteLine("Orders:");
            foreach (var o in Orders)
                Console.WriteLine($"#{o.OrderNumber} - {o.Status}");

            Console.Write("Select order number (0 to Back): ");
            if (!int.TryParse(Console.ReadLine(), out int num)) return null;
            if (num == 0) return null;

            return Orders.Find(o => o.OrderNumber == num);
        }
    }
}
