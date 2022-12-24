using Game.Enemy;
using Game.Model;
using UnityEngine;

namespace Game.Factories.EnemyFactory
{
	public interface IEnemyFactory
	{
		EnemyContext Create(EnemyModel model, Vector3 position, Quaternion rotation);
	}
}