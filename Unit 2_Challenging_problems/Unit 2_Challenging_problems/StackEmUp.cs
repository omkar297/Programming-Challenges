using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_2_Challenging_problems
{
    class StackEmUp
    {
public void run()
	{
		int n = 0;
		n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		Console.Read();
		Console.Read();
		for (int k = 0; k < n; k++)
		{
			int cnt = 0;
			int suit = 0;
			int num = 0;
			uint idx;
			cnt = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			List<List<int>> viiShuffle = VectorHelper.NestedList(cnt, 52, 0);
			List<int> viInput = new List<int>(52);
			List<int> viOutput = new List<int>(52);
			for (int i = 0; i < cnt; i++)
			{
				for (int j = 0; j < 52; j++)
				{
					viiShuffle[i][j] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					viInput[j] = j;
				}
			}
			Console.Read();
			string strIdx;
			while (strIdx = Console.ReadLine())
			{
				if (string.IsNullOrEmpty(strIdx))
				{
					break;
				}
				idx = Convert.ToUInt32(strIdx);
				for (int j = 0; j < 52; j++)
				{
					viOutput[j] = viInput[viiShuffle[idx - 1][j] - 1];
				}
				viInput.assign(viOutput.GetEnumerator(), viOutput.end());
			}
			for (int j = 0; j < 52; j++)
			{
				suit = viOutput[j] / 13;
				num = viOutput[j] % 13;
				if (num >= 0 && num <= 8)
				{
					Console.Write(num + 2);
				}
				else if (num == 9)
				{
					Console.Write("Jack");
				}
				else if (num == 10)
				{
					Console.Write("Queen");
				}
				else if (num == 11)
				{
					Console.Write("King");
				}
				else if (num == 12)
				{
					Console.Write("Ace");
				}
				Console.Write(" of ");
				if (suit == 0)
				{
					Console.Write("Clubs");
					Console.Write("\n");
				}
				else if (suit == 1)
				{
					Console.Write("Diamonds");
					Console.Write("\n");
				}
				else if (suit == 2)
				{
					Console.Write("Hearts");
					Console.Write("\n");
				}
				else if (suit == 3)
				{
					Console.Write("Spades");
					Console.Write("\n");
				}
				//cout << viOutput[j] << ' ';
			}
			if (k != n - 1)
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
			//the first non white space character:
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
