using Db.EnemyData;
using UnityEngine;

namespace Game.Enemy.Movement.Abstract
{
	public abstract class AbstractMovement
	{
		public abstract EnemyMovementType EnemyMovementType { get; }
		public abstract Vector3 TargetPosition { get; }
		public abstract bool ReachedTarget { get; }
		public abstract void Move(float deltaTime);
	}
}