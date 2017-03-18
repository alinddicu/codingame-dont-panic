namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneIfGoingRightAndExitIsOnLeft : TurnDecisionBase
	{
		public BlockCloneIfGoingRightAndExitIsOnLeft(bool[] blockedClonesPerFloor) 
			: base(blockedClonesPerFloor)
		{
		}

		public override bool CanDecide(TurnParams turnParams)
		{
			return turnParams.ShouldCloneReverse(Direction.RIGHT)
				   && turnParams.IsCloneNearPreviousElevator(Direction.RIGHT);
		}

		public override TurnDecision Decide(TurnParams turnParams)
		{
			return BlockClone(turnParams);
		}
	}
}