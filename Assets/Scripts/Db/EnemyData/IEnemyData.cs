using System.Collections.Generic;
using Game.Enemy;
using Game.Model;

namespace Db.EnemyData
{
	public interface IEnemyData
	{
		List<EnemyModel> EnemyModels { get; }
		EnemyContext EnemyPrefab { get; }
	}
}