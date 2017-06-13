using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInvaders
{
	class FileReader
	{
		// FileReader was created to have a simple way to pull files from 
		// resources folder throughout all classes.

		public static void ReadFile(string filename)
		{
			int counter = 0;
			string line;

			var path = Path.Combine(Directory.GetCurrentDirectory(), filename);

			// Read the file and display it line by line.
			System.IO.StreamReader file =
			   new System.IO.StreamReader(path);
			while ((line = file.ReadLine()) != null)
			{
				Console.WriteLine(line);
				counter++;
			}

			file.Close();
		}
	}
}
