namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneIfGoingRightAndExitIsOnLeft : TurnDecisionBase
	{
		public BlockCloneIfGoingRightAndExitIsOnLeft(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			return turnParams.ShouldCloneReverse(Direction.RIGHT)
			       && turnParams.IsCloneOnExitFloor()
				   && turnParams.IsCloneNearPreviousElevator(Direction.RIGHT)
			       && Are0ClonesBlockedOnFloor(turnParams, blockedClonesPerFloor);
		}

		public override TurnDecision Decide(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}
}