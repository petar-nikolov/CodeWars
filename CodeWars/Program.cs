using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string Alphabet = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string sentence = "I ckor rock and orck";
            char[] scoreArray = Alphabet.Replace(",", "").ToLower().ToCharArray();

            string[] wordsToCompete = sentence.Split(' ').Select(x => x.ToLower()).ToArray();
            
            Dictionary<int, int> wordsScores = new Dictionary<int, int>();
            Dictionary<string, int> charScores = new Dictionary<string, int>();

            for (int i = 0; i < scoreArray.Length; i++)
            {
                charScores.Add(scoreArray[i].ToString(), i + 1);
            }

            for (int i = 0; i < wordsToCompete.Length; i++)
            {
                var currentWord = wordsToCompete[i];
                var currentWordScore = currentWord.Sum(character => charScores[character.ToString()]);
                wordsScores.Add(i, currentWordScore);
            } 

            var orderedResults = wordsScores.OrderByDescending(x => x.Value);
            Console.WriteLine($"the winner is: {wordsToCompete[orderedResults.First().Key]}");
        }
    }
}