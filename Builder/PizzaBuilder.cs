using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // PizzaBuilder.cs
    public class PizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();

        public void SetCrust(string crust)
        {
            _pizza.Crust = crust;
        }

        public void AddSauce(string sauce)
        {
            _pizza.Sauces.Add(sauce);
        }

        public void AddMeat(string meat)
        {
            _pizza.Meats.Add(meat);
        }

        public void AddCheese(string cheese)
        {
            _pizza.Cheeses.Add(cheese);
        }

        public void AddVegetable(string vegetable)
        {
            _pizza.Vegetables.Add(vegetable);
        }

        public void AddSpice(string spice)
        {
            _pizza.Spices.Add(spice);
        }

        public Pizza GetPizza()
        {
            Pizza result = _pizza;
            _pizza = new Pizza();
            return result;
        }
    }
}
