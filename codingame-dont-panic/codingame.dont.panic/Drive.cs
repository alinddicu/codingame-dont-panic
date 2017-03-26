namespace codingame.dont.panic
{
	using System;
	using codingame_common;
	using TurnDecision;

	public class Drive
	{
		private readonly Func<string> _readLine;
		private readonly Action<object> _writeLine;

		public Drive(Func<string> readLine, Action<object> writeLine)
		{
			_readLine = readLine;
			_writeLine = writeLine;
		}

		public void Run()
		{
			var driveParams = new DriveParams(_readLine);
			var drive = new CloneMaster(driveParams, new TurnDecisionsFactory());

			// game loop
			while (true)
			{
				try
				{
					var turnParams = new TurnParams(_readLine(), driveParams);
					var decision = drive.Run(turnParams);
					_writeLine(decision); // action: WAIT or BLOCK
				}
				catch (NoMoreLinesToReadException)
				{
					break;
				}
			}
		}
	}
}