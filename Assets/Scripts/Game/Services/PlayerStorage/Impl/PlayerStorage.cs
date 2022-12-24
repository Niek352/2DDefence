using System;
using Game.Player;

namespace Game.Services.PlayerStorage.Impl
{
	public class PlayerStorage : IPlayerStorage
	{
		private PlayerContext _player;
		public PlayerContext Player => _player ? _player : throw new NullReferenceException("Player doesnt Initialized");

		public void SetPlayer(PlayerContext player)
			=> _player = player;
	}
}