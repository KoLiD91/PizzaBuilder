using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public interface IPizzaBuilder
    {
        void SetCrust(string crust);
        void AddSauce(string sauce);
        void AddMeat(string meat);
        void AddCheese(string cheese);
        void AddVegetable(string vegetable);
        void AddSpice(string spice);
        Pizza GetPizza();
    }
}
