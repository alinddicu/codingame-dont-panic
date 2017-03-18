﻿namespace codingame.dont.panic.test
{
	using System.Linq;
	using NFluent;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using panic;

	[TestClass]
	public class DriveParamsTest
	{
		[TestMethod]
		public void GivenDriveParamsFromStandardInputWhenCreateThenValuesOfDriveParamsAreCorrect()
		{
			var driveParams = Create();

			TestDriveParams(driveParams);
		}

		public static DriveParams Create(
			int floorCount,
			int driveWidth,
			int exitFloor,
			int exitPosition,
			int elevatorsCount,
			params Elevator[] elevators)
		{
			var simulator = new ConsoleSimulator(
				floorCount,
				driveWidth,
				exitFloor,
				exitPosition,
				elevatorsCount,
				elevators);

			var driveParams = new DriveParams(simulator.ReadLine);
			return driveParams;
		}

		public static DriveParams Create()
		{
			var simulator = new ConsoleSimulator(
				"8 7 6 5 4 3 2 2",
				"2 1",
				"1 3"
			);

			var driveParams = new DriveParams(simulator.ReadLine);
			return driveParams;
		}

		public static void TestDriveParams(DriveParams driveParams)
		{
			Check.That(driveParams.FloorCount).IsEqualTo(8);
			Check.That(driveParams.DriveWidth).IsEqualTo(7);
			Check.That(driveParams.MaximumRoundCount).IsEqualTo(6);
			Check.That(driveParams.ExitFloor).IsEqualTo(5);
			Check.That(driveParams.ExitPosition).IsEqualTo(4);
			Check.That(driveParams.TotalClonesCount).IsEqualTo(3);
			Check.That(driveParams.AdditionalElevatorsCount).IsEqualTo(2);

			Check.That(driveParams.Elevators).HasSize(2);
			Check.That(driveParams.Elevators.First().Floor).Equals(2);
			Check.That(driveParams.Elevators.First().Position).Equals(1);
			Check.That(driveParams.Elevators.Last().Floor).Equals(1);
			Check.That(driveParams.Elevators.Last().Position).Equals(3);
		}
	}
}
