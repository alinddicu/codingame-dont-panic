namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneIfGoingOppositeOfObjective : ITurnDecision
	{
		private readonly Direction _refereDirection;

		public BlockCloneIfGoingOppositeOfObjective(Direction refereDirection)
		{
			_refereDirection = refereDirection;
		}

		public bool CanDecide(TurnParams turnParams)
		{
			return turnParams.ShouldNextCloneReverse(_refereDirection)
					&& turnParams.IsCloneNearPreviousElevator(_refereDirection);
		}

		public TurnDecision Decide(TurnParams turnParams)
		{
			return TurnDecision.BLOCK;
		}
	}
}