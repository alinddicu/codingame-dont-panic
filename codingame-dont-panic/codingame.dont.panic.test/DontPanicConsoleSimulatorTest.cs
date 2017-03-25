namespace codingame.dont.panic.test
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class DontPanicConsoleSimulatorTest
	{

		[TestMethod]
		public void GivenConsoleSimulatorWithParametersWhenCreateThenValuesOfDriveParamsAreCorrect()
		{
			var simulator = new DontPanicConsoleSimulator(
				8,
				7,
				5,
				4,
				2,
				new Elevator("2 1"),
				new Elevator("1 3")
			);

			var driveParams = new DriveParams(simulator.ReadLine);

			DriveParamsTest.TestDriveParams(driveParams);
		}
	}
}
