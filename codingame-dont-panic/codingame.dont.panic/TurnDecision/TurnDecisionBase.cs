namespace codingame.dont.panic.TurnDecision
{
	using System.Linq;

	public abstract class TurnDecisionBase
	{
		private readonly DriveParams _driveParams;

		protected TurnDecisionBase(DriveParams driveParams)
		{
			_driveParams = driveParams;
		}

		public abstract bool CanDecide(TurnParams turnParams, bool[] blockedClonesPerFloor);

		public abstract TurnDecision Decide(TurnParams turnParams, bool[] blockedClonesPerFloor);

		protected Elevator GetPreviousFloorElevator(TurnParams turnParams)
		{
			return _driveParams.Elevators.FirstOrDefault(e => e.Floor == turnParams.CloneFloor - 1);
		}

		protected static TurnDecision IncrementBlockedClonesPerFloorAndBlock(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			blockedClonesPerFloor[turnParams.CloneFloor] = true;
			return TurnDecision.BLOCK;
		}

		protected static bool Are0ClonesBlockedOnFloor(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			return !blockedClonesPerFloor[turnParams.CloneFloor];
		}

		protected static bool IsNearPreviousElevator(int? previousFloorElevatorPosition, TurnParams turnParams, Direction direction)
		{
			if (direction == Direction.LEFT)
			{
				return previousFloorElevatorPosition - 1 == turnParams.ClonePosition;
			}

			return previousFloorElevatorPosition + 1 == turnParams.ClonePosition;
		}
	}
}