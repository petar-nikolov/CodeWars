using System;
using System.ComponentModel.Design;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace SoftUni
{
    public static class ExamPrep
    {
        public static void AgencyIncome()
        {
            var companyName = Console.ReadLine();
            var adultsTickets = int.Parse(Console.ReadLine());
            var childTickets = int.Parse(Console.ReadLine());
            var netPrice = decimal.Parse(Console.ReadLine());
            var taxMaintenance = decimal.Parse(Console.ReadLine());

            var totalAdultTicketPrice = netPrice + taxMaintenance;
            var totalChildTicketPrice = netPrice - (0.7m * netPrice) + taxMaintenance;

            var totalProfit = (adultsTickets * totalAdultTicketPrice + childTickets * totalChildTicketPrice) * 0.2m;

            Console.WriteLine($"The profit of your agency from {companyName} tickets is {totalProfit:f2} lv.");
        }

        public static void CatWalk()
        {
            var minutesWalk = int.Parse(Console.ReadLine());
            var countOfWalksPerDay = int.Parse(Console.ReadLine());
            var caloriesIncome = int.Parse(Console.ReadLine());

            var totalWalkingMinutesBurnedCalories = minutesWalk * countOfWalksPerDay * 5;
            var halfCalories = caloriesIncome / 2;

            if (totalWalkingMinutesBurnedCalories >= halfCalories)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {totalWalkingMinutesBurnedCalories}. ");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day:{totalWalkingMinutesBurnedCalories}.");
            }
        }

        public static void CoffeeMachine()
        {
            var drink = Console.ReadLine();
            var sugar = Console.ReadLine();
            var countDrinks = int.Parse(Console.ReadLine());

            var drinkPrice = 0m;

            switch (drink)
            {
                case "Espresso":
                    switch (sugar)
                    {
                        case "Without":
                            drinkPrice = 0.90m;
                            break;
                        case "Normal":
                            drinkPrice = 1.00m;
                            break;
                        case "Extra":
                            drinkPrice = 1.20m;
                            break;
                        default:
                            Console.WriteLine("Wrong input, try again:");
                            Console.ReadLine();
                            break;
                    }

                    break;

                case "Cappuccino":
                    switch (sugar)
                    {
                        case "Without":
                            drinkPrice = 1.00m;
                            break;
                        case "Normal":
                            drinkPrice = 1.20m;
                            break;
                        case "Extra":
                            drinkPrice = 1.60m;
                            break;
                        default:
                            Console.WriteLine("Wrong input, try again:");
                            Console.ReadLine();
                            break;
                    }

                    break;

                case "Tea":
                    switch (sugar)
                    {
                        case "Without":
                            drinkPrice = 0.50m;
                            break;
                        case "Normal":
                            drinkPrice = 0.60m;
                            break;
                        case "Extra":
                            drinkPrice = 0.70m;
                            break;
                        default:
                            Console.WriteLine("Wrong input, try again:");
                            Console.ReadLine();
                            break;
                    }

                    break;

                default:
                    Console.WriteLine("Wrong input, try again:");
                    Console.ReadLine();
                    break;
            }

            var total = countDrinks * drinkPrice;

            if (total > 15m)
            {
                total = total - (0.20m * total);
            }

            if (sugar == "Without")
            {
                total = total - (0.35m * total);
            }

            if (drink == "Espresso" && countDrinks >= 5)
            {
                total = total - (0.25m * total);
            }

            Console.WriteLine($"You bought {countDrinks} cups of {drink} for {total:f2} lv.");
        }

        public static void TrackingMania()
        {
            var musala = 0d;
            var montblan = 0d;
            var kilimandjaro = 0d;
            var k2 = 0d;
            var everest = 0d;

            var groupsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < groupsCount; i++)
            {
                var peopleInGroup = int.Parse(Console.ReadLine());
                if (peopleInGroup <= 5)
                {
                    musala += peopleInGroup;
                }
                else if (peopleInGroup >= 6 && peopleInGroup <= 12)
                {
                    montblan += peopleInGroup;
                }
                else if (peopleInGroup >= 13 && peopleInGroup <= 25)
                {
                    kilimandjaro += peopleInGroup;
                }
                else if (peopleInGroup >= 26 && peopleInGroup <= 40)
                {
                    k2 += peopleInGroup;
                }
                else if (peopleInGroup >= 41)
                {
                    everest += peopleInGroup;
                }
            }

            var totalCountOfPeople = musala + montblan + kilimandjaro + k2 + everest;

            var musalaPercent = (musala / totalCountOfPeople) * 100;
            var montblanPercent = (montblan / totalCountOfPeople) * 100;
            var kilimandjaroPercent = (kilimandjaro / totalCountOfPeople) * 100;
            var k2Percent = (k2 / totalCountOfPeople) * 100;
            var everestPercent = (everest / totalCountOfPeople) * 100;

            Console.WriteLine($"{musalaPercent:f2}% изкачващи Мусала");
            Console.WriteLine($"{montblanPercent:f2}% изкачващи Монблан");
            Console.WriteLine($"{kilimandjaroPercent:f2}% изкачващи Килиманджаро");
            Console.WriteLine($"{k2Percent:f2}% изкачващи К2");
            Console.WriteLine($"{everestPercent:f2}% изкачващи Еверест");
        }

        public static void MovieStars()
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