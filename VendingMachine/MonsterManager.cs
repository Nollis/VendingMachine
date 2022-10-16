using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VendingMachine
{

    interface IVending
    {
        void BuyMonster();
        void ShowAllMonsters();
        void addFunds(int amount);
        Dictionary<string, int> EndTransaction(int _availableFunds);
    }

    public class MonsterManager : IVending
    {
        public MonsterManager()
        {
            Monsters = new List<Monster>();
            CreateMonsterList();
            _availableFunds = 0;
        }

        public int _availableFunds;
        private ConsoleKeyInfo status;
        public int[] denominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };

    public List<Monster> Monsters { get; set; }
        public void CreateMonsterList()
        {
            Aliens alien = new Aliens("The Grey", 10, 100);
            Monsters.Add(alien);
            alien = new Aliens("Predator", 20, 50);
            Monsters.Add(alien);
            Ghosts ghost = new Ghosts("White Sheets", 30, 200);
            Monsters.Add(ghost);
            ghost = new Ghosts("Ghoul", 40, 75);
            Monsters.Add(ghost);
            Vampires vampire = new Vampires("Nosferatu", 50, 300);
            Monsters.Add(vampire);
            vampire = new Vampires("Demon", 60, 225);
            Monsters.Add(vampire);
        }

        public void ShowAllMonsters()
        {
            Console.WriteLine("Monsters available for purchase:");
            foreach (Monster monster in Monsters)
            {
                Console.WriteLine($"{monster.Id} Name: {monster.Name} Power: {monster.Power} Price: {monster.CurrentValue}");
            }
        }

        public void addFunds(int amount)
        {
            _availableFunds += amount;
            ShowAvailableFunds();
        }

        public void ShowAvailableFunds()
        {
            Console.WriteLine($"\nFunds available: {_availableFunds}");
        }

        public void UseMonster(string monsterName)
        {
            Console.WriteLine($"Do you want to release {monsterName}?  (Y/N)");
            status = Console.ReadKey();
            if (status.Key ==ConsoleKey.Y)
            {
                Console.WriteLine($"{monsterName} has been released into the world.");
            }
        }

        public void BuyMonster()
        {
            Console.WriteLine("\nEnter Id of the monster you want to buy:");
            int chosenId = int.Parse(Console.ReadLine());

            foreach (Monster monster in Monsters)
            {
                if (monster.Id == chosenId)
                {
                    if (monster.CurrentValue <= _availableFunds)
                    {
                        _availableFunds -= monster.CurrentValue;
                        ShowAvailableFunds();                 
                        UseMonster(monster.Name);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Get a job, and add more funds sucker!");
                    }
                }
            }
        }

        public Dictionary<string, int> EndTransaction(int _availableFunds)
        {
            Dictionary<string, int> _denominations = new Dictionary<string, int>() { { "thousands", 0 }, { "fivehundreds", 0 }, { "hundreds", 0 }, { "fifties", 0 }, { "twenties", 0 }, { "tens", 0 }, { "fives", 0 }, { "ones", 0 } };

            int thousands, fivehundreds, hundreds, fifties, twenties, tens, fives, ones;
            if (_availableFunds >= 1000)
            {
                thousands = _availableFunds / 1000;
                _denominations["thousands"] = thousands;
                _availableFunds -= thousands * 1000;
            }
            if (_availableFunds >= 500)
            {
                fivehundreds = _availableFunds / 500;
                _denominations["fivehundreds"] = fivehundreds;
                _availableFunds -= fivehundreds * 500;
            }
            if (_availableFunds >= 100)
            {
                hundreds = _availableFunds / 100;
                _denominations["hundreds"] = hundreds;
                _availableFunds -= hundreds * 100;
            }
            if (_availableFunds >= 50)
            {
                fifties = _availableFunds / 50;
                _denominations["fifties"] = fifties;
                _availableFunds -= fifties * 50;
            }
            if (_availableFunds >= 20)
            {
                twenties = _availableFunds / 20;
                _denominations["twenties"] = twenties;
                _availableFunds -= twenties * 20;
            }
            if (_availableFunds >= 10)
            {
                tens = _availableFunds / 10;
                _denominations["tens"] = tens;
                _availableFunds -= tens * 10;
            }
            if (_availableFunds >= 5)
            {
                fives = _availableFunds / 5;
                _denominations["fives"] = fives;
                _availableFunds -= fives * 5;
            }

            if (_availableFunds >= 1)
            {
                ones = _availableFunds;
                _denominations["ones"] = ones;

            }

            return _denominations;
        }
    }
}
