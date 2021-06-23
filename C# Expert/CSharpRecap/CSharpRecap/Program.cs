using CSharpRecap.Assignment1;
using CSharpRecap.Assignment2;
using CSharpRecap.Assignment3;
using System;
using System.Threading.Tasks;

namespace CSharpRecap
{
    class Program
    {
        static async Task Main(string[] args)
        {            
            Console.WriteLine("============================== Assignment 1 ============================== ");
            Console.WriteLine("========================================================================== " + Environment.NewLine);
            
            Assignment_1.Execute();
                        
            Console.WriteLine(Environment.NewLine + "============================== Assignment 2 ============================== ");
            Console.WriteLine("========================================================================== " + Environment.NewLine);
            
            await Assignment_2.Execute();

            Console.WriteLine(Environment.NewLine + "============================== Assignment 3 ============================== ");
            Console.WriteLine("========================================================================== " + Environment.NewLine);
            
            Assignment_3.Execute();

            Console.ReadLine();
        }

    }
}