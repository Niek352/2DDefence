using Db.PlayerData;
using Game.Health.Impl;
using Game.Player;
using UnityEngine;

namespace Game.Factories.PlayerFactory.Impl
{
	public class PlayerFactory : IPlayerFactory
	{
		private readonly IPlayerData _playerData;
		
		public PlayerFactory(IPlayerData playerData)
		{
			_playerData = playerData;
		}
		
		public PlayerContext Create()
		{
			var player = Object.Instantiate(_playerData.PlayerPrefab);
			player.transform.position = _playerData.PlayerSpawnPoint;
			
			var health = new BaseHealth(_playerData.MaxHealth);
			player.Init(health);
			
			return player;
		}
	}
}