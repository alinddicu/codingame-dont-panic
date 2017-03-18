namespace codingame.dont.panic.test.TurnDecision
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;
	using panic.TurnDecision;

	[TestClass]
	public class BlockCloneIfGoingLeftAndExitIsOnRightTest
	{
		[TestMethod]
		public void GivenBlockCloneIfGoingLeftAndExitIsOnRightWhenCanDecideThenTrue()
		{
			var blockedClonesPerFloor = new bool[2];
			var turnDecision = new BlockCloneIfGoingLeftAndExitIsOnRight(blockedClonesPerFloor);
			var driveParams = DriveParamsTest.Create(2, 4, 1, 2, 1, new Elevator("0 2"));
			var turnParams = new TurnParams("1 1 LEFT", driveParams);

			Check.That(turnDecision.CanDecide(turnParams)).IsTrue();
			Check.That(turnDecision.Decide(turnParams)).IsEqualTo(TurnDecision.BLOCK);
			Check.That(blockedClonesPerFloor).ContainsExactly(false, true);
		}

		[TestMethod]
		public void GivenBlockCloneIfGoingRightAndExitIsOnRightWhenCanDecideThenFalse()
		{
			var blockedClonesPerFloor = new bool[2];
			var turnDecision = new BlockCloneIfGoingLeftAndExitIsOnRight(blockedClonesPerFloor);
			var driveParams = DriveParamsTest.Create(2, 4, 1, 2, 1, new Elevator("0 2"));
			var turnParams = new TurnParams("1 1 RIGHT", driveParams);

			Check.That(turnDecision.CanDecide(turnParams)).IsFalse();
		}
	}
}
