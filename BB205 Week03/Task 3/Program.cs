namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Developer section
            Developer developerEmployee = new Developer();
            developerEmployee.name = "Ilkin";
            developerEmployee.surname = "Rajabov";
            developerEmployee.age = 19;
            developerEmployee.experience = 2;

            Console.WriteLine("=================================\n" +
                "Information about new Developer\n");
            Console.WriteLine("First name: " + developerEmployee.name);
            Console.WriteLine("Last name: " + developerEmployee.surname);
            Console.WriteLine("Age: " + developerEmployee.age);
            Console.WriteLine("Experience:" + developerEmployee.experience);

            // Backend section
            Backend backendEmployee = new Backend("Miraga", "Eliyev");
            backendEmployee.age = 19;
            backendEmployee.experience = 3;
            backendEmployee.sqlExperienceYear = 2;
            Console.WriteLine("\n===========================================\n" +
                "Information about new Back-End developer\n");
            Console.WriteLine("First name: " + backendEmployee.name);
            Console.WriteLine("Last name: " + backendEmployee.surname);
            Console.WriteLine("Age: " + backendEmployee.age);
            Console.WriteLine("Experience: " + backendEmployee.experience);
            Console.WriteLine("SQL experience: " + backendEmployee.sqlExperienceYear);

            // Frontend section
            Frontend frontendEmployee = new Frontend();
            frontendEmployee.name = "Rufet";
            frontendEmployee.surname = "Quliyev";
            frontendEmployee.age = 19;
            frontendEmployee.experience = 1;
            frontendEmployee.ReactExperienceYear = 3;
            Console.WriteLine("\n===========================================\n" +
                "Information about new Front-End developer\n");
            Console.WriteLine("First name: " + frontendEmployee.name);
            Console.WriteLine("Last name: " + frontendEmployee.surname);
            Console.WriteLine("Age: " + frontendEmployee.age);
            Console.WriteLine("Experience: " + frontendEmployee.experience);
            Console.WriteLine("SQL experience: " + frontendEmployee.ReactExperienceYear);
            Console.WriteLine("\n===========================================");


            // Check section about are you hired or not
            Console.WriteLine("Recruitment information section\n\nFront-End developer: ");
            Console.WriteLine("Your answer:" + frontendEmployee.AreYouHired(frontendEmployee.experience, frontendEmployee.age));
            Console.WriteLine("Back-End developer:");
            Console.WriteLine("Your answer:" + backendEmployee.AreYouHired(backendEmployee.experience, backendEmployee.age));
            Console.WriteLine("Developer:");
            Console.WriteLine("Your answer:" + developerEmployee.AreYouHired(developerEmployee.experience, developerEmployee.age));

            Console.ReadKey();

        }
    }
}
