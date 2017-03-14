namespace codingame.dont.panic.TurnDecision
{
	using System.Linq;

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
			return GetFloorElevator(turnParams, 1);
		}

		private Elevator GetFloorElevator(TurnParams turnParams, int offSet)
		{
			return DriveParams.Elevators.FirstOrDefault(e => e.Floor == turnParams.CloneFloor - offSet);
		}

		protected static TurnDecision IncrementBlockedClonesPerFloorAndBlock(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			blockedClonesPerFloor[turnParams.CloneFloor]++;
			return TurnDecision.BLOCK;
		}

		protected static bool IsHeadingInOppositeDirection(TurnParams turnParams, int? objectivePosition, Direction direction)
		{
			if (turnParams.Direction != direction)
			{
				return false;
			}

			if (direction == Direction.RIGHT)
			{
				return turnParams.ClonePosition > objectivePosition;
			}

			return turnParams.ClonePosition < objectivePosition;
		}

		protected static bool Are0ClonesBlockedOnFloor(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return blockedClonesPerFloor[turnParams.CloneFloor] == 0;
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