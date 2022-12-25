using System;
using Game.Enemy;

namespace Game.Services.CleanUp.Impl
{
	public interface IEnemyCleanUp
	{
		event Action<EnemyContext> OnCleanUp;
		void ObserveEntityDeath(EnemyContext enemyContext);
	}
}