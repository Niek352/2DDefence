using Game.Player;

namespace Game.Factories.PlayerFactory
{
	public interface IPlayerFactory
	{
		PlayerContext Create();
	}
}