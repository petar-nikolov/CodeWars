using System;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = decimal.Parse(Console.ReadLine());
            var leftBudget = budget;
            while (leftBudget > 0)
            {
                var actorsName = Console.ReadLine();

                if (actorsName == "ACTION")
                {
                    break;
                }

                if (actorsName.Length > 15)
                {
                    var actorsBudget = 0.2m * leftBudget;
                    leftBudget -= actorsBudget;
                }

                if (actorsName.Length <= 15)
                {
                    var curActorBudget = decimal.Parse(Console.ReadLine());
                    leftBudget -= curActorBudget;
                }

                if (leftBudget < 0m)
                {
                    Console.WriteLine($"We need {Math.Abs(leftBudget):f2} leva for our actors.");
                    return;
                }
            }

            if (leftBudget < 0m)
            {
                Console.WriteLine($"We need {Math.Abs(leftBudget):f2} leva for our actors.");
            }
            else
            {
                Console.WriteLine($"We are left with {leftBudget:f2} leva.");
            }
        }
    }
}