using Db.EnemyData;
using Factories.EnemyFactory;
using Model;
using Unity.Mathematics;
using UnityEngine;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace Services.Spawner
{
	public class EnemySpawner : IFixedTickable, IStartable
	{
		private readonly IEnemyData _enemyData;
		private readonly IEnemyFactory _enemyFactory;
		private float _tick;
		private const float DELAY = 2f;
		
		public EnemySpawner(IEnemyData enemyData, IEnemyFactory enemyFactory)
		{
			_enemyData = enemyData;
			_enemyFactory = enemyFactory;
		}
		
		public void Start()
		{
			SpawnEnemy();
		}
		
		public void FixedTick()
		{
			//UpdateTimer(Time.fixedDeltaTime);
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
			_enemyFactory.Create(GetRandomModel(), new Vector3(0, 10, 0), quaternion.identity);
		}

		private EnemyModel GetRandomModel() 
			=> _enemyData.EnemyModels[Random.Range(0, _enemyData.EnemyModels.Count)];
		
	}
}