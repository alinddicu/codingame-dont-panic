namespace codingame.dont.panic.test
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public class ConsoleSimulator
	{
		private readonly string[] _linesToRead;
		private readonly List<string> _writtenLines = new List<string>();
		private int _readLinesCount;

		public static ConsoleSimulator Create()
		{
			return new ConsoleSimulator("8 7 6 5 4 3 2 0");
		}

		public ConsoleSimulator(
			int floorCount,
			int driveWidth,
			int exitFloor,
			int exitPosition,
			int elevatorsCount,
			params Elevator[] elevators)
			: this(ToLinesToRead(
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
			var generalParams = string.Format("{0} {1} {2} {3} {4} {5} {6} {7}",
				floorCount,
				driveWidth,
				6,
				exitFloor,
				exitPosition,
				3,
				2,
				elevatorsCount);
			var linesToRead = new List<string> { generalParams };
			linesToRead.AddRange(elevators != null ? elevators.Select(e => e.ToString()) : Enumerable.Empty<string>());
			return linesToRead;
		}

		public ConsoleSimulator(params string[] linesToRead)
		{
			_linesToRead = linesToRead;
		}

		public IEnumerable<string> WrittenLines => _writtenLines;

		public string ReadLine()
		{
			if (_readLinesCount >= _linesToRead.Length)
			{
				throw new ArgumentException("No more lines to read");
			}

			return _linesToRead[_readLinesCount++];
		}

		public void WriteLine(object obj)
		{
			_writtenLines.Add(obj.ToString());
		}
	}
}