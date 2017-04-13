﻿namespace codingame.dont.panic.TurnDecision
{
	public class Wait : ITurnDecision
	{
		public bool CanDecide(TurnParams turnParams)
		{
			return true;
		}

		public TurnDecision Decide()
		{
			return TurnDecision.WAIT;
		}
	}
}