using Db.EnemyData;
using Game.Factories.EnemyFactory;
using Game.Model;
using Game.Services.EnemySpawnPointCalculator;
using Game.Services.EnemyStorage;
using UnityEngine;
using VContainer.Unity;

namespace Game.Services.Spawner
{
	public class EnemySpawner : IFixedTickable
	{
		private readonly IEnemyData _enemyData;
		private readonly IEnemyFactory _enemyFactory;
		private readonly IEnemyStorage _enemyStorage;
		private readonly IEnemySpawnPointCalculateService _calculateService;

		private float _tick;
		private const float DELAY = 2f;
		
		public EnemySpawner(
			IEnemyData enemyData,
			IEnemyFactory enemyFactory,
			IEnemyStorage enemyStorage, 
			IEnemySpawnPointCalculateService calculateService)
		{
			_enemyData = enemyData;
			_enemyFactory = enemyFactory;
			_enemyStorage = enemyStorage;
			_calculateService = calculateService;
		}
		
		public void FixedTick()
		{
			UpdateTimer(Time.fixedDeltaTime);
		}
		
		private void UpdateTimer(float deltaTime)
		{
			_tick += deltaTime;
			if (_tick >= DELAY)
			{
				_tick = 0;
				SpawnEnemy();
			}
		}

		private void SpawnEnemy()
		{
			var enemy = _enemyFactory.Create(GetRandomModel(), _calculateService.GetEnemySpawnPoint(), Quaternion.identity);
			_enemyStorage.AddToStorage(enemy);
		}

		private EnemyModel GetRandomModel() 
			=> _enemyData.EnemyModels[Random.Range(0, _enemyData.EnemyModels.Count)];
		
	}
}