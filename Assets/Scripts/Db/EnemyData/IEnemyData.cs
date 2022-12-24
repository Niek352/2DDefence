using System.Collections.Generic;
using Enemy;
using Model;

namespace Db.EnemyData
{
	public interface IEnemyData
	{
		List<EnemyModel> EnemyModels { get; }
		EnemyContext EnemyPrefab { get; }
	}
}