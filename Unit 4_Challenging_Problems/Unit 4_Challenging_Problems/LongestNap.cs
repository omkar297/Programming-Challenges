using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Challenging_Problems
{
    class LongestNap
    {
		public int SH;
		public int SM;
		public int EH;
		public int EM;

	public static class GlobalMembers
	{
		public static bool compareApps(app a1, app a2)
		{
			int a1SM = a1.SH * 60 + a1.SM;
			int a2SM = a2.SH * 60 + a2.SM;
			return a1SM < a2SM;
		}
		public void run()
		{

			int n;
			string Input = new string(new char[256]);
			int counter = 0;
			while (scanf("%d", n) == 1)
			{
				counter++;
				Input = Console.ReadLine();


				List<app> apps = new List<app>();

				for (int i = 0; i < n; i++)
				{
					Input = Console.ReadLine();
					app a = new app();
					a.SH = (Input[0] - '0') * 10 + Input[1] - '0';
					a.SM = (Input[3] - '0') * 10 + Input[4] - '0';
					a.EH = (Input[6] - '0') * 10 + Input[7] - '0';
					a.EM = (Input[9] - '0') * 10 + Input[10] - '0';
					apps.Add(a);
				}
				apps.Sort(compareApps);
				int maxNapTime = -1;
				int maxStartH;
				int maxStartM;
				string output;

				if (apps[0].SH != 10 || apps[0].SM != 0)
				{
					maxNapTime = apps[0].SH * 60 + apps[0].SM - 10 * 60;
					maxStartH = 10;
					maxStartM = 0;

				}
				for (int i = 1; i < apps.Count; i++)
				{
					if ((apps[i - 1].EH != apps[i].SH || apps[i - 1].EM != apps[i].SM) && maxNapTime < apps[i].SH * 60 + apps[i].SM - apps[i - 1].EH * 60 - apps[i - 1].EM)
					{
						maxNapTime = apps[i].SH * 60 + apps[i].SM - apps[i - 1].EH * 60 - apps[i - 1].EM;
						maxStartH = apps[i - 1].EH;
						maxStartM = apps[i - 1].EM;
					}
				}


				if (apps[apps.Count - 1].EH != 18 && maxNapTime < 18 * 60 - apps[apps.Count - 1].EH * 60 - apps[apps.Count - 1].EM)
				{
					maxNapTime = 18 * 60 - apps[apps.Count - 1].EH * 60 - apps[apps.Count - 1].EM;
					maxStartH = apps[apps.Count - 1].EH;
					maxStartM = apps[apps.Count - 1].EM;

				}

				ostringstream hours = new ostringstream();

				if ((maxNapTime / 60) != 0)
				{
					hours << maxNapTime / 60 << " hours and ";
				}

				Console.Write("Day #");
				Console.Write(counter);
				Console.Write(": the longest nap starts at ");
				Console.Write(maxStartH / 10);
				Console.Write(maxStartH % 10);
				Console.Write(':');
				Console.Write(maxStartM / 10);
				Console.Write(maxStartM % 10);
				Console.Write(" and will last for ");
				Console.Write(hours.str());
				Console.Write(maxNapTime % 60);
				Console.Write(" minutes.\n");


			}
		}
	}

	internal static class DefineConstants
	{
		public const int INT_MAX = 2147483647;
		public const int INT_MIN = -2147483648;
		public const double E = 2.71828182845904523536;
	}

}