using ExtentionMethods.Models;

namespace ExtentionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======== Contain check ========");
            Console.Write("Please, enter a text: ");
            string userInput = Console.ReadLine();
            Console.Write("Please, enter contain value(str || char): ");
            string containInput = Console.ReadLine();
            Console.WriteLine($"Answer: {userInput.Contains(containInput)}"); // ExtentionMethods.Contains(userInput, containInput);

            Console.WriteLine("\n======== Is power of two check ========");
            Console.Write("Please, enter a number: ");
            int numberInput = int.Parse(Console.ReadLine());
            Console.WriteLine($"Answer: {ExtensionMethods.IsPowOfTwo(numberInput)}"); // numberInput.IsPowOfTwo();

            Console.WriteLine("\n======== Is prime check ========");
            Console.Write("Please, enter a number: ");
            int primeInput = int.Parse( Console.ReadLine() );
            Console.WriteLine($"Answer: {primeInput.IsPrime()}"); // ExtentionMethods.IsPrime(primeInput);

        }
    }
}