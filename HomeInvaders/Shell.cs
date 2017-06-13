using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HomeInvaders
{
    class Shell
    {
		// Set all default values first

		private static bool walkedIntoWall = false;
		public static int healthOfHero = 5;
		public static int healthOfGoblin = 5;
		public static int healthOfGoblinKing = 10;
		public static int maxHealthOfHero = 5;
		public static int staminaOfHero = 4;
		public static int maxStaminaOfHero = 4;
		public static bool isKing;
		public static SoundPlayer sndPlayer = new SoundPlayer();
		public static Location location;

        public static void Welcome() // In-game instructions, gets called with every move
        {
            FileReader.ReadFile("Images\\WelcomeText.txt");
        }

        public static void StartGame()
        {
            HomeGenerator.Initialize(); // Create coordinates for house grid, creates position associations & goblin locations
            HomeGenerator.DrawGrid(); // Creates the house grid
			HomeGenerator.Stats(healthOfHero); // Displays the hero's health underneath the house grid

			location = HomeGenerator.homeStateGrid[4][2]; // Location of start position
			Location[] goblinLocations = HomeGenerator.getGoblinLocations(); // Location of goblin positions
						
            bool continuePlaying = true;
            while (continuePlaying)
            {
				Console.Write("\n                           Which way will you move?: ");
				
				ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
						location = MoveHero(location, location.Up);
						Movement.Consequences();
						break;
                        
                    case ConsoleKey.DownArrow:
						location = MoveHero(location, location.Down);
						Movement.Consequences();
						break;

                    case ConsoleKey.RightArrow: 
						location = MoveHero(location, location.Right);
						Movement.Consequences();
						break;

                    case ConsoleKey.LeftArrow:
						location = MoveHero(location, location.Left);
						Movement.Consequences();
						break;

                    case ConsoleKey.Q: // Return to the main menu
						MainMenu.Reset();
						MainMenu.Title();
                        break;

                    default: // Follow directions bro, geez
						Console.WriteLine("\n\n                           Use ↑ ↓ ← → to navigate through the house\n");
                        break;
                }
            }
        }

        public static Location MoveHero(Location oldLocation, Location newLocation)
        { // how location is tracked, watches running into a wall
            if (newLocation.Id == "W")
            {
				walkedIntoWall = true;
				return oldLocation;
            }
            else
            {
                oldLocation.HasHero = false;
                newLocation.HasHero = true;
				
                return newLocation;
            }
		}

		public static void ReDrawGrid()
		{ // Gets called after console is cleared to show new positions and updates
			Console.WriteLine();
			Console.Clear();
			Welcome();
			HomeGenerator.DrawGrid();
			HomeGenerator.Stats(healthOfHero);
			if (walkedIntoWall)
			{
				Console.WriteLine("\n                           You run into a wall on accident. Ouch!");
				walkedIntoWall = false;
			}
		}
    }
}
