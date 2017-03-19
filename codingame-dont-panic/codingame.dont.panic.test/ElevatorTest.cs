namespace codingame.dont.panic.test
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class ElevatorTest
	{
		[TestMethod]
		public void GivenReadlineWhenNewElevatorThenFloorAndPositionAreCorrect()
		{
			var elevator = new Elevator("0 3");

			Check.That(elevator.Floor).IsEqualTo(0);
			Check.That(elevator.Position).IsEqualTo(3);
		}

		[TestMethod]
		public void GivenElevatorWhenToStringThenToStringIsCorrect()
		{
			var elevator = new Elevator("0 3");

			Check.That(elevator.ToString()).IsEqualTo("0 3");
		}

		[TestMethod]
		public void GivenPositiveDistanceWhenGetDistanceThenReturnPositiveValue()
		{
			var elevator = new Elevator("0 3");

			Check.That(elevator.GetDistance(4)).IsEqualTo(1);
		}

		[TestMethod]
		public void GivenNegativeDistanceWhenGetDistanceThenReturnPositiveValue()
		{
			var elevator = new Elevator("0 3");

			Check.That(elevator.GetDistance(1)).IsEqualTo(2);
		}
	}
}
