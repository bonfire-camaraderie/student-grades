using System.Collections.Generic;
using System.IO;

namespace Student_Grades
{
    public class FileReader
    {
        public Dictionary<string, int[]> GetTXTContent()
        {
            IDictionary<string, int[]> gradesDictionary = new Dictionary<string, int[]>();
            string line;

            StreamReader file = new StreamReader("grades.txt");

            while ((line = file.ReadLine()) != null)
            {
                string[] array = line.Split(',');

                string studentName = array[0];
                int[] studentGrades = new int[5];

                gradesDictionary.Add(studentName, null);

                for (int i = 1; i < array.Length; i++)
                {
                    string grade = array[i];

                    switch (grade)
                    {
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                        case "5":
                            studentGrades[i - 1] = int.Parse(grade);
                            break;
                        default:
                            studentGrades[i - 1] = 5;
                            break;
                    }
                }

                gradesDictionary[studentName] = studentGrades;
            }
            
            file.Close();

            return (Dictionary<string, int[]>)gradesDictionary;
        }
    }
}