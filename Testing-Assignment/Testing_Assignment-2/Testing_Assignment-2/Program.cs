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
            string input = Console.ReadLine();

            //Case 1
            Console.WriteLine("ChangeCase :" + input.ChangeCase());

            //Case 2
            Console.WriteLine("ConvertTitleCase :" + input.ConvertTitleCase());

            //Case 3
            Console.WriteLine("ConvertCapitalized :" + input.ConvertCapitalized());

            //Case 4
            Console.WriteLine("CheckForLower :" + input.CheckForLower());

            //Case 5
            Console.WriteLine("CheckForUppar :" + input.CheckForUppar());

            //Case 6
            Console.WriteLine("CheckforInt :" + input.CheckforInt());

            //Case 7
            Console.WriteLine("RemoveLastChar :" + input.RemoveLastChar());

            //Case 8
            Console.WriteLine("WordCount :" + input.WordCount());

            //Case 9
            Console.WriteLine("StringToInt :" + input.StringToInt());

            Console.ReadLine();
        }
    }
}
