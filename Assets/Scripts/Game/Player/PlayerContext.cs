using Db.PlayerData;
using Game.Health;
using Game.Health.Impl;
using UnityEngine;

namespace Game.Player
{
	public class PlayerContext : MonoBehaviour, IPlayerContext
	{
		private BaseHealth _health;
		private PlayerController _playerController;
		private bool _isInited;
		
		public bool IsAlive => _isInited && !_health.IsDead;
		public IHealth Health => _health;
		public Transform Transform => transform;
		public IPlayerData PlayerData { get; private set; }
		public IPlayerController PlayerController => _playerController;

		public void Init(BaseHealth baseHealth, PlayerController playerController, IPlayerData playerData)
		{
			_health = baseHealth;
			_playerController = playerController;
			_isInited = true;
			PlayerData = playerData;
		}
	}

}