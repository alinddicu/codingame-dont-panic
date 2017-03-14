namespace codingame.dont.panic
{
	using System;

	public class TurnParams
	{
		private readonly DriveParams _driveParams;

		public int CloneFloor { get; }

		public int ClonePosition { get; }

		public Direction Direction { get; }

		public TurnParams(string readLineParams, DriveParams driveParams)
		{
			_driveParams = driveParams;
			var inputs = readLineParams.Split(' ');
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

		public bool IsCloneOnExitFloor()
		{
			return CloneFloor == _driveParams.ExitFloor;
		}
	}
}