namespace codingame.dont.panic.test
{
	using System;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class ConsoleSimulatorTest
	{
		[TestMethod]
		public void GivenLinesToReadWhenReadLineThenLinesAreReadInTheCorrectOrder()
		{
			var simulator = new ConsoleSimulator("123", "456");

			Check.That(simulator.ReadLine()).IsEqualTo("123");
			Check.That(simulator.ReadLine()).IsEqualTo("456");
		}

		[TestMethod]
		public void GivenExcessReadLineWhenReadLineThenThrowArgumentException()
		{
			var simulator = new ConsoleSimulator();

			Check.ThatCode(() => simulator.ReadLine()).Throws<ArgumentException>().WithMessage("No more lines to read");
		}

		[TestMethod]
		public void GivenWrittenLinesWhenGetWrittenLinesThenWrittenLinesAreInTheCorrectOrder()
		{
			var simulator = new ConsoleSimulator();

			simulator.WriteLine("123");
			simulator.WriteLine("456");

			Check.That(simulator.WrittenLines).ContainsExactly("123", "456");
		}

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
