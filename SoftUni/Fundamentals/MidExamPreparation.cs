using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;

namespace SoftUni.Fundamentals
{
    public static class MidExamPreparation
    {
        public static void MuOnline()
        {
            var input = Console.ReadLine();
            var splitInput = input.Split('|').ToList();
            var initialHealth = 100;
            var bitCoins = 0;


            foreach (var si in splitInput)
            {
                var siPartNumber = int.Parse(si.Split(' ')[1]);
                var siMonster = si.Split(' ')[0];
                switch (siMonster)
                {
                    case "potion":
                        if (initialHealth + siPartNumber >= 100)
                        {
                            initialHealth = 100;
                        }
                        else
                        {
                            initialHealth += siPartNumber;
                        }

                        Console.WriteLine($"You healed for {siPartNumber} hp.");
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                        break;

                    case "chest":

                        Console.WriteLine($"You found {siPartNumber} bitcoins.");
                        bitCoins += siPartNumber;
                        break;

                    default:
                        initialHealth -= siPartNumber;
                        if (initialHealth > 0)
                        {
                            Console.WriteLine($"You slayed {siMonster}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {siMonster}.");
                            Console.WriteLine($"Best room: {splitInput.IndexOf(si) + 1}");
                            return;
                        }

                        break;
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitCoins}");
            Console.WriteLine($"Health: {initialHealth}");
        }

        public static void NationalCourt()
        {
            var employeesPerHour = 0;
            var workingHours = 0;

            for (int i = 0; i < 3; i++)
            {
                employeesPerHour += int.Parse(Console.ReadLine());
            }

            var employeesToCover = int.Parse(Console.ReadLine());

            for (int i = 1; i <= int.MaxValue - 1; i++)
            {
                if (employeesToCover <= 0)
                {
                    break;
                }

                workingHours++;

                if (i % 4 != 0)
                {
                    employeesToCover -= employeesPerHour;
                }
            }

            Console.WriteLine($"Time needed: {workingHours}h.");
        }

        public static void HeartDelivery()
        {
            var input = string.Empty;
            var housesToCover = Console.ReadLine().Split('@').Select(int.Parse).ToArray();
            var currentIndex = 0;
            var alreadyPassed = new List<int>();

            while (input != "Love!")
            {
                input = Console.ReadLine();
                if (input != "Love!")
                {
                    var jump = int.Parse(input.Split(' ')[1]);
                    if (currentIndex + jump > housesToCover.Length || jump >= housesToCover.Length)
                    {
                        currentIndex = 0;
                    }
                    else
                    {
                        currentIndex += jump;
                    }

                    if (housesToCover[currentIndex] != 0)
                    {
                        housesToCover[currentIndex] -= 2;
                        if (housesToCover[currentIndex] == 0)
                        {
                            Console.WriteLine($"Place {currentIndex} has Valentine's day.");
                            alreadyPassed.Add(currentIndex);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Place {currentIndex} already had Valentine's day.");
                    }
                }
            }

            if (housesToCover.All(x => x.Equals(0)))
            {
                Console.WriteLine("Mission was successful");
                return;
            }

            Console.WriteLine($"Cupid's last position was {currentIndex}.");
            Console.WriteLine($"Cupid has failed {housesToCover.ToList().Count(x => x != 0)} places.");
        }

        public static void CounterStrike()
        {
            var initialEnergy = int.Parse(Console.ReadLine());
            var wonBattles = 0;

            for (int i = 1; i < int.MaxValue - 1; i++)
            {
                var input = Console.ReadLine();
                if (input == "End of battle")
                {
                    Console.WriteLine($"Won battles: {wonBattles}. Energy left: {initialEnergy}");
                    break;
                }

                var distance = int.Parse(input);
                if (initialEnergy - distance < 0)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {initialEnergy} energy");
                    break;
                }

                wonBattles++;
                initialEnergy -= distance;

                if (i % 3 == 0)
                {
                    initialEnergy += wonBattles;
                }
            }
        }

        public static void ShootForTheWin()
        {
            var targets = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var input = string.Empty;

            while (input != "End")
            {
                input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var index = int.Parse(input);
                var targetToShoot = targets[index];
                if (targets[index] != -1)
                {
                    targets[index] = -1;

                    for (var i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] == -1)
                        {
                            continue;
                        }

                        if (targets[i] > targetToShoot)
                        {
                            targets[i] -= targetToShoot;
                        }
                        else
                        {
                            targets[i] += targetToShoot;
                        }
                    }
                }
            }

