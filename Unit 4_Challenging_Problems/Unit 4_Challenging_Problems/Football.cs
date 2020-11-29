using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Challenging_Problems
{
    class Football
    {
public class Team
	{
		public int nGames;
		public int nWins;
		public int nTies;
		public int nLoss;
		public int nGoals;
		public int nGoalsAgainst;
		public int nPoints;
		public string Name;
		public Team(string TN)
		{
			nGames = nWins = nTies = nLoss = nGoals = nGoalsAgainst = 0;
			Name = TN;
		}
		public Team()
		{
			nGames = nWins = nTies = nLoss = nGoals = nGoalsAgainst = 0;
		}
	}

	public static class GlobalMembers
	{
		public static bool CompareTeams(Tuple<string, Team> e1, Tuple<string, Team> e2)
		{
			Team a = e1.Item2;
			Team b = e2.Item2;
			int PointsA = a.nWins * 3 + a.nTies;
			int PointsB = b.nWins * 3 + b.nTies;
			int GDA = a.nGoals - a.nGoalsAgainst;
			int GDB = b.nGoals - b.nGoalsAgainst;
			if (PointsA != PointsB)
			{
				return PointsA > PointsB;
			}
			if (a.nWins != b.nWins)
			{
				return a.nWins > b.nWins;
			}
			if (GDA != GDB)
			{
				return GDA > GDB;
			}
			if (a.nGoals != b.nGoals)
			{
				return a.nGoals > b.nGoals;
			}
			if (a.nGames != b.nGames)
			{
				return a.nGames < b.nGames;
			}
			for (int i = 0; i < (int)a.Name.Length; i++)
			{
				a.Name = StringFunctions.ChangeCharacter(a.Name, i, char.ToLower(a.Name[i]));
			}
			for (int i = 0; i < (int)b.Name.Length; i++)
			{
				b.Name = StringFunctions.ChangeCharacter(b.Name, i, char.ToLower(b.Name[i]));
			}
			return a.Name < b.Name;
		}
		public void run()
		{
			string tempVar = ConsoleInput.ScanfRead();
			if (tempVar != null)
			{
				N = tempVar;
			}
			for (int i = 0; i < N; i++)
			{
				int nTeams;
				string TournName = new string(new char[1000]);
				TournName = Console.ReadLine();
				string tempVar2 = ConsoleInput.ScanfRead();
				if (tempVar2 != null)
				{
					nTeams = int.Parse(tempVar2);
				}
				SortedDictionary<string, Team> Teams = new SortedDictionary<string, Team>();
				for (int j = 0; j < nTeams; j++)
				{
					string TeamName = new string(new char[1000]);
					TeamName = Console.ReadLine();
					Team T = new Team(TeamName);
					Teams.Add(TeamName, T);
				}
				int nGames;
				string tempVar3 = ConsoleInput.ScanfRead();
				if (tempVar3 != null)
				{
					nGames = int.Parse(tempVar3);
				}
				string Game = new string(new char[1000]);
				Game = Console.ReadLine();
				for (int j = 0; j < nGames; j++)
				{
					Game = Console.ReadLine();
					char buff;
					stringstream s = new stringstream(Game);
					string TeamNameA;
					string TeamNameB;
					int GoalsA;
					int GoalsB;
					getline(s, TeamNameA, '#');
					s >> GoalsA >> buff >> GoalsB >> buff;
					getline(s, TeamNameB);
					Teams[TeamNameA].nGames++;
					Teams[TeamNameB].nGames++;
					Teams[TeamNameA].nGoals += GoalsA;
					Teams[TeamNameB].nGoals += GoalsB;
					Teams[TeamNameA].nGoalsAgainst += GoalsB;
					Teams[TeamNameB].nGoalsAgainst += GoalsA;
					if (GoalsA == GoalsB)
					{
						Teams[TeamNameA].nTies++, Teams[TeamNameB].nTies++;
					}
					else if (GoalsA > GoalsB)
					{
						Teams[TeamNameA].nWins++, Teams[TeamNameB].nLoss++;
					}
					else
					{
						Teams[TeamNameA].nLoss++, Teams[TeamNameB].nWins++;
					}
				}
				List<Tuple<string, Team>> SortedTeams = new List<Tuple<string, Team>>();
				copy(Teams.GetEnumerator(), Teams.end(), back_inserter(SortedTeams));
				SortedTeams.Sort(CompareTeams);
				Console.Write("{0}\n", TournName);
				for (int j = 0; j < SortedTeams.Count; j++)
				{
					Console.Write("{0:D}) {1} {2:D}p, {3:D}g ({4:D}-{5:D}-{6:D}), {7:D}gd ({8:D}-{9:D})\n", j + 1, SortedTeams[j].Item1.c_str(), SortedTeams[j].Item2.nWins * 3 + SortedTeams[j].Item2.nTies, SortedTeams[j].Item2.nGames, SortedTeams[j].Item2.nWins, SortedTeams[j].Item2.nTies, SortedTeams[j].Item2.nLoss, SortedTeams[j].Item2.nGoals - SortedTeams[j].Item2.nGoalsAgainst, SortedTeams[j].Item2.nGoals, SortedTeams[j].Item2.nGoalsAgainst);
				}
				if (i != N - 1)
				{
					Console.Write("\n");
				}
			}
		}
	}

	internal static class DefineConstants
	{
		public const int INT_MAX = 2147483647;
		public const int INT_MIN = -2147483648;
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
