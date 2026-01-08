using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.WriteLine("4. Close order");
                Console.WriteLine("5. View all orders");
                Console.WriteLine("0. Exit");
                Console.Write("Select: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": CreateOrder(); break;
                    case "2": ModifyOrder(true); break;
                    case "3": ModifyOrder(false); break;
                    case "4": CloseOrder(); break;
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
                if (o.Dishes.Count > 0)
                {
                    for (int i = 0; i < o.Dishes.Count; i++)
                        Console.WriteLine($"{i + 1}. {o.Dishes[i].Name} - ${o.Dishes[i].Price}");
                    Console.WriteLine($"Total: ${o.Dishes.Sum(d => d.Price)}");
                }
            }
        }

        static void ModifyOrder(bool add)
        {
            var order = SelectOrder();
            if (order == null) return;

            if (add)
            {
                Console.WriteLine("Menu:");
                for (int i = 0; i < Menu.Count; i++)
                    Console.WriteLine($"{i + 1}. {Menu[i].Name} - ${Menu[i].Price}");

                Console.WriteLine("0. Back");
                Console.Write("Choose dish number: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > Menu.Count)
                    return;
                if (choice == 0) return;

                order.Dishes.Add(Menu[choice - 1]);
            }
            else
            {
                if (order.Dishes.Count == 0)
                {
                    Console.WriteLine("Order has no dishes.");
                    return;
                }

                Console.WriteLine("Dishes in order:");
                for (int i = 0; i < order.Dishes.Count; i++)
                    Console.WriteLine($"{i + 1}. {order.Dishes[i].Name} - ${order.Dishes[i].Price}");

                Console.WriteLine("0. Back");
                Console.Write("Choose dish number to remove: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > order.Dishes.Count)
                    return;
                if (choice == 0) return;

                order.Dishes.RemoveAt(choice - 1);
            }
        }


        static void CloseOrder()
        {
            var order = SelectOrder();
            if (order == null) return;

            order.Status = "Closed";
            Console.WriteLine($"Order #{order.OrderNumber} closed.");
        }

        static Order SelectOrder()
        {
            if (Orders.Count == 0)
                return null;

            foreach (var o in Orders)
                Console.WriteLine($"#{o.OrderNumber} - {o.Status}");

            Console.Write("Select order number (0 to Back): ");
            if (!int.TryParse(Console.ReadLine(), out int num)) return null;
            if (num == 0) return null;

            return Orders.Find(o => o.OrderNumber == num);
        }
    }
}
