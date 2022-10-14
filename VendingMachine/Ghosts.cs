using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Ghosts : Monster
    {

        public Ghosts(string name, int power, int currentValue) : base(name, power, currentValue)
        {
        }

        public override void MakeNoise()
        {
            Console.WriteLine("Boooooo!");
        }
    }
}
