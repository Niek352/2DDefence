using System.Collections.Generic;
using Game.Enemy;

namespace Game.Services.EnemyStorage.Impl
{
	public class EnemyStorage : IEnemyStorage
	{
		private readonly HashSet<IEnemyContext> _enemies = new HashSet<IEnemyContext>();
		public ICollection<IEnemyContext> Enemies => _enemies;

		public void AddToStorage(EnemyContext enemyContext)
			=> _enemies.Add(enemyContext);
	}
}