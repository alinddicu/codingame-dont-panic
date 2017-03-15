namespace codingame.dont.panic.TurnDecision
{
	using System.Collections.Generic;

	public class TurnDecisionsFactory
	{
		public IEnumerable<TurnDecisionBase> Create()
		{
			yield return new BlockCloneBeforeColision();
			yield return new BlockCloneIfGoingLeftAndElevatorIsOnRight();
			yield return new BlockCloneIfGoingLeftAndExitIsOnRight();
			yield return new BlockCloneIfGoingRightAndElevatorIsOnLeft();
			yield return new BlockCloneIfGoingRightAndExitIsOnLeft();
			yield return new Wait();
		}
	}
}