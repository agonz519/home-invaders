using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HomeInvaders
{
	class GameOver
	{ // This class handles what happens you die. RIP. 
		public static void YouLost()
		{
			Shell.sndPlayer.SoundLocation = Directory.GetCurrentDirectory() + "\\Music\\Game_Over.wav";
			Shell.sndPlayer.Play();

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("\n\nYOU DIED\n");
			Console.ResetColor();
			FileReader.ReadFile("images\\DeadHero.txt");
			Console.ForegroundColor = ConsoleColor.DarkRed;
			FileReader.ReadFile("images\\DeadHeroBlood.txt");
			Console.ResetColor();
			while (true)
			{
				Console.Write("\nWould you like to play again? (Y/N): ");

				string response = Console.ReadKey().KeyChar.ToString().ToUpper();

				if (response == "Y")
				{
					Shell.sndPlayer.Stop();
					MainMenu.Reset();
					Shell.Welcome();
					Shell.StartGame();
					break;
				}
				else if (response == "N")
				{
					MainMenu.Reset();
					MainMenu.Title();
					break;
				}
				else
				{
					Console.WriteLine("\n\nPlease answer with Y or N\n");
				}
			}
		}
	}
}
