// Not runnable by itself, please turn this into c# project if you want to run this program

using System;

public class Program
{
	public static void Main()
	{
		Human juniper = new Human();
		juniper.BuyFood(1000);
		AutomaticFeeder feeder = new AutomaticFeeder();
		Dog pancake = new Dog(feeder);
		
		pancake.Eat();
		Console.WriteLine(pancake.Energy);
		
		pancake.Eat();
		Console.WriteLine(pancake.Energy);
		
		pancake.Eat();
		Console.WriteLine(pancake.Energy);
		
		pancake.Eat();
		Console.WriteLine(pancake.Energy);
		Console.WriteLine(juniper.AmountOfFood);
		
		pancake.Walk();
		pancake.Sprint();
		
		Console.WriteLine(pancake.Energy);

	}
}

//Dog needs fooddispenser aka human
public class Dog {
	IFoodDispenser _dispenser;
	public Dog(IFoodDispenser dispenser) {
		_dispenser = dispenser;
	}
	public int Energy { get; set; }
	public void Eat() {
		Energy += _dispenser.DispenseFood(20);
	}
	public void Walk() {
		if(Energy <= 10) 
		{
			Console.WriteLine("Will not move, hungry");
			return;
		}
		Console.WriteLine("Walking, my favorite thing!");
		Energy -= 15;
	}
	public void Sprint() {
		if(Energy <= 20) 
		{
			Console.WriteLine("Will not move, hungry");
			return;
		}
		Console.WriteLine("Sprinting, my favorite thing!");
		Energy -= 30;
	}
}

public interface IFoodDispenser {
	void BuyFood(int food);
	
	int DispenseFood(int food);
}

public class Human : IFoodDispenser {
	public int AmountOfFood { get; set; }
	
	public void BuyFood(int food) {
		Console.WriteLine("spent monies to buy food");
		this.AmountOfFood += food;
	}
	
	public int DispenseFood(int food) {
		Console.WriteLine("dispensing food to pets");
		this.AmountOfFood -= food;
		return food; 
	}
}

public class AutomaticFeeder : IFoodDispenser {
	public int AmountOfFood { get; set; }
	
	public void BuyFood(int food) {
		Console.WriteLine("human refilled the food bowl");
		this.AmountOfFood += food;
	}
	
	public int DispenseFood(int food) {
		Console.WriteLine("automatically dispensing food to pets on schedule");
		this.AmountOfFood -= food;
		return food; 
	}
}