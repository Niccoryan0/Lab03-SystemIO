using System;

namespace Lab03_SystemIO
{
    public class Program
    {
        static void Main()
        {
            UserInterface();
        }

        public static void UserInterface()
        {
            int choice = -1;
            while (choice != 9)
            {
                Console.WriteLine("Which code challenge would you like to access?");
                Console.WriteLine("1. Product");
                Console.WriteLine("2. Average");
                Console.WriteLine("3. Products");
                Console.WriteLine("4. Products");
                Console.WriteLine("5. Products");
                Console.WriteLine("6. Products");
                Console.WriteLine("7. Products");
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
                        HandleProdString();
                        break;
                    case 4:
                        HandleProdString();
                        break;
                    case 5:
                        HandleProdString();
                        break;
                    case 6:
                        HandleProdString();
                        break;
                    case 7:
                        HandleProdString();
                        break;
                    case 8:
                        HandleProdString();
                        break;
                    case 9:
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

        static void HandleProdString()
        {
            Console.WriteLine("Please supply 3 numbers separated by commas, i.e. : 1 2 3");
            string userChoice = Console.ReadLine();
            int result = ProdString(userChoice);
            Console.WriteLine($"The product of {userChoice} is : {result}");
        }

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

        public static decimal GetAverage(int[] arr)
        {
            decimal result = 0;
            foreach (int num in arr)
            {
                result += num;
            }
            return result / arr.Length;
        }
    }
}
