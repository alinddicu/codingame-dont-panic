namespace codingame.dont.panic
{
	using System;
	using System.Collections.Generic;
	
	public class Player
	{
		static void Main(string[] args)
		{
			var driveParams = new DriveParams(Console.ReadLine);
			var drive = new Drive(driveParams);

			// game loop
			while (true)
			{
				var turnParams = new TurnParams(Console.ReadLine);
				
				Console.WriteLine(drive.Decide(turnParams)); // action: WAIT or BLOCK
			}
		}
	}

	public enum TurnDecision
	{
		WAIT,
		BLOCK
	}

	public enum Direction
	{
		LEFT,
		RIGHT
	}

	public class Drive
	{
		private readonly DriveParams _driveParams;

		public Drive(DriveParams driveParams)
		{
			_driveParams = driveParams;
		}

		public TurnDecision Decide(TurnParams turnParams)
		{
			throw new NotImplementedException();
		}
	}

	public class TurnParams
	{
		public int CloneFloor { get; private set; }

		public int ClonePosition { get; private set; }

		public Direction Direction { get; private set; }

		public TurnParams(Func<string> readLine)
		{
			var inputs = readLine().Split(' ');
			// floor of the leading clone
			CloneFloor = int.Parse(inputs[0]);
			// position of the leading clone on its floor
			ClonePosition = int.Parse(inputs[1]);
			// direction of the leading clone: LEFT or RIGHT
			Direction = (Direction)Enum.Parse(typeof(Direction), inputs[2]);
		}
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
				_elevators.Add(new Elevator(readLine()));
			}
		}
	}

	public class Elevator
	{
		public Elevator(string readLine)
		{
			var elevatorInputs = readLine.Split(' ');
			Floor = int.Parse(elevatorInputs[0]);
			Position = int.Parse(elevatorInputs[1]);
		}

		public int Floor { get; private set; }

		public int Position { get; private set; }
	}
}
