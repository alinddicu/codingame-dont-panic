namespace codingame.dont.panic.test
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class TurnParamsTest
	{
		[TestMethod]
		public void WhenCreateTurnParamsThenValuesOfTurnParamsAreCorrect()
		{
			var turnParams = new TurnParams("8 7 RIGHT", null);

			Check.That(turnParams.CloneFloor).IsEqualTo(8);
			Check.That(turnParams.ClonePosition).IsEqualTo(7);
			Check.That(turnParams.CloneDirection).IsEqualTo(Direction.RIGHT);
		}

		[TestMethod]
		public void GivenTurnParams00LeftWhenIsLeftCollisionThenTrue()
		{
			var driveParams = new DriveParams(new ConsoleSimulator(2, 3, 1, 3, 0).ReadLine);
			var turnParams = new TurnParams("0 0 LEFT", driveParams);

			Check.That(turnParams.IsLeftColision()).IsTrue();
		}

		[TestMethod]
		public void GivenTurnParams00RightWhenIsLeftCollisionThenFalse()
		{
			var driveParams = new DriveParams(new ConsoleSimulator(2, 3, 1, 3, 0).ReadLine);
			var turnParams = new TurnParams("0 0 RIGHT", driveParams);

			Check.That(turnParams.IsLeftColision()).IsFalse();
		}

		[TestMethod]
		public void GivenTurnParams02RightAndDriveWidthOf3WhenIsLeftCollisionThenTrue()
		{
			var driveParams = new DriveParams(new ConsoleSimulator(2, 3, 1, 3, 0).ReadLine);
			var turnParams = new TurnParams("0 2 RIGHT", driveParams);

			Check.That(turnParams.IsRightColision()).IsTrue();
		}

		[TestMethod]
		public void GivenTurnParams01RightAndDriveWidthOf3WhenIsLeftCollisionThenFalse()
		{
			var driveParams = new DriveParams(new ConsoleSimulator(2, 3, 1, 3, 0).ReadLine);
			var turnParams = new TurnParams("0 1 RIGHT", driveParams);

			Check.That(turnParams.IsRightColision()).IsFalse();
		}

		[TestMethod]
		public void GivenTurnParams11RightAndCloneOn8ThFloorWhenIsCloneOnExitFloorThenReturnTrue()
		{
			var driveParams = new DriveParams(new ConsoleSimulator(2, 3, 1, 3, 0).ReadLine);
			var turnParams = new TurnParams("1 1 RIGHT", driveParams);

			Check.That(turnParams.IsCloneOnExitFloor()).IsTrue();
		}

		[TestMethod]
		public void GivenTurnParams01RightAndCloneOn2ndFloorWhenIsCloneOnExitFloorThenReturnFalse()
		{
			var driveParams = new DriveParams(new ConsoleSimulator(2, 3, 1, 3, 0).ReadLine);
			var turnParams = new TurnParams("0 1 RIGHT", driveParams);

			Check.That(turnParams.IsCloneOnExitFloor()).IsFalse();
		}

		[TestMethod]
		public void GivenElevatorAtLeftAndCloneGoingRightWhenShouldCloneReverseThenReturnTrue()
		{
			var driveParams = new DriveParams(new ConsoleSimulator(3, 4, 3, 3, 2, new Elevator("1 0 "), new Elevator("3 0")).ReadLine);
			var turnParams = new TurnParams("1 3 RIGHT", driveParams);

			Check.That(turnParams.ShouldCloneReverse(Direction.RIGHT)).IsTrue();
		}

		[TestMethod]
		public void GivenElevatorAtLeftAndCloneGoingRightAndReferenceDirectionLeftWhenShouldCloneReverseThenReturnFalse()
		{
			var driveParams = new DriveParams(new ConsoleSimulator(3, 4, 3, 3, 2, new Elevator("1 0 "), new Elevator("3 0")).ReadLine);
			var turnParams = new TurnParams("1 3 RIGHT", driveParams);

			Check.That(turnParams.ShouldCloneReverse(Direction.LEFT)).IsFalse();
		}

		[TestMethod]
		public void GivenElevatorAtLeftAndCloneGoingLeftWhenShouldCloneReverseThenReturnFalse()
		{
			var driveParams = new DriveParams(new ConsoleSimulator(3, 4, 3, 3, 2, new Elevator("1 0 "), new Elevator("3 0")).ReadLine);
			var turnParams = new TurnParams("1 3 LEFT", driveParams);

			Check.That(turnParams.ShouldCloneReverse(Direction.LEFT)).IsFalse();
		}

		[TestMethod]
		public void GivenExitAtLeftAndCloneGoingRightWhenShouldCloneReverseThenReturnTrue()
		{
			var driveParams = new DriveParams(new ConsoleSimulator(3, 4, 3, 0, 2, new Elevator("1 0 "), new Elevator("3 0 ")).ReadLine);
			var turnParams = new TurnParams("3 1 RIGHT", driveParams);

			Check.That(turnParams.ShouldCloneReverse(Direction.RIGHT)).IsTrue();
		}

		[TestMethod]
		public void GivenExitAtLeftAndCloneGoingLeftWhenShouldCloneReverseThenReturnFalse()
		{
			var driveParams = new DriveParams(new ConsoleSimulator(3, 4, 3, 0, 2, new Elevator("1 0 "), new Elevator("3 0 ")).ReadLine);
			var turnParams = new TurnParams("3 1 LEFT", driveParams);

			Check.That(turnParams.ShouldCloneReverse(Direction.LEFT)).IsFalse();
		}
	}
}