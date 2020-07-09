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
            int choice = 0;
            while (choice != 9)
            {
                Console.WriteLine("Which code challenge would you like to access?");
                Console.WriteLine("1. Product");
                Console.WriteLine("2. Average");
                Console.WriteLine("3. Diamond");
                Console.WriteLine("4. Most common occurrence");
                Console.WriteLine("5. Maximum Value");
                Console.WriteLine("6. Write and Read file");
                Console.WriteLine("7. Remove word from file");
                Console.WriteLine("8. Sentence counter");
                Console.WriteLine("9. Exit");
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
                        HandleRemoveWord();
                        break;
                    case 8:
                        HandleSentenceCounter();
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
            string[] newArr = new string[userInput];
            for (int i = 0; i < userInput; i++)
            {
                Console.WriteLine($"Enter a number ({i+1} of {userInput}): ");
                newArr[i] = Console.ReadLine();
            }
            int[] convertedArr = ConvertArray(newArr);
            decimal result = GetAverage(convertedArr);
            Console.WriteLine($"The average of {string.Join(", ", convertedArr)} is {result}");
        }

        /// <summary>
        /// Convert an array of strings to integers
        /// </summary>
        /// <param name="arr">Array to convert</param>
        /// <returns>Converted integer array</returns>
        public static int[] ConvertArray(string[] arr)
        {
            int[] result = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = int.Parse(arr[i]);
            }
            return result;
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
            int currentCount;
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

        /// <summary>
        /// Runs the Write and Read Text methods for words.txt
        /// </summary>
        static void HandleFileWriteAndRead()
        {
            string path = "../../../words.txt";
            Console.WriteLine("Press any button to have your word read from it's file");
            Console.ReadLine();
            FileReadText(path);
        }

        /// <summary>
        /// Write a user's input to a file
        /// </summary>
        /// <param name="path">Path to file</param>
        public static void FileWriteText(string path)
        {
            Console.WriteLine("What is your favorite word?");
            string userInput = Console.ReadLine();
            File.WriteAllText(path, userInput);
        }

        /// <summary>
        /// Read everything from a file and display to the console
        /// </summary>
        /// <param name="path">Path to file</param>
        public static void FileReadText(string path)
        {
            string result = File.ReadAllText(path);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Handle user input for removing a word from words.txt, read from the file and remove the word then rewrite it.
        /// </summary>
        public static void HandleRemoveWord()
        {
            string path = "../../../words.txt";
            Console.WriteLine("What word would you like to remove from the file?");
            string userInput = Console.ReadLine();
            string[] fileResult = File.ReadAllText(path).Split(" ");
            string result = "";
            for (int i = 0; i < fileResult.Length; i++)
            {
                if (!fileResult[i].Equals(userInput))
                {
                    result += fileResult[i];
                    if(i < fileResult.Length)
                    {
                        result += " ";
                    }
                }
            }
            File.WriteAllText(path, result);
            Console.WriteLine($"\"{userInput}\" was removed from the file.");
            string newResult = File.ReadAllText(path);
            Console.WriteLine($"The file now reads: {newResult}");
        }

        /// <summary>
        /// Get user input and call SentenceCounter
        /// </summary>
        public static void HandleSentenceCounter()
        {
            Console.WriteLine("What sentence would you like me to count the letters in each word for?");
            string userInput = Console.ReadLine();
            string[] result = SentenceCounter(userInput);
            Console.WriteLine(string.Join(", ", result));
        }

        /// <summary>
        /// Count the number of letters in each word of a sentence
        /// </summary>
        /// <param name="input">Sentence to be counted</param>
        /// <returns>Array with a string representing each word and it's letter count</returns>
        public static string[] SentenceCounter(string input)
        {
            char[] possibleChars = { ' ', ',', '.', ':', '-', '\t' };
            string[] result = input.Split(possibleChars);
            for (int i = 0; i < result.Length; i++)
            {
                int count = 0;
                foreach (char letter in result[i])
                {
                    count++;
                }
                result[i] += $": {count}";
            }
            return result;
        }
    }
}
