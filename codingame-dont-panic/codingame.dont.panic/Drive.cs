namespace codingame.dont.panic
{
	using System;
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
			var drive = new CloneMaster(driveParams, new TurnDecisionsFactory(driveParams));

			// game loop
			while (true)
			{
				var turnParams = new TurnParams(_readLine(), driveParams);
				if (turnParams.Direction == Direction.EXIT)
				{
					break;
				}

				var decision = drive.Decide(turnParams);
				_writeLine(decision); // action: WAIT or BLOCK
			}
		}
	}
}