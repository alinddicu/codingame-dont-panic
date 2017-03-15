namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneIfGoingLeftAndElevatorIsOnRight : TurnDecisionBase
	{
		public BlockCloneIfGoingLeftAndElevatorIsOnRight(bool[] blockedClonesPerFloor) 
			: base(blockedClonesPerFloor)
		{
		}

		public override bool CanDecide(TurnParams turnParams)
		{
			return turnParams.ShouldCloneReverse(Direction.LEFT)
			       && turnParams.IsCloneNearPreviousElevator(Direction.LEFT)
			       && Are0ClonesBlockedOnFloor(turnParams);
		}

		public override TurnDecision Decide(TurnParams turnParams)
		{
			return BlockClone(turnParams);
		}
	}
}