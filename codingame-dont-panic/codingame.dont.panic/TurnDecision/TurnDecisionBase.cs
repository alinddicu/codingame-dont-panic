﻿namespace codingame.dont.panic.TurnDecision
{
	using System.Linq;

	public abstract class TurnDecisionBase
	{
		protected TurnDecisionBase(DriveParams driveParams)
		{
			DriveParams = driveParams;
		}

		protected DriveParams DriveParams { get; }

		public abstract bool CanDecide(TurnParams turnParams, bool[] blockedClonesPerFloor);

		public abstract TurnDecision Decide(TurnParams turnParams, bool[] blockedClonesPerFloor);

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