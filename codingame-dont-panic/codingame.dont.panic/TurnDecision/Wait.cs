namespace codingame.dont.panic.TurnDecision
{
	public class Wait : TurnDecisionBase
	{
		public Wait(bool[] blockedClonesPerFloor) 
			: base(blockedClonesPerFloor)
		{
		}

		public override bool CanDecide(TurnParams turnParams)
		{
			return true;
		}

		public override TurnDecision Decide(TurnParams turnParams)
		{
			return TurnDecision.WAIT;
		}
	}
}