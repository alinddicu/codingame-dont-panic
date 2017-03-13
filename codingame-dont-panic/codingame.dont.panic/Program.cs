﻿namespace codingame.dont.panic
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

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
			var drive = new CloneMaster(driveParams, new TurnDecisionsFactory(driveParams));

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

	public abstract class TurnDecisionBase
	{
		protected TurnDecisionBase(DriveParams driveParams)
		{
			DriveParams = driveParams;
		}

		protected DriveParams DriveParams { get; }

		public abstract bool CanDecide(TurnParams turnParams, int[] blockedClonesPerFloor);

		public abstract TurnDecision Decide(TurnParams turnParams, int[] blockedClonesPerFloor);

		protected Elevator GetCurrentFloorElevator(TurnParams turnParams)
		{
			return GetFloorElevator(turnParams, 0);
		}

		protected Elevator GetPreviousFloorElevator(TurnParams turnParams)
		{
			return GetFloorElevator(turnParams, 1); ;
		}

		private Elevator GetFloorElevator(TurnParams turnParams, int offSet)
		{
			return DriveParams.Elevators.FirstOrDefault(e => e.Floor == turnParams.CloneFloor - offSet);
		}

		protected TurnDecision IncrementBlockedClonesPerFloorAndBlock(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			blockedClonesPerFloor[turnParams.CloneFloor]++;
			return TurnDecision.BLOCK;
		}
	}

	public class BlockCloneBeforeColision : TurnDecisionBase
	{
		public BlockCloneBeforeColision(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return turnParams.IsLeftColision() || turnParams.IsRightColision(DriveParams.DriveWidth);
		}

		public override TurnDecision Decide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}

	public class BlockCloneIfGoingRightAndElevatorIsOnLeft : TurnDecisionBase
	{
		public BlockCloneIfGoingRightAndElevatorIsOnLeft(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			var currentFloorElevator = GetCurrentFloorElevator(turnParams);
			var previousFloorElevator = GetPreviousFloorElevator(turnParams);
			return
				turnParams.ClonePosition > currentFloorElevator?.Position
				&& turnParams.Direction == Direction.RIGHT
				&& turnParams.CloneFloor == currentFloorElevator?.Floor
				&& previousFloorElevator?.Position + 1 == turnParams.ClonePosition
				&& blockedClonesPerFloor[turnParams.CloneFloor] == 0;
		}

		public override TurnDecision Decide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}

	public class BlockCloneIfGoingRightAndExitIsOnLeft : TurnDecisionBase
	{
		public BlockCloneIfGoingRightAndExitIsOnLeft(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			var previousFloorElevator = GetPreviousFloorElevator(turnParams);
			return 
				turnParams.ClonePosition > DriveParams.ExitPosition
				&& turnParams.Direction == Direction.RIGHT
				&& turnParams.CloneFloor == DriveParams.ExitFloor
				&& previousFloorElevator?.Position + 1 == turnParams.ClonePosition
				&& blockedClonesPerFloor[turnParams.CloneFloor] == 0;
		}

		public override TurnDecision Decide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}

	public class BlockCloneIfGoingLeftAndElevatorIsOnRight : TurnDecisionBase
	{
		public BlockCloneIfGoingLeftAndElevatorIsOnRight(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			var currentFloorElevator = GetCurrentFloorElevator(turnParams);
			var previousFloorElevator = GetPreviousFloorElevator(turnParams);
			return
				turnParams.ClonePosition < currentFloorElevator?.Position
				&& turnParams.Direction == Direction.LEFT
				&& turnParams.CloneFloor == currentFloorElevator?.Floor
				&& previousFloorElevator?.Position - 1 == turnParams.ClonePosition
				&& blockedClonesPerFloor[turnParams.CloneFloor] == 0;
		}

		public override TurnDecision Decide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}

	public class BlockCloneIfGoingLeftAndExitIsOnRight : TurnDecisionBase
	{
		public BlockCloneIfGoingLeftAndExitIsOnRight(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			var previousFloorElevator = GetPreviousFloorElevator(turnParams);
			return turnParams.ClonePosition < DriveParams.ExitPosition
				&& turnParams.Direction == Direction.LEFT
				&& turnParams.CloneFloor == DriveParams.ExitFloor
				&& previousFloorElevator?.Position - 1 == turnParams.ClonePosition
				&& blockedClonesPerFloor[turnParams.CloneFloor] == 0;
		}

		public override TurnDecision Decide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}

	public class Wait : TurnDecisionBase
	{
		public Wait(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return true;
		}

		public override TurnDecision Decide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return TurnDecision.WAIT;
		}
	}

	public class TurnDecisionsFactory
	{
		private readonly DriveParams _driveParams;

		public TurnDecisionsFactory(DriveParams driveParams)
		{
			_driveParams = driveParams;
		}

		public IEnumerable<TurnDecisionBase> Create()
		{
			yield return new BlockCloneBeforeColision(_driveParams);
			yield return new BlockCloneIfGoingLeftAndElevatorIsOnRight(_driveParams);
			yield return new BlockCloneIfGoingLeftAndExitIsOnRight(_driveParams);
			yield return new BlockCloneIfGoingRightAndElevatorIsOnLeft(_driveParams);
			yield return new BlockCloneIfGoingRightAndExitIsOnLeft(_driveParams);
			yield return new Wait(_driveParams);
		}
	}

	public class CloneMaster
	{
		private readonly DriveParams _driveParams;
		private readonly int[] _blockedClonesPerFloor;
		private readonly IEnumerable<TurnDecisionBase> _turnDecisions;

		public CloneMaster(DriveParams driveParams, TurnDecisionsFactory turnDecisionsFactory)
		{
			_driveParams = driveParams;
			_blockedClonesPerFloor = new int[driveParams.FloorCount];
			_turnDecisions = turnDecisionsFactory.Create();
		}

		public TurnDecision Decide(TurnParams turnParams)
		{
			return _turnDecisions
				.First(td => td.CanDecide(turnParams, _blockedClonesPerFloor))
				.Decide(turnParams, _blockedClonesPerFloor);
		}
	}

	public class TurnParams
	{
		public int CloneFloor { get; }

		public int ClonePosition { get; }

		public Direction Direction { get; }

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

		public bool IsLeftColision()
		{
			return ClonePosition == 0 && Direction == Direction.LEFT;
		}

		public bool IsRightColision(int driveWidth)
		{
			return ClonePosition + 1 == driveWidth && Direction == Direction.RIGHT;
		}
	}

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
	}
}
