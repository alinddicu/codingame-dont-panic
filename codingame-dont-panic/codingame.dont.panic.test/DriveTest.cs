﻿using NFluent;

namespace codingame.dont.panic.test
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class DriveTest
	{
		// DriveParams
		// inputs[0] = number of floors
		// inputs[1] = width of the area
		// inputs[2] = maximum number of rounds
		// inputs[3] = floor on which the exit is found
		// inputs[4] = position of the exit on its floor
		// inputs[5] = number of generated clones
		// inputs[6] = number of additional elevators ignore (always zero)
		// inputs[7] = number of elevators

		// Elevator
		// Floor = elevatorInputs[0];
		// Position = elevatorInputs[1];

		// TurnParams
		// CloneFloor = int.Parse(inputs[0]) = floor of the leading clone
		// ClonePosition = int.Parse(inputs[1]) = position of the leading clone on its floor
		// Direction = inputs[2] = direction of the leading clone: LEFT or RIGHT

		[TestMethod]
		public void Given1FloorDriveWithouElevatorWhenRunThenDecisionIsCorrect()
		{
			var consoleSimulator = new ConsoleSimulator(
				"1 5 10 0 4 1 0 0",
				"0 0 RIGHT",
				"0 1 RIGHT",
				"0 2 RIGHT",
				"0 3 RIGHT",
				"0 4 EXIT");

			var driveOuput = RunDrive(consoleSimulator);

			Check.That(driveOuput).ContainsExactly("WAIT", "WAIT", "WAIT", "WAIT");
		}

		private static IEnumerable<string> RunDrive(ConsoleSimulator consoleSimulator)
		{
			var drive = new Drive(consoleSimulator.ReadLine, consoleSimulator.WriteLine);
			drive.Run();

			return consoleSimulator.WrittenLines;
		}
	}
}
