using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_3_Challenging_Problems
{
    class AutomatedJudgeScript
    {
	private string getDigit(List<string> vecstrInput)
	{
		string strRet;
		for (uint i = 0; i < vecstrInput.Count; i++)
		{
			for (uint j = 0; j < vecstrInput[i].Length; j++)
			{
				if (char.IsDigit(vecstrInput[i][j]))
				{
					strRet.push_back(vecstrInput[i][j]);
				}
			}
		}
		return strRet;
	}

	private void judge(List<string> vecstrAnswer, List<string> vecstrCommit)
	{
		if (vecstrAnswer.Count == vecstrCommit.Count)
		{
			bool bAC = true;
			for (uint i = 0; i < vecstrAnswer.Count; i++)
			{
				if (vecstrAnswer[i] != vecstrCommit[i])
				{
					bAC = false;
					break;
				}
			}
			if (bAC)
			{
				Console.Write("Accepted");
				Console.Write("\n");
				return;
			}
		}
		string strAnswer;
		string strCommit;
		strAnswer = getDigit(vecstrAnswer);
		strCommit = getDigit(vecstrCommit);
		if (strAnswer == strCommit)
		{
			Console.Write("Presentation Error");
			Console.Write("\n");
			return;
		}
		Console.Write("Wrong Answer");
		Console.Write("\n");
		return;
	}

	public void run()
	{
		int n = 0;
		int m = 0;
		int cnt = 1;
		while ((n = int.Parse(ConsoleInput.ReadToWhiteSpace(true))).Length > 0)
		{
			if (n == 0)
			{
				break;
			}
			Console.Read();
			List<string> vecstrAnswer = new List<string>();
			List<string> vecstrCommit = new List<string>();
			string strAnswer;
			string strCommit;
			for (int i = 0; i < n; i++)
			{
				strAnswer = Console.ReadLine();
				vecstrAnswer.Add(strAnswer);
			}
			m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			Console.Read();
			for (int i = 0; i < m; i++)
			{
				strCommit = Console.ReadLine();
				vecstrCommit.Add(strCommit);
			}
			Console.Write("Run #");
			Console.Write(cnt++);
			Console.Write(": ");
			judge(vecstrAnswer, vecstrCommit);
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
