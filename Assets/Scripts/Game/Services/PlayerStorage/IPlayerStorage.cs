using Game.Player;

namespace Game.Services.PlayerStorage
{
	public interface IPlayerStorage
	{
		PlayerContext Player { get; }
		void SetPlayer(PlayerContext player);
	}
}