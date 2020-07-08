using System;
using System.IO;

namespace Lab03_SystemIO
{
    public class Program
    {
        /// <summary>
        /// Run the UI.
        /// </summary>
        static void Main()
        {
            UserInterface();
        }

        /// <summary>
        /// UI displays and allows selection of different challenges
        /// </summary>
        public static void UserInterface()
        {
            int choice = -1;
            while (choice != 9)
            {
                Console.WriteLine("Which code challenge would you like to access?");
                Console.WriteLine("1. Product");
                Console.WriteLine("2. Average");
                Console.WriteLine("3. Diamond");
                Console.WriteLine("4. Most common occurrence");
                Console.WriteLine("5. Maximum Value");
                Console.WriteLine("6. Write and Read file");
                Console.WriteLine("8. Products");
                Console.WriteLine("9. Products");
                Console.WriteLine("0. Exit");
                choice = int.TryParse(Console.ReadLine(), out int returnValue) ? returnValue : 0;
                if (choice == 9)
                {
                    break;
                }
                switch (choice)
                {
                    case 1:
                        HandleProdString();
                        break;
                    case 2:
                        HandleAverage();
                        break;
                    case 3:
                        HandleDiamond();
                        break;
                    case 4:
                        HandleFrequency();
                        break;
                    case 5:
                        HandleMax();
                        break;
                    case 6:
                        HandleFileWriteAndRead();
                        break;
                    case 7:
                        HandleProdString();
                        break;
                    case 8:
                        HandleProdString();
                        break;
                }
                Console.WriteLine("Choose another challenge? y/n");
                string repeat = Console.ReadLine();
                if (repeat == "n")
                {
                    break;
                }
            }
            Console.WriteLine("Thanks for visiting!");
        }

        /// <summary>
        /// Get input for and call the Product challenge
        /// </summary>
        static void HandleProdString()
        {
            Console.WriteLine("Please supply 3 numbers separated by commas, i.e. : 1 2 3");
            string userChoice = Console.ReadLine();
            int result = ProdString(userChoice);
            Console.WriteLine($"The product of {userChoice} is : {result}");
        }

        /// <summary>
        /// Find the product of a given string of numbers separated by spaces.
        /// </summary>
        /// <param name="userInput">Input from the user, string of numbers separated by spaces</param>
        /// <returns>Product of the numbers entered</returns>
        public static int ProdString(string userInput)
        {
            
            string[] myArr = userInput.Split(" ");
            if (myArr.Length < 3)
            {
                return 0;
            }
            int prod = 1;
            for (int i = 0; i < 3; i++)
            {
                prod *= int.TryParse(myArr[i], out int returnVal) ? returnVal : 1;
            }
            return prod;
        }

        /// <summary>
        /// Handle getting input for and calling the Average method.
        /// </summary>
        static void HandleAverage()
        {
            Console.WriteLine("Please enter a number between 2 and 10: ");
            int userInput = int.Parse(Console.ReadLine());
            int[] newArr = new int[userInput];
            for (int i = 0; i < userInput; i++)
            {
                Console.WriteLine($"Enter a number ({i+1} of {userInput}): ");
                newArr[i] = int.Parse(Console.ReadLine());
            }
            decimal result = GetAverage(newArr);
            Console.WriteLine($"The average of {string.Join(", ", newArr)} is {result}");
        }

        /// <summary>
        /// Get the average of an array of integers.
        /// </summary>
        /// <param name="arr">Array to be averaged</param>
        /// <returns>Average of the provided integer array</returns>
        public static decimal GetAverage(int[] arr)
        {
            decimal result = 0;
            foreach (int num in arr)
            {
                result += num;
            }
            return result / arr.Length;
        }

        /// <summary>
        /// Get a size for the diamond from the user and call MakeDiamond
        /// </summary>
        public static void HandleDiamond()
        {
            Console.WriteLine("How tall would you like your diamond (Must be odd, even numbers will be reduced by 1)?");
            int diamondSize = int.Parse(Console.ReadLine());
            MakeDiamond(diamondSize);
        }

        /// <summary>
        /// Prints a diamond of specified size to the console. 
        /// </summary>
        /// <param name="size">Number of rows in the diamond</param>
        public static void MakeDiamond(int size)
        {
            int half = (size + 1) / 2;
            // Build the top half first
            for (int i = 1; i <= half; i++)
            {
                for (int j = 1; j <= (half-i); j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= 2*i-1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            // Build the bottom half
            for (int i = half-1; i > 0; i--)
            {
                for (int j = 1; j <= (half-i); j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Handle getting user input for and running GetFrequency
        /// </summary>
        static void HandleFrequency()
        {
            Console.WriteLine("Enter the numbers you would like to test separated by spaces, i.e. 1 1 1 3 3 3 4 5 6 7 4 1 (would return 1)");
            string userInput = Console.ReadLine();
            string[] arr = userInput.Split(" ");
            int[] numArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                numArr[i] = int.Parse(arr[i]);
            }
            int result = GetMostFrequent(numArr);
            Console.WriteLine($"The most frequent number among: {userInput} is {result}");
        }

        /// <summary>
        /// Find the most commonly occurring number in an integer array
        /// </summary>
        /// <param name="arr">Array to be checked</param>
        /// <returns>Most common number in array, or first most common if multiple</returns>
        public static int GetMostFrequent(int[] arr)
        {
            int result = arr[0];
            int currentLead = 0;
            int currentCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                currentCount = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        currentCount++;
                    }
                }
                if (currentCount > currentLead)
                {
                    currentLead = currentCount;
                    result = arr[i];
                }
            }
            return result;
        }

        /// <summary>
        /// Handle getting user input for and running GetFrequency
        /// </summary>
        static void HandleMax()
        {
            Console.WriteLine("Enter the numbers you would like to test separated by spaces, i.e. 5, 25, 99, 123, 78, 96, 555, 108, 4 (would return 555)");
            string userInput = Console.ReadLine();
            string[] arr = userInput.Split(" ");
            int[] numArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                numArr[i] = int.Parse(arr[i]);
            }
            int result = GetMax(numArr);
            Console.WriteLine($"The highest number among: {userInput} is {result}");
        }

        /// <summary>
        /// Find the maximum value in an integer array
        /// </summary>
        /// <param name="arr">Array to be checked</param>
        /// <returns>Maximum value in array</returns>
        public static int GetMax(int[] arr)
        {
            int result = arr[0];
            foreach (int num in arr)
            {
                if (num > result)
                {
                    result = num;
                }
            }
            return result;
        }

        static void HandleFileWriteandRead()
        {
            string path = "../../../words.txt";
            FileWriteText(path);
            Console.WriteLine("Press any button to have your word read from it's file");
            Console.ReadLine();
            FileReadText(path);
        }

        public static void FileWriteText(string path)
        {
            Console.WriteLine("What is your favorite word?");
            string userInput = Console.ReadLine();
            File.WriteAllText(path, userInput);
        }

        public static void FileReadText(string path)
        {
            string result = File.ReadAllText(path);
            Console.WriteLine(result);
        }
    }
}
