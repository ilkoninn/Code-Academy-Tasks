using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Group
    {
        private string _no;
        public string No 
        { 
            get 
            { 
                return _no; 
            } 
            set 
            {
                if (CheckNo(value))
                {
                    _no = value;
                }
                else
                {
                    _no = "false";
                    Console.WriteLine("Group No value is invalid!");
                }
            }
        }
        private int _studentLimit;
        public int StudentLimit
        {
            get
            {
                return _studentLimit;
            }
            set
            {
                if(value >= 5 && value <= 18)
                {
                    _studentLimit = value;
                }
                else
                {
                    _studentLimit = 0;
                    Console.WriteLine("Group students limit value is invalid!");
                }
            }
        }
        public Student[] Students;
        public Group()
        {
            Students = new Student[0];
        }

        public void AddStudent(Student student)
        {
            if (Students.Length < StudentLimit)
            {
                Array.Resize(ref Students, Students.Length + 1);
                Students[Students.Length - 1] = student;
            }
            else
            {
                Console.WriteLine("\nGroup is full(You can not add another student!)");
            }
        }
        public void RemoveStudent(int studentId)
        {
            bool idCheck = false;
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i].Id == studentId)
                {
                    idCheck = true;
                    break;
                }
            }
            if (idCheck)
            {
                Student[] newStudents = new Student[Students.Length - 1];
                int index = 0;

                for (int i = 0; i < Students.Length; i++)
                {
                    if (Students[i].Id != studentId)
                    {
                        newStudents[index] = Students[i];
                        index++;
                    }
                }
                Students = newStudents;
                for (int i = 0;i < Students.Length; i++)
                {
                    if (Students[i].Id == studentId)
                    {
                        Console.WriteLine($"\n{Students[i].Name} {Students[i].Surname} has been removed from {No}");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"\nThere is no such a student in {No} class!");
            }
        }

        public Student[] ShowAllStudent()
        {
            return Students;
        }
        
        public Student[] FilterByName(string text)
        {
            Student[] newData = new Student[0];
            for (int i = 0; i < Students.Length; i++)
            {
                if ($"{Students[i].Name} {Students[i].Surname}".ToLower().Contains(text.ToLower()))
                {
                    Array.Resize(ref newData, newData.Length + 1);
                    newData[newData.Length - 1] = Students[i];
                }
            }

            return newData;
        }

        public bool CheckNo(string value)
        {
            if (char.IsUpper(value[0]) && char.IsUpper(value[1]) &&
                char.IsDigit(value[2]) && char.IsDigit(value[3]) &&
                char.IsDigit(value[4])) return true;
            return false;
        }
        
    }
}
