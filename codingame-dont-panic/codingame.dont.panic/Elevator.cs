namespace codingame.dont.panic
{
	public class Elevator
	{
		public Elevator(string readLine)
		{
			var elevatorInputs = readLine.Split(' ');
			Floor = int.Parse(elevatorInputs[0]);
			Position = int.Parse(elevatorInputs[1]);
		}

		public int Floor { get; }

		public int Position { get; }

		public override string ToString()
		{
			return string.Format("{0} {1}", Floor, Position);
		}
	}
}