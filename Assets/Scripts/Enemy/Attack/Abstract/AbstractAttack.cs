using Db.EnemyData;

namespace Enemy.Attack.Abstract
{
	public abstract class AbstractAttack
	{
		public abstract EnemyAttackType EnemyAttackType { get; }
	}
}