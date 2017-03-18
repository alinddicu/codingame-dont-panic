namespace codingame.dont.panic.TurnDecision
{
	public abstract class TurnDecisionBase
	{
		public abstract bool CanDecide(TurnParams turnParams);

		public abstract TurnDecision Decide(TurnParams turnParams);

		protected static TurnDecision BlockClone(TurnParams turnParams)
		{
			return TurnDecision.BLOCK;
		}
	}
}