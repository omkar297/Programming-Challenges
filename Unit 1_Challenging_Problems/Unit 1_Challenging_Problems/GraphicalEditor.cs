using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1_Challenging_Problems
{
    class GraphicalEditor
    {
		public class bmpFile
		{
			public string name;
			public char[,] data = new char[252, 252];
			public int C;
			public int R;
		}
			public static void Fill(char[,] Canvas, int R, int C, int X, int Y, char color)
			{
				char OriginalColor = Canvas[X,Y];
				Canvas[X,Y] = color;
				if (X > 0 && Canvas[X - 1,Y] == OriginalColor)
				{
					Fill(Canvas, R, C, X - 1, Y, color);
				}

				if (Y > 0 && Canvas[X,Y - 1] == OriginalColor)
				{
					Fill(Canvas, R, C, X, Y - 1, color);
				}

				if (X < C && Canvas[X + 1,Y] == OriginalColor)
				{
					Fill(Canvas, R, C, X + 1, Y, color);
				}

				if (Y < R && Canvas[X,Y + 1] == OriginalColor)
				{
					Fill(Canvas, R, C, X, Y + 1, color);
				}

				if (X > 0 && Y > 0 && Canvas[X - 1,Y - 1] == OriginalColor)
				{
					Fill(Canvas, R, C, X - 1, Y - 1, color);
				}

				if (X > 0 && Y < R && Canvas[X - 1,Y + 1] == OriginalColor)
				{
					Fill(Canvas, R, C, X - 1, Y + 1, color);
				}

				if (X < C && Y > 0 && Canvas[X + 1,Y - 1] == OriginalColor)
				{
					Fill(Canvas, R, C, X + 1, Y - 1, color);
				}

				if (X < C && Y < R && Canvas[X + 1,Y + 1] == OriginalColor)
				{
					Fill(Canvas, R, C, X + 1, Y + 1, color);
				}

				Canvas[X,Y] = color;

				return;
			}
		public void run()
		{
			char Command;
			int C;
			int R;
			char[][] Canvas =
			{
		new char[] {'O', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0'}
	};
			List<bmpFile> results = new List<bmpFile>();
			while ((Command && Command != 'X' = bool.Parse(ConsoleInput.ReadToWhiteSpace(true))).Length > 0)
			{

				if (Command == 'I')
				{
					C = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					R = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					for (int i = 1; i <= R; i++)
					{
						for (int j = 1; j <= C; j++)
						{
							Canvas[i][j] = 'O';
						}
					}
				}

				if (Command == 'C')
				{
					for (int i = 1; i <= R; i++)
					{
						for (int j = 1; j <= C; j++)
						{
							Canvas[i][j] = 'O';
						}
					}
				}

				if (Command == 'L')
				{
					int X;
					int Y;
					X = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					Y = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					Canvas[Y][X] = ConsoleInput.ReadToWhiteSpace(true)[0];
				}

				if (Command == 'V')
				{
					int X;
					int Y1;
					int Y2;
					char color;
					X = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					Y1 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					Y2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					color = ConsoleInput.ReadToWhiteSpace(true)[0];

					if (Y2 < Y1)
					{
						int tmp = Y1;
						Y1 = Y2;
						Y2 = tmp;
					}

					for (int i = Y1; i <= Y2; i++)
					{
						Canvas[i][X] = color;
					}
				}

				if (Command == 'H')
				{
					int Y;
					int X1;
					int X2;
					char color;
					X1 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					X2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					Y = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					color = ConsoleInput.ReadToWhiteSpace(true)[0];
					if (X2 < X1)
					{
						int tmp = X1;
						X1 = X2;
						X2 = tmp;
					}
					for (int i = X1; i <= X2; i++)
					{
						Canvas[Y][i] = color;
					}
				}

				if (Command == 'K')
				{
					int Y1;
					int Y2;
					int X1;
					int X2;
					char color;
					X1 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					Y1 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					X2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					Y2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					color = ConsoleInput.ReadToWhiteSpace(true)[0];
					for (int i = Y1; i <= Y2; i++)
					{
						for (int j = X1; j <= X2; j++)
						{
							Canvas[i][j] = color;
						}
					}
				}

				if (Command == 'F')
				{
					int X;
					int Y;
					char color;
					X = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					Y = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					color = ConsoleInput.ReadToWhiteSpace(true)[0];
					if (color == Canvas[Y][X])
					{
						continue;
					}
					Fill(Canvas, C, R, Y, X, color);
				}

				if (Command == 'S')
				{
					string nam;
					//bmpFile * f = new bmpFile;
					nam = ConsoleInput.ReadToWhiteSpace(true);
					Console.Write(nam);
					Console.Write("\n");
					for (int i = 1; i <= R; i++)
					{
						for (int j = 1; j <= C; j++)
						{
							Console.Write(Canvas[i][j]);
						}
						Console.Write("\n");
					}

				}

			}

			return 0;
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
					//accumulate leading white space if skipLeadingWhiteSpace is false:
					if (!skipLeadingWhiteSpace)
						input += nextChar;
				}
				//the first non white space character:
				input += nextChar;

				//accumulate characters until white space is reached:
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
							//ignore all subsequent white space:
							while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
							{
							}
						}
						else
						{
							//ensure each character matches the expected character in the sequence:
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
