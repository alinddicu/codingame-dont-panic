namespace codingame.dont.panic.TurnDecision
{
	using System.Collections.Generic;

	public class TurnDecisionsFactory
	{
		public IEnumerable<ITurnDecision> Create()
		{
			yield return new BlockCloneBeforeColision();
			yield return new BlockCloneIfGoingOppositeOfObjective(Direction.LEFT);
			yield return new BlockCloneIfGoingOppositeOfObjective(Direction.RIGHT);
			yield return new Wait();
		}
	}
}