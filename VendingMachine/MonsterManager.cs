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
        void EndTransaction(int monsterValue);
    }

    internal class MonsterManager : IVending
    {
        public MonsterManager()
        {
            Monsters = new List<Monster>();
            CreateMonsterList();
            _availableFunds = 0;
        }

        private int _availableFunds;
        private int _idForPurchase;
        private ConsoleKeyInfo status;

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
                        _idForPurchase = monster.Id;
                        ShowAvailableFunds();
                        EndTransaction(monster.CurrentValue);
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

        public void EndTransaction(int monsterValue)
        {
            _availableFunds -= monsterValue;
        }
    }
}
