namespace codingame.dont.panic.test
{
	using System.Collections.Generic;
	using System.Linq;
	using common;

	public class DontPanicConsoleSimulator : ConsoleSimulator
	{
		public DontPanicConsoleSimulator(
			int floorCount,
			int driveWidth,
			int exitFloor,
			int exitPosition,
			int elevatorsCount,
			params Elevator[] elevators)
			: base(ToLinesToRead(
				floorCount,
				driveWidth,
				exitFloor,
				exitPosition,
				elevatorsCount,
				elevators).ToArray())
		{
		}

		private static IEnumerable<string> ToLinesToRead(
			int floorCount,
			int driveWidth,
			int exitFloor,
			int exitPosition,
			int elevatorsCount,
			params Elevator[] elevators)
		{
			var generalParams = $"{floorCount} {driveWidth} {6} {exitFloor} {exitPosition} {3} {2} {elevatorsCount}";
			var linesToRead = new List<string> { generalParams };
			linesToRead.AddRange(elevators?.Select(e => e.ToString()) ?? Enumerable.Empty<string>());
			return linesToRead;
		}
	}
}
