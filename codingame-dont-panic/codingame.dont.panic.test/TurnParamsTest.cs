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
			var turnParams = new TurnParams(() => "8 7 RIGHT");

			Check.That(turnParams.CloneFloor).IsEqualTo(8);
			Check.That(turnParams.ClonePosition).IsEqualTo(7);
			Check.That(turnParams.Direction).IsEqualTo(Direction.RIGHT);
		}

		[TestMethod]
		public void GivenTurnParams00LeftWhenIsLeftCollisionThenTrue()
		{
			var turnParams = new TurnParams(() => "0 0 LEFT");

			Check.That(turnParams.IsLeftColision()).IsTrue();
		}

		[TestMethod]
		public void GivenTurnParams00RightWhenIsLeftCollisionThenFalse()
		{
			var turnParams = new TurnParams(() => "0 0 RIGHT");

			Check.That(turnParams.IsLeftColision()).IsFalse();
		}

		[TestMethod]
		public void GivenTurnParams02RightAndDriveWidthOf3WhenIsLeftCollisionThenTrue()
		{
			var turnParams = new TurnParams(() => "0 2 RIGHT");

			Check.That(turnParams.IsRightColision(3)).IsTrue();
		}

		[TestMethod]
		public void GivenTurnParams01RightAndDriveWidthOf3WhenIsLeftCollisionThenFalse()
		{
			var turnParams = new TurnParams(() => "0 1 RIGHT");

			Check.That(turnParams.IsRightColision(3)).IsFalse();
		}
	}
}