using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUni
{
    public static class DartsGame
    {
        public static void CalculateGame()
        {
            var player = Console.ReadLine();

            var random = new Random();
            var fields = new List<string> {"Single", "Double", "Triple"};
            var startScore = 301;

            while (Console.ReadLine() != "Retire" && startScore != 0)
            {
                var hitField = fields[random.Next(2)];
                var hitScore = random.Next(0, 100);

                switch (hitField)
                {
                    case "Double":
                        hitScore *= 2;
                        break;

                    case "Triple":
                        hitScore *= 3;
                        break;

                    default:
                        hitScore *= 1;
                        break;
                }

                if (hitScore > startScore)
                {
                    continue;
                }
                startScore = startScore - hitScore;
            }

        }
    }
}