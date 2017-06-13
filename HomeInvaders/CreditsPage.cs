using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInvaders
{
	class CreditsPage
	{ // Displays the names of everyone that contributed to making this happen. Much love. 
		public static void ShowCredits()
		{
			Console.ForegroundColor = ConsoleColor.Cyan; 

			FileReader.ReadFile("Images\\Credits.txt");

			Console.ResetColor();

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
