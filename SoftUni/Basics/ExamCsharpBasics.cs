using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUni
{
    public static class ExamCsharpBasics
    {
        public static void ChristmasPrep()
        {
            var paperRoll = int.Parse(Console.ReadLine());
            var clothRoll = int.Parse(Console.ReadLine());
            var glueAmount = decimal.Parse(Console.ReadLine());
            var discount = int.Parse(Console.ReadLine());

            var paperPrice = 5.80m;
            var clothPrice = 7.20m;
            var gluePrice = 1.20m;

            var total = (paperPrice * paperRoll) + (clothPrice * clothRoll) + (gluePrice * glueAmount);
            var finalPriceWithDiscount = total - ((discount / 100m) * total);

            Console.WriteLine($"{finalPriceWithDiscount:f3}");
        }

        public static void BraceletStand()
        {
            var totalDays = 5;
            var dailyMoney = decimal.Parse(Console.ReadLine());
            var dailyProfit = decimal.Parse(Console.ReadLine());
            var totalExpences = decimal.Parse(Console.ReadLine());
            var giftPrice = decimal.Parse(Console.ReadLine());

            var totalMoney = ((totalDays * dailyMoney) + (totalDays * dailyProfit)) - totalExpences;
            if (giftPrice > totalMoney)
            {
                Console.WriteLine($"Insufficient money: {(giftPrice - totalMoney):f2} BGN.");
            }
            else
            {
                Console.WriteLine($"Profit: {totalMoney:f2} BGN, the gift has been purchased.");
            }
        }

        public static void SantasHoliday()
        {
            var days = int.Parse(Console.ReadLine());
            var room = Console.ReadLine();
            var feedback = Console.ReadLine();

            var total = 0m;

            var pricePerNight = 0m;

            switch (room)
            {
                case "room for one person":
                    pricePerNight = 18m;
                    total = (days - 1) * pricePerNight;
                    break;

                case "apartment":
                    pricePerNight = 25m;
                    total = ((days - 1) * pricePerNight);

                    if (days < 10)
                    {
                        total = total - (0.3m * total);
                    }

                    if (days >= 10 && days <= 15)
                    {
                        total = total - (0.35m * total);
                    }

                    if (days > 15)
                    {
                        total = total - (0.5m * total);
                    }

                    break;

                case "president apartment":
                    pricePerNight = 35m;
                    total = ((days - 1) * pricePerNight);

                    if (days < 10)
                    {
                        total = total - (0.1m * total);
                    }

                    if (days >= 10 && days <= 15)
                    {
                        total = total - (0.15m * total);
                    }

                    if (days > 15)
                    {
                        total = total - (0.2m * total);
                    }

                    break;
            }

            if (feedback == "positive")
            {
                total = total + (0.25m * total);
            }

            if (feedback == "negative")
            {
                total = total - (0.1m * total);
            }

            Console.WriteLine($"{total:f2}");
        }

        public static void ComputerFirm()
        {
            var computerModels = int.Parse(Console.ReadLine());
            var totalRating = 0d;
            var totalSales = 0d;
            for (int i = 0; i < computerModels; i++)
            {
                var number = int.Parse(Console.ReadLine());

                var rating = number % 10;
                totalRating += rating;

                var possibleSales = (number / 10) % 100;
                var realSalesPercent = 0d;
                switch (rating)
                {
                    case 2:
                        realSalesPercent = 0;
                        break;
                    case 3:
                        realSalesPercent = 0.50;
                        break;
                    case 4:
                        realSalesPercent = 0.70;
                        break;
                    case 5:
                        realSalesPercent = 0.85;
                        break;
                    case 6:
                        realSalesPercent = 1;
                        break;
                }

                var currentSales = (realSalesPercent * possibleSales);
                totalSales += currentSales;
            }

            Console.WriteLine($"{totalSales:f2}");
            Console.WriteLine($"{totalRating / computerModels:f2}");
        }

        public static void ExcursionSales()
        {
            var seaCount = int.Parse(Console.ReadLine());
            var mountainCount = int.Parse(Console.ReadLine());
            var totalAmount = seaCount + mountainCount;

            var leftSea = seaCount;
            var leftMountain = mountainCount;

            var seaPrice = 680;
            var mountainPrice = 499;

            var profit = 0;

            while (totalAmount > 0)
            {
                var packetName = Console.ReadLine();
                if (packetName == "Stop")
                {
                    break;
                }

                switch (packetName)
                {
                    case "sea":
                        if (leftSea > 0)
                        {
                            leftSea--;
                            totalAmount--;
                            profit += seaPrice;
                        }

                        break;

                    case "mountain":
                        if (leftMountain > 0)
                        {
                            leftMountain--;
                            totalAmount--;
                            profit += mountainPrice;
                        }

                        break;
                }
            }

            if (totalAmount == 0)
            {
                Console.WriteLine("Good job! Everything is sold.");
            }

            Console.WriteLine($"Profit: {profit} leva.");
        }

        public static void UniquePinCodes()
        {
            var firstDigitsBoundary = int.Parse(Console.ReadLine());
            var secondDigitBoundary = int.Parse(Console.ReadLine());
            var thirdDigitBoundary = int.Parse(Console.ReadLine());

            var firstDigits = new List<int>();
            var secondDigits = new List<int>();
            var thirdDigits = new List<int>();

            for (int i = 1; i <= firstDigitsBoundary; i++)
            {
                if (i % 2 == 0)
                {
                    firstDigits.Add(i);
                }
            }

            if (secondDigitBoundary > 7)
            {
                secondDigitBoundary = 7;
            }

            for (int i = 2; i <= secondDigitBoundary; i++)
            {
                if (IsPrime(i))
                {
                    secondDigits.Add(i);
                }
            }

            for (int i = 1; i <= thirdDigitBoundary; i++)
            {
                if (i % 2 == 0)
                {
                    thirdDigits.Add(i);
                }
            }

            for (int i = 0; i < firstDigits.Count; i++)
            {
                for (int j = 0; j < secondDigits.Count; j++)
                {
                    for (int k = 0; k < thirdDigits.Count; k++)
                    {
                        Console.WriteLine($"{firstDigits[i]} {secondDigits[j]} {thirdDigits[k]}");
                    }
                }
            }
        }

        public static bool IsPrime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}