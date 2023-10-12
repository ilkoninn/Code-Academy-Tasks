using ConsoleApp2;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            Store phones = new Store();

            Console.WriteLine("============== Admin Account ==============\n" +
                "Welcome to our Phone Admin Dashboard! :D");
            do
            {
                Console.WriteLine(
                    "\n1. Add Phone to DATA\n" +
                    "2. Show info about Phone\n" +
                    "3. Show all Phone DATA\n" +
                    "4. Show Phones' prices between inputs\n" +
                    "5. Remove Phone from DATA\n" +
                    "6. Exit\n");
                Console.Write("Please, choos a number(1-7): ");
                int userChoice = int.Parse(Console.ReadLine());
                Menu(phones, userChoice);
                if(userChoice == 6) running = false;

            } while (running);
            Console.WriteLine("===========================================");

        }
        public static void Menu(Store phones, int choice) 
        {
            int phoneId = 0;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nPlease enter Phone information:");
                    Console.Write("Name: ");
                    string phoneName = Console.ReadLine();
                    Console.Write("Brand Name: ");
                    string phoneBrand = Console.ReadLine();
                    Console.Write("Price: ");
                    double phonePrice = double.Parse(Console.ReadLine());     
                    Console.Write("Count: ");
                    int phoneCount = int.Parse(Console.ReadLine());
                    phoneId = phones.Phones.Length + 1;

                    Phone newPhone = new Phone(phoneName, phoneBrand, phonePrice, phoneCount, phoneId);
                    if (newPhone != null)
                    {
                        phones.AddPhone(newPhone);
                    }
                    else
                    {
                        Console.WriteLine("\nPhone not added to Data\n");
                    }
                    break;
                case 2:
                    Console.Write($"\nPlease, enter Phone's ID(1-{phones.Phones.Length}): ");
                    int inputId= int.Parse(Console.ReadLine());
                    phones.ShowInfo(inputId);
                    break;
                case 3:
                    Console.WriteLine("\nAll information about Phone Data:");
                    foreach (Phone phone in phones.ShowAllPhone())
                    {
                        Console.WriteLine($"\n{phone.Id}. Phone information:\n" +
                            $"Phone name: {phone.PhoneName}\n" +
                            $"Phone brand name: {phone.BrandName}\n" +
                            $"Phone price: {phone.Price}\n" +
                            $"Phone count in Data: {phone.Count}");
                    }
                    break;
                case 4:
                    Console.Write("\nPlease, enter minimum price for phone: ");
                    int minPrice = int.Parse(Console.ReadLine());
                    Console.Write("Please, enter maximum price for phone: ");
                    int maxPrice = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nPhones between this prices:");
                    phones.ShowPhoneForPrice(minPrice, maxPrice);
                    break;
                case 5:
                    Console.Write("Please, enter Phone ID for delete the item: ");
                    int userInput = int.Parse(Console.ReadLine());
                    
                    phones.RemovePhone(userInput);
                    break;
                case 6:
                    Console.WriteLine("\n      Program has been stopped!\n");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}
