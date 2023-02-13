
using System;

namespace CoinFlipper
{
	public class Flipper
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Coin Flipper Starting...");
			
			Random rand = new Random();
			int value = rand.Next();

			Console.WriteLine("The Random Number Is: " + value);

			bool coin = true;
			
			int remainder = value % 2;
			
			if ( remainder == 0 ) 
			{
				coin = false;
			}


			if ( coin )  // if ( coin == true )
			{
				Console.WriteLine("Your coin was flipped, it was tails");
			}
			
			else
			{
				Console.WriteLine("Your coin was flipped, it was heads");
			}
		}
	}	
}

