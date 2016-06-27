using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExamDemo
{
    public class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int ageInYears { get; set; } = 0;

        public void eat()
        {
            Console.WriteLine(FirstName + " " + LastName + " just ate");
        }

    }
}
