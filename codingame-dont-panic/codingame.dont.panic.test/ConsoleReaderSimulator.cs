namespace codingame.dont.panic.test
{
	public class ConsoleReaderSimulator
	{
		private readonly string[] _lines;
		private int _currentLineCount;

		public ConsoleReaderSimulator(params string[] lines)
		{
			_lines = lines;
		}

		public string ReadLine()
		{
			return _lines[_currentLineCount++];
		}
	}

}