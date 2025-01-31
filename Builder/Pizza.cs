using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Pizza
    {
        public string Crust { get; set; }
        public List<string> Sauces { get; set; } = new List<string>();
        public List<string> Meats { get; set; } = new List<string>();
        public List<string> Cheeses { get; set; } = new List<string>();
        public List<string> Vegetables { get; set; } = new List<string>();
        public List<string> Spices { get; set; } = new List<string>();

        public void ShowPizza()
        {
            Console.WriteLine("\nPizza składniki:");
            Console.WriteLine($"Spód: {Crust}");
            Console.WriteLine($"Sosy: {string.Join(", ", Sauces)}");
            Console.WriteLine($"Wędliny: {string.Join(", ", Meats)}");
            Console.WriteLine($"Sery: {string.Join(", ", Cheeses)}");
            Console.WriteLine($"Warzywa: {string.Join(", ", Vegetables)}");
            Console.WriteLine($"Przyprawy: {string.Join(", ", Spices)}");
        }
    }
}
