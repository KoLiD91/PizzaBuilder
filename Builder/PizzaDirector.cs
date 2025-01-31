using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class PizzaDirector
    {
        private IPizzaBuilder _builder;

        public PizzaDirector(IPizzaBuilder builder)
        {
            _builder = builder;
        }

        public void CreateMargherita()
        {
            _builder.SetCrust("cienki");
            _builder.AddCheese("mozzarella");
            _builder.AddSpice("bazylia");
            _builder.AddSpice("oregano");
        }

        public void CreatePepperoni()
        {
            _builder.SetCrust("gruby");
            _builder.AddMeat("pepperoni");
            _builder.AddCheese("mozzarella");
            _builder.AddSpice("oregano");
        }

        public void CreateVegetarian()
        {
            _builder.SetCrust("cienki");
            _builder.AddCheese("mozzarella");
            _builder.AddVegetable("pieczarki");
            _builder.AddVegetable("papryka");
            _builder.AddVegetable("cebula");
            _builder.AddSpice("oregano");
            _builder.AddSpice("bazylia");
        }
    }
}
