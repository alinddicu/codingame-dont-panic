namespace codingame.dont.panic
{
	using System.Collections.Generic;
	using System.Linq;
	using TurnDecision;

	public class CloneMaster
	{
		private readonly int[] _blockedClonesPerFloor;
		private readonly IEnumerable<TurnDecisionBase> _turnDecisions;

		public CloneMaster(DriveParams driveParams, TurnDecisionsFactory turnDecisionsFactory)
		{
			_blockedClonesPerFloor = new int[driveParams.FloorCount];
			_turnDecisions = turnDecisionsFactory.Create();
		}

		public TurnDecision.TurnDecision Decide(TurnParams turnParams)
		{
			return _turnDecisions
				.First(td => td.CanDecide(turnParams, _blockedClonesPerFloor))
				.Decide(turnParams, _blockedClonesPerFloor);
		}
	}
}