namespace codingame.dont.panic.test
{
	using System;
	using System.Collections.Generic;

	public class ConsoleSimulator
	{
		private readonly string[] _linesToRead;
		private readonly List<string> _writtenLines = new List<string>();
		private int _readLinesCount;

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