using System;

namespace HotOrCold
{
	public class HOC
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hot or Cold Guessing Game");


			var rand = new Random();
			int target = rand.Next(21); //generate a random number between 0 - 20


			// ****************
			// Console.WriteLine(target);
			// ****************
			
		//-----------------------------
			bool loop = true;
			while (loop)
			{	
				Console.WriteLine("Please guess a number between 0 and 20: ");
				int guess = Int32.Parse(Console.ReadLine());
	
				if ( guess == target )
				{
					Console.WriteLine("Congratulations, you guess it!");
					loop = false;
				}
				else if ( guess > target )
				{
					Console.WriteLine("OOPS! That was too high!");
				}
				else
				{
					Console.WriteLine("Oh no! Too low!");
				}
			}
		//------------------------------

		}
	}
}
