using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_6_Challenging_Problems
{
    class HowManyPieces
    {
private BigInt combination(BigInt n, uint m)
	{
		BigInt r = new BigInt();
		if (n == m)
		{
			r = 1;
		}
		else
		{
			r.CopyFrom(n);
			BigInt f = new BigInt(n);
			for (uint i = 1; i < m; i++)
			{
				f -= 1;
				r.CopyFrom(r * f);
			}
			r.CopyFrom(r / BigInt.fact(m));
		}
		return new BigInt(r);
	}

	private BigInt how_many_pieces(int n)
	{
		BigInt bn = new BigInt(n);
		return combination(bn, 2) + combination(bn, 4) + 1;
	}

	public void run()
	{
		int s;
		s = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		for (int i = 0; i < s; i++)
		{
			int n;
			n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			Console.Write(how_many_pieces(n));
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
