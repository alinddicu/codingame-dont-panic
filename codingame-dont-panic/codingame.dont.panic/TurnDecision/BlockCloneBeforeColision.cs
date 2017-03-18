namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneBeforeColision : TurnDecisionBase
	{
		public override bool CanDecide(TurnParams turnParams)
		{
			return turnParams.IsLeftColision() || turnParams.IsRightColision();
		}

		public override TurnDecision Decide(TurnParams turnParams)
		{
			return BlockClone(turnParams);
		}
	}
}