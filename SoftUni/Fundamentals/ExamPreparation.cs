using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace SoftUni.Fundamentals
{
    public static class ExamPreparation
    {
        public static void CountChars()
        {
            var input = Console.ReadLine();

            var charArr = input.ToCharArray().ToList().Where(x => x != ' ');

            var charCount = new Dictionary<char, int>();

            foreach (var charElement in charArr.Distinct())
            {
                var charElementCount = charArr.Count(x => x == charElement);
                charCount.Add(charElement, charElementCount);
                Console.WriteLine($"{charElement} -> {charElementCount}");
            }
        }

        public static void MinerTask()
        {
            var input = "";

            var dict = new Dictionary<string, long>();
            var inputs = new List<string>();

            while (input != "stop")
            {
                input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }

                inputs.Add(input);
            }

            var resources = new List<string>();
            var quantities = new List<long>();
            for (int i = 0; i <= inputs.Count - 1; i++)
            {
                if (i % 2 != 0)
                {
                    quantities.Add(long.Parse(inputs[i]));
                }
                else
                {
                    resources.Add(inputs[i]);
                }
            }

            for (int i = 0; i < resources.Count; i++)
            {
                if (dict.ContainsKey(resources[i]))
                {
                    dict[resources[i]] += quantities[i];
                }
                else
                {
                    dict.Add(resources[i], quantities[i]);
                }
            }

            foreach (var dictKey in dict.Keys)
            {
                Console.WriteLine($"{dictKey} -> {dict[dictKey]}");
            }
        }

        public static void LegendaryFarming()
        {
            var keyMaterials = new Dictionary<string, long>();
            var legendaryItems = new Dictionary<string, long>();
            legendaryItems.Add("Shadowmourne", 0);
            legendaryItems.Add("Valanyr", 0);
            legendaryItems.Add("Dragonwrath", 0);
            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);
            var junkMaterials = new Dictionary<string, long>();

            var values = legendaryItems.Select(x => x.Value);
            while (true)
            {
                if (values.Any(x => x >= 250))
                {
                    break;
                }

                var inputLine = Console.ReadLine().Split();

                for (int i = 1; i < inputLine.Length; i += 2)
                {
                    var keyMaterial = inputLine[i].ToLower();
                    var amount = long.Parse(inputLine[i - 1]);
                    switch (keyMaterial)
                    {
                        case "shards":
                            keyMaterials["shards"] += amount;
                            legendaryItems["Shadowmourne"] += amount;
                            break;

                        case "fragments":
                            keyMaterials["fragments"] += amount;
                            legendaryItems["Valanyr"] += amount;
                            break;

                        case "motes":
                            keyMaterials["motes"] += amount;
                            legendaryItems["Dragonwrath"] += amount;
                            break;

                        default:
                            if (junkMaterials.ContainsKey(inputLine[i]))
                            {
                                junkMaterials[keyMaterial] += amount;
                            }

                            else
                            {
                                junkMaterials.Add(keyMaterial, amount);
                            }

                            break;
                    }

                    if (values.Any(x => x >= 250))
                    {
                        keyMaterials[keyMaterial] -= 250;
                        if (keyMaterials[keyMaterial] < 0)
                        {
                            keyMaterials[keyMaterial] = 0;
                        }

                        break;
                    }
                }
            }

            var legendaryItem = legendaryItems.OrderBy(x => x.Key).First(x => x.Value >= 250).Key;

            Console.WriteLine($"{legendaryItem} obtained!");
            var materialToList = keyMaterials.Where(x => x.Key != legendaryItem).OrderByDescending(x => x.Value).ThenBy(y => y.Key);

            foreach (var keyValuePair in materialToList)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
            }

            foreach (var junk in junkMaterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{junk.Key}: {junk.Value}");
            }
        }

        public static void Orders()
        {
            var input = "";

            var productPrices = new Dictionary<string, decimal>();
            var productQntys = new Dictionary<string, int>();

            while (input != "buy")
            {
                input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                var inputParts = input.Split();
                var name = inputParts[0];
                var price = decimal.Parse(inputParts[1]);
                var qnty = int.Parse(inputParts[2]);

                if (productPrices.ContainsKey(name))
                {
                    productPrices[name] = price;
                    productQntys[name] += qnty;
                }

                else
                {
                    productPrices.Add(name, price);
                    productQntys.Add(name, qnty);
                }
            }

            foreach (var productKey in productPrices.Keys)
            {
                var totalPrice = productPrices[productKey] * productQntys[productKey];
                Console.WriteLine($"{productKey} -> {totalPrice:f2}");
            }
        }

        public static void ForceBook()
        {
            var input = Console.ReadLine();
            var forceSides = new Dictionary<string, List<string>>();

            while (input != "Lumpawaroo")
            {
                string[] keyWords;
                var isLine = input.Contains("|");
                string forceUser;
                string forceSide;

                keyWords = isLine ? input.Split("|") : input.Split("->");

                if (isLine)
                {
                    forceSide = keyWords[0].Trim();
                    forceUser = keyWords[1].Trim();

                    AddUserToForceGroup(forceSides, forceSide, forceUser);
                }
                else
                {
                    forceSide = keyWords[1].Trim();
                    forceUser = keyWords[0].Trim();
                    var existingUserForceSide = forceSides.FirstOrDefault(x => x.Value.Any(v => v == forceUser)).Key;
                    var currentForceSideUsers = new List<string>();
                    if (existingUserForceSide == null)
                    {
                        AddUserToForceGroup(forceSides, forceSide, forceUser);
                    }
                    else
                    {
                        currentForceSideUsers = forceSides[existingUserForceSide];
                        currentForceSideUsers.Remove(forceUser);
                        AddUserToForceGroup(forceSides, forceSide, forceUser);
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            var forceSidesToPrint = forceSides.Where(x => x.Value.Any()).OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key);

            foreach (var fcToPrint in forceSidesToPrint)
            {
                Console.WriteLine($"Side: {fcToPrint.Key}, Members: {fcToPrint.Value.Count}");
                foreach (var fcUser in fcToPrint.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {fcUser}");
                }
            }
        }

        public static void SoftUniResults()
        {
            var userSubmissionPoints = new Dictionary<string, int>();
            var bannedUsers = new List<string>();
            var submissionCounts = new Dictionary<string, int>();

            var input = Console.ReadLine();

            while (input != "exam finished")
            {
                var inputParams = input.Split("-").Select(x => x.Trim()).ToList();

                var username = inputParams[0];
                var lang = inputParams[1];

                if (lang != "banned")
                {
                    var points = int.Parse(inputParams[2]);
                    if (userSubmissionPoints.ContainsKey(username))
                    {
                        if (points > userSubmissionPoints[username])
                        {
                            userSubmissionPoints[username] = points;
                        }
                    }
                    else
                    {
                        userSubmissionPoints.Add(username, points);
                    }

                    if (submissionCounts.ContainsKey(lang))
                    {
                        submissionCounts[lang]++;
                    }
                    else
                    {
                        submissionCounts.Add(lang, 1);
                    }
                }
                else
                {
                    if (!bannedUsers.Contains(username))
                    {
                        bannedUsers.Add(username);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            var selectedPoints = bannedUsers.Any()
                ? userSubmissionPoints.Where(x => bannedUsers.Any(b => b != x.Key)).OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList()
                : userSubmissionPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();

            foreach (var keyValuePair in selectedPoints)
            {
                Console.WriteLine($"{keyValuePair.Key} | {keyValuePair.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var keyValuePair in submissionCounts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value}");
            }
        }

        private static void AddUserToForceGroup(Dictionary<string, List<string>> forceSides, string forceSide, string forceUser)
        {
            if (!forceSides.ContainsKey(forceSide))
            {
                forceSides.Add(forceSide, new List<string> {forceUser});
            }
            else
            {
                var currentForceSideUsers = forceSides[forceSide];
                currentForceSideUsers.Add(forceUser);
            }
        }

        public static void ValidUsernames()
        {
            var input = Console.ReadLine();
            var usernames = input.Split(", ");
            var validUsernames = new List<string>();

            foreach (var username in usernames)
            {
                if (username.Length < 3 || username.Length > 16)
                {
                    continue;
                }

                if (username.ToCharArray().All(x => char.IsLetterOrDigit(x) || x == '_' || x == '-'))
                {
                    validUsernames.Add(username);
                }
            }
        }

        public static void CharMultiplier()
        {
            var input = Console.ReadLine();
            var strings = input.Split();
            string shorter;
            string longer;
            var sum = 0;

            if (strings[0].Length <= strings[1].Length)
            {
                shorter = strings[0];
                longer = strings[1];
            }
            else
            {
                shorter = strings[1];
                longer = strings[0];
            }

            var stringToSumRemaining = longer.Substring(shorter.Length, longer.Length - shorter.Length);
            var stringToCalculate = longer.Substring(0, shorter.Length);

            var generalCalculation = CalculateChars(shorter.ToCharArray(), stringToCalculate.ToCharArray());
            var remainingSum = CalculateRemainingCharsSum(stringToSumRemaining.ToCharArray());
            sum += (generalCalculation + remainingSum);


            Console.WriteLine(sum);
        }

        private static int CalculateRemainingCharsSum(char[] charArray)
        {
            return charArray.Sum(x => x);
        }

        private static int CalculateChars(char[] charArray1, char[] charArray2)
        {
            var sum = 0;
            for (int i = 0; i < charArray1.Length; i++)
            {
                var curMult = charArray1[i] * charArray2[i];
                sum += curMult;
            }

            return sum;
        }

        private static void ExtractFile()
        {
            var path = Console.ReadLine();

            var parts = path.Split("\\");

            var lastParts = parts.Last().Split('.');

            var filename = lastParts[0];
            var extension = lastParts[1];

            Console.WriteLine($"File name: {filename}");
            Console.WriteLine($"File extension: {extension}");
        }

        public static void LetterChangeNumbers()
        {
            var input = Console.ReadLine();

            var inputStrings = input.Split(" ").Select(x => x.Trim()).Where(x => x != string.Empty).ToList();

            var totalSum = 0d;

            foreach (var inputString in inputStrings)
            {
                var currNumber = double.Parse(new string(inputString.Where(char.IsNumber).ToArray()));
                var currLetters = inputString.Where(char.IsLetter).ToArray();
                var firstChar = currLetters[0];
                var secondChar = currLetters[1];

                var firstCharAlphabetPosition = char.ToUpper(firstChar) - 64;
                var firstCharResult = 0d;

                if (char.IsUpper(firstChar))
                {
                    firstCharResult = currNumber / firstCharAlphabetPosition;
                }
                else
                {
                    firstCharResult = currNumber * firstCharAlphabetPosition;
                }

                var secondCharResult = 0d;
                var secondCharAlphabetPosition = char.ToUpper(secondChar) - 64;

                if (char.IsUpper(secondChar))
                {
                    secondCharResult = firstCharResult - secondCharAlphabetPosition;
                }
                else
                {
                    secondCharResult = firstCharResult + secondCharAlphabetPosition;
                }

                totalSum += secondCharResult;
            }

            Console.WriteLine($"{Math.Round(totalSum, 2):F2}");
        }
    }
}