using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal abstract class Monster
    {
        public Monster(string name, int power, int currentValue)
        {
            _index++;
            Id = _index;
            Name = name;
            CurrentValue = currentValue;
            Power = power;

        }

        private static int _index = 0;

        public int Id { get; }

        public string Name { get; set; }

        public int Power { get; set; }

        public int CurrentValue { get; set; }

        public abstract void MakeNoise();

    }
}
