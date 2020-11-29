using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_6_Challenging_Problems
{
    class Counting
    {
private List<BigInt> N = new List<BigInt>();

	private void init()
	{
		N.Capacity = 1001;
		N.Add(0);
		N.Add(2);
		N.Add(5);
		N.Add(13);
	}

	private BigInt count(int n)
	{
		if (n >= N.Count)
		{
			for (int i = N.Count; i <= n; i++)
			{
				BigInt bi = 2 * N[i - 1] + N[i - 2] + N[i - 3];
				N.Add(bi);
			}
		}
		return new BigInt(N[n]);
	}

	public void run()
	{
		init();
		int n;
		while ((n = int.Parse(ConsoleInput.ReadToWhiteSpace(true))).Length > 0)
		{
			Console.Write(count(n));
			Console.Write("\n");
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
