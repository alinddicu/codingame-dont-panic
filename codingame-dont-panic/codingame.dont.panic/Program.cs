namespace codingame.dont.panic
{
	using System;
	using System.Collections.Generic;

	public class Drive
	{
	}

	public class DriveParams
	{
		private readonly List<Elevator> _elevators = new List<Elevator>();
		
		public int FloorCount { get; private set; }
		
		public int DriveWidth { get; private set; }
		
		public int MaximumRoundCount { get; private set; }
		
		public int ExitFloor { get; private set; }
		
		public int ExitPosition { get; private set; }
		
		public int TotalClonesCount { get; private set; }
		
		public int AdditionalElevatorsCount { get; private set; }

		public IEnumerable<Elevator> Elevators => _elevators;

		public DriveParams(Func<string> readLine)
		{
			var inputs = readLine().Split(' ');
			FloorCount = int.Parse(inputs[0]); // number of floors
			DriveWidth = int.Parse(inputs[1]); // width of the area
			MaximumRoundCount = int.Parse(inputs[2]); // maximum number of rounds
			ExitFloor = int.Parse(inputs[3]); // floor on which the exit is found
			ExitPosition = int.Parse(inputs[4]); // position of the exit on its floor
			TotalClonesCount = int.Parse(inputs[5]); // number of generated clones
			AdditionalElevatorsCount = int.Parse(inputs[6]); // ignore (always zero)
			var nbElevators = int.Parse(inputs[7]); // number of elevators
			for (var i = 0; i < nbElevators; i++)
			{
				var elevatorInputs = readLine().Split(' ');
				_elevators.Add(new Elevator(int.Parse(elevatorInputs[0]), int.Parse(elevatorInputs[1])));
			}
		}
	}

	public class Elevator
	{
		public Elevator(int floor, int position)
		{
			Floor = floor;
			Position = position;
		}

		public int Floor { get; private set; }

		public int Position { get; private set; }
	}
}
