using Enemy;
using Model;
using UnityEngine;

namespace Factories.EnemyFactory
{
	public interface IEnemyFactory
	{
		EnemyContext Create(EnemyModel model, Vector3 position, Quaternion rotation);
	}
}