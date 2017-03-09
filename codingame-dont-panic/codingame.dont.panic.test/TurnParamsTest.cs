using NFluent;

namespace codingame.dont.panic.test
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class TurnParamsTest
	{
		[TestMethod]
		public void GivenTurnParamsFromStandardInputWhenCreateThenValuesOfTurnParamsAreCorrect()
		{
			var simulator = new ConsoleSimulator("8 7 RIGHT");

			var turnParams = new TurnParams(simulator.ReadLine);

			Check.That(turnParams.CloneFloor).IsEqualTo(8);
			Check.That(turnParams.ClonePosition).IsEqualTo(7);
			Check.That(turnParams.Direction).IsEqualTo(Direction.RIGHT);
		}
	}
}