using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Drinks;
using Getraenkeautomat;

namespace Automata
{
    internal class Automat
    {
        public float m_wallet = 0.0f;
        public int m_input = 0;
        public float m_currentBalance;
        public string m_ynChoice = "";
        public float m_amount = 0.0f;
        Drink[] m_drinkChoices = new Drink[] { new Drink(500, 0),
                                               new Drink(1000, 0),
                                               new Drink(250, 40),
                                               new Drink(330, 100),
                                               new Drink(500, 15),
                                              };

        float[] m_drinkPrice = new float[] { 1.0f, 1.5f, 1.5f, 2.0f, 3.0f };

        string[] m_drinkNames = new string[] { "Wasser", "Wasser", "Cola", "Süßer Tee", "Süßer Tee" };

        public void ShowDrinkList()
        {
            for (int i = 0; i < m_drinkChoices.Length; i++)
            {
                Console.WriteLine("{0}. {1}: {2} ml, {3} Euro", i + 1, m_drinkNames[i], m_drinkChoices[i].m_liquidVolume, m_drinkPrice[i]);
            }
        }

        public float Wallet(float _money)
        {
            Console.WriteLine("m_amount during wallet transfer = {0}", _money);
            m_wallet += _money;
            Console.WriteLine("m_wallet after wallet transfer = {0}", m_wallet);
            return m_wallet;
        }


        public int UserInput()
        {
            Console.WriteLine("Please input the number corresponding to the drink you would like to buy.");
            do
            {
                int.TryParse(Console.ReadLine(), out m_input);                

                if (m_input <= m_drinkChoices.Length && m_input > 0)
                {
                    Console.WriteLine("Your choice is {0}. The Price is {1}Euro.", m_drinkNames[m_input - 1] , m_drinkPrice[m_input - 1]);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please input a valid number.");
                }
            } while (m_input > m_drinkChoices.Length || m_input <= 0);
            Console.WriteLine("m_input = {0}", m_input );
            return m_input;
        }


        public float inputMoney()
        {
            Console.WriteLine("Your Wallet has a balance of {0}Euro", m_wallet);
            Console.WriteLine("Would you like to add more to your balance?");
            m_ynChoice = Convert.ToString(Console.ReadLine());
            do
            {
                switch (m_ynChoice)
                {
                    case "yes":
                        Console.WriteLine("Please enter the amount of money you would like to add.");
                        Single.TryParse(Console.ReadLine(), out m_amount);
                        break;
                    case "no":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input. Please only input yes or no.");
                        m_ynChoice = Convert.ToString(Console.ReadLine());
                        break;
                }
            } while (m_ynChoice != "yes" && m_ynChoice != "no");
            Console.WriteLine("m_amount = {0}", m_amount);
            return m_amount;
        }

        public void Purchase(int _input, float _balance)
        {
            Console.WriteLine("m_wallet during purchase = {0}", _balance);
            Console.WriteLine("the necessary amount of money needed is {0}", m_drinkPrice[_input - 1]);

            if (_input <= m_drinkChoices.Length && _input > 0)
            {
                if (_balance >= m_drinkPrice[_input - 1])
                {
                    _balance -= m_drinkPrice[_input - 1];
                    Console.WriteLine("Thank you for your purchase. Your remaining balance is {0}.", _balance);
                }
                else
                {
                    Console.WriteLine("Your Wallet has a balance of {0}Euro", _balance);
                    Console.WriteLine("Your Wallet has not enough balance!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }


    }
}
