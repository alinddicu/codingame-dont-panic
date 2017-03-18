namespace codingame.dont.panic
{
	using System;
	using System.Linq;

	public class TurnParams
	{
		private readonly DriveParams _driveParams;

		public int CloneFloor { get; }

		public int ClonePosition { get; }

		public Direction CloneDirection { get; }

		public TurnParams(string readLineParams, DriveParams driveParams)
		{
			_driveParams = driveParams;
			var inputs = readLineParams.Split(' ');
			// floor of the leading clone
			CloneFloor = int.Parse(inputs[0]);
			// position of the leading clone on its floor
			ClonePosition = int.Parse(inputs[1]);
			// referenceDirection of the leading clone: LEFT or RIGHT
			CloneDirection = (Direction)Enum.Parse(typeof(Direction), inputs[2]);
		}

		public bool IsLeftColision()
		{
			return ClonePosition == 0 && CloneDirection == Direction.LEFT;
		}

		public bool IsRightColision()
		{
			return ClonePosition + 1 == _driveParams.DriveWidth && CloneDirection == Direction.RIGHT;
		}

		private int GetObjectivePosition()
		{
			return _driveParams.ExitFloor == CloneFloor
				? _driveParams.ExitPosition
				: _driveParams.Elevators.First(e => e.Floor == CloneFloor).Position;
		}

		public bool ShouldCloneReverse(Direction referenceDirection)
		{
			if (CloneDirection != referenceDirection)
			{
				return false;
			}

			var objectivePosition = GetObjectivePosition();
			if (referenceDirection == Direction.RIGHT)
			{
				return ClonePosition > objectivePosition;
			}

			return ClonePosition < objectivePosition;
		}

		private Elevator GetPreviousFloorElevator()
		{
			return _driveParams.Elevators.FirstOrDefault(e => e.Floor == CloneFloor - 1);
		}

		public bool IsCloneNearPreviousElevator(Direction referenceDirection)
		{
			var previousFloorElevatorPosition = GetPreviousFloorElevator()?.Position;
			if (referenceDirection == Direction.LEFT)
			{
				return previousFloorElevatorPosition - 1 == ClonePosition;
			}

			return previousFloorElevatorPosition + 1 == ClonePosition;
		}
	}
}