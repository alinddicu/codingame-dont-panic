namespace codingame.dont.panic
{
	using System;
	using System.Collections.Generic;

	public class DriveParams
	{
		private readonly List<Elevator> _elevators = new List<Elevator>();

		public int FloorCount { get; }

		public int DriveWidth { get; }

		public int MaximumRoundCount { get; private set; }

		public int ExitFloor { get; }

		public int ExitPosition { get; }

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
			AdditionalElevatorsCount = int.Parse(inputs[6]); // number of additional elevators ignore (always zero)
			var nbElevators = int.Parse(inputs[7]); // number of elevators
			for (var i = 0; i < nbElevators; i++)
			{
				_elevators.Add(new Elevator(readLine()));
			}
		}
	}
}