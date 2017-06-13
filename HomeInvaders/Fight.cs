using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media;
using System.Threading;

namespace HomeInvaders
{
	class Fight
	{ 
		/* Play sound effects and music using MediaPlayer class.
		   Had to use MediaPlayer class instead of SoundPlayer class because SoundPlayer
		   cannot play two sounds at once. */
		
		public static MediaPlayer sndEffect1 = new MediaPlayer();
		public static MediaPlayer sndEffect2 = new MediaPlayer();

		// MediaPlayer class was a royal pain to figure out looping so decided to move on
		public static MediaPlayer musicPlayer = new MediaPlayer();
		
		
		public static string goblinFightMusic = Directory.GetCurrentDirectory() + "\\Music\\battleThemeA.wav";
		public static string kingGoblinFightMusic = Directory.GetCurrentDirectory() + "\\Music\\Boss_01.wav";

		public static void PlaySound1(string audioPath)
		{
			sndEffect1.Open(new System.Uri(audioPath));
			sndEffect1.Volume = 1; // 1 is max volume for MediaPlayer. Wanted sound to be louder than music.
			sndEffect1.Play();
		}

		public static void PlaySound2(string audioPath)
		{
			sndEffect2.Open(new System.Uri(audioPath));
			sndEffect2.Volume = 1; // 1 is max volume for MediaPlayer. Wanted sound to be louder than music.
			sndEffect2.Play();
		}

		public static void PlayMusic(string audioPath)
		{
			musicPlayer.Open(new System.Uri(audioPath));
			musicPlayer.Volume = .3; // Music much lower than sound effects
			musicPlayer.Play();
		}

		public static void StopMusic()
		{
			musicPlayer.Stop();
		}

		public static void FightUI(int HeroHp, int GoblinHp, int HeroStamina, bool kingFightUI)
		{ // This method creates the display above the hero and goblin
						
			string titles;
			
			if (kingFightUI) 
			{
				titles = "                HERO                                       GOBLIN KING"; 
			}
			else
				titles = "                HERO                                       GOBLIN"; //39 spaces
			

			int hHp;
			int gHP;
			int hSt;
			string displayHeroHP = "         HEALTH ";
			string displayGoblinHP = "";
			string displayHeroStamina = "        STAMINA ";

			// Create the health block displays for Hero and Goblin
			for (hHp = HeroHp; hHp > 0; hHp--)
			{
				displayHeroHP = displayHeroHP + "██ ";
			}
			for (gHP = GoblinHp; gHP > 0; gHP--)
			{
				displayGoblinHP = displayGoblinHP + " ██";
			}
			Console.WriteLine(titles + Environment.NewLine +
							  displayHeroHP + SpaceManager(HeroHp) + displayGoblinHP);
			Console.WriteLine();
			for (hSt = HeroStamina; hSt > 0; hSt--)
			{
				displayHeroStamina = displayHeroStamina + "██ ";
			}
			Console.WriteLine(displayHeroStamina);
		}

		/* As health goes up and down, need to keep the titles above each health bar
		   in the correct location */
		public static string SpaceManager(int HeroHp)
		{
			if (HeroHp <= 0)
				return "                                          "; //42 spaces
			if (HeroHp == 1)
				return "                                       "; //39 spaces
			if (HeroHp == 2)
				return "                                    "; //36 spaces
			if (HeroHp == 3)
				return "                                 "; //33 spaces
			if (HeroHp == 4)
				return "                              "; //30 spaces
			if (HeroHp == 5)
				return "                           "; //27 spaces
			if (HeroHp == 6)
				return "                        "; //24 spaces
			if (HeroHp == 7)
				return "                     "; //21 spaces
			if (HeroHp == 8)
				return "                  "; //18 spaces
			if (HeroHp == 9)
				return "               "; //15 spaces
			if (HeroHp == 10)
				return "            "; //12 spaces
			if (HeroHp == 11)
				return "         "; //9 spaces

			else
				return "OH NO BLANK-SPACE MANAGER BROKE";
		}

