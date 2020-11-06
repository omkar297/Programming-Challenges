using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_2_Challenging_problems
{
    class ErdpsNumber
    {
private List<string> getAuthors(string strAuthor)
	{
		List<string> vstrAuthors = new List<string>();
		uint begin = 0;
		uint end = (uint)strAuthor.IndexOf(".,", begin);
		while (end != -1)
		{
			vstrAuthors.Add(strAuthor.Substring(begin, end + 1 - begin));
			begin = end + 3;
			end = (uint)strAuthor.IndexOf(".,", begin);
		}
		vstrAuthors.Add(strAuthor.Substring(begin));
		return new List<string>(vstrAuthors);
	}

	private void calErdosNum(SortedDictionary<string, int> mstriErdos, SortedDictionary<string, SortedSet<string>> mstrsstrCop)
	{
		SortedSet<string> sstrInput = new SortedSet<string>();
		SortedSet<string> sstrUpdate = new SortedSet<string>();
		mstriErdos["Erdos, P."] = 0;
		sstrInput.Add("Erdos, P.");
		int iErdos = 1;
		while (true)
		{
			for (var iterAuthor = sstrInput.GetEnumerator(); iterAuthor != sstrInput.end(); iterAuthor++)
			{
				if (mstrsstrCop.ContainsKey(*iterAuthor))
				{
					SortedSet<string> sstrCoper = mstrsstrCop[*iterAuthor];
					for (var iterCoper = sstrCoper.GetEnumerator(); iterCoper != sstrCoper.end(); iterCoper++)
					{
						if (!mstriErdos.ContainsKey(*iterCoper))
						{
							mstriErdos[*iterCoper] = iErdos;
							sstrUpdate.Add(*iterCoper);
						}
					}
				}
			}
			if (sstrUpdate.Count == 0)
			{
				break;
			}
			iErdos++;
			sstrInput = new SortedSet<string>(sstrUpdate);
			sstrUpdate.Clear();
		}
	}

	public void run()
	{
		int T = 0;
		T = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		for (int t = 0; t < T; t++)
		{
			int P = 0;
			int N = 0;
			P = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			N = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			Console.Read();
			SortedDictionary<string, int> mstriErdos = new SortedDictionary<string, int>();
			SortedDictionary<string, SortedSet<string>> mstrsstrCop = new SortedDictionary<string, SortedSet<string>>();
			List<string> vstrAuthor = new List<string>();
			string strPaper;
			for (int p = 0; p < P; p++)
			{
				strPaper = Console.ReadLine();
				vstrAuthor = new List<string>(getAuthors(strPaper.Substring(0, strPaper.IndexOfAny((Convert.ToString(':')).ToCharArray()))));
				for (uint i = 0; i < vstrAuthor.Count; i++)
				{
					for (uint j = 0; j < vstrAuthor.Count; j++)
					{
						if (i != j)
						{
							mstrsstrCop[vstrAuthor[i]].Add(vstrAuthor[j]);
						}
					}
				}
			}
			calErdosNum(mstriErdos, mstrsstrCop);
			Console.Write("Scenario ");
			Console.Write(t + 1);
			Console.Write("\n");
			string strAuthor;
			for (int n = 0; n < N; n++)
			{
				strAuthor = Console.ReadLine();
				Console.Write(strAuthor);
				Console.Write(' ');
				var iter = mstriErdos.find(strAuthor);
				if (iter != mstriErdos.end())
				{
					Console.Write(iter.second);
					Console.Write("\n");
				}
				else
				{
					Console.Write("infinity");
					Console.Write("\n");
				}
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
