using System;

namespace Unit_6_Challenging_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                #region variable
                int choice;
                #endregion
                #region class object
                howmanyfibs howmanyfibs = new howmanyfibs();
                HowManyPieces howManyPieces = new HowManyPieces();
                Counting counting = new Counting();
                #endregion
                Console.WriteLine("Welcome in Competitive Programming - I!");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("your choice is " + choice);
                #region SwitchCase
                switch (choice)
                {
                    case 1:
                        {
                            howmanyfibs.run();
                        }
                        break;
                    case 2:
                        {
                            howManyPieces.run();
                        }
                        break;
                    case 3:
                        {
                            counting.run();
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please enter your true choice!!");
                        }
                        break;
                }
                #endregion
                Console.ReadKey();
            }
        }
    }
}
