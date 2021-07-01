using System;
using System.Collections.Generic;

namespace SoftUni
{
    public static class EasterMarket
    {
        public static void EasterMarketTask()
        {
            var countOfClients = int.Parse(Console.ReadLine());

            var exitCommand = "";
            var stocksAndPrices = new Dictionary<string, decimal>();
            stocksAndPrices.Add("basket", (decimal) 1.50);
            stocksAndPrices.Add("wreath", (decimal) 3.80);
            stocksAndPrices.Add("chocolate bunny", 7);

            decimal totalSumOfAllClients = 0;

            for (int i = 0; i < countOfClients; i++)
            {
                var countStocks = 0;

                decimal purchasePrice = 0;

                while (exitCommand != "Finish")
                {
                    var inputStock = Console.ReadLine();
                    countStocks++;

                    switch (inputStock)
                    {
                        case "basket":
                            purchasePrice += stocksAndPrices[inputStock];
                            break;

                        case "wreath":
                            purchasePrice += stocksAndPrices[inputStock];
                            break;

                        case "chocolate bunny":
                            purchasePrice += stocksAndPrices[inputStock];
                            break;
                    }

                    Console.WriteLine("Finish? ");
                    exitCommand = Console.ReadLine();
                }

                if (countStocks % 2 == 0)
                {
                    purchasePrice -= purchasePrice * (decimal) 0.20;
                }

                totalSumOfAllClients += purchasePrice;
            }

            var average = totalSumOfAllClients / countOfClients;
        }
    }
}