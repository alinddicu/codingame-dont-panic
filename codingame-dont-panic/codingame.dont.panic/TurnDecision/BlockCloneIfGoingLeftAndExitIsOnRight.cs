﻿namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneIfGoingLeftAndExitIsOnRight : TurnDecisionBase
	{
		public BlockCloneIfGoingLeftAndExitIsOnRight(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			return turnParams.ShouldCloneReverse(Direction.LEFT)
			       && turnParams.IsCloneOnExitFloor()
				   && turnParams.IsCloneNearPreviousElevator(Direction.LEFT)
			       && Are0ClonesBlockedOnFloor(turnParams, blockedClonesPerFloor);
		}

		public override TurnDecision Decide(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}
}