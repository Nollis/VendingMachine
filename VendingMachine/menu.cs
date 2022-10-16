namespace VendingMachine
{
    public class Menu
    {
        MonsterManager mm = new MonsterManager();
        private ConsoleKeyInfo status;

        public void Display()
        {

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1] Display Vending Machine Items");
                Console.WriteLine("2] Purchase");
                Console.WriteLine("3] Insert money");
                Console.WriteLine("4] End Transaction");
                Console.WriteLine("Q] Quit");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Displaying Items");
                    mm.ShowAllMonsters();
                }
                else if (input == "2")
                {
                    Console.Clear();
                    mm.ShowAllMonsters();
                    mm.BuyMonster();
                }
                else if (input == "3")
                {
                    InsertMoney();
                }
                else if (input == "4")
                {
 
                    Dictionary<string, int> denominations = mm.EndTransaction(mm._availableFunds);
                    foreach (KeyValuePair<string, int> kv in denominations)
                        Console.WriteLine(kv.Value.ToString() + " " + kv.Key.ToString());
                    Console.WriteLine("Returned to buyer!");
                    Console.ReadKey();
                }
                else if (input.ToUpper() == "Q")
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        public void InsertMoney()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(">>> How much do you want to insert?");
                Console.Write("1, 5, 10, 20, 50, 100, 500, 1000 kr? ");
                string input = Console.ReadLine();
                if (input == "1"
                            || input == "5"
                            || input == "10"
                            || input == "20"
                            || input == "50"
                            || input == "100"
                            || input == "500"
                            || input == "1000")
                {
                    mm.addFunds(Int32.Parse(input));
                    Console.WriteLine("You want to add more? (Y/N)");
                    status = Console.ReadKey();
                    if (status.Key == ConsoleKey.Y)
                    {
                        ;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Add a valid amount");
                    Console.ReadKey();
                }
            }
        }
    }
}

