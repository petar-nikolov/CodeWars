using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWars
{
    /// <summary>
    /// In this kata you will create a function that takes a list of non-negative integers and strings and returns a new list with the strings filtered out.
    ///ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b"}) => {1, 2}
    ///ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b", 0, 15}) => { 1, 2, 0, 15}
    ///ListFilterer.GetIntegersFromList(new List<object>() { 1, 2, "a", "b", "aasf", "1", "123", 231 }) => { 1, 2, 231}
    /// </summary>
    public static class ListFiltering
    {
        public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
        {
            var listToReturn = new List<int>();
            foreach (object listOfItem in listOfItems)
            {
                if (listOfItem.GetType().Name.Equals(nameof(Int32)))
                {
                    listToReturn.Add((int)listOfItem);
                }
            }

            return listToReturn;
        }
    }
}