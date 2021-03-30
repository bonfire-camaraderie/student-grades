using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            Grades grades = new Grades(fileReader.GetTXTContent());

            Bot bot = new Bot();

            bot.StartChat(grades);         
        }
    }
}
