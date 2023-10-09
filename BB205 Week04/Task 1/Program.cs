using ConsoleApp12;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Alabas", 5);
            Cat cat = new Cat("Atlas", 3);
            Snake snake = new Snake("Poison", 4);
            Dolphin dolphin = new Dolphin("Merlin", 8);

            dog.Breed = "Golden";
            cat.Breed = "British Shorthair";
            snake.Breed = "Piton";
            dolphin.Breed = "Spinner";

            Console.WriteLine("Dog information:");
            dog.getInfo();
            Console.WriteLine("\nCat information:");
            cat.getInfo();
            Console.WriteLine("\nSnake information:");
            snake.getInfo();
            Console.WriteLine("\nDolphin information:");
            dolphin.getInfo();

            // Snake is poisonous?
            Console.WriteLine("\n==================================================\n");
            Console.WriteLine("Information about snake is poisonous or not:");
            snake.IsPoisonous = false;
            


            Console.ReadKey();

        }
    }
}