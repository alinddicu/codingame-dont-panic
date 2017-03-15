namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneIfGoingLeftAndExitIsOnRight : TurnDecisionBase
	{
		public BlockCloneIfGoingLeftAndExitIsOnRight(bool[] blockedClonesPerFloor) 
			: base(blockedClonesPerFloor)
		{
		}

		public override bool CanDecide(TurnParams turnParams)
		{
			return turnParams.ShouldCloneReverse(Direction.LEFT)
			       && turnParams.IsCloneOnExitFloor()
				   && turnParams.IsCloneNearPreviousElevator(Direction.LEFT)
			       && Are0ClonesBlockedOnFloor(turnParams);
		}

		public override TurnDecision Decide(TurnParams turnParams)
		{
			return BlockClone(turnParams);
		}
	}
}