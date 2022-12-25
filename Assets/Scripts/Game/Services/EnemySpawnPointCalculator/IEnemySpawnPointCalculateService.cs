using UnityEngine;

namespace Game.Services.EnemySpawnPointCalculator
{
	public interface IEnemySpawnPointCalculateService
	{
		Vector3 GetEnemySpawnPoint();
	}
}