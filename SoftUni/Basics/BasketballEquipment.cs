using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace SoftUni
{
    public static class BasketballEquipment
    {
        public static int ValidateInput(string input)
        {
            var isValid = int.TryParse(input, out var yearTax);
            if (!isValid && yearTax <= 0 && yearTax > 999)
            {
                Console.WriteLine("Please enter valid integer between 0 and 999");
                Console.ReadLine();
            }

            return yearTax;
        }

        public static decimal DefineShoesPrice(int yearTax)
        {
            var part = (decimal) 40 / 100 * yearTax;
            var shoesPrice = yearTax - part;
            return shoesPrice;
        }   
        
        public static decimal DefineClothesPrice(decimal shoesPrice)
        {
            var clothesPrice = shoesPrice - ((decimal)20 /100 * shoesPrice);
            return clothesPrice;
        }       
        
        public static decimal DefineBallPrice(decimal clothesPrice)
        {
            var ballPrice = (decimal)1 / 4 * clothesPrice;
            return ballPrice;
        }        
        public static decimal DefineAccessoriesPrice(decimal ballPrice)
        {
            var accessoriesPrice = (decimal)1/5 * ballPrice;
            return accessoriesPrice;
        }

        public static void ReturnTotalCost(string input)
        {
            var yearTax = ValidateInput(input);
            var shoesPrice = DefineShoesPrice(yearTax);
            var clothesPrice = DefineClothesPrice(shoesPrice);
            var ballPrice = DefineBallPrice(clothesPrice);
            var accessories = DefineAccessoriesPrice(ballPrice);

            var total = Math.Round(yearTax + shoesPrice + ballPrice + clothesPrice + accessories , 2);
            
            Console.WriteLine(total);
        }
    }
}