using System.Collections.Generic;
using Enemy;

namespace Services.EnemyStorage.Impl
{
	public class EnemyStorage : IEnemyStorage
	{
		private readonly HashSet<EnemyContext> _enemies = new HashSet<EnemyContext>();

		public ICollection<EnemyContext> Enemies => _enemies;
		
		public EnemyStorage()
		{
			
		}

		public void AddToStorage(EnemyContext enemyContext)
			=> _enemies.Add(enemyContext);
	}
}