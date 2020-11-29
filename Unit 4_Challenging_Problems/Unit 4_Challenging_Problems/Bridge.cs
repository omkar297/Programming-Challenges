using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Challenging_Problems
{
    class Bridge
    {
	public void run()
	{
		int N;
		int n;

		N = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

		for (int i = 0; i < N; i++)
		{
			LinkedList<int> LeftSide = new LinkedList<int>();
			LinkedList<int> RightSide = new LinkedList<int>();

			n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			int T;
			for (int i = 0; i < n; i++)
			{
				T = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				LeftSide.AddLast(T);
			}

			LeftSide.Sort();
			int TotalTime = 0;
			stringstream fout = new stringstream();
			while (true)
			{

				int A = LeftSide[0];

				if (LeftSide.Count == 1)
				{
					fout << A;
					TotalTime += A;
					break;
				}

				int B = LeftSide[1];
				if (LeftSide.Count == 2)
				{
					fout << A << " " << B;
					TotalTime += B;
					break;
				}

				if (LeftSide.Count == 3)
				{
					fout << A << " " << LeftSide[2] << "\n" << A << "\n" << A << " " << B;
					TotalTime += B + A + LeftSide[2];
					break;
				}
				int Y;
				int Z;

				Z = LeftSide.Last.Value;
				LeftSide.RemoveLast();
				Y = LeftSide.Last.Value;
				LeftSide.RemoveLast();
				if (A + Y < 2 * B)
				{
					fout << A << " " << Z << "\n" << A << "\n" << A << " " << Y << "\n" << A << "\n";
					TotalTime += Z + 2 * A + Y;
				}
				else
				{
					fout << A << " " << B << "\n" << A << "\n" << Y << " " << Z << "\n" << B << "\n";
					TotalTime += 2 * B + A + Z;
				}
			}

			Console.Write(TotalTime);
			Console.Write("\n");
			Console.Write(fout.str());
			Console.Write("\n");

			if (i != N - 1)
			{
				Console.Write("\n");
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
