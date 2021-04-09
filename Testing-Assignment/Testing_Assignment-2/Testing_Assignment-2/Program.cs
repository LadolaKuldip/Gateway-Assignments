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
            Console.WriteLine("ChangeCase :" + input.InvertsCase());

            //Case 2
            Console.WriteLine("ConvertTitleCase :" + input.ConvertToTitleCase());

            //Case 3
            Console.WriteLine("ConvertCapitalized :" + input.ConvertToCapitalized());

            //Case 4
            Console.WriteLine("CheckForLower :" + input.CheckForLowercase());

            //Case 5
            Console.WriteLine("CheckForUppar :" + input.CheckForUpparcase());

            //Case 6
            Console.WriteLine("CheckforInt :" + input.CheckForInteger());

            //Case 7
            Console.WriteLine("RemoveLastChar :" + input.RemoveLastCharacter());

            //Case 8
            Console.WriteLine("WordCount :" + input.CountNoOfWords());

            //Case 9
            Console.WriteLine("StringToInt :" + input.StringToInt());

            Console.ReadLine();
        }
    }
}
