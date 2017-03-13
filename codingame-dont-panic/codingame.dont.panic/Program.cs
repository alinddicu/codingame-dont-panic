namespace codingame.dont.panic
{
	using System;

	public class Program
	{
		public static void Main(string[] args)
		{
			var drive = new Drive(Console.ReadLine, Console.WriteLine);
			drive.Run();
		}
	}
}
