namespace codingame.dont.panic.TurnDecision
{
	public class BlockCloneBeforeColision : TurnDecisionBase
	{
		public BlockCloneBeforeColision(DriveParams driveParams) : base(driveParams)
		{
		}

		public override bool CanDecide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return turnParams.IsLeftColision() || turnParams.IsRightColision(DriveParams.DriveWidth);
		}

		public override TurnDecision Decide(TurnParams turnParams, int[] blockedClonesPerFloor)
		{
			return IncrementBlockedClonesPerFloorAndBlock(turnParams, blockedClonesPerFloor);
		}
	}
}