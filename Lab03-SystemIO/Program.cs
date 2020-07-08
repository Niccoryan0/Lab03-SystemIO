using System;

namespace Lab03_SystemIO
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserInterface();
        }

        public static void UserInterface()
        {
            int choice = 0;
            while (choice != 9)
            {
                Console.WriteLine("Which code challenge would you like to access?");
                Console.WriteLine("1. Products");
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

        public static void HandleProdString()
        {
            Console.WriteLine("Please supply 3 numbers seperated by commas, i.e. : 1 2 3");
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
                prod *= int.Parse(myArr[i]);
            }
            return prod;
        }
    }
}
