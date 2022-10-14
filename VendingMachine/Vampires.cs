using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Vampires : Monster
    {

        public Vampires(string name, int power, int currentValue) : base(name, power, currentValue)
        {
        }

        public override void MakeNoise()
        {
            Console.WriteLine("I want your blood!");
        }
    }
}
