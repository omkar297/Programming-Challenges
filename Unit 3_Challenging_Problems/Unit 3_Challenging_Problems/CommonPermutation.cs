using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_3_Challenging_Problems
{
    class CommonPermutation
    {
public void run()
	{
		List<int> viCnt1 = new List<int>();
		List<int> viCnt2 = new List<int>();
		string str1;
		string str2;
		while (str1 = Console.ReadLine() && str2 = Console.ReadLine())
		{
			viCnt1.assign(26, 0);
			viCnt2.assign(26, 0);
			foreach (var ch in str1)
			{
				if (char.IsLower(ch))
				{
					viCnt1[ch - 'a']++;
				}
			}
			foreach (var ch in str2)
			{
				if (char.IsLower(ch))
				{
					viCnt2[ch - 'a']++;
				}
			}
			for (uint idx = 0; idx < viCnt1.Count; idx++)
			{
				if (viCnt1[idx] < viCnt2[idx])
				{
					Console.Write((string)(viCnt1[idx], (char)idx + 'a'));
				}
				else
				{
					Console.Write((string)(viCnt2[idx], (char)idx + 'a'));
				}
			}
			Console.Write("\n");
		}
	}
}
