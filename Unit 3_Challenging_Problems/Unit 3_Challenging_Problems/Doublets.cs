using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_3_Challenging_Problems
{
    class Doublets
    {
private char[][] word = RectangularArrays.RectangularCharArray(25145, 17);
	private int n = 0;
	private List<int>[] g = Arrays.InitializeWithDefaultInstances<List<int>>(25145);
	private List<int>[] bucket = Arrays.InitializeWithDefaultInstances<List<int>>(17);
	private SortedDictionary<string, int>[] S2N = Arrays.InitializeWithDefaultInstances<SortedDictionary<string, int>>(17);
	private int isDoublet_i;
	private int isDoublet_cnt;

	private int isDoublet(int x, int y, int len)
	{
		for (isDoublet_i = 0, isDoublet_cnt = 0; isDoublet_i < len; isDoublet_i++)
		{
			isDoublet_cnt += word[x][isDoublet_i] != word[y][isDoublet_i];
			if (isDoublet_cnt > 1)
			{
				return 0;
			}
		}
		return isDoublet_cnt == 1;
	}
	private void build_graph()
	{
		int i;
		int j;
		int k;
		int m;
		int x;
		int y;
		for (i = 1; i <= 16; i++)
		{
			m = bucket[i].Count;
			for (j = 0; j < m; j++)
			{
				for (k = j + 1; k < m; k++)
				{
					x = bucket[i][j], y = bucket[i][k];
					if (isDoublet(x, y, i) != 0)
					{
						g[x].Add(y);
						g[y].Add(x);
					}
				}
			}
		}
	}
	private int[] pre = new int[25145];
	private void bfs(int st, int ed)
	{
		Queue<int> Q = new Queue<int>();
		const string used = "";
		Q.Enqueue(st), used[st] = 1, pre[st] = -1;
		while (Q.Count > 0)
		{
			st = Q.Peek(), Q.Dequeue();
			foreach (int it in g[st])
			{
				if (!used[it])
				{
					used = StringFunctions.ChangeCharacter(used, it, 1);
					pre[it] = st;
					Q.pushit;
				}
			}
			if (used[ed])
			{
				break;
			}
		}
		if (!used[ed])
		{
			Console.WriteLine("No solution.");
		}
		else
		{
			while (ed >= 0)
			{
				Console.WriteLine(word[ed]);
				ed = pre[ed];
			}
		}
	}
	public void run()
	{
		int word_len;
		int st_len;
		int ed_len;
		while (gets(word[n]) && word[n][0] != '\0')
		{
			word_len = Convert.ToString(word[n]).Length;
			bucket[word_len].Add(n);
			S2N[word_len][word[n]] = n;
			n++;
		}
		build_graph();
		string st = new string(new char[20]);
		string ed = new string(new char[20]);
		int first = 0;
		int x;
		int y;
		while (scanf("%s %s", st, ed) == 2)
		{
			if (first != 0)
			{
				Console.WriteLine("");
			}
			first = 1;
			st_len = st.Length;
			ed_len = ed.Length;
			if (st_len != ed_len)
			{
				Console.WriteLine("No solution.");
				continue;
			}
			x = S2N[st_len][st];
			y = S2N[ed_len][ed];
			bfs(y, x);
		}
	}
	internal static class Arrays
	{
		public static T[] InitializeWithDefaultInstances<T>(int length) where T : new()
		{
			T[] array = new T[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = new T();
			}
			return array;
		}

		public static void DeleteArray<T>(T[] array) where T : System.IDisposable
		{
			foreach (T element in array)
			{
				if (element != null)
					element.Dispose();
			}
		}
	}
	internal static class StringFunctions
	{
		public static string ChangeCharacter(string sourceString, int charIndex, char newChar)
		{
			return (charIndex > 0 ? sourceString.Substring(0, charIndex) : "")
				+ newChar.ToString() + (charIndex < sourceString.Length - 1 ? sourceString.Substring(charIndex + 1) : "");
		}
		public static bool IsXDigit(char character)
		{
			if (char.IsDigit(character))
				return true;
			else if ("ABCDEFabcdef".IndexOf(character) > -1)
				return true;
			else
				return false;
		}
		public static string StrChr(string stringToSearch, char charToFind)
		{
			int index = stringToSearch.IndexOf(charToFind);
			if (index > -1)
				return stringToSearch.Substring(index);
			else
				return null;
		}
		public static string StrRChr(string stringToSearch, char charToFind)
		{
			int index = stringToSearch.LastIndexOf(charToFind);
			if (index > -1)
				return stringToSearch.Substring(index);
			else
				return null;
		}
		public static string StrStr(string stringToSearch, string stringToFind)
		{
			int index = stringToSearch.IndexOf(stringToFind);
			if (index > -1)
				return stringToSearch.Substring(index);
			else
				return null;
		}
		private static string activeString;
		private static int activePosition;
		public static string StrTok(string stringToTokenize, string delimiters)
		{
			if (stringToTokenize != null)
			{
				activeString = stringToTokenize;
				activePosition = -1;
			}
			if (activeString == null)
				return null;
			if (activePosition == activeString.Length)
				return null;
			activePosition++;
			while (activePosition < activeString.Length && delimiters.IndexOf(activeString[activePosition]) > -1)
			{
				activePosition++;
			}
			if (activePosition == activeString.Length)
				return null;
			int startingPosition = activePosition;
			do
			{
				activePosition++;
			} while (activePosition < activeString.Length && delimiters.IndexOf(activeString[activePosition]) == -1);

			return activeString.Substring(startingPosition, activePosition - startingPosition);
		}
	}
	internal static class RectangularArrays
	{
		public static char[][] RectangularCharArray(int size1, int size2)
		{
			char[][] newArray = new char[size1][];
			for (int array1 = 0; array1 < size1; array1++)
			{
				newArray[array1] = new char[size2];
			}

			return newArray;
		}
	}

}
}
