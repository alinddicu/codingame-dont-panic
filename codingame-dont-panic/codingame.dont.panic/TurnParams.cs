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
			// direction of the leading clone: LEFT or RIGHT
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

		public bool IsCloneOnExitFloor()
		{
			return CloneFloor == _driveParams.ExitFloor;
		}

		private int? GetObjectivePosition()
		{
			return _driveParams.ExitFloor == CloneFloor
				? _driveParams.ExitPosition
				: _driveParams.Elevators.FirstOrDefault(e => e.Floor == CloneFloor && e.Position == ClonePosition)?.Position;
		}

		public bool IsHeadingInOppositeDirection(Direction direction)
		{
			if (CloneDirection != direction)
			{
				return false;
			}

			var objectivePosition = GetObjectivePosition();
			if (direction == Direction.RIGHT)
			{
				return ClonePosition > objectivePosition;
			}

			return ClonePosition < objectivePosition;
		}
	}
}