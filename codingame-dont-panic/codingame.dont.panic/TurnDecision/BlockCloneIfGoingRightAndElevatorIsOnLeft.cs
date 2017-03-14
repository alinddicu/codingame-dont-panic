namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneIfGoingRightAndElevatorIsOnLeft : TurnDecisionBase
	{
		public BlockCloneIfGoingRightAndElevatorIsOnLeft(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			var previousFloorElevator = GetPreviousFloorElevator(turnParams);
			return turnParams.ShouldCloneReverse(Direction.RIGHT)
			       && IsNearPreviousElevator(previousFloorElevator?.Position, turnParams, Direction.RIGHT)
			       && Are0ClonesBlockedOnFloor(turnParams, blockedClonesPerFloor);
		}

		public override TurnDecision Decide(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}
}