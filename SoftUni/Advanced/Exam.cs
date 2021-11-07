using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUni.Advanced
{
    class Exam
    {
        public static void FoodFinder()
        {
            var vowelsInput = Console.ReadLine().Split(' ').Select(char.Parse).ToList();
            var consonantsInput = Console.ReadLine().Split(' ').Select(char.Parse).ToList();

            var vowels = new Queue<char>();
            var consonants = new Stack<char>();

            vowelsInput.ForEach(x => vowels.Enqueue(x));
            consonantsInput.ForEach(x => consonants.Push(x));

            var listOfWords = new List<string> { "pear", "flour", "pork", "olive" };
            var containingLetters = new List<char>();

            while (consonants.Any())
            {
                var currentConsonant = consonants.Pop();

                if (listOfWords.Any(word => word.Contains(currentConsonant)))
                {
                    containingLetters.Add(currentConsonant);
                }
            }

            containingLetters.AddRange(vowels.ToList());

            var foundWords = listOfWords.Where(word => word.All(x => containingLetters.Any(cl => cl == x))).ToList();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Words found: {foundWords.Count}");
            foreach (var foundWord in foundWords)
            {
                stringBuilder.AppendLine(foundWord);
            }

            Console.WriteLine(stringBuilder.ToString().TrimEnd());
        }
    }
}