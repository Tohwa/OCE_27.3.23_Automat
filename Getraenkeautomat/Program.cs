using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automata;

namespace Getraenkeautomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Automat drinkDispenser = new Automat();
            Automat userChoice = new Automat();
            Automat wallet = new Automat();
            Automat purchase = new Automat();
            Automat moneyInput = new Automat();

            drinkDispenser.ShowDrinkList();
            int input = userChoice.UserInput();
            float balance = wallet.Wallet(moneyInput.inputMoney());
            purchase.Purchase(input, balance);
        }
    }
}