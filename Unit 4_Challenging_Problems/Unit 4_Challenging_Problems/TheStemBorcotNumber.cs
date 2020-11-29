using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Challenging_Problems
{
    class TheStemBorcotNumber
    {
public void run()
	{

		int m;
		int n;

		while (true)
		{
			m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			if (m == 1 && n == 1)
			{

				int Nm = 1;
				int Nn = 1;
				int NFm = 0;
				int NFn = 1;
				int NMn = 0;
				int NMm = 1;
			}
			string output = "";
			double value = (double)m / n;


			for (; Nm != m || Nn != n; Nm = NFm + NMm, Nn = NFn + NMn)
			{
				if (value > (double)Nm / Nn)
				{
					NFn = Nn,NFm = Nm,output += "R";
				}
				else
				{
					NMn = Nn,NMm = Nm,output += "L";
				}
			}

			Console.Write(output);
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
