using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HomeInvaders
{
	class Victory
	{ // This class handles what happens when you defeat a goblin or the goblin king
		public static void YouWon()
		{
			if (Shell.isKing == false)
			{
				Shell.sndPlayer.SoundLocation = Directory.GetCurrentDirectory() + "\\Sounds\\victory.wav";
				Shell.sndPlayer.Play();

				Shell.maxHealthOfHero += 2;
				Shell.healthOfHero += 2;
				Shell.ReDrawGrid();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\nYou fell the goblin and take its head as a trophy. You revel in your bloodlust.");
				Console.ResetColor();
				FileReader.ReadFile("images\\DeadGoblin.txt");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\nYou rest and heal back 2 hit points.");
				Console.WriteLine("\nYour max health has increased to " + Shell.maxHealthOfHero + ". Currently you have " + Shell.healthOfHero + " hit points.");
				Console.ResetColor();

				if (Shell.location.HasG1)
				{
					Shell.location.HasG1 = false;
				}
				else if (Shell.location.HasG2)
				{
					Shell.location.HasG2 = false;
				}
				else if (Shell.location.HasG3)
				{
					Shell.location.HasG3 = false;
				}

				HomeGenerator.RevealKing();
			}
			else if (Shell.isKing == true)
			{
				Shell.sndPlayer.SoundLocation = Directory.GetCurrentDirectory() + "\\Music\\Victory.wav";
				Shell.sndPlayer.Play();

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\nYou WIN!\n THANKS FOR SAVING MY HOME, HERO!");
				Console.ResetColor();
				FileReader.ReadFile("images\\DeadGoblinKing.txt");
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
}
