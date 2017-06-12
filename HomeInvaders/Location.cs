using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInvaders
{
    public class Location
    {
        public string Id { get; set; }

        public Location(string id, int x, int y):
			this(x, y)
        {
            Id = id;
        }

		public Location(int x, int y)
		{
			X = x;
			Y = y;
		}

        public Location Up { get; set; }
        public Location Down { get; set; }
        public Location Left { get; set; }
        public Location Right { get; set; }

		public int X { get; private set; }
		public int Y { get; private set; }

        public bool HasHero { get; set; }
		public bool HasG1 { get; set; }
		public bool HasG2 { get; set; }
		public bool HasG3 { get; set; }
		public bool HasGKing { get; set; }

		public int CurrentGoblinCount()
		{
			int returnVal = 0;

			if (HasG1)
				returnVal++;
			if (HasG2)
				returnVal++;
			if (HasG3)
				returnVal++;

			return returnVal;
		} 
		
        public string Display()
        {
            string display = "";
            
			if (Id == "S")
            {
                display = display + "            ";
            }

            display = display + "║";

			if (HasHero && !(HasG1 || HasG2 || HasG3 || HasGKing))
            {
				string hero = "  o  ";
				
				display = display + hero;				
            }
			else if (HasHero && (HasG1 || HasG2 || HasG3))
			{
				display = display + " x o ";
			}
			else if (HasHero && ((HasG1 && HasG2) || (HasG2 && HasG3) || (HasG3 && HasG1)))
			{
				display = display + "x o x";
			}
			else if (HasHero && HasG1 && HasG2 && HasG3)
			{
				display = display + "o xxx";
			}
			else if (!HasHero && (HasG1 || HasG2 || HasG3))
			{
				display = display + "  x  ";
			}
			else if (!HasHero && (HasG1 && HasG2 || HasG2 && HasG3 || HasG3 && HasG1))
			{
				display = display + " x x ";
			}
			else if (!HasHero && HasG1 && HasG2 && HasG3)
			{
				display = display + "x x x";
			}
			else if (HasHero && HasGKing)
			{
				display = display + " K o ";
			}
			else if (HasGKing && !HasHero)
			{
				display = display + "  K  ";
			}
			else 
            {
                display = display + "     ";
            }

            if (Right.Id == "W")
            {
                display = display + "║";
            }

            return display;
        }

        public string DisplayHorizontalWall()
        {
            string display = "";

            if (Id == "S")
            {
                display = display + "            ";
            }

            display = display + "╬═════";

            if (Right.Id == "W")
            {
				display = display + "╬";
            }

            return display;
        }

		public static Location Wall = new Location("W", -1, -1);
		public static Location Null = new Location("N", -1, -1);
    }
}
