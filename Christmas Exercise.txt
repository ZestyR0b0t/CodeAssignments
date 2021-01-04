using System;
					
public class Program
{
	public static void Main()
	{
		ChristmasSpirit xmasSpirit = new ChristmasSpirit();
		
		Child billy = new Child("Billy");

		billy.NaughtyOrNice();
		billy.ChangeOfHeart(xmasSpirit);
		billy.NaughtyOrNice();
	}
}

public class Child
{
	private string _name;
	private ChristmasSpirit _spirit = null;
	
	public Child(string argName)
	{
		_name = argName; 
	}
	
	public void NaughtyOrNice()
	{
		if (_spirit == null)
		{
			Console.WriteLine("This is " + _name + " covered in coal.\n" + _name + " is naughty right down the soul.\n");
			Console.WriteLine("Selfish, ill-mannered, mean " + _name + " never gives.\nOn Santa's naughty list young " + _name + " always lives.\n");
			return;
		}
		else
		{
			Console.WriteLine("From that day on young " + _name + " has been nice .\nSanta, now pleased, thinks gifts will suffice.\n");
			Console.WriteLine("Clean as a whistle, no coal to witness,\n" + _name + " understands the true meaning of Christmas!");
		}
	}
	
	public void ChangeOfHeart(ChristmasSpirit spiritArg)
	{
		{
			_spirit = spiritArg;
			Console.WriteLine("One night however, a scary ghost came through. \nAnd showed naughty " + _name + " what not to do.\n");
		}
	}
}

public class ChristmasSpirit
{
	// NO TOUCHY
}