using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1_Challenging_Problems
{
    class _3n_1
    {
        #region Variable
        int i, j, k = 0, n = 0, cycleLength;
        #endregion
        #region Public Function
        public void run()
        {
            do
            {
                try
                {
                    Console.WriteLine("Enter a pair of input integers between which to find maximum cycle length: ");
                    i = Int32.Parse(Console.ReadLine().ToString());
                    j = Int32.Parse(Console.ReadLine().ToString());
                    Console.Write("\n");
                    Array a = Array.CreateInstance(typeof(Int32), j);
                    Console.Write(i + " " + j + " ");

                    do
                    {
                        n = i;
                        cycleLength = 1;
                        do
                        {
                            bool parity = n % 2 == 0 ? true : false;
                            if (parity)
                                n /= 2;
                            else
                                n = 3 * n + 1;
                            //Console.Write(n + " ");
                            cycleLength++;

                        } while (n != 1);

                        a.SetValue(cycleLength++, k++);
                        i++;

                    } while (i != j);

                    Array.Sort(a);

                    Console.WriteLine(a.GetValue(a.Length - 1));
                    Console.WriteLine("Cycle:-- " + cycleLength);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        #endregion
    }
}
