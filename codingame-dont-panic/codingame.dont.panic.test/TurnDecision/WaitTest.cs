namespace codingame.dont.panic.test.TurnDecision
{
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;
	using panic.TurnDecision;

	[TestClass]
	public class WaitTest
	{
		[TestMethod]
		public void GivenWaitTurnDecisionBaseWhenCanDecideThenTrue()
		{
			var waitTurnDecisionBase = new Wait();
			var turnParams = new TurnParams("0 1 RIGHT", DriveParamsTest.Create());

			Check.That(waitTurnDecisionBase.CanDecide(turnParams)).IsTrue();
			Check.That(waitTurnDecisionBase.Decide(turnParams)).IsEqualTo(TurnDecision.WAIT);
		}
	}
}
