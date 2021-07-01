using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUni
{
    class ForLoops
    {
        public static void HalfSumElement()
        {
            var numCount = int.Parse(Console.ReadLine());
            var allNums = new int[numCount];
            var totalSum = 0;
            for (int i = 0; i < numCount; i++)
            {
                var currNum = int.Parse(Console.ReadLine());
                allNums[i] = currNum;
                totalSum += currNum;
            }

            var isEqualToSum = false;

            foreach (var currentNumber in allNums)
            {
                if ((totalSum - currentNumber) == currentNumber)
                {
                    Console.WriteLine("Yes");
                    Console.WriteLine($"Sum = {currentNumber}");
                    isEqualToSum = true;
                    break;
                }
            }

            var maxElement = allNums.Max();

            if (!isEqualToSum)
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(maxElement - (allNums.Sum() - maxElement))}");
            }
        }
    }
}