            var shotTargets = targets.Count(x => x == -1);
            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(' ', targets)}");
        }

        public static void MovingTarget()
        {
            var targets = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var command = string.Empty;

            while (command != "End")
            {
                command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var manipulation = command.Split(" ");
                var action = manipulation[0];
                var index = int.Parse(manipulation[1]);
                var parameter = int.Parse(manipulation[2]);

                var maxIndex = targets.Count - 1;
                switch (action)
                {
                    case "Shoot":
                        if (index > targets.Count - 1 || index < 0)
                        {
                            continue;
                        }

                        if (targets[index] > 0)
                        {
                            targets[index] -= parameter;
                        }

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }

                        break;

                    case "Add":
                        if (index > maxIndex || index < 0)
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        else
                        {
                            targets.Insert(index, parameter);
                        }

                        break;

                    case "Strike":
                        var indexesToStrike = new List<int>();
                        for (int i = 1; i <= parameter; i++)
                        {
                            indexesToStrike.Add(index + i);
                            indexesToStrike.Add(index - i);
                        }

                        indexesToStrike.Add(index);

                        if (indexesToStrike.Any(x => x > maxIndex || x < 0))
                        {
                            Console.WriteLine("Strike missed!");
                        }

                        else
                        {
                            targets.RemoveRange(index - 1, (parameter * 2) + 1);
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join('|', targets));
        }

        public static void ArrayModifier()
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var input = string.Empty;

            while (input != "end")
            {
                input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                var command = input.Split(' ');
                var action = command[0];
                int index1;
                int index2;

                switch (action)
                {
                    case "swap":
                        index1 = int.Parse(command[1]);
                        index2 = int.Parse(command[2]);
                        if (IsValidIndex(array, index1) && IsValidIndex(array, index2))
                        {
                            var valueOfIndex1 = array[index1];
                            var valueOfIndex2 = array[index2];

                            array[index1] = valueOfIndex2;
                            array[index2] = valueOfIndex1;
                        }

                        break;

                    case "multiply":
                        index1 = int.Parse(command[1]);
                        index2 = int.Parse(command[2]);
                        if (IsValidIndex(array, index1) || IsValidIndex(array, index2))
                        {
                            var valueOfIndex1 = array[index1];
                            var valueOfIndex2 = array[index2];
                            array[index1] = valueOfIndex1 * valueOfIndex2;
                        }

                        break;

                    case "decrease":
                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i] -= 1;
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }

        public static bool IsValidIndex(Array array, int i)
        {
            return !(i > (array.Length - 1) || i < 0);
        }

        public static void Numbers()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var average = numbers.Average(x => x);
            var top5 = numbers.Where(x => x > average).OrderByDescending(x => x).Take(5);
            if (!top5.Any())
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", top5));
            }
        }

        public static void SecretChat()
        {
            var message = Console.ReadLine();
            var input = string.Empty;
            var separator = ":|:";
            while (input != "Reveal")
            {
                input = Console.ReadLine();
                if (input == "Reveal")
                {
                    break;
                }

                var splitString = input.Split(separator);
                var command = splitString[0];
                var indexSubstring = splitString[1];

                switch (command)
                {
                    case "InsertSpace":
                        message = message.Insert(int.Parse(indexSubstring), " ");
                        Console.WriteLine(message);
                        break;

                    case "Reverse":
                        if (message.Contains(indexSubstring))
                        {
                            var reversedSubstring = new string(indexSubstring.Reverse().ToArray());
                            message = message.Remove(message.IndexOf(indexSubstring));
                            message = message.Insert(message.Length, reversedSubstring);
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;

                    case "ChangeAll":
                        var replacement = splitString[2];
                        message = message.Replace(indexSubstring, replacement);
                        Console.WriteLine(message);
                        break;
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }

        public static void MirrorWords()
        {
            var inputString = Console.ReadLine();
            var diesPairs = inputString.Split('#');
        }
    }
}