namespace codingame.dont.panic.TurnDecision
{
	public class Wait : TurnDecisionBase
	{
		public Wait(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			return true;
		}

		public override TurnDecision Decide(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			return TurnDecision.WAIT;
		}
	}
}