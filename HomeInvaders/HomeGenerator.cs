using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInvaders
{
    class HomeGenerator
    {
		public static Location[][] homeStateGrid;
		public static Location[] startingGoblinLocations;

        public static void Initialize()
        {
			homeStateGrid = new Location[5][];
			for (int i = 0; i < 5; i++ )
			{
				homeStateGrid[i] = new Location[5];
			}
			for (int i = 0; i < 4; i++ )
			{
				for(int j = 0; j < 5; j++)
				{
					//Console.WriteLine("Creating Location " + i + " " + j);
					homeStateGrid[i][j] = new Location(j, i);
				}
			}

			homeStateGrid[4][2] = new Location("S", 2, 4);

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (i == 0)
					{
						homeStateGrid[i][j].Up = Location.Wall;
					}
					else
					{
						homeStateGrid[i][j].Up = homeStateGrid[i - 1][j];
					}

					if (j == 0)
					{
						homeStateGrid[i][j].Left = Location.Wall;
					}
					else
					{
						homeStateGrid[i][j].Left = homeStateGrid[i][j - 1];
					}

					if (i == 3 && j != 2)
					{
						homeStateGrid[i][j].Down = Location.Wall;
					}
					else
					{
						homeStateGrid[i][j].Down = homeStateGrid[i + 1][j];
					}

					if (j == 4)
					{
						homeStateGrid[i][j].Right = Location.Wall;
					}
					else
					{
						homeStateGrid[i][j].Right = homeStateGrid[i][j + 1];
					}
				}
			}

			// Link "D3 pos 3, 2" and "Start pos 4, 2"
			homeStateGrid[3][2].Down = homeStateGrid[4][2];
			homeStateGrid[4][2].Up = homeStateGrid[3][2];
			homeStateGrid[4][2].Left = Location.Wall;
			homeStateGrid[4][2].Right = Location.Wall;
			homeStateGrid[4][2].Down = Location.Wall;

			homeStateGrid[4][2].HasHero = true;

			Random r = new Random();
			startingGoblinLocations = new Location[4];

			Location g1 = homeStateGrid[r.Next(0, 3)][r.Next(0, 4)];
			Location g2 = homeStateGrid[r.Next(0, 3)][r.Next(0, 4)];

			while (g2 == g1)
			{
				g2 = homeStateGrid[r.Next(0, 3)][r.Next(0, 4)];
			}

			Location g3 = homeStateGrid[r.Next(0, 3)][r.Next(0, 4)];

			while (g3 == g1 || g3 == g2)
			{
				g3 = homeStateGrid[r.Next(0, 3)][r.Next(0, 4)];
			}

			Location g4 = homeStateGrid[r.Next(0, 3)][r.Next(0, 4)];

			while (g4 == g1 || g4 == g2 || g4 == g3)
			{
				g4 = homeStateGrid[r.Next(0, 3)][r.Next(0, 4)];
			}

			g1.HasG1 = true;
			g2.HasG2 = true;
			g3.HasG3 = true;

			startingGoblinLocations[0] = g1;
			startingGoblinLocations[1] = g2;
			startingGoblinLocations[2] = g3;
			startingGoblinLocations[3] = g4;
		}
		
		public static void RevealKing() 
		{
			if (startingGoblinLocations[0].HasG1 == false && startingGoblinLocations[1].HasG2 == false && startingGoblinLocations[2].HasG3 == false)
			{
				startingGoblinLocations[3].HasGKing = true;
			}
		}

		public static void DrawGrid()
        {
			Console.ForegroundColor = ConsoleColor.Cyan;
			
			for (int i = 0; i < 4; i++)
			{
				string line = "                             ";
				for (int j = 0; j < 5; j++)
				{
					line += homeStateGrid[i][j].DisplayHorizontalWall();
				}
				line += System.Environment.NewLine;

				string contents = "                             ";
				for (int j = 0; j < 5; j++)
				{
					contents += homeStateGrid[i][j].Display();
				}
				contents += System.Environment.NewLine;

				Console.Write(line);
				Console.Write(contents);
			}
			string bottomline = "                             ";
			for (int j = 0; j < 5; j++)
			{
				bottomline += homeStateGrid[3][j].DisplayHorizontalWall();
			}
			bottomline += System.Environment.NewLine;
			Console.Write(bottomline);

			Console.Write("                             " + homeStateGrid[4][2].Display() + System.Environment.NewLine);
			Console.Write("                             " + homeStateGrid[4][2].DisplayHorizontalWall() + System.Environment.NewLine);
			Console.ResetColor();
		}
		
		public static void Stats(int health)
		{
			int hp;
			string displayHP = "";
			for (hp = health; hp > 0; hp--)
			{
				displayHP = displayHP + "██ ";
			}
			Console.WriteLine();
			Console.WriteLine("                       ╔════════════════════════════════════════╗" + Environment.NewLine +
							  "                          Hero's current health                  " + Environment.NewLine +
							  "                          HP: " + displayHP + "                  " + Environment.NewLine +
							  "                       ╚════════════════════════════════════════╝");

		}

		public static Location[] getGoblinLocations()
		{
			return startingGoblinLocations;					
		}
	}
}
