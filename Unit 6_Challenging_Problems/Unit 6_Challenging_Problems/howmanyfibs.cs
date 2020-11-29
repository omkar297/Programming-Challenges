using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_6_Challenging_Problems
{
    class howmanyfibs
    {
	private string str1 = new string(new char[10000]);
	private string str2 = new string(new char[10000]);
	private string str3 = new string(new char[10000]);
	private string a = new string(new char[10000]);
	private string b = new string(new char[10000]);
	private bool bigger(string t1, string t2)
	{
		int len1 = t1.Length;
		int len2 = t2.Length;
		if (len1 > len2)
		{
			return true;
		}
		else if (len1 < len2)
		{
			return false;
		}
		else
		{
			for (int i = 0; i < len1; i++)
			{
				if (t1[i] > t2[i])
				{
					return true;
				}
				else if (t1[i] < t2[i])
				{
					return false;
				}
			}
			return true;
		}
	}
	private bool contain(string str)
	{
		if (bigger(str, a) && bigger(b, str))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	private void plus(string str1, string str2, string str3)
	{
		int len1 = str1.Length;
		int len2 = str2.Length;
		int len3 = ((len1) >= (len2) ? (len1) : (len2)) + 1;
		int i;
		int j;
		int k;
		int temp;
		int carry;
		str3[len3] = '\0';
		for (i = len1 - 1, j = len2 - 1, k = len3 - 1, carry = 0; i >= 0 || j >= 0;)
		{
			if (i >= 0 && j >= 0)
			{
				temp = str1[i--] - '0' + str2[j--] - '0' + carry;
			}
			else if (i >= 0)
			{
				temp = str1[i--] - '0' + carry;
			}
			else
			{
				temp = str2[j--] - '0' + carry;
			}
			carry = temp / 10;
			temp %= 10;
			str3[k--] = '0' + temp;
		}
		str3[k] = '0' + carry;
		if (str3[0] == '0')
		{
			memmove(str3, str3 + 1, sizeof(char) * len3);
		}
	}
	public void run()
	{
		while (scanf("%s%s", a, b) == 2)
		{
			if (a[0] == '0' && b[0] == '0')
			{
				break;
			}
			str1 = StringFunctions.ChangeCharacter(str1, 0, '1', str1[1] = '\0');
			str2 = StringFunctions.ChangeCharacter(str2, 0, '2', str2[1] = '\0');

			int count = 0;
			if (contain(str1))
			{
				count++;
			}
			if (contain(str2))
			{
				count++;
			}
			while (!bigger(str2, b))
			{
				plus(str1, str2, str3);
				if (contain(str3))
				{
					count++;
				}
				memmove(str1, str2, sizeof(char));
				memmove(str2, str3, sizeof(char));
			}
			Console.Write("{0:D}\n", count);
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

}
}
