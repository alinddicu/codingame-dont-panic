namespace codingame.dont.panic
{
	using System.Collections.Generic;
	using System.Linq;
	using TurnDecision;

	public class CloneMaster
	{
		private readonly IEnumerable<ITurnDecision> _turnPossibleDecisions;

		public CloneMaster(TurnDecisionsFactory turnDecisionsFactory)
		{
			_turnPossibleDecisions = turnDecisionsFactory.Create();
		}

		public TurnDecision.TurnDecision Decide(TurnParams turnParams)
		{
			return _turnPossibleDecisions
				.First(td => td.CanDecide(turnParams))
				.Decide(turnParams);
		}
	}
}