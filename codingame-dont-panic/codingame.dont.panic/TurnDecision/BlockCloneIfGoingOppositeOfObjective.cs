namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneIfGoingOppositeOfObjective : TurnDecisionBase
	{
		private readonly Direction _refereDirection;

		public BlockCloneIfGoingOppositeOfObjective(Direction refereDirection)
		{
			_refereDirection = refereDirection;
		}

		public override bool CanDecide(TurnParams turnParams)
		{
			return turnParams.ShouldCloneReverse(_refereDirection)
					&& turnParams.IsCloneNearPreviousElevator(_refereDirection);
		}

		public override TurnDecision Decide(TurnParams turnParams)
		{
			return BlockClone(turnParams);
		}
	}
}