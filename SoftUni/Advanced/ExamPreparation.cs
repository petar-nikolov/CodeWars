using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni.Advanced
{
    public static class ExamPreparation
    {
        public static void Masterched()
        {
            var singleBasketIngredients = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var freshness = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var dishes = new Dictionary<int, string>();
            dishes.Add(150, "Dipping sauce");
            dishes.Add(250, "Green salad");
            dishes.Add(300, "Chocolate cake");
            dishes.Add(400, "Lobster");

            var cookedDishes = new List<string>();

            while (true)
            {
                if (!singleBasketIngredients.Any() || !freshness.Any())
                {
                    break;
                }

                var firstIngredient = singleBasketIngredients[0];
                if (firstIngredient == 0)
                {
                    singleBasketIngredients.Remove(firstIngredient);
                    continue;
                }

                var lastFresh = freshness[^1];
                var calc = firstIngredient * lastFresh;

                if (dishes.Keys.Any(k => k.Equals(calc)))
                {
                    cookedDishes.Add(dishes[calc]);
                    singleBasketIngredients.Remove(firstIngredient);
                    freshness.RemoveAt(freshness.Count - 1);
                }
                else
                {
                    var increased = firstIngredient + 5;
                    freshness.Remove(lastFresh);
                    singleBasketIngredients.Remove(firstIngredient);

                    singleBasketIngredients.Add(increased);
                }
            }

            Console.WriteLine(cookedDishes.Distinct().Count() == 4
                ? "Applause! The judges are fascinated by your dishes!"
                : "You were voted off. Better luck next year.");

            if (singleBasketIngredients.Any())
            {
                Console.WriteLine($"Ingredients left: {singleBasketIngredients.Sum()}");
            }

            var dishesToPrint = cookedDishes.OrderBy(x => x).Distinct().ToDictionary(dish => dish, dish => cookedDishes.Count(x => x == dish));

            foreach (var i in dishesToPrint)
            {
                Console.WriteLine($"# {i.Key} --> {i.Value}");
            }
        }

        public static void BattleOfArmies()
        {
            var armor = int.Parse(Console.ReadLine());
            var numberOfRows = int.Parse(Console.ReadLine());
            var matrix = new char[numberOfRows][];
            int[] mordor;
            int[] army = new int[] { };

            for (int row = 0; row < numberOfRows; row++)
            {
                var rowLine = Console.ReadLine().ToCharArray();

                matrix[row] = rowLine;

                if (rowLine.Any(x => x == 'M'))
                {
                    mordor = new[] { row, Array.IndexOf(rowLine, 'M') };
                }

                if (rowLine.Any(x => x == 'A'))
                {
                    army = new[] { row, Array.IndexOf(rowLine, 'A') };
                }
            }

            var isWon = false;

            while (armor > 0 && isWon == false)
            {
                var commandLine = Console.ReadLine().Split();
                var command = commandLine[0];
                var row = int.Parse(commandLine[1]);
                var col = int.Parse(commandLine[2]);

                matrix[row][col] = 'O';
                armor--;

                switch (command)
                {
                    case "up":
                        if (IsInside(army[0] - 1, army[1], matrix.Length))
                        {
                            matrix[army[0]][army[1]] = '-';
                            army[0] -= 1;
                            if (IsMordor(army[0], army[1], matrix, armor))
                            {
                                isWon = true;
                            }

                            if (matrix[army[0]][army[1]] == 'O')
                            {
                                armor -= 2;
                            }

                            //matrix[army[0]][army[1]] = 'A';
                            //PrintMatrix(matrix);
                        }

                        break;

                    case "down":
                        if (IsInside(army[0] - 1, army[1], matrix.Length))
                        {
                            matrix[army[0]][army[1]] = '-';
                            army[0] += 1;
                            if (IsMordor(army[0], army[1], matrix, armor))
                            {
                                isWon = true;
                            }

                            if (matrix[army[0]][army[1]] == 'O')
                            {
                                armor -= 1;
                            }

                            // matrix[army[0]][army[1]] = 'A';
                            //PrintMatrix(matrix);
                        }

                        break;

                    case "left":
                        if (IsInside(army[0], army[1] - 1, matrix.Length))
                        {
                            matrix[army[0]][army[1]] = '-';
                            army[1] -= 1;
                            if (IsMordor(army[0], army[1], matrix, armor))
                            {
                                isWon = true;
                            }

                            if (matrix[army[0]][army[1]] == 'O')
                            {
                                armor -= 1;
                            }

                            // matrix[army[0]][army[1]] = 'A';
                            //PrintMatrix(matrix);
                        }

                        break;

                    case "right":
                        if (IsInside(army[0], army[1] + 1, matrix.Length))
                        {
                            matrix[army[0]][army[1]] = '-';
                            army[1] += 1;
                            if (IsMordor(army[0], army[1], matrix, armor))
                            {
                                isWon = true;
                            }

                            if (matrix[army[0]][army[1]] == 'O')
                            {
                                armor -= 1;
                            }

                            // matrix[army[0]][army[1]] = 'A';
                            //PrintMatrix(matrix);
                        }

                        break;
                }
            }

            if (armor <= 0)
            {
                matrix[army[0]][army[1]] = 'X';
                Console.WriteLine($"The army was defeated at {army[0]};{army[1]}.");
            }

            PrintMatrix(matrix);
        }

        public static void PrintMatrix(char[][] matrix)
        {
            foreach (var charArr in matrix)
            {
                Console.WriteLine(new string(charArr));
            }
        }

        public static bool IsInside(int x, int y, int matrixLength)
        {
            return x >= 0 && x <= matrixLength - 1 && y >= 0 && y <= matrixLength - 1;
        }

        public static bool IsMordor(int x, int y, char[][] matrixChars, int armor)
        {
            if (matrixChars[x][y] == 'M')
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                matrixChars[x][y] = '-';
                return true;
            }

            return false;
        }

        public static void BirthdayCelebration()
        {
            var eatingCapacity = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var plates = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var foodWaste = 0;

            var guestQueue = new Queue<int>();
            var platesStack = new Stack<int>();

            eatingCapacity.ForEach(x => guestQueue.Enqueue(x));
            plates.ForEach(x => platesStack.Push(x));

            while (guestQueue.Any() && platesStack.Any())
            {
                var currentGuess = guestQueue.Peek();
                var currentPlate = platesStack.Pop();

                if (currentPlate == currentGuess)
                {
                    guestQueue.Dequeue();
                    //platesStack.Pop();
                }

                if (currentPlate > currentGuess)
                {
                    foodWaste += (currentPlate - currentGuess);
                    guestQueue.Dequeue();
                    //platesStack.Pop();
                }

                if (currentPlate < currentGuess)
                {
                    //currentPlate = platesStack.Pop();
                    while (currentGuess > 0)
                    {
                        if (currentPlate >= currentGuess)
                        {
                            foodWaste += (currentPlate - currentGuess);
                            break;
                        }

                        currentGuess -= currentPlate;
                        currentPlate = platesStack.Pop();
                    }

                    guestQueue.Dequeue();
                }
            }

            if (platesStack.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ", platesStack.ToList())}");
            }

            if (guestQueue.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ", guestQueue.ToList())}");
            }

            Console.WriteLine($"Wasted grams of food: {foodWaste}");
        }

        public static void WarWinter()
        {
            var hats = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var scarfs = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var sets = new List<int>();
            var scarfsQueue = new Queue<int>();
            var hatsStack = new Stack<int>();
            var incremented = false;
            scarfs.ForEach(x => scarfsQueue.Enqueue(x));
            hats.ForEach(x => hatsStack.Push(x));
            var currentHat = 0;

            while (scarfsQueue.Any() && hatsStack.Any())
            {
                var currentScarf = scarfsQueue.Peek();

                if (incremented == false)
                {
                    currentHat = hatsStack.Peek();
                }

                if (currentHat > currentScarf)
                {
                    sets.Add(currentScarf + currentHat);
                    hatsStack.Pop();
                    scarfsQueue.Dequeue();
                    incremented = false;
                }

                else if (currentScarf > currentHat)
                {
                    hatsStack.Pop();
                    incremented = false;
                }

                else

                {
                    scarfsQueue.Dequeue();
                    currentHat++;
                    incremented = true;
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.OrderByDescending(x => x).First()}");
            Console.WriteLine(string.Join(" ", sets));
        }

        public static void SuperMario()
        {
            // Input
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] field = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                var chars = Console.ReadLine().ToCharArray();
                field[i] = chars;
            }

            // Find hero
            var heroRow = 0;
            var heroCol = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'M')
                    {
                        heroRow = i;
                        heroCol = j;
                    }
                }
            }

            // Moves
            while (true)
            {
                var commandLine = Console.ReadLine();
                var commandParts = commandLine.Split(' ');
                var command = commandParts[0];
                var bRow = int.Parse(commandParts[1]);
                var bCol = int.Parse(commandParts[2]);

                lives--;
                field[bRow][bCol] = 'B';
                field[heroRow][heroCol] = '-';

                // Move
                if (command == "W" && heroRow - 1 >= 0)
                {
                    heroRow--;
                }
                else if (command == "S" && heroRow + 1 < rows)
                {
                    heroRow++;
                }
                else if (command == "A" && heroCol - 1 >= 0)
                {
                    heroCol--;
                }
                else if (command == "D" && heroCol + 1 < field[heroRow].Length)
                {
                    heroCol++;
                }

                // Already moved
                if (field[heroRow][heroCol] == 'B')
                {
                    lives -= 2;
                }

                if (field[heroRow][heroCol] == 'P')
                {
                    field[heroRow][heroCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    break;
                }

                if (lives <= 0)
                {
                    field[heroRow][heroCol] = 'X';
                    Console.WriteLine($"Mario died at {heroRow};{heroCol}.");
                    break;
                }

                field[heroRow][heroCol] = 'M';
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(new string(field[i]));
            }

        }
    }
}