namespace codingame.dont.panic
{
	using System.Collections.Generic;
	using System.Linq;
	using TurnDecision;

	public class CloneMaster
	{
		private readonly IEnumerable<ITurnDecision> _turnDecisions;

		public CloneMaster(DriveParams driveParams, TurnDecisionsFactory turnDecisionsFactory)
		{
			_turnDecisions = turnDecisionsFactory.Create();
		}

		public TurnDecision.TurnDecision Run(TurnParams turnParams)
		{
			return _turnDecisions
				.First(td => td.CanDecide(turnParams))
				.Decide(turnParams);
		}
	}
}