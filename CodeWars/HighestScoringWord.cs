using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public class HighestScoringWord
    {
        public static string HighestScoreWord(string sentence)
        {
            const string Alphabet = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            var scoreArray = Alphabet.Replace(",", "").ToLower().ToCharArray();

            var wordsToCompete = sentence.Split(' ').Select(x => x.ToLower()).ToArray();

            var wordsScores = new Dictionary<int, int>();
            var charScores = new Dictionary<string, int>();

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

            return wordsToCompete[orderedResults.First().Key];
        }
    }
}