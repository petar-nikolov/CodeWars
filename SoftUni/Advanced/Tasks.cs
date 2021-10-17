using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni.Advanced
{
    public static class Tasks
    {
        public static void BasicStackOperations()
        {
            var stack = new Stack<int>();

            var firstLine = Console.ReadLine().Split();
            var secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var n = int.Parse(firstLine[0]);
            var s = int.Parse(firstLine[1]);
            var x = int.Parse(firstLine[2]);

            for (int i = 0; i < n; i++)
            {
                stack.Push(secondLine[i]);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }

            else if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine($"{stack.Min()}");
            }
        }

        public static void BasicQueueOperations()
        {
            var queue = new Queue<int>();

            var firstLine = Console.ReadLine().Split();
            var secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var n = int.Parse(firstLine[0]);
            var s = int.Parse(firstLine[1]);
            var x = int.Parse(firstLine[2]);

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(secondLine[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }

            else if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine($"{queue.Min()}");
            }
        }

        public static void MaxAndMinElementInStack()
        {
            var stack = new Stack<int>();
            var queriesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < queriesCount; i++)
            {
                var query = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (query.Length == 1 && stack.Any())
                {
                    switch (query[0])
                    {
                        case 2:
                            stack.Pop();
                            break;

                        case 3:
                            Console.WriteLine($"{stack.Max()}");
                            break;

                        case 4:
                            Console.WriteLine($"{stack.Min()}");
                            break;
                    }
                }

                else if (query.Length == 2 && query[0] == 1)
                {
                    stack.Push(query[1]);
                }
            }

            Console.WriteLine($"{string.Join(", ", stack)}");
        }

        public static void FastFood()
        {
            var ordersQueue = new Queue<int>();

            var quantityOfFood = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToList();

            orders.ForEach(x => ordersQueue.Enqueue(x));

            Console.WriteLine($"{orders.Max()}");

            foreach (var order in orders)
            {
                if (order <= quantityOfFood)
                {
                    ordersQueue.Dequeue();
                    quantityOfFood -= order;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(ordersQueue.Count == 0 ? "Orders complete" : $"Orders left: {string.Join(' ', ordersQueue)}");
        }

        public static void CrossRoads()
        {
            var greenLightSeconds = int.Parse(Console.ReadLine());
            var freeWindowSeconds = int.Parse(Console.ReadLine());
            var totalTimeToPass = greenLightSeconds + freeWindowSeconds;
            var carsQueue = new Queue<string>();
            var crossRoad = new Queue<string>();
            var totalCars = 0;
            var consoleReadLine = Console.ReadLine();
            var isOk = true;
            var inputs = new List<string>();

            while (consoleReadLine != "END")
            {
                if (consoleReadLine != "END")
                {
                    inputs.Add(consoleReadLine);
                }

                consoleReadLine = Console.ReadLine();
            }

            foreach (var input in inputs)
            {
                if (input != "green")
                {
                    carsQueue.Enqueue(input);
                }
                else
                {
                    var leftTime = totalTimeToPass;
                    var currentGreen = greenLightSeconds;
                    while (leftTime > 0 && carsQueue.Any() && currentGreen > 0)
                    {
                        var carToPass = carsQueue.Peek();
                        if (currentGreen > 0)
                        {
                            crossRoad.Enqueue(carToPass);
                        }

                        currentGreen -= carToPass.Length;

                        if (carToPass.Length <= leftTime)
                        {
                            leftTime -= carToPass.Length;
                            carsQueue.Dequeue();
                            if (crossRoad.Any())
                            {
                                crossRoad.Dequeue();
                            }

                            totalCars++;
                        }

                        if (carToPass.Length > leftTime && crossRoad.Any())
                        {
                            var crashedChar = carToPass.Substring(leftTime, 1);
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{carToPass} was hit at {crashedChar}.");
                            isOk = false;
                            break;
                        }
                    }

                    if (!isOk)
                    {
                        break;
                    }
                }
            }

            if (isOk)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCars} total cars passed the crossroads.");
            }
        }

        public static void KeyRevolver()
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            var intelligence = int.Parse(Console.ReadLine());
            var shotsCount = 0;

            while (bullets.Any())
            {
                //Check the success
                if (!locks.Any())
                {
                    break;
                }

                shotsCount++;
                //take a shot to a lock
                var bullet = bullets.Peek();
                var lockToShot = locks.Peek();

                //Check status of the shot
                if (bullet <= lockToShot)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                //Clear the bullet
                bullets.Pop();

                //Pay the price of the bullet
                intelligence -= bulletPrice;


                if (!bullets.Any())
                {
                    break;
                }

                //Check reloading
                if (shotsCount == gunBarrelSize)
                {
                    shotsCount = 0;
                    Console.WriteLine("Reloading!");
                }
            }

            Console.WriteLine(locks.Any()
                ? $"Couldn't get through. Locks left: {locks.Count}"
                : $"{bullets.Count} bullets left. Earned ${intelligence}");
        }

        public static void CupsAndBottles()
        {
            var cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            var bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            var wastedWater = 0;
            var allCupsFilled = false;
            while (bottles.Any())
            {
                if (!cups.Any())
                {
                    allCupsFilled = true;
                    break;
                }

                var cupToFill = cups.Peek();

                while (cupToFill > 0)
                {
                    var currentBottle = bottles.Pop();
                    if (currentBottle > cupToFill)
                    {
                        wastedWater += currentBottle - cupToFill;
                    }

                    cupToFill -= currentBottle;

                    if (cupToFill <= 0)
                    {
                        cups.Dequeue();
                        break;
                    }
                }
            }

            Console.WriteLine(allCupsFilled
                ? $"Bottles: {string.Join(" ", bottles)}"
                : $"Cups: {string.Join(" ", cups)}");

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }

        public static void DiagonalDiff()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new int[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                var lineElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = lineElements[j];
                }
            }

            var firstDiag = 0;
            for (int i = 0; i < matrixSize; i++)
            {
                firstDiag += matrix[i, i];
            }

            var secondDiag = 0;
            for (int i = 0; i < matrixSize; i++)
            {
                var elem = matrix[i, matrixSize - 1 - i];
                secondDiag += elem;
            }

            Console.WriteLine(Math.Abs(firstDiag - secondDiag));
        }

        public static void TwoSquareMatrixCharEquality()
        {
            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new string[matrixSize[0], matrixSize[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var lineElements = Console.ReadLine().Split();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = lineElements[j];
                }
            }

            var foundMatrixCount = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var currentElement = matrix[row, col];
                    var nextColElement = matrix[row, col + 1];
                    var aboveRowElement = matrix[row + 1, col];
                    var aboveColElement = matrix[row + 1, col + 1];
                    if (currentElement == nextColElement &&
                        currentElement == aboveRowElement &&
                        currentElement == aboveColElement)
                    {
                        foundMatrixCount++;
                    }
                }
            }

            Console.WriteLine(foundMatrixCount);
        }

        public static void SnakeMove()
        {
            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = matrixSize[0];
            var cols = matrixSize[1];
            var matrix = new string[rows, cols];
            var snake = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToList();
            var reverse = false;
            var currentSnakeIndex = 0;
            var currentRow = 0;

            for (int row = 0; row < rows; row++)
            {
                if (reverse == false)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (currentSnakeIndex == snake.Count)
                        {
                            currentSnakeIndex = 0;
                        }

                        matrix[row, col] = snake[currentSnakeIndex];
                        currentSnakeIndex++;
                    }

                    reverse = true;
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (currentSnakeIndex == snake.Count)
                        {
                            currentSnakeIndex = 0;
                        }

                        matrix[row, col] = snake[currentSnakeIndex];
                        currentSnakeIndex++;
                    }

                    reverse = false;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}