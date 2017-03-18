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
			var turnDecision = new BlockCloneBeforeColision();
			var driveParams = DriveParamsTest.Create(1, 3, 0, 1, 0);
			var turnParams = new TurnParams("0 0 LEFT", driveParams);

			Check.That(turnDecision.CanDecide(turnParams)).IsTrue();
			Check.That(turnDecision.Decide(turnParams)).IsEqualTo(TurnDecision.BLOCK);
		}
		
		[TestMethod]
		public void GivenBlockCloneBeforeColisionAndBlockedAtRightWhenGoingRighttWhenCanDecideThenTrue()
		{
			var turnDecision = new BlockCloneBeforeColision();
			var driveParams = DriveParamsTest.Create(1, 3, 0, 0, 0);
			var turnParams = new TurnParams("0 2 RIGHT", driveParams);

			Check.That(turnDecision.CanDecide(turnParams)).IsTrue();
			Check.That(turnDecision.Decide(turnParams)).IsEqualTo(TurnDecision.BLOCK);
		}

		[TestMethod]
		public void GivenBlockCloneBeforeColisionAndNotBlockedAtRightWhenGoingRighttWhenCanDecideThenFalse()
		{
			var turnDecision = new BlockCloneBeforeColision();
			var driveParams = DriveParamsTest.Create(1, 3, 0, 0, 0);
			var turnParams = new TurnParams("0 1 RIGHT", driveParams);

			Check.That(turnDecision.CanDecide(turnParams)).IsFalse();
		}
	}
}
