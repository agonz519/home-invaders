using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HomeInvaders
{
	class MainMenu
	{
		public static void Title()
		{
			SoundPlayer sndPlayer = new SoundPlayer();
			sndPlayer.SoundLocation = Directory.GetCurrentDirectory() + "\\Music\\bensound_instinct.wav";
			sndPlayer.PlayLooping();

			Console.ForegroundColor = ConsoleColor.Green; 
			FileReader.ReadFile("Images\\HomeInvadersTitle.txt");
			Console.ResetColor();
			Console.WriteLine();
			FileReader.ReadFile("Images\\MainMenu.txt");
			
			while (true)
			{
				Console.Write("             ║ Make your choice [1][2][3][Q]: ");

				string response = Console.ReadKey().KeyChar.ToString().ToUpper();

				switch (response)
				{
					case "1":
						sndPlayer.Stop();
						Console.Clear();
						Shell.Welcome();
						Shell.StartGame();
						break;

					case "2":
						Console.Clear();
						HelpPage.Help();
						break;

					case "3":
						Console.Clear();
						CreditsPage.ShowCredits();
						break;

					case "Q":
						Console.WriteLine("\n\nNow exiting...\n");
						System.Threading.Thread.Sleep(500);
						Environment.Exit(0);
						break;

					default:
						Console.WriteLine("Please choose 1, 2, or Q.\n");
						System.Threading.Thread.Sleep(2000);
						Console.Clear();
						Title();
						break;
				}
			}
		}

		public static void Reset()
		{
			Console.Clear();
			Shell.healthOfHero = 5;
			Shell.healthOfGoblin = 5;
			Shell.healthOfGoblinKing = 10;
			Shell.maxHealthOfHero = 5;
		}
	}
}
