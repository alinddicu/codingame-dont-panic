namespace codingame.dont.panic
{
	using System;
	using System.Collections.Generic;
	
	public class Player
	{
		public static void Main(string[] args)
		{
			var drive = new Drive(Console.ReadLine, Console.WriteLine);
			drive.Run();
		}
	}

	public class Drive
	{
		private readonly Func<string> _readLine;
		private readonly Action<object> _writeLine;

		public Drive(Func<string> readLine, Action<object> writeLine)
		{
			_readLine = readLine;
			_writeLine = writeLine;
		}

		public void Run()
		{
			var driveParams = new DriveParams(_readLine);
			var drive = new CloneMaster(driveParams);

			// game loop
			while (true)
			{
				var turnParams = new TurnParams(_readLine);
				if (turnParams.Direction == Direction.EXIT)
				{
					break;
				}

				var decision = drive.Decide(turnParams);
				_writeLine(decision); // action: WAIT or BLOCK
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
		RIGHT,
		EXIT
	}

	public class CloneMaster
	{
		private readonly DriveParams _driveParams;

		public CloneMaster(DriveParams driveParams)
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
			AdditionalElevatorsCount = int.Parse(inputs[6]); // number of additional elevators ignore (always zero)
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
