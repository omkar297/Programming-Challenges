using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Challenging_Problems
{
	class primaryarithmetic
	{
		public void run()
		{

			while (true)
			{
				int m;
				int n;
				m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				if (m == 0 && n == 0)
				{
					break;
				}
				int carry = 0;
				int ncarries = 0;
				while (m > 0 || n > 0)
				{
					carry = (m % 10 + n % 10 + carry) / 10;
					m /= 10;
					n /= 10;
					if (carry != 0)
					{
						ncarries++;
					}
				}

				if (ncarries == 0)
				{
					Console.Write("No carry operation.\n");
				}
				else
				{
					Console.Write(ncarries);
					Console.Write(" carry operation");
					Console.Write(((ncarries > 1) ? ("s.\n") : (".\n")));
				}
			}
		}

		internal static class DefineConstants
		{
			public const int INT_MAX = 2147483647;
			public const int INT_MIN = -2147483648;
			public const double E = 2.71828182845904523536;
		}
		internal static class ConsoleInput
		{
			private static bool goodLastRead = false;
			public static bool LastReadWasGood
			{
				get
				{
					return goodLastRead;
				}
			}

			public static string ReadToWhiteSpace(bool skipLeadingWhiteSpace)
			{
				string input = "";

				char nextChar;
				while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
				{
					if (!skipLeadingWhiteSpace)
						input += nextChar;
				}
				input += nextChar;

				while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
				{
					input += nextChar;
				}

				goodLastRead = input.Length > 0;
				return input;
			}

			public static string ScanfRead(string unwantedSequence = null, int maxFieldLength = -1)
			{
				string input = "";

				char nextChar;
				if (unwantedSequence != null)
				{
					nextChar = '\0';
					for (int charIndex = 0; charIndex < unwantedSequence.Length; charIndex++)
					{
						if (char.IsWhiteSpace(unwantedSequence[charIndex]))
						{
							while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
							{
							}
						}
						else
						{
							nextChar = (char)System.Console.Read();
							if (nextChar != unwantedSequence[charIndex])
								return null;
						}
					}

					input = nextChar.ToString();
					if (maxFieldLength == 1)
						return input;
				}

				while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
				{
					input += nextChar;
					if (maxFieldLength == input.Length)
						return input;
				}

				return input;
			}
		}
	}
}
