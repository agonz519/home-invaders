using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeInvaders
{
	class GameStudios
	{
		public static void DisplayStudios()
		{
			// Changes the color of "Buckley Studios" every fourth of a second.
			// Console is cleared inbetween to give the illusion its changing colors.

			Console.ForegroundColor = ConsoleColor.Cyan;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			FileReader.ReadFile("Images\\BuckleyStudios.txt");
			Thread.Sleep(250);
			Console.Clear();

			// Displays "Gonzo Gaming" with some added animations again using
			// console clear
			
			Console.ForegroundColor = ConsoleColor.Red;
			FileReader.ReadFile("Images\\GGstudios1.txt");
			Thread.Sleep(250);
			Console.Clear();
			FileReader.ReadFile("Images\\GGstudios2.txt");
			Thread.Sleep(250);
			Console.Clear();
			FileReader.ReadFile("Images\\GGstudios3.txt");
			Thread.Sleep(250);
			Console.Clear();
			FileReader.ReadFile("Images\\GGstudios4.txt");
			Thread.Sleep(250);
			Console.Clear();
			FileReader.ReadFile("Images\\GGstudios5.txt");
			Thread.Sleep(5000);
			Console.Clear();

			MainMenu.Title(); // Time to start playing!

		}
	}
}
