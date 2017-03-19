namespace codingame.dont.panic.test
{
	using System.Collections.Generic;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

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
		// CloneFloor = inputs[0] = floor of the leading clone
		// ClonePosition = inputs[1] = position of the leading clone on its floor
		// CloneDirection = inputs[2] = direction of the leading clone: LEFT or RIGHT

		[TestMethod]
		public void Given2ElevatorsPerFloorWhenRunThenBlockToPickTheClosestOne()
		{
			// 22222222E
			// e1111e111
			// 0000e0000<-
			var consoleSimulator = new ConsoleSimulator(
				"2 9 99 2 8 3 0 3",
				"0 4",
				"1 0",
				"1 5",
				"0 8 LEFT", "0 7 LEFT", "0 6 LEFT", "0 5 LEFT", "0 4 LEFT",
				"1 4 LEFT", "1 3 LEFT",
				"1 0 EXIT");

			var driveOuput = RunDrive(consoleSimulator);

			Check.That(driveOuput).ContainsExactly(
				"WAIT", "WAIT", "WAIT", "WAIT", "WAIT",
				"WAIT", "BLOCK");
		}

		[TestMethod]
		public void Given2By4DriveWith1ElevatorWithRightUTurnWhenRunThenBlock1StCloneImmediately()
		{
			// 111E
			// 00e0<-
			var consoleSimulator = new ConsoleSimulator(
				"2 4 99 1 3 2 0 1",
				"0 2",
				"0 3 LEFT", "0 2 LEFT", "1 2 LEFT", "1 1 LEFT",
				"1 0 EXIT");

			var driveOuput = RunDrive(consoleSimulator);

			Check.That(driveOuput).ContainsExactly(
				"WAIT", "WAIT", "WAIT", "BLOCK");
		}

		[TestMethod]
		public void Given2By4DriveWith1ElevatorWithLeftUTurnWhenRunThenBlock1StCloneImmediately()
		{
			//   E111
			// ->0e00
			var consoleSimulator = new ConsoleSimulator(
				"2 4 99 1 0 2 0 1",
				"0 1",
				"0 0 RIGHT", "0 1 RIGHT", "1 1 RIGHT", "1 2 RIGHT",
				"1 2 EXIT");

			var driveOuput = RunDrive(consoleSimulator);

			Check.That(driveOuput).ContainsExactly(
				"WAIT", "WAIT", "WAIT", "BLOCK");
		}

		[TestMethod]
		public void Given2FloorDriveWith1ElevatorEnteredFromRightWhenRunThenDecisionsAreCorrect()
		{
			// 11eE
			// 0e00<-
			var consoleSimulator = new ConsoleSimulator(
				"2 4 99 1 3 2 0 1",
				"0 1",
				"0 3 LEFT", "0 2 LEFT", "0 1 LEFT", "1 1 LEFT", "1 0 LEFT",
				"0 3 LEFT", "0 2 LEFT", "0 1 LEFT", "1 1 LEFT", "1 2 RIGHT", "1 3 RIGHT",
				"1 3 EXIT");

			var driveOuput = RunDrive(consoleSimulator);

			Check.That(driveOuput).ContainsExactly(
				"WAIT", "WAIT", "WAIT", "WAIT", "BLOCK",
				"WAIT", "WAIT", "WAIT", "WAIT", "WAIT",
				"BLOCK");
		}

		[TestMethod]
		public void Given2FloorDriveWith1ElevatorAndUTurnWhenRunThenDecisionsAreCorrect()
		{
			//   E11
			// ->0e0
			var consoleSimulator = new ConsoleSimulator(
				"2 3 10 1 0 2 0 1",
				"0 1",
				"0 0 RIGHT", "0 1 RIGHT", "1 1 RIGHT", "1 2 RIGHT",
				"0 0 RIGHT", "0 1 RIGHT", "1 1 LEFT",
				"1 0 EXIT");

			var driveOuput = RunDrive(consoleSimulator);

			Check.That(driveOuput).ContainsExactly(
				"WAIT", "WAIT", "WAIT", "BLOCK",
				"WAIT", "WAIT", "WAIT");
		}

		[TestMethod]
		public void Given1FloorDriveWithoutElevatorWhenRunThenDecisionsAreCorrect()
		{
			// ->0000E
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
