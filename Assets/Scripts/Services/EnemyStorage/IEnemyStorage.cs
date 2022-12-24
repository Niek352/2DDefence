using System.Collections.Generic;
using Enemy;

namespace Services.EnemyStorage
{
	public interface IEnemyStorage
	{
		ICollection<EnemyContext> Enemies { get; }

		void AddToStorage(EnemyContext enemyContext);
	}
}