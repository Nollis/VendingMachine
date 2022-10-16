using Newtonsoft.Json.Linq;
using VendingMachine;

namespace MonsterManagerTest
{
    [TestClass]
    public class MonsterManagerTest
    {
        MonsterManager mm = new MonsterManager();
        int[] denomTest = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        int _availableFundsTest = 500;
        bool isArrayEqual = true;

        [TestMethod]
        public void MonsterListSize()
        {
            
            Assert.AreEqual(6, mm.Monsters.Count);
        }
        [TestMethod]
        public void DenominationWorks()
        {
            for (int i = 0 ; i < denomTest.Length; i++)
            {
                if (denomTest[i] != mm.denominations[i])
                {
                    isArrayEqual = false;
                }
            }
            Assert.IsTrue(isArrayEqual);
            
        }
        [TestMethod]
        public void EndTransactionWorks()
        {
            Dictionary<string, int> MoneyLeft = mm.EndTransaction(165);
            Assert.IsTrue(MoneyLeft["hundreds"] == 1 && MoneyLeft["fifties"] == 1 && MoneyLeft["tens"] == 1 && MoneyLeft["fives"] == 1);

        }
        [TestMethod]
        public void EndTransactionIsZero()
        {
            Dictionary<string, int> MoneyLeft = mm.EndTransaction(165);
            Assert.AreEqual(0, mm._availableFunds);

        }
    }
}