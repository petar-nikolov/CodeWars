using System;
using System.Threading.Channels;

namespace SoftUni
{
    public static class BasicsOfConditions
    {
        public static void SecondsSum()
        {
            var firstTime = int.Parse(Console.ReadLine());
            var secondTime = int.Parse(Console.ReadLine());
            var thirdTime = int.Parse(Console.ReadLine());

            var totalTime = firstTime + secondTime + thirdTime;

            var minutes = totalTime / 60;
            var seconds = totalTime % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }

        public static void BonusScore()
        {
            var input = int.Parse(Console.ReadLine());
            double bonus = 0.0;

            if (input <= 100)
            {
                bonus = 5;
            }

            else if (input > 100 && input <= 1000)
            {
                bonus = 0.2 * input;
            }
            else if (input > 1000)
            {
                bonus = 0.1 * input;
            }

            if (input % 2 == 0)
            {
                bonus += 1;
            }
            else if (input % 5 == 0)
            {
                bonus += 2;
            }

            Console.WriteLine(bonus);
            Console.WriteLine(input + bonus);
        }

        public static void SpeedInfo()
        {
            var input = double.Parse(Console.ReadLine());

            if (input <= 10)
            {
                Console.WriteLine("slow");
            }

            else if (input > 10 && input <= 50)
            {
                Console.WriteLine("average");
            }
            else if (input > 50 && input <= 150)
            {
                Console.WriteLine("fast");
            }
            else if (input > 150 && input <= 1000)
            {
                Console.WriteLine("ultra fast");
            }
            else
            {
                Console.WriteLine("extremely fast");
            }
        }

        public static void Convertor()
        {
            var metricValue = int.Parse(Console.ReadLine());
            var fromMetric = Console.ReadLine();
            var toMetric = Console.ReadLine();

            double convertedToMms = 1;

            if (fromMetric == "m")
            {
                convertedToMms *= metricValue * 1000;
            }
            else if (fromMetric == "cm")
            {
                convertedToMms = metricValue * 10;
            }

            else if (fromMetric == "mm")
            {
                convertedToMms = metricValue;
            }

            if (toMetric == "m")
            {
                convertedToMms /= 1000;
            }

            else if (toMetric == "cm")
            {
                convertedToMms /= 10;
            }

            Console.WriteLine($"{convertedToMms:f3}");
        }

        public static void GodzilaVsKong()
        {
            {
                var inputBudget = decimal.Parse(Console.ReadLine());
                var staticPersons = int.Parse(Console.ReadLine());
                var clothesPrice = decimal.Parse(Console.ReadLine());

                var decor = 0.1m * inputBudget;

                if (staticPersons > 150)
                {
                    clothesPrice -= clothesPrice * 0.1m;
                }

                if ((clothesPrice * staticPersons + decor) > inputBudget)
                {
                    Console.WriteLine("Not enough money!");
                    Console.WriteLine($"Wingard needs {(((clothesPrice * staticPersons) + decor) - inputBudget):f2} leva more.");
                }

                else
                {
                    Console.WriteLine("Action!");
                    Console.WriteLine($"Wingard starts filming with {(inputBudget - (clothesPrice * staticPersons) - decor):f2} leva left.");
                }
            }
        }

        public static void Add15Min()
        {
            var inputHours = Console.ReadLine();
            var inputMinutes = Console.ReadLine();
            var datetime = new DateTime(2021, 01, 01, int.Parse(inputHours), int.Parse(inputMinutes), 0).AddMinutes(15);
            Console.WriteLine($"{datetime:H:mm}");
        }

        public static void SwimRecord()
        {
            var record = double.Parse(Console.ReadLine());
            var distance = double.Parse(Console.ReadLine());
            var timePerMeter = double.Parse(Console.ReadLine());
            var slowDownCoef = 12.5;
            var timeForDistance = timePerMeter * distance;
            var timesToSlowdown = (distance / 15) * 12.5;
            var totalTime = timeForDistance + timesToSlowdown;

            if (totalTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }

            else
            {
                Console.WriteLine($"No, he failed! He was {(totalTime - record):f2} seconds slower.");
            }
        }

        public static void ScolarShip()
        {
            var income = decimal.Parse(Console.ReadLine());
            var avgCoef = decimal.Parse(Console.ReadLine());
            var minSalary = decimal.Parse(Console.ReadLine());

            var socialScolarShip = minSalary * 0.35m;
            var degreeScolarShip = avgCoef * 25;
            var highestScholarship = socialScolarShip > degreeScolarShip ? socialScolarShip : degreeScolarShip;
            if (avgCoef <= 4.50m && income > minSalary)
            {
                Console.WriteLine("You cannot get a scholarship!");
                return;
            }
            if(avgCoef > 4.50m && avgCoef < 5.50m && income < minSalary)
            {
                Console.WriteLine($"You get a Social scholarship {socialScolarShip} BGN");
            }
            else if (avgCoef > 5.50m && income > minSalary)
            {
                Console.WriteLine($"You get a scholarship for excellent results {degreeScolarShip} BGN");

            }

            else if (avgCoef > 5.50m && income < minSalary)
            {
                Console.WriteLine($"You get a scholarship for excellent results {highestScholarship} BGN");

            }
        }
    }
}