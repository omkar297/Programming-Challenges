using System;

namespace Unit_1_Challenging_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ClassDeclaration
            _3n_1 _3N_1 = new _3n_1();
            Trip trip = new Trip();
            LCDDisplay lCDDisplay = new LCDDisplay();
            GraphicalEditor graphicalEditor = new GraphicalEditor();
            Interpreter interpreter = new Interpreter();
            AustralianVoting australianVoting = new AustralianVoting();
            #endregion
            #region WelcomeDisplay
            Console.WriteLine("Welcome in Competitive Programming - I!");
            Console.WriteLine("1> 3n + 1\n2> The Trip\n3> LCD Display\n4> Graphical Editor\n5> Interpreter\n 6> Australian Voting");
            #endregion
            Console.WriteLine("Enter your choice");
            #region choice
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your choice is " + choice);
            #endregion
            #region SwitchCase
            switch (choice)
            {
                case 1:
                    {
                        _3N_1.run();
                    }break;
                case 2:
                    {
                        trip.run();
                    }break;
                case 3:
                    {
                        lCDDisplay.run();
                    }
                    break;
                case 4:
                    {
                        graphicalEditor.run();
                    }
                    break;
                case 5:
                    {
                        interpreter.run();
                    }
                    break;
                case 6:
                    {
                        australianVoting.run();
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Please Enter your true choice");
                    }break;
            }
            #endregion
            Console.ReadKey();
        }
    }
}
