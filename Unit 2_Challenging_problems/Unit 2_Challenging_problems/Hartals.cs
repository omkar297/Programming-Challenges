using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_2_Challenging_problems
{
    class Hartals
    {

public void run()
	{
		int T = 0;
		T = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		for (int i = 0; i < T; i++)
		{
			int N;
			int P;
			N = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			P = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			List<int> vh = new List<int>(P);
			List<int> vd;
			for (int k = 0; k < P; k++)
			{
				vh[k] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			}
			int today;
			for (int k = 0; k < P; k++)
			{
				for (int day = vh[k] - 1; day < N; day += vh[k])
				{
					today = day % 7;
					if (today == 5 || today == 6)
					{
						continue;
					}
					else
					{
						//vd[day] = true;
					}
				}
			}
			int cnt = 0;
			foreach (var b in vd)
			{
				if (b != 0)
				{
					cnt++;
				}
			}
			Console.Write(cnt);
			Console.Write("\n");
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
}
