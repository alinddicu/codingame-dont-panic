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
			var turnParams = new TurnParams("0 0 LEFT", new DriveParams(() => "2 3 99 1 3 2 0 1"));

			Check.That(turnParams.IsLeftColision()).IsTrue();
		}

		[TestMethod]
		public void GivenTurnParams00RightWhenIsLeftCollisionThenFalse()
		{
			var turnParams = new TurnParams("0 0 RIGHT", new DriveParams(() => "2 3 99 1 3 2 0 1"));

			Check.That(turnParams.IsLeftColision()).IsFalse();
		}

		[TestMethod]
		public void GivenTurnParams02RightAndDriveWidthOf3WhenIsLeftCollisionThenTrue()
		{
			var turnParams = new TurnParams("0 2 RIGHT", new DriveParams(() => "2 3 99 1 3 2 0 1"));

			Check.That(turnParams.IsRightColision()).IsTrue();
		}

		[TestMethod]
		public void GivenTurnParams01RightAndDriveWidthOf3WhenIsLeftCollisionThenFalse()
		{
			var turnParams = new TurnParams("0 1 RIGHT", new DriveParams(() => "2 3 99 1 3 2 0 1"));

			Check.That(turnParams.IsRightColision()).IsFalse();
		}

		[TestMethod]
		public void GivenTurnParams81RightAndCloneOn8ThFloorWhenIsCloneOnExitFloorThenReturnTrue()
		{
			var turnParams = new TurnParams("8 1 RIGHT", new DriveParams(() => "8 7 6 8 4 3 2 0"));

			Check.That(turnParams.IsCloneOnExitFloor()).IsTrue();
		}

		[TestMethod]
		public void GivenTurnParams81RightAndCloneOn7ThFloorWhenIsCloneOnExitFloorThenReturnFalse()
		{
			var turnParams = new TurnParams("8 1 RIGHT", new DriveParams(() => "8 7 6 7 4 3 2 0"));

			Check.That(turnParams.IsCloneOnExitFloor()).IsFalse();
		}

		[TestMethod]
		public void GivenElevatorAtLeftAndCloneGoingRightWhenShouldCloneReverseThenReturnTrue()
		{
			var consoleSimulator = new ConsoleSimulator("3 4 99 3 3 99 0 2", "1 0", "3 0");
			var turnParams = new TurnParams("1 3 RIGHT", new DriveParams(consoleSimulator.ReadLine));

			Check.That(turnParams.ShouldCloneReverse(Direction.RIGHT)).IsTrue();
		}

		[TestMethod]
		public void GivenElevatorAtLeftAndCloneGoingRightAndReferenceDirectionLeftWhenShouldCloneReverseThenReturnFalse()
		{
			var consoleSimulator = new ConsoleSimulator("3 4 99 3 3 99 0 2", "1 0", "3 0");
			var turnParams = new TurnParams("1 3 RIGHT", new DriveParams(consoleSimulator.ReadLine));

			Check.That(turnParams.ShouldCloneReverse(Direction.LEFT)).IsFalse();
		}

		[TestMethod]
		public void GivenElevatorAtLeftAndCloneGoingLeftWhenShouldCloneReverseThenReturnFalse()
		{
			var consoleSimulator = new ConsoleSimulator("3 4 99 3 3 99 0 2", "1 0", "3 0");
			var turnParams = new TurnParams("1 3 LEFT", new DriveParams(consoleSimulator.ReadLine));

			Check.That(turnParams.ShouldCloneReverse(Direction.LEFT)).IsFalse();
		}

		[TestMethod]
		public void GivenExitAtLeftAndCloneGoingRightWhenShouldCloneReverseThenReturnTrue()
		{
			var consoleSimulator = new ConsoleSimulator("3 4 99 3 0 99 0 2", "1 0", "3 3");
			var turnParams = new TurnParams("3 1 RIGHT", new DriveParams(consoleSimulator.ReadLine));

			Check.That(turnParams.ShouldCloneReverse(Direction.RIGHT)).IsTrue();
		}

		[TestMethod]
		public void GivenExitAtLeftAndCloneGoingLeftWhenShouldCloneReverseThenReturnFalse()
		{
			var consoleSimulator = new ConsoleSimulator("3 4 99 3 0 99 0 2", "1 0", "3 3");
			var turnParams = new TurnParams("3 1 LEFT", new DriveParams(consoleSimulator.ReadLine));

			Check.That(turnParams.ShouldCloneReverse(Direction.LEFT)).IsFalse();
		}
	}
}