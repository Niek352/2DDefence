using System.Collections.Generic;
using Db.PlayerData;
using Game.Health.Impl;
using Game.Player;
using UnityEngine;

namespace Game.Factories.PlayerFactory.Impl
{
	public class PlayerFactory : IPlayerFactory
	{
		private readonly IPlayerData _playerData;
		private readonly Camera _camera;

		public PlayerFactory(IPlayerData playerData, Camera camera)
		{
			_playerData = playerData;
			_camera = camera;
		}
		
		public PlayerContext Create()
		{
			var player = Object.Instantiate(_playerData.PlayerPrefab);
			player.transform.position = _playerData.PlayerSpawnPoint;

			var health = new BaseHealth(_playerData.MaxHealth);
			var playerController = new PlayerController(CreatePlayerServices(player));
			
			player.Init(health, playerController);
			
			return player;
		}

		private List<IPlayerService> CreatePlayerServices(PlayerContext playerContext) => new List<IPlayerService>
		{
			new PlayerRotator(playerContext, _camera)
		};
	}
}