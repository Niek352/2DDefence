using Db.EnemyData;
using Enemy.Movement.Abstract;

namespace Enemy.Movement.Impl
{
	public class SimpleMovement : AbstractMovement
	{
		public override EnemyMovementType EnemyMovementType => EnemyMovementType.SimpleMovement;
	}
}