using Db.EnemyData;

namespace Enemy.Movement.Abstract
{
	public abstract class AbstractMovement
	{
		public abstract EnemyMovementType EnemyMovementType { get; }
	}
}