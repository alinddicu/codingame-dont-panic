namespace codingame.dont.panic.TurnDecision
{
	using System.Linq;

	public abstract class TurnDecisionBase
	{
		private readonly DriveParams _driveParams;

		protected TurnDecisionBase(DriveParams driveParams)
		{
			_driveParams = driveParams;
		}

		public abstract bool CanDecide(TurnParams turnParams, bool[] blockedClonesPerFloor);

		public abstract TurnDecision Decide(TurnParams turnParams, bool[] blockedClonesPerFloor);

		protected static TurnDecision IncrementBlockedClonesPerFloorAndBlock(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			blockedClonesPerFloor[turnParams.CloneFloor] = true;
			return TurnDecision.BLOCK;
		}

		protected static bool Are0ClonesBlockedOnFloor(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			return !blockedClonesPerFloor[turnParams.CloneFloor];
		}
	}
}