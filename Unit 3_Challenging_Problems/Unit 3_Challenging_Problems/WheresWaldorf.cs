using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_3_Challenging_Problems
{
    class WheresWaldorf
    {
	private bool find(List<List<char>> vvcRec, string strWord, int x, int y, int dirx, int diry)
	{
		uint k;
		uint i;
		uint j;
		for (k = 0, i = (uint)x, j = (uint)y; k < strWord.Length && i >= 0 && i < vvcRec.Count && j >= 0 && j < vvcRec[0].Count; k++, i += dirx, j += diry)
		{
			if (vvcRec[i][j] != strWord[k])
			{
				break;
			}
		}
		if (k != strWord.Length)
		{
			return false;
		}
		else
		{
			Console.Write(x + 1);
			Console.Write(' ');
			Console.Write(y + 1);
			Console.Write("\n");
			return true;
		}
	}

	public void run()
	{
		int T = 0;
		T = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		Console.Read();
		Console.Read();
		for (int t = 0; t < T; t++)
		{
			int m = 0;
			int n = 0;
			int k = 0;
			m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			List<List<char>> vvcRec = VectorHelper.NestedList(m, n, '\0');
			for (int i = 0; i < m; i++)
			{
				for (int j = 0; j < n; j++)
				{
					vvcRec[i][j] = ConsoleInput.ReadToWhiteSpace(true)[0];
					vvcRec[i][j] = char.ToLower(vvcRec[i][j]);
				}
			}
			k = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			Console.Read();
			List<string> vstrWord = new List<string>();
			string strWord;
			while (strWord = Console.ReadLine())
			{
				if (string.IsNullOrEmpty(strWord))
				{
					break;
				}
				foreach (char ch in strWord)
				{
					ch = char.ToLower(ch);
				}
				vstrWord.Add(strWord);
			}
			foreach (var word in vstrWord)
			{
				bool bFind = false;
				for (int i = 0; i < m; i++)
				{
					for (int j = 0; j < n; j++)
					{
						if (vvcRec[i][j] == word[0] && (find(vvcRec, word, i, j, -1, 0) || find(vvcRec, word, i, j, -1, 1) || find(vvcRec, word, i, j, 0, 1) || find(vvcRec, word, i, j, 1, 1) || find(vvcRec, word, i, j, 1, 0) || find(vvcRec, word, i, j, 1, -1) || find(vvcRec, word, i, j, 0, -1) || find(vvcRec, word, i, j, -1, -1)))
						{
							bFind = true;
							break;
						}
					}
					if (bFind)
					{
						break;
					}
				}
			}
			if (t != T - 1)
			{
				Console.Write("\n");
			}
		}
	}
internal static class VectorHelper
	{
		public static void Resize<T>(this List<T> list, int newSize, T value = default(T))
		{
			if (list.Count > newSize)
				list.RemoveRange(newSize, list.Count - newSize);
			else if (list.Count < newSize)
			{
				for (int i = list.Count; i < newSize; i++)
				{
					list.Add(value);
				}
			}
		}

		public static void Swap<T>(this List<T> list1, List<T> list2)
		{
			List<T> temp = new List<T>(list1);
			list1.Clear();
			list1.AddRange(list2);
			list2.Clear();
			list2.AddRange(temp);
		}

		public static List<T> InitializedList<T>(int size, T value)
		{
			List<T> temp = new List<T>();
			for (int count = 1; count <= size; count++)
			{
				temp.Add(value);
			}

			return temp;
		}

		public static List<List<T>> NestedList<T>(int outerSize, int innerSize)
		{
			List<List<T>> temp = new List<List<T>>();
			for (int count = 1; count <= outerSize; count++)
			{
				temp.Add(new List<T>(innerSize));
			}

			return temp;
		}

		public static List<List<T>> NestedList<T>(int outerSize, int innerSize, T value)
		{
			List<List<T>> temp = new List<List<T>>();
			for (int count = 1; count <= outerSize; count++)
			{
				temp.Add(InitializedList(innerSize, value));
			}

			return temp;
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