using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public static class NumberOfPeopleInTheBus
    {
        public static int Number(List<int[]> peopleListInOut)
        {
            var peopleIn = peopleListInOut.Select(x => x.First()).ToList();
            var peopleOut = peopleListInOut.Select(x => x.Last()).ToList();

            var peopleInTheBus = peopleIn.Sum() - peopleOut.Sum();

            return peopleInTheBus;
        }
    }
}