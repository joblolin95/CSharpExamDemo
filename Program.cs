using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExamDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person joseph = new Person();
            joseph.FirstName = "Joseph";
            joseph.LastName = "Olin";
            

            var type = joseph.GetType();

            var property = type.GetProperty("ageInYears");
            var age = property.GetValue(joseph, null);
            var method = type.GetMethod("eat");

            var printOut = (string)method.Invoke(joseph, null);
            Console.WriteLine(printOut + " and is " + age + " years old");

            ProgramFlow.Class1.Pause();
        }
    }
}
