using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_2_Challenging_problems
{
    class PokerHands
    {
		int first;
	public class isValue
	{
		public isValue(int x)
		{
			this._x = x;
		}
		public static bool functorMethod(Tuple<int, int> v)
		{
			return v.Item2 == _x;
		}

		public int _x;
	}
	public class card
	{
		public char suit;
		public int value;

	}

	public static class GlobalMembers
	{
		public const string values = "23456789TJQKA";

		public static bool compareCards(card c1, card c2)
		{
			return c1.value < c2.value;
		}
		public static int isStraightFlush(List<card> Hand)
		{
			int IValue = Hand[0].value;
			char ISuit = Hand[0].suit;
			for (int i = 1; i < 5; i++)
			{
				if (Hand[i].value != IValue + i || Hand[i].suit != ISuit)
				{
					return -1;
				}
			}
			return Hand[4].value;
		}

		public static int isFourOfAKind(List<card> Hand, SortedDictionary<int, int> CardSet)
		{

			SortedDictionary<int, int>.Enumerator it = find_if(CardSet.GetEnumerator(), CardSet.end(), new isValue(4));
			if (CardSet.Count == 2 && it != CardSet.end())
			{
				return it.first;
			}
			return -1;

		}

		public static int isFullHouse(List<card> Hand, SortedDictionary<int, int> CardSet)
		{

			SortedDictionary<int, int>.Enumerator it = find_if(CardSet.GetEnumerator(), CardSet.end(), new isValue(3));
			if (CardSet.Count == 2 && it != CardSet.end())
			{
				return it.first;
			}
			return -1;

		}

		public static int isFlush(List<card> Hand)
		{
			char ISuit = Hand[0].suit;
			int value = 0;
			for (int i = 0; i < 5; i++)
			{
				if (ISuit != Hand[i].suit)
				{
					return -1;
				}
				value += Math.Pow(14.0, i) * Hand[i].value;
			}

			return value;
		}

		public static int isStraight(List<card> Hand)
		{
			int IValue = Hand[0].value;

			for (int i = 1; i < 5; i++)
			{
				if (Hand[i].value != IValue + i)
				{
					return -1;
				}
			}
			return Hand[4].value;
		}

		public static int isThreeOfAKind(List<card> Hand, SortedDictionary<int, int> CardSet)
		{
			SortedDictionary<int, int>.Enumerator it = find_if(CardSet.GetEnumerator(), CardSet.end(), new isValue(3));
			if (it != CardSet.end())
			{
				return it.first;
			}
			return -1;
		}

		public static int isTwoPairs(List<card> Hand, SortedDictionary<int, int> CardSet)
		{
			SortedDictionary<int, int>.Enumerator it = find_if(CardSet.GetEnumerator(), CardSet.end(), new isValue(2));
			if (it == CardSet.end())
			{
				return -1;
			}
			int P1Value = it.first;
			it++;
			it = find_if(it, CardSet.end(), new isValue(2));
			if (it == CardSet.end())
			{
				return -1;
			}
			int P2Value = it.first;
			return Math.Max(P1Value, P2Value) * 14 * 14 + Math.Min(P1Value, P2Value) * 14 + find_if(CardSet.GetEnumerator(), CardSet.end(), new isValue(1)).first;
		}

		public static int isPair(List<card> Hand, SortedDictionary<int, int> CardSet)
		{
			SortedDictionary<int, int>.Enumerator it = find_if(CardSet.GetEnumerator(), CardSet.end(), new isValue(2));
			if (it == CardSet.end())
			{
				return -1;
			}
			int PValue = it.first;
			int p1;
			int p2;
			int p3;
			SortedDictionary<int, int>.Enumerator it1;
			SortedDictionary<int, int>.Enumerator it2;
			SortedDictionary<int, int>.Enumerator it3;

			it1 = find_if(CardSet.GetEnumerator(), CardSet.end(), new isValue(1));
			p1 = it1.first;
			it1++;
			it2 = find_if(it1, CardSet.end(), new isValue(1));
			p2 = it2.first;
			it2++;
			it3 = find_if(it2, CardSet.end(), new isValue(1));
			p3 = it3.first;
			if (it1 == CardSet.end() || it2 == CardSet.end() || it3 == CardSet.end())
			{
				return -1;
			}
			return PValue * Math.Pow(14.0, 3) + p3 * Math.Pow(14.0, 2) + p2 * Math.Pow(14.0, 1) + p1;
		}
	}
private int other(List<card> Hand)
	{
		int value = 0;
		for (int i = 0; i < 5; i++)
		{
			value += Hand[i].value * Math.Pow(14.0, i);
		}
		return value;
	}
	public void run()
	{

		SortedDictionary<char, int> valueMap = new SortedDictionary<char, int>();

		for (int i = 0; i < 14; i++)
		{
			valueMap.Add(values[i], i);
		}
		string input = new string(new char[40]);
		while (fgets(input, 40, stdin))
		{
			List<List<card>> Hands = new List<List<card>>();
			List<card> h1 = new List<card>();
			List<card> h2 = new List<card>();
			Hands.Add(h1);
			Hands.Add(h2);

			for (long i = 0; i < 5; i++)
			{
				card c = new card();
				Hands[0].Add(c);
				Hands[0][i].value = valueMap[input[3 * i]];
				Hands[0][i].suit = input[3 * i + 1];

				Hands[1].Add(c);
				Hands[1][i].value = valueMap[input[3 * 5 + 3 * i]];
				Hands[1][i].suit = input[3 * i + 1 + 3 * 5];

			}
			Hands[0].Sort(compareCards);
			Hands[1].Sort(compareCards);
			SortedDictionary<int, int>[] CardSet = Arrays.InitializeWithDefaultInstances<SortedDictionary<int, int>>(2);


			int[] HandRanks = new int[2];
			int[] HandValues = new int[2];
			for (int i = 0; i < 10; i++)
			{
				SortedDictionary<int, int>.Enumerator it;
				it.CopyFrom(CardSet[i / 5].find(Hands[i / 5][i % 5].value));
				if (it == CardSet[i / 5].end())
				{
					CardSet[i / 5].Add(Hands[i / 5][i % 5].value, 1);
				}
				else
				{
					it.second++;
				}
			}

			for (int i = 0; i < 2; i++)
			{
				HandValues[i] = isStraightFlush(Hands[i]);
				if (HandValues[i] != -1)
				{
					HandRanks[i] = 9;
					continue;
				}

				HandValues[i] = isFourOfAKind(Hands[i], CardSet[i]);
				if (HandValues[i] != -1)
				{
					HandRanks[i] = 8;
					continue;
				}

				HandValues[i] = isFullHouse(Hands[i], CardSet[i]);
				if (HandValues[i] != -1)
				{
					HandRanks[i] = 7;
					continue;
				}

				HandValues[i] = isFlush(Hands[i]);
				if (HandValues[i] != -1)
				{
					HandRanks[i] = 6;
					continue;
				}

				HandValues[i] = isStraight(Hands[i]);
				if (HandValues[i] != -1)
				{
					HandRanks[i] = 5;
					continue;
				}

				HandValues[i] = isThreeOfAKind(Hands[i], CardSet[i]);
				if (HandValues[i] != -1)
				{
					HandRanks[i] = 4;
					continue;
				}

				HandValues[i] = isTwoPairs(Hands[i], CardSet[i]);
				if (HandValues[i] != -1)
				{
					HandRanks[i] = 3;
					continue;
				}

				HandValues[i] = isPair(Hands[i], CardSet[i]);
				if (HandValues[i] != -1)
				{
					HandRanks[i] = 2;
					continue;
				}

				HandValues[i] = other(new List<List<card>>(Hands[i]));
				HandRanks[i] = 1;

			}

			if (HandRanks[0] > HandRanks[1])
			{
				Console.Write("Black wins.");
			}
			else if (HandRanks[0] < HandRanks[1])
			{
				Console.Write("White wins.");
			}
			else
			{
				if (HandValues[0] > HandValues[1])
				{
					Console.Write("Black wins.");
				}
				else if (HandValues[0] < HandValues[1])
				{
					Console.Write("White wins.");
				}
				else
				{
					Console.Write("Tie.");
				}
			}

			Console.Write("\n");
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

}  
