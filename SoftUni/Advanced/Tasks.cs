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
    }
}