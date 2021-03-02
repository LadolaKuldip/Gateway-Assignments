using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string output;

            //Case 1
            output = ExtensionMethods.StringConvert(inputString, "UppartoLower");

            //Case 2
            output = ExtensionMethods.StringConvert(inputString, "TitleCase");

            //Case 3
            output = ExtensionMethods.StringConvert(inputString, "Capitalized");

            //Case 4
            output = ExtensionMethods.StringConvert(inputString, "CheckLower");

            //Case 5
            output = ExtensionMethods.StringConvert(inputString, "CheckUppar");

            //Case 6
            output = ExtensionMethods.StringConvert(inputString, "CheckforInt");

            //Case 7
            output = ExtensionMethods.StringConvert(inputString, "RemoveLastChar");

            //Case 8
            output = ExtensionMethods.StringConvert(inputString, "WordCount");

            //Case 9
            output = ExtensionMethods.StringConvert(inputString, "StringToInt");
        }
    }
}
