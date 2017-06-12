using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInvaders
{
	class HelpPage
	{
		public static void Help()
		{
			Console.ForegroundColor = ConsoleColor.Black;
			Console.BackgroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("                             ~ H O M E  I N V A D E R S - H E L P ~                            ");
			Console.ResetColor();
			FileReader.ReadFile("Images\\HelpMenu.txt");

			while (true)
			{
				Console.WriteLine(); Console.WriteLine();
				Console.Write("Press any key to return to Main Menu...");

				string response = Console.ReadKey().KeyChar.ToString();

				switch (response)
				{
					default:
						Console.Clear();
						MainMenu.Title();
						break;
				}
			}
		}
	}
}
