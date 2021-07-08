using System;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = Console.ReadLine();

            var diesPairs = inputString.Split("##");
            Console.WriteLine(string.Join(' ', diesPairs));
        }
    }
}