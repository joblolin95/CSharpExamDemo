using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostics
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] name =
            {
                'J','o','s','e','p','h',' ','O','l','i','n'
            };

            for(int i = 0; i < 3000000; i++)
            {
                var stringName = BuildName(name);
                var stringBuilderName = BuildNameWithStringBuilder(name);

                Console.WriteLine(stringName);
                Console.WriteLine(stringBuilderName);
            }
            Console.WriteLine("Done!");
            ProgramFlow.Class1.Pause();

        }

        public static string BuildName(char [] nameLetters)
        {
            var name = "";
            for(int i = 0; i < nameLetters.Length; i++)
            {
                name += nameLetters[i];
            }
            return name;
        }

        public static string BuildNameWithStringBuilder(char[] nameLetters)
        {
            StringBuilder name = new StringBuilder();
            for(int i = 0; i < nameLetters.Length; i++)
            {
                name.Append(nameLetters[i]);
            }

            return name.ToString();
        }
        
    }
}
