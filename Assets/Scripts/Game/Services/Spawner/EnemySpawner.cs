using Db.EnemyData;
using Db.GameParameters;
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
		private readonly IGameParameters _gameParameters;

		private float _tick;
		
		public EnemySpawner(
			IEnemyData enemyData,
			IEnemyFactory enemyFactory,
			IEnemyStorage enemyStorage, 
			IEnemySpawnPointCalculateService calculateService,
			IGameParameters gameParameters)
		{
			_enemyData = enemyData;
			_enemyFactory = enemyFactory;
			_enemyStorage = enemyStorage;
			_calculateService = calculateService;
			_gameParameters = gameParameters;
		}
		
		public void FixedTick()
		{
			UpdateTimer(Time.fixedDeltaTime);
		}
		
		private void UpdateTimer(float deltaTime)
		{
			_tick += deltaTime;
			if (_tick >= _gameParameters.SpawnDelay)
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