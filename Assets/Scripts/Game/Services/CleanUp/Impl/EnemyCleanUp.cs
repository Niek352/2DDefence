using Game.Enemy;
using UnityEngine;

namespace Game.Services.CleanUp.Impl
{
	public class EnemyCleanUp : StorageCleanUp<EnemyContext>, IEnemyCleanUp
	{
		public override void Cleanup(EnemyContext context)
		{
			Object.Destroy(context.gameObject);
		}
	}
}