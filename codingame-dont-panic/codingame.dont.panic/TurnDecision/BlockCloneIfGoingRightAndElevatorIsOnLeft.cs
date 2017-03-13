﻿namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneIfGoingRightAndElevatorIsOnLeft : TurnDecisionBase
	{
		public BlockCloneIfGoingRightAndElevatorIsOnLeft(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			var currentFloorElevator = GetCurrentFloorElevator(turnParams);
			var previousFloorElevator = GetPreviousFloorElevator(turnParams);
			return IsHeadingInOppositeDirection(turnParams, currentFloorElevator?.Position, Direction.RIGHT)
			       && IsNearPreviousElevator(previousFloorElevator?.Position, turnParams, Direction.RIGHT)
			       && Are0ClonesBlockedOnFloor(turnParams, blockedClonesPerFloor);
		}

		public override TurnDecision Decide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}
}