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
	}
}
