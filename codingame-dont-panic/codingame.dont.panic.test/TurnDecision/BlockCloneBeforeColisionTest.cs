namespace codingame.dont.panic.test.TurnDecision
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;
	using panic.TurnDecision;

	[TestClass]
	public class BlockCloneBeforeColisionTest
	{
		[TestMethod]
		public void GivenBlockCloneBeforeColisionAndBlockedAtLeftWhenGoinfLeftWhenCanDecideThenTrue()
		{
			var blockedClonesPerFloor = new bool[1];
			var turnDecision = new BlockCloneBeforeColision(blockedClonesPerFloor);
			var driveParams = DriveParamsTest.Create(1, 3, 0, 1, 0);
			var turnParams = new TurnParams("0 0 LEFT", driveParams);

			Check.That(turnDecision.CanDecide(turnParams)).IsTrue();
			Check.That(turnDecision.Decide(turnParams)).IsEqualTo(TurnDecision.BLOCK);
			Check.That(blockedClonesPerFloor[0]).IsTrue();
		}
		
		[TestMethod]
		public void GivenBlockCloneBeforeColisionAndBlockedAtRightWhenGoingRighttWhenCanDecideThenTrue()
		{
			var blockedClonesPerFloor = new bool[1];
			var turnDecision = new BlockCloneBeforeColision(blockedClonesPerFloor);
			var driveParams = DriveParamsTest.Create(1, 3, 0, 0, 0);
			var turnParams = new TurnParams("0 2 RIGHT", driveParams);

			Check.That(turnDecision.CanDecide(turnParams)).IsTrue();
			Check.That(turnDecision.Decide(turnParams)).IsEqualTo(TurnDecision.BLOCK);
			Check.That(blockedClonesPerFloor[0]).IsTrue();
		}

		[TestMethod]
		public void GivenBlockCloneBeforeColisionAndNotBlockedAtRightWhenGoingRighttWhenCanDecideThenFalse()
		{
			var blockedClonesPerFloor = new bool[1];
			var turnDecision = new BlockCloneBeforeColision(blockedClonesPerFloor);
			var driveParams = DriveParamsTest.Create(1, 3, 0, 0, 0);
			var turnParams = new TurnParams("0 1 RIGHT", driveParams);

			Check.That(turnDecision.CanDecide(turnParams)).IsFalse();
			Check.That(blockedClonesPerFloor[0]).IsFalse();
		}
	}
}
