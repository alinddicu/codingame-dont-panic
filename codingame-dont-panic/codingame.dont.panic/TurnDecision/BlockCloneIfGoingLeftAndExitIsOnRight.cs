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
				   && turnParams.IsCloneNearPreviousElevator(Direction.LEFT);
		}

		public override TurnDecision Decide(TurnParams turnParams)
		{
			return BlockClone(turnParams);
		}
	}
}