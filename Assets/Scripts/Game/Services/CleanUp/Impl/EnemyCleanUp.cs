using System;
using Game.Enemy;
using Object = UnityEngine.Object;

namespace Game.Services.CleanUp.Impl
{
	public class EnemyCleanUp : StorageCleanUp<EnemyContext>, IEnemyCleanUp
	{
		public override void Cleanup(EnemyContext context)
		{
			Object.Destroy(context.gameObject);
		}
	}

	public interface IEnemyCleanUp
	{
		event Action<EnemyContext> OnCleanUp;
		void ObserveEntityDeath(EnemyContext enemyContext);
	}
}