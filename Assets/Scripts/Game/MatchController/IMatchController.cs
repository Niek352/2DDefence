using System;

namespace Game.MatchController
{
	public interface IMatchController
	{
		event Action<int> OnScoreChanged;
	}
}