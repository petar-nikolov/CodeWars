using System;

namespace SoftUni
{
    public static class SealedConditions
    {
        public static void WeekDay()
        {
            var dayNum = int.Parse(Console.ReadLine());
            switch (dayNum)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        public static void WeekDayOrNot()
        {
            var dayNum = Console.ReadLine();
            switch (dayNum)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    Console.WriteLine("Working day");
                    break;
                case "Saturday":
                case "Sunday":
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        public static void Stores()
        {
            var product = Console.ReadLine();
            var city = Console.ReadLine();
            var amount = int.Parse(Console.ReadLine());

            var cityCost = 0m;

            if (city.Equals("Sofia"))
            {
                switch (product)
                {
                    case "coffee":
                        cityCost = 0.5m;
                        break;

                    case "water":
                        cityCost = 0.8m;
                        break;

                    case "beer":
                        cityCost = 1.2m;
                        break;

                    case "sweets":
                        cityCost = 1.45m;
                        break;

                    case "peanuts":
                        cityCost = 1.6m;
                        break;
                }
            }

            if (city.Equals("Plovdiv"))
            {
                switch (product)
                {
                    case "coffee":
                        cityCost = 0.4m;
                        break;

                    case "water":
                        cityCost = 0.7m;
                        break;

                    case "beer":
                        cityCost = 1.15m;
                        break;

                    case "sweets":
                        cityCost = 1.30m;
                        break;

                    case "peanuts":
                        cityCost = 1.5m;
                        break;
                }
            }

            if (city.Equals("Varna"))
            {
                switch (product)
                {
                    case "coffee":
                        cityCost = 0.45m;
                        break;

                    case "water":
                        cityCost = 0.7m;
                        break;

                    case "beer":
                        cityCost = 1.1m;
                        break;

                    case "sweets":
                        cityCost = 1.35m;
                        break;

                    case "peanuts":
                        cityCost = 1.55m;
                        break;
                }
            }

            Console.WriteLine($"{cityCost * amount:f4}");
        }

        public static void SkiHoliday()
        {
            var days = int.Parse(Console.ReadLine());
            var room = Console.ReadLine();
            var feedback = Console.ReadLine();

            var discount = 1m;
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
    }
}