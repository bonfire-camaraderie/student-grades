using System;
using System.Collections.Generic;

namespace Student_Grades
{
    public class Bot
    {
        public void ProcessOperation(Grades grades)
        {
            char option = Console.ReadKey().KeyChar;
            Console.Clear();

            switch (option)
            {
                case '0':
                    System.Environment.Exit(1);
                    break;
                case '1':
                    foreach (KeyValuePair<string, int[]> entry in grades.GetGradeDictionary())
                    {
                        string line = entry.Key + ": " + String.Join(", ", entry.Value);
                        Console.WriteLine(line);
                    }
                    break;
                case '2':
                    Console.WriteLine("\nEnter please name of the student");
                    string name = Console.ReadLine();
                    Console.WriteLine(name + ": " + String.Join(", ", grades.GetStudentGrades(name)));
                    break;
                case '3':
                    foreach (KeyValuePair<string, List<string>> entry in grades.GetBestWorstStudent())
                    {
                        string line = entry.Key + ": " + String.Join(", ", entry.Value);
                        Console.WriteLine(line);
                    }
                    break;
                case '4':
                    Console.WriteLine("Enter please the grade");

                    if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int grade))
                    {
                        Console.Clear();
                        Console.WriteLine(String.Join(", ", grades.GetBetterStudents(grade)));
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid grade has been provided!");
                    }         
                    break;
                case '5':
                    Console.WriteLine(grades.GetOverallAverageGrade());
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }

        public void ShowOptions()
        {
            Console.Clear();
            Console.WriteLine("WELCOME!");
            Console.WriteLine("PLEASE SELECT OPTION:");
            Console.WriteLine("1 - View all students and grades");
            Console.WriteLine("2 - View grades of specific student");
            Console.WriteLine("3 - View students of the best and worst average grades");
            Console.WriteLine("4 - View students with better average grade than ...");
            Console.WriteLine("5 - View overall average grade");
            Console.WriteLine("0 - EXIT");
        }

        public void Welcome()
        {
            Console.WriteLine("WELCOME!\n");
        }
    }
}