using Builder;

class Program
{
    private static PizzaBuilder builder = new PizzaBuilder();
    private static PizzaDirector director = new PizzaDirector(builder);

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nWitaj w systemie zamawiania pizzy!");
            Console.WriteLine("1. Wybierz gotową pizzę");
            Console.WriteLine("2. Stwórz własną pizzę");
            Console.WriteLine("3. Zakończ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    OrderPredefinedPizza();
                    break;
                case "2":
                    OrderCustomPizza();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    break;
            }
        }
    }

    private static void OrderPredefinedPizza()
    {
        Console.WriteLine("\nWybierz rodzaj pizzy:");
        Console.WriteLine("1. Margherita");
        Console.WriteLine("2. Pepperoni");
        Console.WriteLine("3. Wegetariańska");
        Console.WriteLine("0. Powrót do głównego menu");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                director.CreateMargherita();
                break;
            case "2":
                director.CreatePepperoni();
                break;
            case "3":
                director.CreateVegetarian();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Nieprawidłowy wybór.");
                return;
        }

        Pizza pizza = builder.GetPizza();
        pizza.ShowPizza();
    }

    private static void OrderCustomPizza()
    {
        // Wybór ciasta
        Console.WriteLine("\nWybierz rodzaj ciasta:");
        var crusts = PizzaMenu.AvailableIngredients["Ciasto"];
        for (int i = 0; i < crusts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {crusts[i]}");
        }
        Console.WriteLine("0. Powrót do głównego menu");

        if (int.TryParse(Console.ReadLine(), out int crustChoice))
        {
            if (crustChoice == 0) return;
            if (crustChoice >= 1 && crustChoice <= crusts.Count)
            {
                builder.SetCrust(crusts[crustChoice - 1]);
            }
        }

        // Wybór składników
        if (!SelectIngredients("Sosy", (sauce) => builder.AddSauce(sauce))) return;
        if (!SelectIngredients("Sery", (cheese) => builder.AddCheese(cheese))) return;
        if (!SelectIngredients("Wędliny", (meat) => builder.AddMeat(meat))) return;
        if (!SelectIngredients("Warzywa", (vegetable) => builder.AddVegetable(vegetable))) return;
        if (!SelectIngredients("Przyprawy", (spice) => builder.AddSpice(spice))) return;

        Pizza pizza = builder.GetPizza();
        Console.WriteLine("\nTwoja pizza jest gotowa!");
        pizza.ShowPizza();
    }

    private static bool SelectIngredients(string category, Action<string> addIngredient)
    {
        while (true)
        {
            Console.WriteLine($"\nWybierz {category}:");
            var ingredients = PizzaMenu.AvailableIngredients[category];

            for (int i = 0; i < ingredients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ingredients[i]}");
            }
            Console.WriteLine("B. Brak składników z tej kategorii");
            Console.WriteLine("0. Powrót do głównego menu");
            Console.WriteLine("\nAby wybrać kilka składników, wpisz numery rozdzielone spacją (np. '1 3 4')");

            string input = Console.ReadLine().ToUpper();

            if (input == "0") return false;
            if (input == "B") break; // Brak składników - przechodzimy dalej

            if (!string.IsNullOrWhiteSpace(input))
            {
                var selections = input.Split(' ')
                    .Where(x => int.TryParse(x, out int n) && n >= 1 && n <= ingredients.Count)
                    .Select(x => ingredients[int.Parse(x) - 1])
                    .Distinct(); // Unikamy duplikatów

                if (selections.Any())
                {
                    foreach (var selection in selections)
                    {
                        addIngredient(selection);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    continue;
                }
            }
        }
        return true;
    }
}