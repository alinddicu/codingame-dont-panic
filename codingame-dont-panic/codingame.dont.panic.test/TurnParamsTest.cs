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

		private static DriveParams GetDriveParams(
				int floorCount,
				int driveWidth,
				int exitFloor,
				int exitPosition,
				int elevatorsCount,
				params Elevator[] elevators)
		{
			return new DriveParams(
				new DontPanicConsoleSimulator(
					floorCount,
					driveWidth,
					exitFloor,
					exitPosition,
					elevatorsCount,
					elevators).ReadLine);
		}

		[TestMethod]
		public void GivenTurnParams00LeftWhenIsLeftCollisionThenTrue()
		{
			var driveParams = GetDriveParams(2, 3, 1, 3, 0);
			var turnParams = new TurnParams("0 0 LEFT", driveParams);

			Check.That(turnParams.IsColision()).IsTrue();
		}

		[TestMethod]
		public void GivenTurnParams00RightWhenIsLeftCollisionThenFalse()
		{
			var driveParams = GetDriveParams(2, 3, 1, 3, 0);
			var turnParams = new TurnParams("0 0 RIGHT", driveParams);

			Check.That(turnParams.IsColision()).IsFalse();
		}

		[TestMethod]
		public void GivenTurnParams02RightAndDriveWidthOf3WhenIsLeftCollisionThenTrue()
		{
			var driveParams = GetDriveParams(2, 3, 1, 3, 0);
			var turnParams = new TurnParams("0 2 RIGHT", driveParams);

			Check.That(turnParams.IsColision()).IsTrue();
		}

		[TestMethod]
		public void GivenTurnParams01RightAndDriveWidthOf3WhenIsLeftCollisionThenFalse()
		{
			var driveParams = GetDriveParams(2, 3, 1, 3, 0);
			var turnParams = new TurnParams("0 1 RIGHT", driveParams);

			Check.That(turnParams.IsColision()).IsFalse();
		}

		[TestMethod]
		public void GivenElevatorAtLeftAndCloneGoingRightWhenShouldCloneReverseThenReturnTrue()
		{
			var driveParams = GetDriveParams(3, 4, 3, 3, 2, new Elevator("1 0"), new Elevator("3 0"));
			var turnParams = new TurnParams("1 3 RIGHT", driveParams);

			Check.That(turnParams.ShouldCloneReverse(Direction.RIGHT)).IsTrue();
		}

		[TestMethod]
		public void GivenElevatorAtLeftAndCloneGoingRightAndReferenceDirectionLeftWhenShouldCloneReverseThenReturnFalse()
		{
			var driveParams = GetDriveParams(3, 4, 3, 3, 2, new Elevator("1 0"), new Elevator("3 0"));
			var turnParams = new TurnParams("1 3 RIGHT", driveParams);

			Check.That(turnParams.ShouldCloneReverse(Direction.LEFT)).IsFalse();
		}

		[TestMethod]
		public void GivenElevatorAtLeftAndCloneGoingLeftWhenShouldCloneReverseThenReturnFalse()
		{
			var driveParams = GetDriveParams(3, 4, 3, 3, 2, new Elevator("1 0"), new Elevator("3 0"));
			var turnParams = new TurnParams("1 3 LEFT", driveParams);

			Check.That(turnParams.ShouldCloneReverse(Direction.LEFT)).IsFalse();
		}

		[TestMethod]
		public void GivenExitAtLeftAndCloneGoingRightWhenShouldCloneReverseThenReturnTrue()
		{
			var driveParams = GetDriveParams(3, 4, 3, 0, 2, new Elevator("1 0"), new Elevator("3 0"));
			var turnParams = new TurnParams("3 1 RIGHT", driveParams);

			Check.That(turnParams.ShouldCloneReverse(Direction.RIGHT)).IsTrue();
		}

		[TestMethod]
		public void GivenExitAtLeftAndCloneGoingLeftWhenShouldCloneReverseThenReturnFalse()
		{
			var driveParams = GetDriveParams(3, 4, 3, 0, 2, new Elevator("1 0"), new Elevator("3 0"));
			var turnParams = new TurnParams("3 1 LEFT", driveParams);

			Check.That(turnParams.ShouldCloneReverse(Direction.LEFT)).IsFalse();
		}

		[TestMethod]
		public void Given2ElevatorPerFloorWhenShouldCloneReverseThenReturnTrue()
		{
			var elevators = new[] { new Elevator("0 4"), new Elevator("1 0"), new Elevator("1 5") };
			var driveParams = GetDriveParams(3, 9, 2, 8, 3, elevators);
			var turnParams = new TurnParams("1 3 LEFT", driveParams);

			Check.That(turnParams.ShouldCloneReverse(Direction.LEFT)).IsTrue();
		}

		[TestMethod]
		public void GivenGroundFloorAndGoingLeftWhenIsCloneNearPreviousElevatorTheFalse()
		{
			var driveParams = GetDriveParams(1, 4, 1, 3, 1, new Elevator("0 0"));
			var turnParams = new TurnParams("0 2 LEFT", driveParams);

			Check.That(turnParams.IsCloneNearPreviousElevator(Direction.LEFT)).IsFalse();
		}

		[TestMethod]
		public void GivenGroundFloorAndGoingRightWhenIsCloneNearPreviousElevatorTheFalse()
		{
			var driveParams = GetDriveParams(1, 4, 1, 3, 1, new Elevator("0 0"));
			var turnParams = new TurnParams("0 1 RIGHT", driveParams);

			Check.That(turnParams.IsCloneNearPreviousElevator(Direction.RIGHT)).IsFalse();
		}

		[TestMethod]
		public void Given1StFloorAndGoingRightWhenIsCloneNearPreviousElevatorTheTrue()
		{
			var driveParams = GetDriveParams(2, 4, 1, 3, 1, new Elevator("0 0"));
			var turnParams = new TurnParams("1 1 RIGHT", driveParams);

			Check.That(turnParams.IsCloneNearPreviousElevator(Direction.RIGHT)).IsTrue();
		}

		[TestMethod]
		public void Given1StFloorAndGoingLeftWhenIsCloneNearPreviousElevatorTheTrue()
		{
			var driveParams = GetDriveParams(2, 4, 1, 0, 1, new Elevator("0 2"));
			var turnParams = new TurnParams("1 1 LEFT", driveParams);

			Check.That(turnParams.IsCloneNearPreviousElevator(Direction.LEFT)).IsTrue();
		}

		[TestMethod]
		public void Given1StFloorAndGoingLeftWhenNotIsCloneNearPreviousElevatorTheFalse()
		{
			var driveParams = GetDriveParams(2, 4, 1, 0, 1, new Elevator("0 2"));
			var turnParams = new TurnParams("1 2 LEFT", driveParams);

			Check.That(turnParams.IsCloneNearPreviousElevator(Direction.LEFT)).IsFalse();
		}
	}
}