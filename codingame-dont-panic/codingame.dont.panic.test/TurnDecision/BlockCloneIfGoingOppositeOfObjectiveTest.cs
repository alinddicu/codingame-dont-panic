namespace codingame.dont.panic.test.TurnDecision
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;
	using panic.TurnDecision;

	[TestClass]
	public	class BlockCloneIfGoingOppositeOfObjectiveTest
	{
		[TestMethod]
		public void GivenBlockCloneIfGoingLeftAndElevatorIsOnRightWhenCanDecideThenTrue()
		{
			var turnDecision = new BlockCloneIfGoingOppositeOfObjective(Direction.LEFT);
			var driveParams = DriveParamsTest.Create(2, 4, 1, 2, 2, new Elevator("0 2"), new Elevator("1 3"));
			var turnParams = new TurnParams("1 1 LEFT", driveParams);

			Check.That(turnDecision.CanDecide(turnParams)).IsTrue();
			Check.That(turnDecision.Decide(turnParams)).IsEqualTo(TurnDecision.BLOCK);
		}
		
		[TestMethod]
		public void GivenBlockCloneIfGoingLeftAndElevatorIsOnRightWhenCannotDecideThenFalse()
		{
			var turnDecision = new BlockCloneIfGoingOppositeOfObjective(Direction.LEFT);
			var driveParams = DriveParamsTest.Create(2, 4, 1, 2, 2, new Elevator("0 2"), new Elevator("1 3"));
			var turnParams = new TurnParams("1 1 RIGHT", driveParams);

			Check.That(turnDecision.CanDecide(turnParams)).IsFalse();
		}
	}
}
