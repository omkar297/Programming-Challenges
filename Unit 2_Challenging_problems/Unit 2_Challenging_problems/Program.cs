using System;

namespace Unit_2_Challenging_problems
{
    class Program
    {
        static void Main(string[] args)
        {
            #region variable
            int choice;
            #endregion
            #region class object
            JollyJumper jollyJumper = new JollyJumper();
            PokerHands pokerHands = new PokerHands();
            Hartals hartals = new Hartals();
            CryptKicker cryptKicker = new CryptKicker();
            StackEmUp stackEmUp = new StackEmUp();
            ErdpsNumber erdpsNumber = new ErdpsNumber();
            #endregion
            Console.WriteLine("Welcome in Competitive Programming - I!");
            Console.WriteLine("\n1>Jolly Jumpers\n2> Poker Hands\n3> Hartals\n4> Crypt Kicker\n5> Stack em Up\n6> Erdos Number");
            Console.WriteLine("Enter your choice");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("your choice is " + choice);
            #region SwitchCase
            switch (choice)
            {
                case 1:
                    {
                        jollyJumper.run();
                    }break;
                case 2:
                    {
                        pokerHands.run();
                    }
                    break;
                case 3:
                    {
                        hartals.run();
                    }
                    break;
                case 4:
                    {
                        cryptKicker.run();
                    }
                    break;
                case 5:
                    {
                        stackEmUp.run();
                    }
                    break;
                case 6:
                    {
                        erdpsNumber.run();
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Please enter your true choice!!");
                    }break;
            }
            #endregion
            Console.ReadKey();
        }
    }
}
