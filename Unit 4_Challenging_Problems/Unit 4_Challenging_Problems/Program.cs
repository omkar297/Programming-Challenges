using System;

namespace Unit_4_Challenging_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            #region variable
            int choice;
            #endregion
            #region class object
            VitosFamily vitosFamily = new VitosFamily();
            Bridge bridge = new Bridge();
            LongestNap longestNap = new LongestNap();
            Football football = new Football();
            primaryarithmetic primaryarithmetic = new primaryarithmetic();
            ReverseAndAdd reverseAndAdd = new ReverseAndAdd();
            TheStemBorcotNumber theStemBorcotNumber = new TheStemBorcotNumber();
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
                        vitosFamily.run();
                    }
                    break;
                case 2:
                    {
                        bridge.run();
                    }
                    break;
                case 3:
                    {
                        longestNap.run();
                    }
                    break;
                case 4:
                    {
                        football.run();
                    }
                    break;
                case 5:
                    {
                        primaryarithmetic.run();
                    }
                    break;
                case 6:
                    {
                        reverseAndAdd.run();
                    }
                    break;
                case 7:
                    {
                        theStemBorcotNumber.run();
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
