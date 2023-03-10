using System;
using System.Collections.Generic;
using Game.Enemy;
using Game.Services.CleanUp.Impl;

namespace Game.Services.EnemyStorage.Impl
{
	public class EnemyStorage : IEnemyStorage
	{
		private readonly IEnemyCleanUp _storageCleanUp;
		private readonly HashSet<IEnemyContext> _enemies = new HashSet<IEnemyContext>();
		public ICollection<IEnemyContext> Enemies => _enemies;
		public event Action<IEnemyContext> OnDead;
		public event Action<IEnemyContext> OnCreate;

		public EnemyStorage(IEnemyCleanUp storageCleanUp)
		{
			_storageCleanUp = storageCleanUp;
			_storageCleanUp.OnCleanUp += OnCleanUp;
		}
		
		private void OnCleanUp(EnemyContext enemyContext)
		{
			OnDead?.Invoke(enemyContext);
			_enemies.Remove(enemyContext);
		}

		public void AddToStorage(EnemyContext enemyContext)
		{
			_enemies.Add(enemyContext);
			_storageCleanUp.ObserveEntityDeath(enemyContext);
			OnCreate?.Invoke(enemyContext);
		}
	}
}