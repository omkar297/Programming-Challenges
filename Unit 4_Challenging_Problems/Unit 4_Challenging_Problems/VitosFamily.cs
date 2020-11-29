using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Challenging_Problems
{
	class VitosFamily
	{
		public void run()
		{
			int N;

			N = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

			for (int i = 0; i < N; i++)
			{
				List<int> streets = new List<int>();

				int R;
				R = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

				for (int j = 0; j < R; j++)
				{
					int T;
					T = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					streets.Add(T);
				}
				streets.Sort();
				int best;

				best = streets[streets.Count / 2];

				long TotalDistance = 0;
				for (int j = 0; j < streets.Count; j++)
				{
					TotalDistance += Math.Abs(best - streets[j]);
				}
				Console.Write(TotalDistance);
				Console.Write("\n");
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
