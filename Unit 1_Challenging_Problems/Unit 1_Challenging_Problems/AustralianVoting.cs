using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1_Challenging_Problems
{
    class AustralianVoting
    {
public void run()
	{
			int t, n, i, j;
			t = Convert.ToInt32(Console.ReadLine());
		Console.Read();
		while ((t--) != 0)
		{
			string tempVar2 = ConsoleInput.ScanfRead();
			if (tempVar2 != null)
			{
				n = int.Parse(tempVar2);
			}
			Console.Read();
			string[] name = new string[25];
			string line;
			int[][] vote = RectangularArrays.RectangularIntArray(1005, 25);
			for (i = 1; i <= n; i++)
			{
				name[i] = Console.ReadLine();
			}
			int m = 0;
			while (line = Console.ReadLine())
			{
				if (line == "")
				{
					break;
				}
				stringstream sin = new stringstream();
				sin << line;
				int idx = 0;
				while ((sin >> vote[m][idx]) != 0)
				{
					idx++;
				}
				m++;
			}
			int[] Idx = new int[1005];
			int[] fire = new int[25];
			while (true)
			{
				int[] p = new int[25];
				int tot = 0;
				for (i = 0; i < m; i++)
				{
					while (Idx[i] < n && fire[vote[i][Idx[i]]] != 0)
					{
						Idx[i]++;
					}
					if (Idx[i] < n)
					{
						p[vote[i][Idx[i]]]++;
						tot++;
					}
				}
				int half = tot / 2 + tot % 2;
				int mx = 0;
				int mi = 0xffff;
				for (i = 1; i <= n; i++)
				{
					if (fire[i] == 0)
					{
						if (p[i] > mx)
						{
							mx = p[i];
						}
						if (p[i] < mi)
						{
							mi = p[i];
						}
					}
				}
				if (mx == mi || mx >= half)
				{
					for (i = 1; i <= n; i++)
					{
						if (p[i] == mx)
						{
							Console.Write(name[i]);
							Console.Write("\n");
						}
					}
					break;
				}
				for (i = 1; i <= n; i++)
				{
					if (p[i] == mi)
					{
						fire[i] = 1;
					}
				}
			}
			if (t != 0)
			{
				Console.WriteLine("");
			}
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
	internal static class RectangularArrays
	{
		public static int[][] RectangularIntArray(int size1, int size2)
		{
			int[][] newArray = new int[size1][];
			for (int array1 = 0; array1 < size1; array1++)
			{
				newArray[array1] = new int[size2];
			}

			return newArray;
		}
	}

}
}
