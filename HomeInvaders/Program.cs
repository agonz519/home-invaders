using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
			if (Console.LargestWindowHeight < 48 )
			{
				Console.WindowHeight = Console.LargestWindowHeight;
				Console.BufferHeight = Console.LargestWindowHeight + 5;
			}
			else
			{
				Console.WindowHeight = 48;
				Console.BufferHeight = 48;
			}
			if (Console.LargestWindowWidth < 100)
			{
				Console.WindowWidth = Console.LargestWindowWidth;
				Console.BufferWidth = Console.LargestWindowWidth + 20;
			}
			else
			{
				Console.WindowWidth = 100;
				Console.BufferWidth = 100;
			}

			Console.Title = "Home Invaders";
			GameStudios.DisplayStudios();
        }

    }
}
