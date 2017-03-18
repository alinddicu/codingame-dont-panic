namespace codingame.dont.panic.TurnDecision
{
	public abstract class TurnDecisionBase
	{
		private readonly bool[] _blockedClonesPerFloor;

		protected TurnDecisionBase(bool[] blockedClonesPerFloor)
		{
			_blockedClonesPerFloor = blockedClonesPerFloor;
		}

		public abstract bool CanDecide(TurnParams turnParams);

		public abstract TurnDecision Decide(TurnParams turnParams);

		protected TurnDecision BlockClone(TurnParams turnParams)
		{
			_blockedClonesPerFloor[turnParams.CloneFloor] = true;
			return TurnDecision.BLOCK;
		}

		protected bool Are0ClonesBlockedOnFloor(TurnParams turnParams)
		{
			return !_blockedClonesPerFloor[turnParams.CloneFloor];
		}
	}
}