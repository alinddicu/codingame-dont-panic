namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneBeforeColision : TurnDecisionBase
	{
		public override bool CanDecide(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			return turnParams.IsLeftColision() || turnParams.IsRightColision();
		}

		public override TurnDecision Decide(TurnParams turnParams, bool[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}
}