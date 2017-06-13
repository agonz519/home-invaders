using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInvaders
{
	class Movement
	{ // This class handles everything that happens when a hero runs into a goblin
		public static void Consequences()
		{
			Console.Beep();
			Shell.ReDrawGrid();

			if (Shell.location.HasHero && (Shell.location.HasG1 || Shell.location.HasG2 || Shell.location.HasG3))
			{
				Shell.isKing = false;
				Console.Clear();
				Shell.healthOfHero = Fight.FightTime(Shell.healthOfHero, Shell.healthOfGoblin, Shell.maxHealthOfHero, Shell.staminaOfHero, Shell.maxStaminaOfHero, Shell.isKing);

				if (Shell.healthOfHero > 0)
				{
					Victory.YouWon();
				}

				if (Shell.healthOfHero <= 0)
				{
					GameOver.YouLost();
				}
			}
			if (Shell.location.HasHero && Shell.location.HasGKing)
			{
				Shell.isKing = true;
				Console.Clear();
				Shell.healthOfHero = Fight.FightTime(Shell.healthOfHero, Shell.healthOfGoblinKing, Shell.maxHealthOfHero, Shell.staminaOfHero, Shell.maxStaminaOfHero, Shell.isKing);

				if (Shell.healthOfHero > 0)
				{
					Victory.YouWon();
				}
				if (Shell.healthOfHero <= 0)
				{
					GameOver.YouLost();
				}
			}
		}
	}
}
