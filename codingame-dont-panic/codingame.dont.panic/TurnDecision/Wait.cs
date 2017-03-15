namespace codingame.dont.panic.TurnDecision
{
	public class Wait : TurnDecisionBase
	{
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