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
			var turnParams = new TurnParams("0 0 LEFT", null);

			Check.That(turnParams.IsLeftColision()).IsTrue();
		}

		[TestMethod]
		public void GivenTurnParams00RightWhenIsLeftCollisionThenFalse()
		{
			var turnParams = new TurnParams("0 0 RIGHT", null);

			Check.That(turnParams.IsLeftColision()).IsFalse();
		}

		[TestMethod]
		public void GivenTurnParams02RightAndDriveWidthOf3WhenIsLeftCollisionThenTrue()
		{
			var turnParams = new TurnParams("0 2 RIGHT", null);

			Check.That(turnParams.IsRightColision(3)).IsTrue();
		}

		[TestMethod]
		public void GivenTurnParams01RightAndDriveWidthOf3WhenIsLeftCollisionThenFalse()
		{
			var turnParams = new TurnParams("0 1 RIGHT", null);

			Check.That(turnParams.IsRightColision(3)).IsFalse();
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
	}
}