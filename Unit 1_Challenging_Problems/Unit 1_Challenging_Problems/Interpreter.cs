using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1_Challenging_Problems
{
    class Interpreter
    {
		private int StoI(string s)
		{
			int R;
			R = (s[0] - '0') * 100;
			R += (s[1] - '0') * 10;
			R += (s[2] - '0');
			return R;
		}

		private string ItoS(int I)
		{
			string R = "000";
			R = StringFunctions.ChangeCharacter(R, 2, I % 10 + '0');
			I /= 10;
			R = StringFunctions.ChangeCharacter(R, 1, I % 10 + '0');
			I /= 10;
			R = StringFunctions.ChangeCharacter(R, 0, I % 10 + '0');

			return R;
		}
		public void run()
        {
				int N;
				int nCommands;
				char C1;
				char C2;
				char C3;
				char d;
				char n;
				char s;
				char a;
				string instr = new string(new char[5]);

				string tempVar = ConsoleInput.ScanfRead();
				if (tempVar != null)
				{
					N = int.Parse(tempVar);
				}
				fgets(instr, sizeof(char), stdin);
				fgets(instr, sizeof(char), stdin);

				bool exit = false;
				string[] RAM = new string[1000];
				string Ts;
				List<int> Results = new List<int>();
				int PC;

				for (int i = 0; i < N; i++)
				{
					for (int j = 0; j < 1000; j++)
					{
						RAM[j] = "000";
					}
					PC = 0;

					while (fgets(instr, sizeof(char), stdin) != null)
					{

						if (instr[0] == '\n')
						{
							break;
						}

						RAM[PC] = StringFunctions.ChangeCharacter(RAM[PC], 0, instr[0]);
						RAM[PC] = StringFunctions.ChangeCharacter(RAM[PC], 1, instr[1]);
						RAM[PC++] = StringFunctions.ChangeCharacter(RAM[PC++], 2, instr[2]);

					}

					string[] Registers = new string[10];
					int T;
					for (int j = 0; j < 10; j++)
					{
						Registers[j] = "000";
					}
					nCommands = 0;
					exit = false;
					PC = 0;
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
		while (!exit)
	{
		nCommands++;
			switch (RAM[PC][0])
			{
				case '1':
					exit = true;
					PC++;
				break;

				case '2':
					d = RAM[PC][1];
					n = RAM[PC][2];

					Registers[d - '0'] = ItoS(n - '0');
		PC++;

				break;

				case '3':
					d = RAM[PC][1];
					n = RAM[PC][2];

					Registers[d - '0'] = ItoS((StoI(Registers[d - '0']) + (n - '0')) % 1000);
					PC++;
				break;

				case '4':
					d = RAM[PC][1];
					n = RAM[PC][2];
					Registers[d - '0'] = ItoS((StoI(Registers[d - '0']) * (n - '0')) % 1000);
					PC++;
				break;

				case '5':
					d = RAM[PC][1];
					s = RAM[PC][2];
					Registers[d - '0'] = Registers[s - '0'];
					PC++;
				break;

				case '6':
					d = RAM[PC][1];
					s = RAM[PC][2];
					Registers[d - '0'] = ItoS((StoI(Registers[d - '0']) + StoI(Registers[s - '0'])) % 1000);
					PC++;
				break;

				case '7':
					d = RAM[PC][1];
					s = RAM[PC][2];
					Registers[d - '0'] = ItoS((StoI(Registers[d - '0']) * StoI(Registers[s - '0'])) % 1000);
					PC++;
				break;

				case '8':
					d = RAM[PC][1];
					a = RAM[PC][2];

					Registers[d - '0'] = RAM[StoI(Registers[a - '0'])];
					PC++;

				break;
					s = RAM[PC][1];
					a = RAM[PC][2];
					PC++;
					RAM[StoI(Registers[a - '0'])] = Registers[s - '0'];
				break;
				case '0':
					d = RAM[PC][1];
					s = RAM[PC][2];
					if (StoI(Registers[s - '0']) != 0)
						PC = StoI(Registers[d - '0']);
					else
						PC++;
				break;

			}
	Console.Write(nCommands);
Console.Write("\n");
if (i<N - 1)
{
	Console.Write("\n");
}
return 0;
}
