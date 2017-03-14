namespace codingame.dont.panic.test.TurnDecision
{
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;
	using panic.TurnDecision;

	[TestClass]
	public class TurnDecisionsFactoryTest
	{
		[TestMethod]
		public void WhenCreateThenTurnDecisionsAreGeneratedInTheCorrectOrder()
		{
			var factory = new TurnDecisionsFactory(new DriveParams(ConsoleSimulator.Create().ReadLine));

			var turnDecisionTypes = factory.Create().Select(td => td.GetType()).ToArray();

			Check.That(turnDecisionTypes).HasSize(6);
			Check.That(turnDecisionTypes.Last()).IsEqualTo(typeof(Wait));
		}
	}
}
