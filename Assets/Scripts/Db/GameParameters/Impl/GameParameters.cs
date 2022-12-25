using UnityEngine;

namespace Db.GameParameters.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(GameParameters), fileName = nameof(GameParameters))]
	public class GameParameters : ScriptableObject, IGameParameters
	{
		[SerializeField] private PlayerData.Impl.PlayerData _playerData;
		[SerializeField] private EnemyData.Impl.EnemyData _enemyData;
		[SerializeField] private float _spawnDelay;
		
		
		public float SpawnDelay { get => _spawnDelay; set => _spawnDelay = value; }
		public EnemyData.Impl.EnemyData EnemyData => _enemyData;
		public PlayerData.Impl.PlayerData PlayerData => _playerData;
	}
}