		public static int FightTime(int heroHealth, int goblinHealth, int maxHealth, int heroStamina, int maxStamina, bool kingFight)
		{
			if (kingFight)
			{
				PlayMusic(kingGoblinFightMusic);
			}
			else
			{
				PlayMusic(goblinFightMusic);
			}

			int o = heroHealth;
			int x = goblinHealth;
			int s = heroStamina;

			FightUI(o, x, s, kingFight);
			Console.WriteLine();

			if (kingFight) 
			{
				FileReader.ReadFile("Images\\CharacterDisplayKing.txt");
			}
			else
				FileReader.ReadFile("Images\\CharacterDisplay.txt");
			
			Console.WriteLine(Environment.NewLine + Environment.NewLine + Environment.NewLine);
			
			// Decides what the goblins attacks with
			Random guess = new Random();
			int min = 1;
			int max = 3;

			while (x > 0 && o > 0)
			{
				int GobAttack = guess.Next(min, max + 1);

				FileReader.ReadFile("Images\\FightCommands.txt");
				Console.Write("                ║   Enter your move [A][B][R]: ");

				string response = Console.ReadKey().KeyChar.ToString().ToUpper();
				Console.Clear();
				Shell.ReDrawGrid();
				switch (response)
				{
					case "A":
						Console.Clear();

						if (GobAttack == 1)
						{
							int missChance = guess.Next(min, max + 2); //1 hero hits, 2 gob hits, 3 both hit, 4 both miss 
							if (s <= 0)
							{
								missChance = guess.Next(min, 3) * 2; //either goblin hits, or both miss, guaranteed hero misses
								
							}
							if (missChance == 1)
							{
								PlaySound1(Directory.GetCurrentDirectory() + "\\Sounds\\hitHero.wav");
								PlaySound2(Directory.GetCurrentDirectory() + "\\Sounds\\missGoblin.wav");

								int outx, outs;
								Attack(x, s, out outx, out outs);
								x = outx;
								s = outs;
								FightUI(o, x, s, kingFight);
								Console.WriteLine();
								if (kingFight)
								{
									FileReader.ReadFile("Images\\AttackAttack_GKmiss.txt");
									Console.WriteLine();
									Console.WriteLine("\n                       \"Hero hits as the Goblin King misses\"\n");
								}
								else
								{
									FileReader.ReadFile("Images\\AttackAttack_Gmiss.txt");
									Console.WriteLine();
									Console.WriteLine("\n                       \"Hero hits as the Goblin misses\"\n");
								}
								
							}
							else if (missChance == 2)
							{
								PlaySound1(Directory.GetCurrentDirectory() + "\\Sounds\\missHero.wav");

								int outo, outs;
								Attack(o, s, out outo, out outs);
								o = outo;
								s = outs;
								FightUI(o, x, s, kingFight);
								Console.WriteLine();
								if (kingFight)
								{
									PlaySound2(Directory.GetCurrentDirectory() + "\\Sounds\\GKPunch.wav");
									FileReader.ReadFile("Images\\AttackAttack_Hmiss1.txt");
									Console.WriteLine();
									Console.WriteLine("\n                       \"Hero misses as the Goblin King hits\"\n");
								}
								else
								{
									PlaySound2(Directory.GetCurrentDirectory() + "\\Sounds\\hitGoblin.wav");
									FileReader.ReadFile("Images\\AttackAttack_Hmiss2.txt");
									Console.WriteLine();
									Console.WriteLine("\n                       \"Hero misses as the Goblin hits\"\n");
								}
								
							}
							else if (missChance == 3)
							{
								PlaySound1(Directory.GetCurrentDirectory() + "\\Sounds\\hitHero3.wav");

								int outx, outs, outo;
								Attack(x, 0, out outx, out outs);
								Attack(o, s, out outo, out outs);
								o = outo;
								s = outs;
								x = outx;
								FightUI(o, x, s, kingFight);
								Console.WriteLine();
								if (kingFight)
								{
									PlaySound2(Directory.GetCurrentDirectory() + "\\Sounds\\GKPunch.wav");
									FileReader.ReadFile("Images\\AttackAttackKing.txt");
									Console.WriteLine();
									Console.WriteLine("\n                       \"Hero and Goblin King both hit each other\"\n");
								}
								else
								{
									PlaySound2(Directory.GetCurrentDirectory() + "\\Sounds\\hitGoblin.wav");
									FileReader.ReadFile("Images\\AttackAttack.txt");
									Console.WriteLine();
									Console.WriteLine("\n                       \"Hero and Goblin both hit each other\"\n");
								}
							}
							else if (missChance == 4)
							{
								PlaySound1(Directory.GetCurrentDirectory() + "\\Sounds\\missGoblin.wav");
								PlaySound2(Directory.GetCurrentDirectory() + "\\Sounds\\missHero.wav");
								int outx, outs;
								Attack(x, s, out outx, out outs);
								s = outs;
								FightUI(o, x, s, kingFight);
								Console.WriteLine();
								if (kingFight)
								{
									FileReader.ReadFile("Images\\AttackAttack_BothMissKing.txt");
									Console.WriteLine();
									Console.WriteLine("\n                       \"Hero and Goblin King both miss each other\"\n");
								}
								else
								{
									FileReader.ReadFile("Images\\AttackAttack_BothMiss.txt");
									Console.WriteLine();
									Console.WriteLine("\n                       \"Hero and Goblin both miss each other\"\n");
								}
							}
						}
						if (GobAttack == 2)
						{
							if (s > 0)
							{
								PlaySound1(Directory.GetCurrentDirectory() + "\\Sounds\\Block.wav");
								int outx, outs;
								Attack(x, s, out outx, out outs);
								s = outs;
								FightUI(o, x, s, kingFight);
								Console.WriteLine();
								if (kingFight)
								{
									FileReader.ReadFile("Images\\AttackBlockKing.txt");
									Console.WriteLine();
									Console.WriteLine("\n                    \"Hero attacks but the Goblin King successfully blocks\"\n");
								}
								else
								{
									FileReader.ReadFile("Images\\AttackBlock.txt");
									Console.WriteLine();
									Console.WriteLine("\n                    \"Hero attacks but the Goblin successfully blocks\"\n");
								}
							}
							else
							{
								FightUI(o, x, s, kingFight);
								Console.WriteLine();
								if (kingFight)
								{
									FileReader.ReadFile("Images\\RestBlockKing.txt");
									Console.WriteLine();
									Console.WriteLine("\n                    \"Hero is too tired to attack.\"\n");
								}
								else
								{
									FileReader.ReadFile("Images\\RestBlock.txt");
									Console.WriteLine();
									Console.WriteLine("\n                    \"Hero is too tired to attack.\"\n");
								}
							}
						}
						if (GobAttack == 3)
						{
							if (s > 0)
							{
								PlaySound1(Directory.GetCurrentDirectory() + "\\Sounds\\crit.wav");

								int outx, outs;
								Attack(x, s, out outx, out outs);
								x = outx;
								s = outs;
								Attack(x, 0, out outx, out outs);
								x = outx;
								FightUI(o, x, s, kingFight);
								Console.WriteLine();
								if (kingFight)
								{
									FileReader.ReadFile("Images\\AttackRestKing.txt");
									Console.WriteLine();
									Console.WriteLine("\n                       \"Hero lands a critical hit on the Goblin King!\"\n");
								}
								else
								{
									FileReader.ReadFile("Images\\AttackRest.txt");
									Console.WriteLine();
									Console.WriteLine("\n                       \"Hero lands a critical hit on the Goblin!\"\n");
								}
							}
							else
							{
								FightUI(o, x, s, kingFight);
								Console.WriteLine();
								if (kingFight)
								{
									FileReader.ReadFile("Images\\RestRestKing.txt");
									Console.WriteLine();
									Console.WriteLine("\n                    \"Hero is too tired to attack.\"\n");
								}
								else
								{
									FileReader.ReadFile("Images\\RestRest.txt");
									Console.WriteLine();
									Console.WriteLine("\n                    \"Hero is too tired to attack.\"\n");
								}
							}
						}
						break;

					case "B":
						Console.Clear();

						if (GobAttack == 1)
						{
							FightUI(o, x, s, kingFight);
							Console.WriteLine();
							if (kingFight)
							{
								PlaySound2(Directory.GetCurrentDirectory() + "\\Sounds\\GKPunchBlock.wav");
								FileReader.ReadFile("Images\\BlockAttackKing.txt");
								Console.WriteLine();
								Console.WriteLine("\n                     \"Hero blocks the Goblin King's attack\"\n");
							}
							else
							{
								PlaySound2(Directory.GetCurrentDirectory() + "\\Sounds\\Block.wav");
								FileReader.ReadFile("Images\\BlockAttack.txt");
								Console.WriteLine();
								Console.WriteLine("\n                     \"Hero blocks the Goblin's attack\"\n");
							}
						}
						if (GobAttack == 2)
						{
							FightUI(o, x, s, kingFight);
							Console.WriteLine();
							if (kingFight)
							{
								FileReader.ReadFile("Images\\BlockBlockKing.txt");
								Console.WriteLine();
								Console.WriteLine("\n                     \"Hero and Goblin King both block\"\n");
							}
							else
							{
								FileReader.ReadFile("Images\\BlockBlock.txt");
								Console.WriteLine();
								Console.WriteLine("\n                     \"Hero and Goblin both raise there shields\"\n");
							}
						}
						if (GobAttack == 3)
						{
							int outh, outs;
							Rest(x, goblinHealth, 0, 0, out outh, out outs);
							x = outh;
							FightUI(o, x, s, kingFight);
							Console.WriteLine();
							if (kingFight)
							{
								FileReader.ReadFile("Images\\BlockRestKing.txt");
								Console.WriteLine();
								Console.WriteLine("\n                  \"Hero raises shield, the Goblin King takes a quick rest\"\n");
							}
							else
							{
								FileReader.ReadFile("Images\\BlockRest.txt");
								Console.WriteLine();
								Console.WriteLine("\n                  \"Hero raises shield, the Goblin takes a quick rest\"\n");
							}
						}
						break;

					case "R":
						Console.Clear();

						if (GobAttack == 1)
						{
							PlaySound1(Directory.GetCurrentDirectory() + "\\Sounds\\crit.wav");

							int outs, outo;
							Attack(o, 0, out outo, out outs);
							o = outo;
							Attack(o, 0, out outo, out outs);
							o = outo;
							FightUI(o, x, s, kingFight);
							Console.WriteLine();
							if (kingFight)
							{
								FileReader.ReadFile("Images\\RestAttackKing.txt");
								Console.WriteLine();
								Console.WriteLine("\n                     \"Goblin King lands a critical hit on the Hero!\"\n");
							}
							else
							{
								FileReader.ReadFile("Images\\RestAttack.txt");
								Console.WriteLine();
								Console.WriteLine("\n                     \"Goblin lands a critical hit on the Hero!\"\n");
							}
						}
						if (GobAttack == 2)
						{
							int outh, outs;
							Rest(o, maxHealth, s, maxStamina, out outh, out outs);
							o = outh;
							s = outs;
							FightUI(o, x, s, kingFight);
							Console.WriteLine();
							if (kingFight)
							{
								FileReader.ReadFile("Images\\RestBlockKing.txt");
								Console.WriteLine();
								Console.WriteLine("\n               \"The hero takes a quick rest while the Goblin King blocks\"\n");
							}
							else
							{
								FileReader.ReadFile("Images\\RestBlock.txt");
								Console.WriteLine();
								Console.WriteLine("\n               \"The hero takes a quick rest while the Goblin raises his shield\"\n");
							}
						}
						if (GobAttack == 3)
						{
							int outh, outs;
							Rest(o, maxHealth, s, maxStamina, out outh, out outs);
							o = outh;
							s = outs;
							Rest(x, goblinHealth, 0, 0, out outh, out outs);
							x = outh;
							FightUI(o, x, s, kingFight);
							Console.WriteLine();
							if (kingFight)
							{
								FileReader.ReadFile("Images\\RestRestKing.txt");
								Console.WriteLine();
								Console.WriteLine("\n                    \"The Hero and the Goblin King both take a rest\"\n");
							}
							else
							{
								FileReader.ReadFile("Images\\RestRest.txt");
								Console.WriteLine();
								Console.WriteLine("\n                    \"The Hero and the Goblin both catch their breaths\"\n");
							}
						}



						break;

					//case "Q":
					//	Console.WriteLine();
					//	Environment.Exit(0);
					//	break;
					//	//Took this out as you can accidently press Q when trying to press A for attack. Someone thought I was rage-quitting. 

					default: // If you fail to follow instructions...
						Console.Clear();
						FightUI(o, x, s, kingFight);
						Console.WriteLine();
						if (kingFight)
						{
							FileReader.ReadFile("Images\\CharacterDisplayKingNoGulp.txt");
							Console.WriteLine();
							Console.WriteLine("\n                       MUST USE [A] ATTACK, [B] BLOCK, [R] REST!\n");
						}
						else
						{
							FileReader.ReadFile("Images\\CharacterDisplay.txt");
							Console.WriteLine();
							Console.WriteLine("\n                       MUST USE [A] ATTACK, [B] BLOCK, [R] REST!\n");
						}
						break;
				}
			}

			StopMusic();
			return o;
		}


		public static void Attack(int heroHealthIn, int heroStaminaIn, out int heroHealthOut, out int heroStaminaOut)
		{ // handles what happens on an attack
			int health = heroHealthIn;
			int stamina = heroStaminaIn;
			health -= 1;
			if (stamina > 0)
				stamina -= 1;
			heroHealthOut = health;
			heroStaminaOut = stamina;
			return;
		}

		static void Rest(int h, int hmax, int s, int smax, out int outh, out int outs)
		{ // handles what happens on a rest
			int health = h;
			int stamina = s;
			if (health < hmax)
				health += 1;
			if (stamina < smax)
				stamina += 1;
			outh = health;
			outs = stamina;
			return;
		}
	}
}
