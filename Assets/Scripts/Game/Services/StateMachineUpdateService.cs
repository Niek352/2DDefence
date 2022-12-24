using Game.Services.EnemyStorage;
using UnityEngine;
using VContainer.Unity;

namespace Game.Services
{
	public class StateMachineUpdateService : ITickable
	{
		private readonly IEnemyStorage _enemyStorage;
		
		public StateMachineUpdateService(IEnemyStorage enemyStorage)
		{
			_enemyStorage = enemyStorage;
		}
		
		public void Tick()
		{
			var deltaTime = Time.deltaTime;
			foreach (var enemy in _enemyStorage.Enemies)
			{
				enemy.StateMachine.Update(deltaTime);	
			}			
		}
	}
}