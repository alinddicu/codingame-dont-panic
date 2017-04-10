namespace codingame.dont.panic.TurnDecision
{
	public interface ITurnDecision
	{
		bool CanDecide(TurnParams turnParams);

		TurnDecision Decide(TurnParams turnParams);
	}
}