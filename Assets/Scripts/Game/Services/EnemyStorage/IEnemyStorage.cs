using System.Collections.Generic;
using Game.Enemy;

namespace Game.Services.EnemyStorage
{
	public interface IEnemyStorage
	{
		ICollection<IEnemyContext> Enemies { get; }

		void AddToStorage(EnemyContext enemyContext);
	}
}