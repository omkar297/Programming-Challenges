using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1_Challenging_Problems
{
    class LCDDisplay
    {
        int nLines;
        int nColumns;
        char[,] lcdNumber = new char[23, 12];
        char[,,] lcdNumbers = new char[8, 23, 12];
        void setLcdSize(int size)
        {
            nLines = 2 * size + 3;
            nColumns = size + 2;
        }
        void clearLcd()
        {
            for(int i = 0; i < nLines; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    lcdNumber[i, j] = ' ';
                }
            }
        }
        void drawLine(int lineNumber)
        {
            for(int j = 1; j < nColumns - 1; j++)
            {
                lcdNumber[lineNumber, j] = '-';
            }
        }
        void drawFirstLine()
        {
            drawLine(0);
        }
        void drawMiddleLine()
        {
            drawLine(nLines / 2);
        }

        void drawLastLine()
        {
            drawLine(nLines - 1);
        }

        void drawFirstColumn(int columnNumber)
        {
            int i;
            for (i = 1; i < nLines / 2; i++)
            {
                lcdNumber[i, columnNumber] = '|';
            }
        }

        void drawLastColumn(int columnNumber)
        {
            int i;
            for (i = (nLines / 2) + 1; i < nLines - 1; i++)
            {
                lcdNumber[i, columnNumber] = '|';
            }
        }

        void drawFirstLeftColumn()
        {
            drawFirstColumn(0);
        }

        void drawLastLeftColumn()
        {
            drawLastColumn(0);
        }

        void drawFirstRightColumn()
        {
            drawFirstColumn(nColumns - 1);
        }

        void drawLastRightColumn()
        {
            drawLastColumn(nColumns - 1);
        }
        void printLcd(int position)
        {
            for(int i = 0; i < nLines; i++)
            {
                for(int j = 0; j < nColumns; j++)
                {
                    lcdNumbers[position, i, j] = lcdNumber[i, j];
                }
            }
        }
        void printZero(int position)
        {
            clearLcd();
            drawFirstLine();
            drawFirstLeftColumn();
            drawFirstRightColumn();
            drawLastLeftColumn();
            drawLastRightColumn();
            drawLastLine();
            printLcd(position);
        }

        void printOne(int position)
        {
            clearLcd();
            drawFirstRightColumn();
            drawLastRightColumn();
            printLcd(position);
        }

        void printTwo(int position)
        {
            clearLcd();
            drawFirstLine();
            drawFirstRightColumn();
            drawMiddleLine();
            drawLastLeftColumn();
            drawLastLine();
            printLcd(position);
        }

        void printThree(int position)
        {
            clearLcd();
            drawFirstLine();
            drawFirstRightColumn();
            drawMiddleLine();
            drawLastRightColumn();
            drawLastLine();
            printLcd(position);
        }

        void printFour(int position)
        {
            clearLcd();
            drawFirstLeftColumn();
            drawFirstRightColumn();
            drawMiddleLine();
            drawLastRightColumn();
            printLcd(position);
        }

        void printFive(int position)
        {
            clearLcd();
            drawFirstLine();
            drawFirstLeftColumn();
            drawMiddleLine();
            drawLastRightColumn();
            drawLastLine();
            printLcd(position);
        }

        void printSix(int position)
        {
            clearLcd();
            drawFirstLine();
            drawFirstLeftColumn();
            drawMiddleLine();
            drawLastLeftColumn();
            drawLastRightColumn();
            drawLastLine();
            printLcd(position);
        }

        void printSeven(int position)
        {
            clearLcd();
            drawFirstLine();
            drawFirstRightColumn();
            drawLastRightColumn();
            printLcd(position);
        }

        void printEight(int position)
        {
            clearLcd();
            drawFirstLine();
            drawFirstLeftColumn();
            drawFirstRightColumn();
            drawMiddleLine();
            drawLastLeftColumn();
            drawLastRightColumn();
            drawLastLine();
            printLcd(position);
        }

        void printNine(int position)
        {
            clearLcd();
            drawFirstLine();
            drawFirstLeftColumn();
            drawFirstRightColumn();
            drawMiddleLine();
            drawLastRightColumn();
            drawLastLine();
            printLcd(position);
        }
        private void printNumber(int n, int position)
        {
            //C++ TO C# CONVERTER TODO TASK: The following line could not be converted:
            functionsDelegate[] functions = { printZero, printOne, printTwo, printThree, printFour, printFive, printSix, printSeven, printEight, printNine };

            functions[n](position);
        }

        private delegate void functionsDelegate(int position);
        public int run()
        {
            int size = 0;
            string strNumber = new string(new char[9]);
            Console.WriteLine("Enter Size:-- ");
            size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Number:-- ");
            strNumber = Console.ReadLine();
            while (size != 0 || Convert.ToInt32(strNumber) != 0)
            {
                setLcdSize(size);
                int length = strNumber.Length;
                for(int i = 0; i < length; i++)
                {
                    int n = strNumber[i] - '0';
                    printNumber(n, i);
                }
                for(int i = 0; i < nLines; i++)
                {
                    for(int n = 0; n < length; n++)
                    {
                        for(int j = 0; j < nColumns; j++)
                        {
                            Console.WriteLine(lcdNumbers[n, i, j]);
                        }
                        if (n < length - 1)
                        {
                            Console.WriteLine(" ");
                        }
                    }
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n");
                size = Convert.ToInt32(Console.ReadLine());
                strNumber = Console.ReadLine();
            }
            return 0;
        }
    }
}
