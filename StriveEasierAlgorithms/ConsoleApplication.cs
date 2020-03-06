using System;
using System.Collections.Generic;

namespace StriveEasierAlgorithms
{
    class ConsoleApplication
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to Strive Easier Algorithms!");

            while (true) // Show this menu until the user actually wants to exit
            {
                Console.WriteLine(@"
Please select you algorithm:
1. Greatest Common Divisor
2. Bubble Sort
3. Binary Search Algorithm
4. Exit
");
                switch (ReadAnIntegerInputFromTheUser())
                {
                    case 1: RunGcd(); break;
                    case 2: RunBubbleSort(); break;
                    case 3: RunBinarySearchAlgorithm(); break;
                    case 4: return;
                    default: Console.WriteLine("Please select one of the options below."); break;
                }
            }
            
        }

        /// <summary>
        /// Handles the user interface for providing inputs to the GcdEuclidSolver
        /// </summary>
        private static void RunGcd()
        {
            Console.WriteLine("Let's solve the GCD problem. Please enter X:");
            int x = ReadAnIntegerInputFromTheUser();

            Console.WriteLine("Thanks. Now please enter Y:");
            int y = ReadAnIntegerInputFromTheUser();

            GcdEuclidSolver solver = new GcdEuclidSolver(); // Of course we need to create an instance/object of GcdEuclidSolver in order to use its methods
            int result = solver.FindGreatestCommonDivisor(x, y);

            Console.WriteLine($"The greatest common divisor between {x} and {y} is {result}");
        }

        /// <summary>
        /// Handles the user interface for providing inputs to the BubbleSorter
        /// </summary>
        private static void RunBubbleSort()
        {
            List<int> outOfOrderCollection = new List<int>();

            // Fill-up the collection with the numbers provided by the user
            Console.WriteLine("Please insert the numbers (-1 to stop):");
            while (true)
            {
                int nextNumber = ReadAnIntegerInputFromTheUser();
                if (nextNumber < 0)
                    break;

                outOfOrderCollection.Add(nextNumber);
            }

            Console.WriteLine("Do you want them in [a]scending order or [d]escending?");
            bool? ascending = null; // Nullables: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types
            while (ascending == null) // Keep asking the user until he/she provides a valid answer
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "a": ascending = true; break;
                    case "d": ascending = false; break;
                    default: Console.WriteLine("Please select 'a' or 'd'"); break;
                }
            }

            BubbleSorter sorter = new BubbleSorter(); // Of course we need to create an instance/object of BubbleSorter in order to use its methods

            sorter.Sort(outOfOrderCollection, ascending.Value); // We cannot provide a 'bool?' to a method that's expecting a 'bool': 
                                                                // that's why call .Value, that returns a bool
                                                                // Beware: we can do it because we're sure we put either a 'true' or 'false' inside that variable;
                                                                // if I call ascending.Value and ascending is currently null, an exception is being thrown

            Console.WriteLine(string.Join("|", outOfOrderCollection));
        }

        private static void RunBinarySearchAlgorithm()
        {
            List<int> outOfOrderCollection = BinaryAlgorithm.GetBinaryList();

            // Fill-up the collection with the numbers provided by the user
            Console.WriteLine("Please insert the number you want to search:");
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            while (true)
            {
                int nextNumber = ReadAnIntegerInputFromTheUser();
                if (nextNumber < 0)
                    break;
                try
                {
                    int indexOfNumber = outOfOrderCollection.IndexOf(nextNumber);
                    if(indexOfNumber<0)
                    { Console.WriteLine("The number you entered not found in the list .\nPlease search again with correct number."); }
                    else
                    Console.WriteLine("The index of the value " + nextNumber + " is :" + indexOfNumber);
                }
                catch (Exception)
                {
                    Console.WriteLine("The number you entered not found in the list . \n Please search again with correct number.");
                     
                }
                watch.Stop(); 
                Console.Write($"\nExecution Time: {watch.ElapsedMilliseconds} ms");
            }

        
        }

        /// <summary>
        /// This handy methods ensure that the user is actually entering a proper integer as an input
        /// </summary>
        /// <returns></returns>
        private static int ReadAnIntegerInputFromTheUser()
        {
            int result;
            while (true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out result))
                    return result;

                Console.WriteLine("Please enter a valid integer number:");
            }
        }
    }
}
