using System.Collections.Generic;

namespace Student_Grades
{
    public class Grades
    {
        private IDictionary<string, int[]> gradesDictionary;

        public Grades(IDictionary<string, int[]> gradesDictionary)
        {
            this.gradesDictionary = gradesDictionary;
        }

        public void SetGradeDictionary(IDictionary<string, int[]> gradesDictionary)
        {
            this.gradesDictionary = gradesDictionary;
        }

        public IDictionary<string, int[]> GetGradeDictionary()
        {
            return this.gradesDictionary;
        }

        public int[] GetStudentGrades(string studentName)
        {

            if (this.gradesDictionary.TryGetValue(studentName, out int[] value))
            {
                return value;
            }

            return null;
        }

        public IDictionary<string, List<string>> GetBestWorstStudent()
        {
            List<string> bestStudents = new List<string>();
            List<string> worstStudents = new List<string>();
            int highestAverage = 1;
            int lowestAverage = 5;

            IDictionary<string, List<string>> bestWorstStudents = new Dictionary<string, List<string>>();

            foreach (KeyValuePair<string, int[]> entry in this.gradesDictionary)
            {
                int sum = 0;

                foreach (int grade in entry.Value)
                {
                    sum += grade;
                }

                int averageGrade = sum / entry.Value.Length;

                if (averageGrade == highestAverage)
                {
                    worstStudents.Add(entry.Key);
                }

                if (averageGrade == lowestAverage)
                {
                    bestStudents.Add(entry.Key);
                }

                if (averageGrade > highestAverage)
                {
                    highestAverage = averageGrade;
                    bestStudents.Clear();
                    worstStudents.Add(entry.Key);
                }

                if (averageGrade < lowestAverage)
                {
                    lowestAverage = averageGrade;
                    bestStudents.Clear();
                    bestStudents.Add(entry.Key);
                }
            }

            bestWorstStudents.Add("Best Students", bestStudents);
            bestWorstStudents.Add("Worst Students", worstStudents);

            return bestWorstStudents;
        }

        public List<string> GetBetterStudents(int averageGrade)
        {
            List<string> betterStudents = new List<string>();

            foreach (KeyValuePair<string, int[]> entry in this.gradesDictionary)
            {
                int sum = 0;

                foreach (int grade in entry.Value)
                {
                    sum += grade;
                }

                int currentAverageGrade = sum / entry.Value.Length;

                if (currentAverageGrade < averageGrade)
                {
                    betterStudents.Add(entry.Key);
                }
            }

            return betterStudents;
        }

        public int GetOverallAverageGrade()
        {
            int numberOfGrades = 0;
            int sum = 0;

            foreach (KeyValuePair<string, int[]> entry in this.gradesDictionary)
            {
                foreach (int grade in entry.Value)
                {
                    sum += grade;
                }

                numberOfGrades += entry.Value.Length;
            }

            return sum / numberOfGrades;
        }
    }
}