namespace codingame.dont.panic.TurnDecision
{
	using System.Collections.Generic;

	public class TurnDecisionsFactory
	{
		private readonly DriveParams _driveParams;

		public TurnDecisionsFactory(DriveParams driveParams)
		{
			_driveParams = driveParams;
		}

		public IEnumerable<TurnDecisionBase> Create()
		{
			yield return new BlockCloneBeforeColision(_driveParams);
			yield return new BlockCloneIfGoingLeftAndElevatorIsOnRight(_driveParams);
			yield return new BlockCloneIfGoingLeftAndExitIsOnRight(_driveParams);
			yield return new BlockCloneIfGoingRightAndElevatorIsOnLeft(_driveParams);
			yield return new BlockCloneIfGoingRightAndExitIsOnLeft(_driveParams);
			yield return new Wait(_driveParams);
		}
	}
}