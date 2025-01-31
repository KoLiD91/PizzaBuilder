using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class PizzaMenu
    {
        public static Dictionary<string, List<string>> AvailableIngredients = new Dictionary<string, List<string>>
    {
        { "Ciasto", new List<string> { "cienkie", "grube", "średnie" } },
        { "Sosy", new List<string> { "pomidorowy", "czosnkowy", "BBQ" } },
        { "Sery", new List<string> { "mozzarella", "parmezan", "gouda", "ser pleśniowy" } },
        { "Wędliny", new List<string> { "szynka", "pepperoni", "salami", "boczek" } },
        { "Warzywa", new List<string> { "pieczarki", "cebula", "papryka", "pomidor", "kukurydza", "oliwki" } },
        { "Przyprawy", new List<string> { "oregano", "bazylia", "czosnek", "pieprz" } }
    };

        public static void DisplayMenu()
        {
            Console.WriteLine("\nDostępne składniki:");
            foreach (var category in AvailableIngredients)
            {
                Console.WriteLine($"\n{category.Key}:");
                for (int i = 0; i < category.Value.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {category.Value[i]}");
                }
            }
        }
    }
}
