using System;
using System.Collections.Generic;
using Game.Enemy;

namespace Game.Services.EnemyStorage
{
	public interface IEnemyStorage
	{
		ICollection<IEnemyContext> Enemies { get; }

		event Action<IEnemyContext> OnCreate; 
		void AddToStorage(EnemyContext enemyContext);
	}
}