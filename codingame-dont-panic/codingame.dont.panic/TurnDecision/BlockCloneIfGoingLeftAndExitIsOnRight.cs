﻿namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneIfGoingLeftAndExitIsOnRight : TurnDecisionBase
	{
		public BlockCloneIfGoingLeftAndExitIsOnRight(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			var previousFloorElevator = GetPreviousFloorElevator(turnParams);
			return IsHeadingInOppositeDirection(turnParams, DriveParams.ExitPosition, Direction.LEFT)
			       && IsCloneOnExitFloor(turnParams)
			       && IsNearPreviousElevator(previousFloorElevator?.Position, turnParams, Direction.LEFT)
			       && Are0ClonesBlockedOnFloor(turnParams, blockedClonesPerFloor);
		}

		public override TurnDecision Decide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}
}