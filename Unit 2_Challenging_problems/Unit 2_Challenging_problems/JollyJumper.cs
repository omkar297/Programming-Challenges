using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_2_Challenging_problems
{
    class JollyJumper
    {
		public void run()
		{

			int Left;
			int Right;
			while (true)
			{
				int n;
				int[] Numbers = new int[3000];
				char input;
				input = Console.ReadLine();
				if (input == '\n')
				{
					break;
				}
				if (cin.eof())
				{
					break;
				}
				cin.putback(input);
				n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

				Right = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

				for (int i = 0; i < n - 1; i++)
				{
					Left = Right;
					Right = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					int diff = Math.Abs(Right - Left);
					if (diff >= 1 && diff <= n - 1)
					{
						Numbers[diff] = 1;
					}
				}

				bool Jolly = true;

				for (int i = 1; i < n; i++)
				{
					if (Numbers[i] == 0)
					{
						Jolly = false;
					}
				}

				if (Jolly)
				{
					Console.Write("Jolly");
				}
				else
				{
					Console.Write("Not jolly");
				}

				Console.Write("\n");
				Console.Read();
			}
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
					//accumulate leading white space if skipLeadingWhiteSpace is false:
					if (!skipLeadingWhiteSpace)
						input += nextChar;
				}
				//the first non white space character:
				input += nextChar;

				//accumulate characters until white space is reached:
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
							//ignore all subsequent white space:
							while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
							{
							}
						}
						else
						{
							//ensure each character matches the expected character in the sequence:
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
