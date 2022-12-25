using Game.Player;
using UnityEngine;

namespace Db.PlayerData.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(PlayerData), fileName = nameof(PlayerData))]
	public class PlayerData : ScriptableObject, IPlayerData
	{
		[SerializeField] private Vector3 _playerSpawnPoint;
		[SerializeField] private PlayerContext _playerPrefab;
		[SerializeField] private float _maxHealth;
		[SerializeField] private float _rotationSpeed = 1;
		[SerializeField] private string _bulletId;

		public Vector3 PlayerSpawnPoint => _playerSpawnPoint;
		public PlayerContext PlayerPrefab => _playerPrefab;
		public float MaxHealth => _maxHealth;
		public float RotationSpeed => _rotationSpeed;
		public string BulletId => _bulletId;
	}
}