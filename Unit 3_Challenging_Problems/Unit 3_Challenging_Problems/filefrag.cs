using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_3_Challenging_Problems
{
    class filefrag
    {
public void Run()
	{
		string s;
		s = Console.ReadLine();
		uint T;
		istringstream ss = new istringstream(s);
		ss >> (int)T;
		// Skip the first empty line.
		s = Console.ReadLine();
		while ((T--) != 0)
		{
			List<string> fragments = new List<string>();
			while (s = Console.ReadLine() && !string.IsNullOrEmpty(s))
			{
				ss.clear();
				ss.str(s);
				string fragment;
				ss >> fragment;
				fragments.Add(fragment);
			}
			SortedDictionary<string, int> memo = new SortedDictionary<string, int>();
			for (uint i = 0; i < fragments.Count; ++i)
			{
				for (uint j = i + 1; j < fragments.Count; ++j)
				{
					++memo[fragments[i] + fragments[j]];
					++memo[fragments[j] + fragments[i]];
				}
			}
			SortedDictionary<string, int>.Enumerator iter = new SortedDictionary<string, int>.Enumerator(memo.GetEnumerator());
			SortedDictionary<string, int>.Enumerator file = new SortedDictionary<string, int>.Enumerator(memo.GetEnumerator());
			while (iter.MoveNext())
			{
				if (iter.Current.Value > file.second)
				{
					file.CopyFrom(iter);
				}
			}
			Console.Write(file.first);
			Console.Write("\n");
			if (T != 0)
			{
				Console.Write("\n");
			}
		}
	}
}
