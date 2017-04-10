namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneBeforeColision : ITurnDecision
	{
		public bool CanDecide(TurnParams turnParams)
		{
			return turnParams.IsColision();
		}

		public TurnDecision Decide(TurnParams turnParams)
		{
			return TurnDecision.BLOCK;
		}
	}
}