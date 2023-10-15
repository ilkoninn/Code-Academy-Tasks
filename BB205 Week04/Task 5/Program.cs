using System.ComponentModel.Design;
using System.Threading.Channels;

namespace ConsoleApp4
{
    internal class Program
    {
        static int idCount = 1;
        static void Main(string[] args)
        {

            Group newGroup = new Group();
            bool running = true;

            Console.WriteLine("================ Class App ================");
            do
            {
                if(newGroup.No == "false" || newGroup.StudentLimit == 0)
                {
                    Console.WriteLine("\n\t========= Menu =========\n\n" +
                    "\t1. Create group\n" +
                    "\t2. Exit\n");
                    Console.Write("Please, enter a number(1-2): ");
                    int userChoice = int.Parse(Console.ReadLine());
                    if(userChoice == 2) running = false;

                    FirstMenu(newGroup, userChoice);
                    if (newGroup.No == null)
                    {
                        Console.Write("\nDo you want to continue?(Y/N): ");
                        string userContinue = Console.ReadLine();
                        if (userContinue.ToLower() == "y" || userContinue.ToLower() == "yes")
                        {
                            running = true;
                        }
                        else
                        {
                            running = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"\n\t========= {newGroup.No} =========\n\n" +
                    "\t1. Add student\n" +
                    "\t2. Remove student\n" +
                    "\t3. Show all students\n" +
                    "\t4. Filter students by name\n" +
                    "\t5. Exit\n");
                    Console.Write("Please, enter a number(1-5): ");
                    int userChoice = int.Parse(Console.ReadLine());
                    if (userChoice == 5) running = false;
                    Menu(newGroup, userChoice);
                }

                ;

            } while (running);
            Console.WriteLine("\n\tProgram has been stopped!\n");
            Console.WriteLine("===========================================");
        }
        public static void FirstMenu(Group newGroup,int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("\nPlease, enter group informations:");
                    Console.Write("Group No("AA000"): ");
                    string userInput = Console.ReadLine();
                    Console.Write("Student limit(5-18): ");
                    int userInput2 = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    newGroup.No = userInput;
                    newGroup.StudentLimit = userInput2;
                    if (newGroup.No != "false" && newGroup.StudentLimit != 0) Console.WriteLine("New group has been created!");
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("\nUser input is invalid!");
                    break;
            }
        }
        public static void Menu(Group newGroup, int userChoice) 
        {
            
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("\nPlease, enter student's information: ");
                    Console.Write("Student name: ");
                    string studentName = Console.ReadLine();
                    Console.Write("Student surname: ");
                    string studentSurname = Console.ReadLine();
                    Console.Write("Student average point(1-100): ");
                    byte avgPoint = byte.Parse(Console.ReadLine());
                    
                    Student student = new Student(studentName, studentSurname, avgPoint, idCount++);
                    newGroup.AddStudent(student);

                    break;
                case 2:
                    Console.Write($"\nPlease, enter student ID(1-{newGroup.ShowAllStudent().Length}) for delete: ");
                    int userInput = int.Parse(Console.ReadLine());

                    newGroup.RemoveStudent(userInput);
                    break;
                case 3:
                    Console.WriteLine($"\n======= {newGroup.No} class students =======\n");
                    Console.WriteLine("ID. First name | Last name | Average point");
                    int count = 1;
                    foreach (Student item in newGroup.ShowAllStudent())
                    {
                        Console.WriteLine($"{item.GetStudentInfo()}");
                        count++;
                    }
                    break;
                case 4:
                    Console.Write("\nPlease, enter text for searching: ");
                    string ourText = Console.ReadLine();
                    Console.WriteLine("\n======= All Students for input =======\n");
                    foreach(Student item in newGroup.FilterByName(ourText))
                    {
                        Console.WriteLine($"Student name: {item.Name}\n" +
                            $"Student surname: {item.Surname}\n" +
                            $"Student average point: {item.AvgPoint}\n");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}
