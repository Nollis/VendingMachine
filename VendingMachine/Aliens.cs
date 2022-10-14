using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{

    // Derived class (inherit from VendingItem)
    internal class Aliens : Monster
    {

        public Aliens(string name, int power, int currentValue) : base(name, power, currentValue)
        {
        }

        public override void MakeNoise()
        {
            Console.WriteLine("Hello stranger!");
        }
    }
}
