using System;

namespace Unit_3_Challenging_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            #region variable
            int choice;
            #endregion
            #region class object
            WERTYU wERTYU = new WERTYU();
            WheresWaldorf wheresWaldorf = new WheresWaldorf();
            CommonPermutation commonPermutation = new CommonPermutation();
            AutomatedJudgeScript automatedJudgeScript = new AutomatedJudgeScript();
            #endregion
            Console.WriteLine("Welcome in Competitive Programming - I!");
            Console.WriteLine("\n1> WERTYU\n2> Where's Waldorf\n3> Common Permutation\n4> Automated Judge Script");
            Console.WriteLine("Enter your choice");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("your choice is " + choice);
            #region SwitchCase
            switch (choice)
            {
                case 1:
                    {
                        wERTYU.run();
                    }
                    break;
                case 2:
                    {
                        wheresWaldorf.run();
                    }
                    break;
                case 3:
                    {
                        commonPermutation.run();
                    }
                    break;
                case 4:
                    {
                        automatedJudgeScript.run();
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
