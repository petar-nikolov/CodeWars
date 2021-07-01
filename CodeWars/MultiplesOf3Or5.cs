using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    public static class MultiplesOf3Or5
    {
        public static int Solution(int value)
        {
            var listOfNums = new List<int>();
            for (int i = 0; i < value; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    listOfNums.Add(i);
                }
            }

            return listOfNums.Sum();
        }
    }
}
