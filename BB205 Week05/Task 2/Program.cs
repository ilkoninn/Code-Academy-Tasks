using EnumTask.Models;
using Microsoft.CSharp.RuntimeBinder;

namespace EnumTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== Currency App ==========");
            Console.WriteLine("Please, enter to exchange type(AZN to ?)");
            
            bool running = true;

            while (running)
            {
                Console.Write("\nUser choice(USD, TRY, RUB, EUR, GPB, JPY): ");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "USD":
                        Console.Write("\nPlease, enter amount value(AZN): ");
                        decimal userAmount = decimal.Parse(Console.ReadLine());
                        Console.Write("Please, enter conversation rate: ");
                        decimal conversation = decimal.Parse(Console.ReadLine());


                        Money money = new Money(userAmount, Currency.USD);

                        decimal convertedMoney = money.ConvertCurrency(money, conversation);

                        Console.WriteLine($"Converted Amount: {convertedMoney} USD");
                        running = false;
                        break;
                    case "TRY":
                        Console.Write("\nPlease, enter amount value(AZN): ");
                        decimal userAmount2 = decimal.Parse(Console.ReadLine());
                        Console.Write("Please, enter conversation rate: ");
                        decimal conversation2 = decimal.Parse(Console.ReadLine());


                        Money money2 = new Money(userAmount2, Currency.TRY);

                        decimal convertedMoney2 = money2.ConvertCurrency(money2, conversation2);

                        Console.WriteLine($"Converted Amount: {convertedMoney2} TRY");
                        running = false;
                        break;
                    case "RUB":
                        Console.Write("\nPlease, enter amount value(AZN): ");
                        decimal userAmount3 = decimal.Parse(Console.ReadLine());
                        Console.Write("Please, enter conversation rate: ");
                        decimal conversation3 = decimal.Parse(Console.ReadLine());


                        Money money3 = new Money(userAmount3, Currency.RUB);

                        decimal convertedMoney3 = money3.ConvertCurrency(money3, conversation3);

                        Console.WriteLine($"Converted Amount: {convertedMoney3} RUB");
                        running = false;
                        break;
                    case "EUR":
                        Console.Write("\nPlease, enter amount value(AZN): ");
                        decimal userAmount4 = decimal.Parse(Console.ReadLine());
                        Console.Write("Please, enter conversation rate: ");
                        decimal conversation4 = decimal.Parse(Console.ReadLine());


                        Money money4 = new Money(userAmount4, Currency.EUR);

                        decimal convertedMoney4 = money4.ConvertCurrency(money4, conversation4);

                        Console.WriteLine($"Converted Amount: {convertedMoney4} EUR");
                        running = false;
                        break;
                    case "GPB":
                        Console.Write("\nPlease, enter amount value(AZN): ");
                        decimal userAmount5 = decimal.Parse(Console.ReadLine());
                        Console.Write("Please, enter conversation rate: ");
                        decimal conversation5 = decimal.Parse(Console.ReadLine());


                        Money money5 = new Money(userAmount5, Currency.GPB);

                        decimal convertedMoney5 = money5.ConvertCurrency(money5, conversation5);

                        Console.WriteLine($"Converted Amount: {convertedMoney5} GPB");
                        running = false;
                        break;
                    case "JPY":
                        Console.Write("\nPlease, enter amount value(AZN): ");
                        decimal userAmount6 = decimal.Parse(Console.ReadLine());
                        Console.Write("Please, enter conversation rate: ");
                        decimal conversation6 = decimal.Parse(Console.ReadLine());


                        Money money6 = new Money(userAmount6, Currency.JPY);

                        decimal convertedMoney6 = money6.ConvertCurrency(money6, conversation6);

                        Console.WriteLine($"Converted Amount: {convertedMoney6} JPY");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice, try again!\n");
                        break;
                }
            }

        }
    }
}