namespace codingame.dont.panic
{
	using System;
	using System.Linq;

	public class TurnParams
	{
		private readonly DriveParams _driveParams;
		private readonly int _leadingCloneFloor;
		private readonly int _leadingClonePosition;
		private readonly Direction _leadingCloneDirection;

		public TurnParams(string readLineParams, DriveParams driveParams)
		{
			_driveParams = driveParams;
			var inputs = readLineParams.Split(' ');
			// floor of the leading clone
			_leadingCloneFloor = int.Parse(inputs[0]);
			// position of the leading clone on its floor
			_leadingClonePosition = int.Parse(inputs[1]);
			// referenceDirection of the leading clone: LEFT or RIGHT
			_leadingCloneDirection = (Direction)Enum.Parse(typeof(Direction), inputs[2]);
		}

		public bool IsColision()
		{
			return IsLeftColision() || IsRightColision();
		}

		private bool IsLeftColision()
		{
			return _leadingClonePosition == 0 && _leadingCloneDirection == Direction.LEFT;
		}

		private bool IsRightColision()
		{
			return _leadingClonePosition + 1 == _driveParams.DriveWidth && _leadingCloneDirection == Direction.RIGHT;
		}

		private int GetObjectivePosition()
		{
			return _driveParams.ExitFloor == _leadingCloneFloor
				? _driveParams.ExitPosition
				: _driveParams.GetClosestElevator(_leadingCloneFloor, _leadingClonePosition).Position;
		}

		public bool ShouldNextCloneReverse(Direction referenceDirection)
		{
			if (_leadingCloneDirection != referenceDirection)
			{
				return false;
			}

			var objectivePosition = GetObjectivePosition();
			if (referenceDirection == Direction.RIGHT)
			{
				return _leadingClonePosition > objectivePosition;
			}

			return _leadingClonePosition < objectivePosition;
		}

		private Elevator GetPreviousFloorElevator()
		{
			return _driveParams.Elevators.FirstOrDefault(e => e.Floor == _leadingCloneFloor - 1);
		}

		public bool IsCloneNearPreviousElevator(Direction referenceDirection)
		{
			var previousFloorElevatorPosition = GetPreviousFloorElevator()?.Position;
			if (referenceDirection == Direction.LEFT)
			{
				return previousFloorElevatorPosition - 1 == _leadingClonePosition;
			}

			return previousFloorElevatorPosition + 1 == _leadingClonePosition;
		}
	}
}