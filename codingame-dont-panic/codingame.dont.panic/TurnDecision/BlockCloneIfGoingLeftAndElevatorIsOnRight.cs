﻿namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneIfGoingLeftAndElevatorIsOnRight : TurnDecisionBase
	{
		public BlockCloneIfGoingLeftAndElevatorIsOnRight(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			var currentFloorElevator = GetCurrentFloorElevator(turnParams);
			var previousFloorElevator = GetPreviousFloorElevator(turnParams);
			return IsHeadingInOppositeDirection(turnParams, currentFloorElevator?.Position, Direction.LEFT)
			       && IsNearPreviousElevator(previousFloorElevator?.Position, turnParams, Direction.LEFT)
			       && Are0ClonesBlockedOnFloor(turnParams, blockedClonesPerFloor);
		}

		public override TurnDecision Decide(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}
}