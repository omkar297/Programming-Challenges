using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_2_Challenging_problems
{
    class CryptKicker
    {
	private void decrypt(SortedSet<string> sstrCipher, SortedSet<string>.Enumerator sstriterCurr, SortedDictionary<string, bool> mstrbDic, ref SortedDictionary<char, char> mccDec, SortedDictionary<char, char> mccEnc, SortedDictionary<char, char> mccTmp, ref bool bSolved)
	{
		if (sstriterCurr == sstrCipher.end())
		{
			mccDec = mccTmp;
			bSolved = true;
			return;
		}
		List<bool> vbNew = new List<bool>(sstriterCurr.Length, false);
		for (var iter = mstrbDic.GetEnumerator(); iter != mstrbDic.end(); iter++)
		{
			if (bSolved)
			{
				return;
			}
			if (iter.second == null && iter.first.size() == sstriterCurr.Length)
			{
				bool bConflict = false;
				for (uint i = 0; i < sstriterCurr.Length; i++)
				{
					if (mccTmp.ContainsKey(sstriterCurr[i]))
					{
						if ((mccTmp[sstriterCurr[i]] != iter.first.at(i)))
						{
							bConflict = true;
							break;
						}
					}
					else if (mccEnc.ContainsKey(iter.first.at(i)))
					{
						if ((mccEnc[iter.first.at(i)] != sstriterCurr[i]))
						{
							bConflict = true;
							break;
						}
					}
					else
					{
						mccTmp[sstriterCurr[i]] = iter.first.at(i);
						mccEnc[iter.first.at(i)] = sstriterCurr[i];
						vbNew[i] = true;
					}
				}
				if (bConflict)
				{
					for (uint i = 0; i < sstriterCurr.Length; i++)
					{
						if (vbNew[i])
						{
							mccTmp.Remove(sstriterCurr[i]);
							mccEnc.Remove(iter.first.at(i));
							vbNew[i] = false;
						}
					}
					continue;
				}
				iter.second = true;
				sstriterCurr++;
				decrypt(sstrCipher, new SortedSet<string>.Enumerator(sstriterCurr), mstrbDic, ref mccDec, mccEnc, mccTmp, ref bSolved);
				sstriterCurr--;
				iter.second = false;
				for (uint i = 0; i < sstriterCurr.Length; i++)
				{
					if (vbNew[i])
					{
						mccTmp.Remove(sstriterCurr[i]);
						mccEnc.Remove(iter.first.at(i));
						vbNew[i] = false;
					}
				}
			}
		}
	}

	public void run()
	{
		int size = 0;
		size = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		string strWord;
		string strCipher;
		SortedDictionary<string, bool> mstrbDic = new SortedDictionary<string, bool>();
		for (int i = 0; i < size; i++)
		{
			strWord = ConsoleInput.ReadToWhiteSpace(true);
			mstrbDic[strWord] = false;
		}
		Console.Read();
		while (strCipher = Console.ReadLine())
		{
			SortedSet<string> sstrCipher = new SortedSet<string>();
			SortedDictionary<char, char> mccDec = new SortedDictionary<char, char>();
			SortedDictionary<char, char> mccEnc = new SortedDictionary<char, char>();
			SortedDictionary<char, char> mccTmp = new SortedDictionary<char, char>();
			istringstream iss = new istringstream(strCipher);
			while ((iss >> strWord) != 0)
			{
				sstrCipher.Add(strWord);
			}
			bool bSolved = false;
			decrypt(sstrCipher, sstrCipher.GetEnumerator(), mstrbDic, ref mccDec, mccEnc, mccTmp, ref bSolved);
			foreach (var c in strCipher)
			{
				if (c == ' ')
				{
					Console.Write(' ');
				}
				else
				{
					if (bSolved)
					{
						Console.Write(mccDec[c]);
					}
					else
					{
						Console.Write('*');
					}
				}
			}
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
