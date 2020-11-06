using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1_Challenging_Problems
{
    class Trip
    {
        int[] Costs = new int[1000];
        int nCosts = 1000;

        int SumCosts()
        {
            int sum = 0;
            for(int i = 0; i < nCosts; i++)
            {
                sum += Costs[i];
            }
            return sum;
        }
        public int run()
        {
            for(; ; )
            {
                Console.WriteLine("Enter how many member in your trip:-- \t");
                nCosts = Convert.ToInt32(Console.ReadLine());
                if (nCosts == 0)
                {
                    break;
                }
                for(int c = 0; c < nCosts; c++)
                {
                    int Rs, cents;
                    Console.WriteLine(c + "> Member: ");
                    Rs = Convert.ToInt32(Console.ReadLine());
                    cents = Rs;
                    Costs[c] = Rs * 100 + cents;
                }
                int SumCents = SumCosts();
                double avgCents = ((double)SumCents) / nCosts;
                double taken = 0;
                double given = 0;
                for(int i = 0; i < nCosts; i++)
                {
                    double deltaCents = Costs[i] - avgCents;
                    if (deltaCents < 0)
                    {
                        taken += -((int)deltaCents) / 100.0;
                    }
                    else
                    {
                        given += ((int)deltaCents) / 100.0;
                    }
                }
                Console.WriteLine("Output:-- ");
                if (taken > given)
                {
                    Console.WriteLine(taken);
                }
                else
                {
                    Console.WriteLine(given);
                }
            }
            return 0;
        }
    }
}
