namespace codingame.dont.panic.TurnDecision
{
	using System.Collections.Generic;

	public class TurnDecisionsFactory
	{
		public IEnumerable<TurnDecisionBase> Create(bool[] blockedClonesPerFloor)
		{
			yield return new BlockCloneBeforeColision(blockedClonesPerFloor);
			yield return new BlockCloneIfGoingLeftAndElevatorIsOnRight(blockedClonesPerFloor);
			yield return new BlockCloneIfGoingLeftAndExitIsOnRight(blockedClonesPerFloor);
			yield return new BlockCloneIfGoingRightAndElevatorIsOnLeft(blockedClonesPerFloor);
			yield return new BlockCloneIfGoingRightAndExitIsOnLeft(blockedClonesPerFloor);
			yield return new Wait(blockedClonesPerFloor);
		}
	}
}