using System.Collections.Generic;

namespace EggstasyApp
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public List<Dish> Dishes { get; set; } = new List<Dish>();
        public string Status { get; set; } = "Open";
    }
}
